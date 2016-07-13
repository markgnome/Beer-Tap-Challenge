namespace BeerTapHypermedia.DataAccess
{
    public class DatabaseContextFactory : IDatabaseContextFactory<BeerTapContext>
    {
        private const string connectionName = "BeerTapContext";
        public BeerTapContext CreateContext()
        {
            var context = new BeerTapContext(connectionName);
            return context;
        }
    }
}
