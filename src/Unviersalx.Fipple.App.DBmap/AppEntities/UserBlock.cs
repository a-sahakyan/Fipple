using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class UserBlock
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long BlockedUserId { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual User BlockedUser { get; set; }
        public virtual User User { get; set; }
    }
}
