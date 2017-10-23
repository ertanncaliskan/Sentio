using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio
{
    public class Notification
    {
        public long Id { get; set; }

        public long ConversationId { get; set; }

        public string NotificationsString { get; set; }
    }
}
