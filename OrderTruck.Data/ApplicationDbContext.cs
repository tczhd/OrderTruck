using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderTruck.Model;
using OrderTruck.Model.Entities;

namespace OrderTruck.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountSetting> AccountSetting { get; set; }
        public virtual DbSet<AccountUser> AccountUser { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Element> Element { get; set; }
        public virtual DbSet<Form> Form { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Reg> Reg { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Signup> Signup { get; set; }
        public virtual DbSet<SignupSetting> SignupSetting { get; set; }
        public virtual DbSet<Slot> Slot { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserSetting> UserSetting { get; set; }
        public virtual DbSet<Waiver> Waiver { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>(entity =>
            {
                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.PlanId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });

            builder.Entity<AccountSetting>(entity =>
            {
                entity.Property(e => e.Setting)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Value).IsRequired();
            });

            builder.Entity<AccountUser>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");
            });

            builder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Message).IsRequired();
            });

            builder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.Cccode)
                    .HasColumnName("CCCode")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Ccmonth).HasColumnName("CCMonth");

                entity.Property(e => e.Ccname)
                    .HasColumnName("CCName")
                    .HasMaxLength(100);

                entity.Property(e => e.Ccnumber)
                    .HasColumnName("CCNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ccyear).HasColumnName("CCYear");

                entity.Property(e => e.DefaultPayment).HasDefaultValueSql("((0))");
            });

            builder.Entity<Form>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifed).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            builder.Entity<Message>(entity =>
            {
                entity.Property(e => e.ReadDate).HasColumnType("datetime");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(1000);
            });

            builder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.PayFor).HasMaxLength(500);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.TransactionNumber)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            builder.Entity<Reg>(entity =>
            {
                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.RegDate).HasColumnType("datetime");

                entity.Property(e => e.VerifyDate).HasColumnType("datetime");
            });

            builder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            builder.Entity<Signup>(entity =>
            {
                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(500);
            });

            builder.Entity<SignupSetting>(entity =>
            {
                entity.Property(e => e.Setting)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.Entity<Slot>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Avatar).HasColumnType("image");

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.MiddleName).HasMaxLength(200);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.Username).HasMaxLength(200);
            });

            builder.Entity<UserSetting>(entity =>
            {
                entity.Property(e => e.Setting)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            builder.Entity<Waiver>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");
            });
        }
    }
}
