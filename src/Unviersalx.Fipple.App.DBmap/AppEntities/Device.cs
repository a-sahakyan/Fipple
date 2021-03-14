using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class Device
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Udid { get; set; }
        public bool LoggedIn { get; set; }
        public DateTime LastLoginDateUtc { get; set; }
        public string OsType { get; set; }
        public string AppVersion { get; set; }
        public string TimeZone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }

        public virtual User User { get; set; }
    }
}
