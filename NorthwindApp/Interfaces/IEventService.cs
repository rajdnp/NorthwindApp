namespace NorthwindApp.Interfaces
{
    public interface IEventService
    {
        void OnEvent(object source, EventArgs args);
    }
}
