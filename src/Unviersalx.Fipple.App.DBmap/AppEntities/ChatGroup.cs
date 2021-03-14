using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class ChatGroup
    {
        public ChatGroup()
        {
            ChatParticipants = new HashSet<ChatParticipant>();
            Messages = new HashSet<Message>();
        }

        public long Id { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual ICollection<ChatParticipant> ChatParticipants { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
