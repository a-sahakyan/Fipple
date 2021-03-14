using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class MatchParticipant
    {
        public MatchParticipant()
        {
            Matches = new HashSet<Match>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public long MatchGroupId { get; set; }

        public virtual MatchGroup MatchGroup { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
