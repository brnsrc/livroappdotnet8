namespace Northwind.ViewModels;

public class Summary
{
    // These properties can be initialized once but hen never used changed.
    public string? FullName { get; init; }
    public decimal Total { get; init; }

    
    // This record class will have a default parameterless constructor.
    // The following commented statement is automatically generated:
    // public Summary() { }
}
