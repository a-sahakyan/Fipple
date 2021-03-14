using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class CreditCard
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public short ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public short Cvc { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }
        public bool IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
