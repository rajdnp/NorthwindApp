using Microsoft.EntityFrameworkCore;
using NorthwindApp.Data;
using NorthwindApp.Entities;
using NorthwindApp.Interfaces;

namespace NorthwindApp.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NorthwindContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<User>> GetAllUsers(bool includeNotifications)
        {
            if(includeNotifications)
            return await context.Users.Include("Notifications").ToListAsync();
            else
           return await context.Users.ToListAsync();
        }
    }
}
