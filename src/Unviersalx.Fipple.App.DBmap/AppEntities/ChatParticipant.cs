using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class ChatParticipant
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ChatGroupId { get; set; }
        public bool IsActive { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
        public virtual User User { get; set; }
    }
}
