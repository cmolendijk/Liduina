using Liduina.DL.Models.Profile;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Liduina.DL.Models;

namespace Liduina.DL.Providers
{
    public class DbProvider : DbContext
    {
        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<AidOffer> AidOffers { get; set; }
        public virtual DbSet<AidProvider> AidProviders { get; set; }
        public virtual DbSet<AidRequest> AidRequests { get; set; }
        public virtual DbSet<AidRequester> AidRequesters { get; set; }
        public virtual DbSet<Button> Button { get; set; }
        public virtual DbSet<ButtonAction> ButtonActions { get; set; }
        public virtual DbSet<ButtonAidRequest> ButtonAidRequests { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<ConfigurationKey> ConfigurationKeys { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<SendAidRequest> SendAidRequests { get; set; }
        public virtual DbSet<SendRequest> SendRequests { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}