using Microsoft.EntityFrameworkCore;

namespace FinTracker.Service
{
    public abstract class AbstractService
    {
        private DbContextOptionsBuilder<Dal.FinTrackerContext> _optionsBuilder;
        protected MapperService _mapperService;

        public AbstractService(string connectionString, MapperService mapperService)
        {
            _optionsBuilder = new DbContextOptionsBuilder<Dal.FinTrackerContext>();
            _optionsBuilder.UseSqlServer(connectionString);

            // dev environment
            _optionsBuilder.EnableDetailedErrors(true);
            _optionsBuilder.EnableSensitiveDataLogging(true);

            _mapperService = mapperService;
        }

        protected Dal.FinTrackerContext CreateDbContext()
        {
            return new Dal.FinTrackerContext(_optionsBuilder.Options);
        }
    }
}
