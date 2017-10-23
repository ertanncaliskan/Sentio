using Sentio.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Conversation
{
    public static class ConversationFactory
    {

        public static ConversationBase BuildConversation(ConversationType type = ConversationType.Group, List<ConversationUser> Attendees = null)
        {
            ConversationBase conversation = null;
            if (Attendees == null) throw new Exception("Please add contact");
            switch (type)
            {
                case ConversationType.Group:
                    conversation = new GroupConversation { Id = Guid.NewGuid().GetHashCode(), Attendees = Attendees, ConversationType = type };
                    break;
                case ConversationType.Private:
                    if (Attendees.Count > 2) throw new Exception("Private conversations must be contained 2 users");
                    conversation = new PrivateConversation { Id = Guid.NewGuid().GetHashCode(), Attendees = Attendees, ConversationType = type };
                    break;
            }
            foreach (var attendee in Attendees)
                attendee.AttendedConversations.Add(conversation);
            return conversation;
            throw new NotImplementedException();
        }

    }
}
