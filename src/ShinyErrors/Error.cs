using ShinyErrors.Interfaces;

namespace ShinyErrors;

public class Error : IError
{
    public string Description { get; init; }
}
