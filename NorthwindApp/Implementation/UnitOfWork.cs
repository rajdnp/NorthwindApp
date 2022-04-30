using NorthwindApp.Data;
using NorthwindApp.Entities;
using NorthwindApp.Interfaces;

namespace NorthwindApp.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext context;

        public IGenericRepository<Notification> NotificationRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(NorthwindContext context, IGenericRepository<Notification> notificationRepository, IUserRepository userRepository)
        {
            this.context = context;
            NotificationRepository = notificationRepository;
            UserRepository = userRepository;
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
    }
}
