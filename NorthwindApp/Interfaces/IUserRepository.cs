using NorthwindApp.Entities;

namespace NorthwindApp.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers(bool includeNotifications);
    }
}
