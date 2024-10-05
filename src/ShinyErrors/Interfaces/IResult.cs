namespace ShinyErrors.Interfaces;

public interface IResult<TExpected>
{
    public TExpected? Expected { get; }
    public IError? Error { get; }

    public bool HasError() => Error is null; 
}
