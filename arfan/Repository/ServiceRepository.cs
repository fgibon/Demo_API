using arfan.Data;
using arfan.Repository.IRepository;
using arfan.Models;

namespace arfan.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _db;

        public ServiceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}