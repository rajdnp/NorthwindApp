using NorthwindApp.Helpers;

namespace NorthwindApp.Events
{
    public class UserEvent : EventArgs
    {
        public int UserId { get; set; }
        public string EventSource { get; set; }
        public EventTypeEnum EventType;
    }
}
