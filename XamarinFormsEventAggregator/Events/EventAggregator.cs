using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace XamarinFormsEventAggregator.Events
{
    public class EventAggregator : IEventAggregator
    {
    
        public EventAggregator()
        {
            mSynchronizationContext = SynchronizationContext.Current;
        }

    
        public void SendMessage<T>(T message)
        {
            if (message == null)
            {
                return;
            }

            if (mSynchronizationContext != null)
            {
                mSynchronizationContext.Send(
                    m => Dispatch<T>((T)m),
                    message);
            }
            else
            {
                Dispatch(message);
            }
        }


        public void PostMessage<T>(T message)
        {
            if (message == null)
            {
                return;
            }

            if (mSynchronizationContext != null)
            {
                mSynchronizationContext.Post(
                    m => Dispatch<T>((T)m),
                    message);
            }
            else
            {
                Dispatch(message);
            }
        }

        public Action<T> RegisterHandler<T>(Action<T> eventHandler)
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException("eventHandler");
            }

            mHandlers.Add(eventHandler);
            return eventHandler;
        }


        public void UnregisterHandler<T>(Action<T> eventHandler)
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException("eventHandler");
            }

            mHandlers.Remove(eventHandler);
        }


        private void Dispatch<T>(T message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var compatibleHandlers
                = mHandlers.OfType<Action<T>>()
                    .ToList();
            foreach (var h in compatibleHandlers)
            {
                h(message);
            }
        }

        private readonly List<Delegate> mHandlers = new List<Delegate>();

        private readonly SynchronizationContext mSynchronizationContext;
    }
}
