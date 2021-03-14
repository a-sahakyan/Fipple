using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class Match
    {
        public long Id { get; set; }
        public long SelectedParticipantId { get; set; }
        public DateTime CreatedDateUtc { get; set; }

        public virtual MatchParticipant SelectedParticipant { get; set; }
    }
}
