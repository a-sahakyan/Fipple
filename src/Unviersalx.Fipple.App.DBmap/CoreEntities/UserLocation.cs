using System;
using System.Collections.Generic;
using System.Net;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.CoreEntities
{
    public partial class UserLocation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int CityId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        public IPAddress Ip { get; set; }

        public virtual City City { get; set; }
    }
}
