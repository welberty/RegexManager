using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RegexManagerCore.Interfaces;

namespace RegexManagerCore
{
    public class RegexManager
    {
        public Action<Match> NoMatchCallback
        {
            get;
        }

        public IList<IRegexExecute<Match>> RegexToExecute { get; protected set; }

        public RegexManager()
        {
            RegexToExecute = new List<IRegexExecute<Match>>();
            NoMatchCallback = (m) => { throw new Exception("Not implemented."); };
        }

        public RegexManager(Action<Match> noMatchCallback)
        {
            RegexToExecute = new List<IRegexExecute<Match>>();
            NoMatchCallback = noMatchCallback;
        }

        public void Run(string test){
        
            var index = 0;

            var success = false;
            Match match = null;
            IRegexExecute<Match> regexExecute;

            while (!success && index< RegexToExecute.Count())
            {
                regexExecute = RegexToExecute.ElementAt(index);

                var rex = new Regex(regexExecute.Pattern);
                match = rex.Match(test);
                success = match.Success;

                if (success)
                    regexExecute.MatchCallback?.Invoke(match);
                index++;

            }

            if (!success)
                NoMatchCallback?.Invoke(match);

        }

        public RegexManager AddRegex(IRegexExecute<Match> regexExecute){
            RegexToExecute.Add(regexExecute);
            return this;
        }
    }

}
