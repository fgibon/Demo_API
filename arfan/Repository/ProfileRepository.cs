using arfan.Data;
using arfan.Repository.IRepository;
using arfan.Models;

namespace arfan.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly ApplicationDbContext _db;

        public ProfileRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
