using NorthwindApp.Entities;

namespace NorthwindApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Notification> NotificationRepository { get; }
        public IUserRepository UserRepository { get; }
        Task<int> SaveChanges();
    }
}
