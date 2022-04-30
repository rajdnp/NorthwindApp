using NorthwindApp.Events;
using NorthwindApp.Interfaces;

namespace NorthwindApp.Implementation
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void OnEvent(object source, EventArgs args)
        {
            if (args is UserEvent)
            {
                var userEvent = (UserEvent)args;
                switch (userEvent.EventType)
                {
                    case Helpers.EventTypeEnum.ADD:
                        unitOfWork.NotificationRepository.Add(new Entities.Notification { Message = "User created successfully", UserId = userEvent.UserId });
                        unitOfWork.SaveChanges();
                    break;
                }
            }
        }
    }
}
