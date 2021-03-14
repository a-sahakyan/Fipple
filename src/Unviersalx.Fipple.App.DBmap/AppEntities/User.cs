using System;
using System.Collections.Generic;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class User
    {
        public User()
        {
            ChatParticipants = new HashSet<ChatParticipant>();
            CreditCards = new HashSet<CreditCard>();
            Devices = new HashSet<Device>();
            MatchGroups = new HashSet<MatchGroup>();
            MatchParticipants = new HashSet<MatchParticipant>();
            UserBlockBlockedUsers = new HashSet<UserBlock>();
            UserBlockUsers = new HashSet<UserBlock>();
            UserImages = new HashSet<UserImage>();
            UserPayments = new HashSet<UserPayment>();
            UserPreferences = new HashSet<UserPreference>();
            UserReportReportedUsers = new HashSet<UserReport>();
            UserReportUsers = new HashSet<UserReport>();
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime? UpdatedDateUtc { get; set; }

        public virtual ICollection<ChatParticipant> ChatParticipants { get; set; }
        public virtual ICollection<CreditCard> CreditCards { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<MatchGroup> MatchGroups { get; set; }
        public virtual ICollection<MatchParticipant> MatchParticipants { get; set; }
        public virtual ICollection<UserBlock> UserBlockBlockedUsers { get; set; }
        public virtual ICollection<UserBlock> UserBlockUsers { get; set; }
        public virtual ICollection<UserImage> UserImages { get; set; }
        public virtual ICollection<UserPayment> UserPayments { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
        public virtual ICollection<UserReport> UserReportReportedUsers { get; set; }
        public virtual ICollection<UserReport> UserReportUsers { get; set; }
    }
}
