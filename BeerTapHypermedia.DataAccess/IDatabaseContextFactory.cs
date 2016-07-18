namespace BeerTapHypermedia.DataAccess
{
    public interface IDatabaseContextFactory<out T>
    {
        T CreateContext();
    }
}
