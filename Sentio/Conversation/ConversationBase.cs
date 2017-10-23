using Sentio.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Conversation
{
    public enum ConversationType
    {
        Group,
        Private
    }

    //I don't know maybe in future group and private conversations can have some differencies. I want to derive them from base class
    public abstract class ConversationBase
    {
        public long Id { get; set; }

        public ConversationType ConversationType { get; set; }

        public abstract void NotifyConversationUsers(string message);

        public List<ConversationUser> Attendees { get; set; }

        public List<string> MessageHistory { get; set; }
    }
}
