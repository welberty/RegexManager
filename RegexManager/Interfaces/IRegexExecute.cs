using System;
namespace RegexManagerCore.Interfaces
{
    public interface IRegexExecute<T> where T : class
    {
        string Pattern
        {
            get;
            set;
        }

        Action<T> MatchCallback { get; set; }
    }
}
