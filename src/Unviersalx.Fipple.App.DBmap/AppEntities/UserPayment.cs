using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class UserPayment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public short SubscriptionTypeId { get; set; }
        public DateTime? ExpireDateUtc { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }

        public virtual SubscriptionType SubscriptionType { get; set; }
        public virtual User User { get; set; }
    }
}
