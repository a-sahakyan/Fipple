using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Unviersalx.Fipple.App.DBmap.AppEntities
{
    public partial class AppContext : DbContext
    {
        public AppContext()
        {
        }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChatGroup> ChatGroups { get; set; }
        public virtual DbSet<ChatParticipant> ChatParticipants { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchGroup> MatchGroups { get; set; }
        public virtual DbSet<MatchParticipant> MatchParticipants { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBlock> UserBlocks { get; set; }
        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<UserInterest> UserInterests { get; set; }
        public virtual DbSet<UserPayment> UserPayments { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<UserReport> UserReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=fipple;Username=postgres;Password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1251");

            modelBuilder.Entity<ChatGroup>(entity =>
            {
                entity.ToTable("chat_groups", "app");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");
            });

            modelBuilder.Entity<ChatParticipant>(entity =>
            {
                entity.ToTable("chat_participants", "app");

                entity.HasIndex(e => e.ChatGroupId, "chat_participants_chat_group_id");

                entity.HasIndex(e => e.UserId, "chat_participants_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChatGroupId).HasColumnName("chat_group_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ChatGroup)
                    .WithMany(p => p.ChatParticipants)
                    .HasForeignKey(d => d.ChatGroupId)
                    .HasConstraintName("chat_participants_chat_group_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChatParticipants)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("chat_participants_user_id_fkey");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("credit_cards", "app");

                entity.HasIndex(e => e.UserId, "credit_cards_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("card_number");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.Cvc).HasColumnName("cvc");

                entity.Property(e => e.ExpMonth).HasColumnName("exp_month");

                entity.Property(e => e.ExpYear).HasColumnName("exp_year");

                entity.Property(e => e.HolderName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("holder_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.UpdatedDateUtc).HasColumnName("updated_date_utc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CreditCards)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("credit_cards_user_id_fkey");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("devices", "app");

                entity.HasIndex(e => e.UserId, "devices_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppVersion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("app_version");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastLoginDateUtc).HasColumnName("last_login_date_utc");

                entity.Property(e => e.LoggedIn).HasColumnName("logged_in");

                entity.Property(e => e.OsType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("os_type");

                entity.Property(e => e.TimeZone)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("time_zone");

                entity.Property(e => e.Udid)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("udid");

                entity.Property(e => e.UpdatedDateUtc).HasColumnName("updated_date_utc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("devices_user_id_fkey");
            });

            modelBuilder.Entity<Interest>(entity =>
            {
                entity.ToTable("interests", "app");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("matches", "app");

                entity.HasIndex(e => e.SelectedParticipantId, "matches_selected_participant_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.SelectedParticipantId).HasColumnName("selected_participant_id");

                entity.HasOne(d => d.SelectedParticipant)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.SelectedParticipantId)
                    .HasConstraintName("matches_selected_participant_id_fkey");
            });

            modelBuilder.Entity<MatchGroup>(entity =>
            {
                entity.ToTable("match_groups", "app");

                entity.HasIndex(e => e.PlayerUserId, "match_groups_player_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.PlayerUserId).HasColumnName("player_user_id");

                entity.HasOne(d => d.PlayerUser)
                    .WithMany(p => p.MatchGroups)
                    .HasForeignKey(d => d.PlayerUserId)
                    .HasConstraintName("match_groups_player_user_id_fkey");
            });

            modelBuilder.Entity<MatchParticipant>(entity =>
            {
                entity.ToTable("match_participants", "app");

                entity.HasIndex(e => e.MatchGroupId, "match_participants_match_group_id");

                entity.HasIndex(e => e.UserId, "match_participants_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MatchGroupId).HasColumnName("match_group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.MatchGroup)
                    .WithMany(p => p.MatchParticipants)
                    .HasForeignKey(d => d.MatchGroupId)
                    .HasConstraintName("match_participants_match_group_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MatchParticipants)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("match_participants_user_id_fkey");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages", "app");

                entity.HasIndex(e => e.ChatGroupId, "messages_chat_group_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChatGroupId).HasColumnName("chat_group_id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasColumnName("message");

                entity.Property(e => e.UpdatedDateUtc).HasColumnName("updated_date_utc");

                entity.HasOne(d => d.ChatGroup)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChatGroupId)
                    .HasConstraintName("messages_chat_group_id_fkey");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("reports", "app");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SubscriptionType>(entity =>
            {
                entity.ToTable("subscription_types", "app");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.DurationMonth).HasColumnName("duration_month");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.Package)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("package");

                entity.Property(e => e.Price)
                    .HasPrecision(9, 2)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "app");

                entity.HasIndex(e => e.UserId, "users_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");

                entity.Property(e => e.UpdatedDateUtc).HasColumnName("updated_date_utc");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<UserBlock>(entity =>
            {
                entity.ToTable("user_blocks", "app");

                entity.HasIndex(e => e.BlockedUserId, "user_blocks_blocked_user_id");

                entity.HasIndex(e => e.UserId, "user_blocks_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BlockedUserId).HasColumnName("blocked_user_id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BlockedUser)
                    .WithMany(p => p.UserBlockBlockedUsers)
                    .HasForeignKey(d => d.BlockedUserId)
                    .HasConstraintName("user_blocks_blocked_user_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserBlockUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_blocks_user_id_fkey");
            });

            modelBuilder.Entity<UserImage>(entity =>
            {
                entity.ToTable("user_images", "app");

                entity.HasIndex(e => e.UserId, "user_images_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("image");

                entity.Property(e => e.IsCover).HasColumnName("is_cover");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserImages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_images_user_id_fkey");
            });

            modelBuilder.Entity<UserInterest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_interests", "app");

                entity.HasIndex(e => e.InterestId, "user_interests_interest_id");

                entity.HasIndex(e => e.UserId, "user_interests_user_id");

                entity.Property(e => e.InterestId).HasColumnName("interest_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Interest)
                    .WithMany()
                    .HasForeignKey(d => d.InterestId)
                    .HasConstraintName("user_interests_interest_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_interests_user_id_fkey");
            });

            modelBuilder.Entity<UserPayment>(entity =>
            {
                entity.ToTable("user_payments", "app");

                entity.HasIndex(e => e.SubscriptionTypeId, "user_payments_subscription_type_id");

                entity.HasIndex(e => e.UserId, "user_payments_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.ExpireDateUtc).HasColumnName("expire_date_utc");

                entity.Property(e => e.SubscriptionTypeId).HasColumnName("subscription_type_id");

                entity.Property(e => e.UpdatedDateUtc).HasColumnName("updated_date_utc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.UserPayments)
                    .HasForeignKey(d => d.SubscriptionTypeId)
                    .HasConstraintName("user_payments_subscription_type_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPayments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_payments_user_id_fkey");
            });

            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.ToTable("user_preferences", "app");

                entity.HasIndex(e => e.UserId, "user_preferences_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsGlobal)
                    .IsRequired()
                    .HasColumnName("is_global")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.MaxAge)
                    .HasColumnName("max_age")
                    .HasDefaultValueSql("100");

                entity.Property(e => e.MaxDistanceMi)
                    .HasColumnName("max_distance_mi")
                    .HasDefaultValueSql("100");

                entity.Property(e => e.MinAge)
                    .HasColumnName("min_age")
                    .HasDefaultValueSql("18");

                entity.Property(e => e.ShowMe)
                    .HasMaxLength(1)
                    .HasColumnName("show_me");

                entity.Property(e => e.UpdateDateUtc).HasColumnName("update_date_utc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPreferences)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_preferences_user_id_fkey");
            });

            modelBuilder.Entity<UserReport>(entity =>
            {
                entity.ToTable("user_reports", "app");

                entity.HasIndex(e => e.ReportId, "user_reports_report_id");

                entity.HasIndex(e => e.ReportedUserId, "user_reports_reported_user_id");

                entity.HasIndex(e => e.UserId, "user_reports_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDateUtc)
                    .HasColumnName("created_date_utc")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.ReportedUserId).HasColumnName("reported_user_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.UserReports)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("user_reports_report_id_fkey");

                entity.HasOne(d => d.ReportedUser)
                    .WithMany(p => p.UserReportReportedUsers)
                    .HasForeignKey(d => d.ReportedUserId)
                    .HasConstraintName("user_reports_reported_user_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReportUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_reports_user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
