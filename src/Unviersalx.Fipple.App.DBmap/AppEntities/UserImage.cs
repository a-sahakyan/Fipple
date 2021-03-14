using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class UserImage
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Image { get; set; }
        public bool IsCover { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual User User { get; set; }
    }
}
