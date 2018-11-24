using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RegexManagerLib
{
    public class RegexManager
    {
        public Action NoMatchCallback
        {
            get;
        }
        public IEnumerable<IRegexExecute> RegexToExecute { get; protected set; }

        public RegexManager()
        {
            RegexToExecute = new List<IRegexExecute>();
        }
        public RegexManager(Action noMatchCallback)
        {
            RegexToExecute = new List<IRegexExecute>();
            NoMatchCallback = noMatchCallback;
        }

        public void Run(string test){

            var patterns = RegexToExecute.Select(r => r.Pattern);

            var index = -1;


            var success = false;
            Match match;
            IRegexExecute regexExecute;

            while (!success && index< RegexToExecute.Count())
            {
                index++;
                regexExecute = RegexToExecute.ElementAt(index);

                Regex rex = new Regex(regexExecute.Pattern);
                match = rex.Match(test);
                success = match.Success;

                if (success)
                    regexExecute.MatchCallback?.Invoke(match);

            }

            if (!success)
                NoMatchCallback?.Invoke();

        }

        public RegexManager JoinRegex(IRegexExecute regexExecute){
            var l = RegexToExecute.ToList();
            l.Add(regexExecute);
            RegexToExecute = l;
            return this;
        }
    }

    public interface IRegexExecute
    {
        string Pattern
        {
            get;
            set;
        }

        Action<Group> MatchCallback { get; set; }
    }

    public interface IRegexResult
    {
        Group match { get; }
    }
}
