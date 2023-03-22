using arfan.Data;
using arfan.Repository.IRepository;
using arfan.Models;

namespace arfan.Repository
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        private readonly ApplicationDbContext _db;

        public ReserveRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}

