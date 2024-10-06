namespace ShinyErrors;

public class Result<TExpected>
{
    public TExpected? Expected { get; init; }
    public Error? Error { get; init; }

    public bool HasError() => Error is not null;

    public Result(TExpected? expected) => Expected = expected;

    public Result(Error? error) => Error = error;
}
