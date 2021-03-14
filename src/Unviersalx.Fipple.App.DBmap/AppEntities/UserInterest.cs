using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class UserInterest
    {
        public long UserId { get; set; }
        public short InterestId { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual User User { get; set; }
    }
}
