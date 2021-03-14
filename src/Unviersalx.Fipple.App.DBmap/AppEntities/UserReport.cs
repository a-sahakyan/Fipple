using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class UserReport
    {
        public int Id { get; set; }
        public long UserId { get; set; }
        public long ReportedUserId { get; set; }
        public short ReportId { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual Report Report { get; set; }
        public virtual User ReportedUser { get; set; }
        public virtual User User { get; set; }
    }
}
