using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class UserPreference
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public char ShowMe { get; set; }
        public short MaxDistanceMi { get; set; }
        public short MinAge { get; set; }
        public short MaxAge { get; set; }
        public bool? IsGlobal { get; set; }
        public DateTime? UpdateDateUtc { get; set; }

        public virtual User User { get; set; }
    }
}
