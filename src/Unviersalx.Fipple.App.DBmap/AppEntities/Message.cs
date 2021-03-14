using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class Message
    {
        public long Id { get; set; }
        public long ChatGroupId { get; set; }
        public string Message1 { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public bool IsActive { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
    }
}
