using System;

namespace KonigLabs.CocaColaEvent.CommonViewModels.Messenger
{
    public class MessageFactory
    {
        public TMessage CreateMessage<TMessage>()
        {
            return Activator.CreateInstance<TMessage>();
        }
    }
}
