# ShinyErrors
Errors as values for .NET apps. Errors can be valuable. Errors can be shiny.

## Structure

A Result is composed of two things: an expected value of return and an error. If all is right, the error will be null. If something is off, the expected field will be in its default value and the error won't be null. Pretty simple.

```csharp
public class Result<TExpected>
{
    public TExpected? Expected { get; init; }
    public Error? Error { get; init; }

    public bool HasError() => Error is not null;

    public Result(TExpected? expected) => Expected = expected;

    public Result(Error? error) => Error = error;
}
```

## Examples

Let's suppose we have the following method:

```csharp
public int Division(int x, int y)
{
    return x / y;
}
```

It works, right? It will work for 10/2, 2/2, 69/420, any number, really.

But what if y == 0? Well, the program will crash. An exception will be thrown, an exception that is not explicit at all.

So, in order to fix this, we can use a try catch block together with our Result class:

```csharp
public Result<int> Division(int x, int y)
{
    try
    {
        result = (x / y);
        return result.AsSuccessfulResult();
    }
        catch (Exception e)
    {
        return e.Message.AsFaultyResult<int>();
    }
}
```

## Pros

It reminds me of go. I like go.

## Cons

Kinda bureaucratic not gonna lie
