﻿namespace BookStore.Domain.BaseTypes
{
    public sealed record ValidationError : Error
    {
        public Error[] Errors { get; }
        public ValidationError(Error[] errors)
            : base(
                "General.Validation",
                "One or more validation errors occurred",
                ErrorType.Validation)
        {
            Errors = errors;
        }
        public static ValidationError FromResults(IEnumerable<Result> results) =>
            new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
    }

}
