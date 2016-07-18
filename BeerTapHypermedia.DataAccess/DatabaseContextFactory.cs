namespace BeerTapHypermedia.DataAccess
{
    public class DatabaseContextFactory : IDatabaseContextFactory<BeerTapDbContext>
    {
        public BeerTapDbContext CreateContext()
        {
            var context = new BeerTapDbContext();
            return context;
        }
    }
}
