using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sentio.Conversation;
namespace Sentio.User
{
    public class ConversationUser
    {
        public long Id { get; set; }
        public Account UserAccount { get; set; }
        public List<ConversationBase> AttendedConversations { get; set; }
        public List<Notification> Notifications { get; set; }

        public void SendMessage(long conversationId, string message)
        {
            message = UserAccount.UserName + ": " + message + " - " + DateTime.Now.ToShortDateString();
            var conversation = AttendedConversations.Where(x => x.Id == conversationId).FirstOrDefault();
            conversation.NotifyConversationUsers(message);
        }

        public void Notify(long conversationId, string notification)
        {
            Notifications.Add(new Notification { Id = Guid.NewGuid().GetHashCode(), ConversationId = conversationId, NotificationsString = notification });
        }

        public List<Notification> ShowConversationNotifications(long conversationId)
        {
            var notifications = Notifications.Where(x => x.ConversationId == conversationId).ToList();
            ClearNotifications(conversationId);
            return notifications;
        }

        public List<string> ShowMessageHistory(long conversationId)
        {
            var conversation = AttendedConversations.Where(x => x.Id == conversationId).FirstOrDefault();
            return conversation.MessageHistory;
        }

        public void ClearNotifications(long conversationId)
        {
            Notifications = Notifications.Where(x => x.ConversationId != conversationId).ToList();
        }

        public void QuitFromConversation(long conversationId)
        {
            var conversation = AttendedConversations.Where(x => x.Id == conversationId).FirstOrDefault();
            var attendee = conversation.Attendees.Where(x => x.UserAccount.Id == UserAccount.Id).FirstOrDefault();
            conversation.Attendees.Remove(attendee);
            AttendedConversations.Remove(conversation);
            conversation.NotifyConversationUsers(UserAccount.UserName + " has quitted from conversation. " + DateTime.Now.ToShortDateString());
        }


    }
}
