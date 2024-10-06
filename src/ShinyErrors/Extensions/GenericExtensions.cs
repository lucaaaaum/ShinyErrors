namespace ShinyErrors.Extensions;

public static class GenericExtensions
{
    public static Result<TExpected> AsFaultyResult<TExpected>(this string description) => new Result<TExpected>(description.AsError());

    public static Error AsError(this string description) => new Error(description);

    public static Result<TExpected> AsSuccessfulResult<TExpected>(this TExpected expected) => new Result<TExpected>(expected);

    public static Result<TExpected> AsShiny<TExpected>(this string description) => description.AsFaultyResult<TExpected>();
    public static Result<TExpected> AsMatte<TExpected>(this TExpected expected) => expected.AsSuccessfulResult();
}
