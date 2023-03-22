using arfan.Data;
using arfan.Repository.IRepository;
using arfan.Models;

namespace arfan.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}