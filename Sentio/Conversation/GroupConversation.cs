using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.Conversation
{
    public class GroupConversation : ConversationBase
    {
        public override void NotifyConversationUsers(string message)
        {
            MessageHistory.Add(message);
            foreach (var attendee in Attendees)
            {
                attendee.Notify(Id, "New Notification!! " + message);
            }
        }
    }
}
