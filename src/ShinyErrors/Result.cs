using ShinyErrors.Interfaces;

namespace ShinyErrors;

public class Result<TExpected> : IResult<TExpected>
{
    public TExpected? Expected { get; init; }
    public IError? Error { get; init; }

    public Result(TExpected? expected, IError? error)
    {
        Expected = expected;
        Error = error;
    }
}
