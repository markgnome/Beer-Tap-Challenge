namespace BeerTapHypermedia.DataAccess
{
    public class DatabaseContextFactory : IDatabaseContextFactory<BeerTapContext>
    {
        private const string ConnectionName = "BeerTapContext";
        public BeerTapContext CreateContext()
        {
            var context = new BeerTapContext(ConnectionName);
            return context;
        }
    }
}
