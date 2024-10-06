namespace ShinyErrors;

public class Error
{
    public string Description { get; init; }

    public Error(string description) => Description = description;
}
