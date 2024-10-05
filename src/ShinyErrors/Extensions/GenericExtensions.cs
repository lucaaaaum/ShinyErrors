using ShinyErrors.Interfaces;

namespace ShinyErrors.Extensions;

public static class GenericExtensions
{
    public static IResult<TExpected> AsResult<TExpected>(this TExpected obj) => new Result<TExpected>(obj, null);
}
