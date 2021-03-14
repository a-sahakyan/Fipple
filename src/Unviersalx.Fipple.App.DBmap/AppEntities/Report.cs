using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class Report
    {
        public Report()
        {
            UserReports = new HashSet<UserReport>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserReport> UserReports { get; set; }
    }
}
