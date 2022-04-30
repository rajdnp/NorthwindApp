using NorthwindApp.Entities;

namespace NorthwindApp.Interfaces
{
    public interface IGenericEventHandler<T> where T : class
    {
        public event EventHandler<T> Event;
        void TriggerEvent(T data);
    }

    public class GenericEventHandler<T> : IGenericEventHandler<T> where T : class
    {
        public event EventHandler<T> Event;

        public void TriggerEvent(T data)
        {
            Event?.Invoke(this, data);
        }
    }
}
