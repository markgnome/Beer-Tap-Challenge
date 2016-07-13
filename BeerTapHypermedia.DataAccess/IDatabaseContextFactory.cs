namespace BeerTapHypermedia.DataAccess
{
    public interface IDatabaseContextFactory<out T> where T : BeerTapContext
    {
        T CreateContext();
    }
}
