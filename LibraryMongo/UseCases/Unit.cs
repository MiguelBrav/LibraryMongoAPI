namespace LibraryMongo.UseCases;

public sealed class Unit
{
    // sealed class for empty request using TRequest
    public static readonly Unit Value = new Unit();
    private Unit() { }
}
