using System;
using System.Text.RegularExpressions;
using RegexManagerCore.Interfaces;

namespace RegexManagerCore
{
    public class RegexExecute : IRegexExecute<Match>
    {
        public string Pattern { get; set; }
        public Action<Match> MatchCallback { get; set; }

        public RegexExecute(string pattern, Action<Match> matchCallback)
        {
            Pattern = pattern;
            MatchCallback = matchCallback;
        }
    }
}
