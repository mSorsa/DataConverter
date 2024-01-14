namespace DataConversions;

public abstract class DataConverter<TInType, TOutType>
{
    public abstract Task<TOutType> Convert(TInType input, CancellationToken cancellationToken = new());
}