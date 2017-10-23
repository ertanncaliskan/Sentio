using Sentio.Conversation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.User
{
    public class Account : LoginUser
    {
        public Account()
        {
            Contacts = new List<Account>();
            ContactRequests = new List<Account>();
            ConversationUser = new ConversationUser { UserAccount = this };
        }
        public List<Account> Contacts { get; set; }
        public List<Account> ContactRequests { get; set; }
        private string Status { get; set; }
        public ConversationUser ConversationUser { get; set; }

        public void SetStatus(string status)
        {
            Status = status + " " + DateTime.Now.ToShortDateString();
        }


        public void AcceptContactRequest(long contactId)
        {
            var contact = ContactRequests.Where(x => x.Id == contactId).FirstOrDefault();
            if (contact == null)
                throw new Exception("Contact can't be found");

            Contacts.Add(contact);
            ContactRequests.Remove(contact);
        }

        public void AddContact(Account account)
        {
            account.ContactRequests.Add(this);
        }


        public string GetStatus()
        {
            return IsOnline ? "user is online - " + Status : "user is offline " + Status;
        }

        public void CreateConversation(ConversationType type = ConversationType.Group, List<ConversationUser> Attendees = null)
        {
            if (Attendees == null) Attendees = Contacts.Select(x => x.ConversationUser).ToList();
            Attendees.Add(ConversationUser);
            var conversation = ConversationFactory.BuildConversation(type, Attendees);
        }
    }
}
