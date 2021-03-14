using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.CoreEntities
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public short Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
