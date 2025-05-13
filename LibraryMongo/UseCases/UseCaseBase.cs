namespace LibraryMongo.UseCases;

public abstract class UseCaseBase<TRequest>
{
    public abstract Task<IResult> Execute(TRequest request);
}