using System;
namespace RegexManagerCore.Interfaces
{
    public interface IRegexExecute<TInput, TResult>
    {
        string Pattern
        {
            get;
            set;
        }

        Func<TInput,TResult> MatchCallback { get; set; }
    }
}
