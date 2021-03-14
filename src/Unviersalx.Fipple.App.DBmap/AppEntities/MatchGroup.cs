using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class MatchGroup
    {
        public MatchGroup()
        {
            MatchParticipants = new HashSet<MatchParticipant>();
        }

        public long Id { get; set; }
        public long PlayerUserId { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual User PlayerUser { get; set; }
        public virtual ICollection<MatchParticipant> MatchParticipants { get; set; }
    }
}
