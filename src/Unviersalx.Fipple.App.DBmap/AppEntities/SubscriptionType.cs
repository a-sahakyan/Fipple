using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            UserPayments = new HashSet<UserPayment>();
        }

        public short Id { get; set; }
        public string Package { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public short? DurationMonth { get; set; }

        public virtual ICollection<UserPayment> UserPayments { get; set; }
    }
}
