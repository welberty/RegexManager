using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RegexManagerCore.Interfaces;

namespace RegexManagerCore
{
    public class RegexManager<TResult>
    {
        public Action NoMatchCallback
        {
            get;
        }

        public IList<IRegexExecute<Match, TResult>> RegexToExecute { get; protected set; }

        public RegexManager()
        {
            RegexToExecute = new List<IRegexExecute<Match, TResult>>();
        }

        public RegexManager(Action noMatchCallback)
        {
            RegexToExecute = new List<IRegexExecute<Match, TResult>>();
            NoMatchCallback = noMatchCallback;
        }

        public TResult Run(string test){
        
            var index = 0;

            var success = false;
            Match match = null;
            IRegexExecute<Match, TResult> regexExecute;

            while (!success && index< RegexToExecute.Count())
            {
                regexExecute = RegexToExecute.ElementAt(index);

                var rex = new Regex(regexExecute.Pattern);
                match = rex.Match(test);
                success = match.Success;

                if (success)
                {
                    if (regexExecute.MatchCallback != null)
                        return regexExecute.MatchCallback.Invoke(match);
                    else
                        return default(TResult);

                }

                index++;

            }

            NoMatchCallback?.Invoke();
            return default(TResult);

        }

        public RegexManager<TResult> AddRegex(IRegexExecute<Match, TResult> regexExecute){
            RegexToExecute.Add(regexExecute);
            return this;
        }
    }

}
