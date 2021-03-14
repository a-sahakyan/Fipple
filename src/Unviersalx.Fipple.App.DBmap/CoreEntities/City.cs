using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.CoreEntities
{
    public partial class City
    {
        public City()
        {
            UserLocations = new HashSet<UserLocation>();
        }

        public int Id { get; set; }
        public short CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<UserLocation> UserLocations { get; set; }
    }
}
