using System;
using System.Text.RegularExpressions;
using RegexManagerCore.Interfaces;

namespace RegexManagerCore
{
    public class RegexExecute<TResult> : IRegexExecute<Match, TResult>
    {
        public string Pattern { get; set; }
        public Func<Match, TResult> MatchCallback { get; set; }

        public RegexExecute(string pattern, Func<Match, TResult> matchCallback)
        {
            Pattern = pattern;
            MatchCallback = matchCallback;
        }
    }
}
