using Microsoft.EntityFrameworkCore;

namespace GMapsServices.Api.Components
{
    public class GMapsServicesContext : DbContext
    {
        public GMapsServicesContext(DbContextOptions<GMapsServicesContext> options) : base(options)
        {
            Database.AutoTransactionsEnabled = false;
        }
    }
}
