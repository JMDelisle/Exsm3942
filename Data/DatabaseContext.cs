using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassroomStart.Models;
using System.Security.Cryptography;

namespace ClassroomStart.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Accounttype> Accounttypes { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=csharp2_assignment_jeanmarc", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccId)
                    .HasName("PRIMARY");

                entity.ToTable("account");

                entity.HasIndex(e => e.AccClientId, "acc_client_id");

                entity.HasIndex(e => e.AccTypeId, "acc_type_id");

                entity.Property(e => e.AccId)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_id");

                entity.Property(e => e.AccBalance)
                    .HasPrecision(5, 2)
                    .HasColumnName("acc_balance");

                entity.Property(e => e.AccClientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_client_id");

                entity.Property(e => e.AccInterestapplieddate)
                    .HasColumnType("datetime")
                    .HasColumnName("acc_interestapplieddate");

                entity.Property(e => e.AccTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("acc_type_id");


                entity.HasOne(d => d.AccClient)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_1");

                entity.HasOne(d => d.AccType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_2");

                entity.HasData(
                    new Account[]
                    {          //ACCID, ACCClientID, AccBalance, InterestDateApplied!
                    new Account (-1, -1, 165000m, new DateTime (1979, 08, 03)) {AccId=-1},

                    new Account (-2, -1, 25000m, new DateTime (2010, 02, 14)) {AccId=-2},

                    new Account (-1, -2, 99000m, new DateTime (2015, 01, 29)) {AccId=-3},

                    new Account (-2, -2, 5000m, new DateTime (2020, 10, 25)) {AccId=-4},

                    new Account (-2, -3, 345000m, new DateTime (2018, 04, 28)) {AccId=-5},

                    new Account (-1, -3, 109656, new DateTime (2004, 06, 28)) {AccId=-6},

                   // new Account() { AccId = 7, AccClientId = 7, AccTypeId = 7, AccBalance = 80000.00m, AccInterestapplieddate = new DateTime(2020, 08, 16) }
                     });
            });

            modelBuilder.Entity<Accounttype>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PRIMARY");

                entity.ToTable("accounttype");

                entity.Property(e => e.AtId)
                    .HasColumnType("int(11)")
                    .HasColumnName("at_id");

                entity.Property(e => e.AtInterestrate)
                    .HasPrecision(5, 2)
                    .HasColumnName("at_interestrate");

                entity.Property(e => e.AtName)
                    .HasMaxLength(50)
                    .HasColumnName("at_name");

                entity.HasData(
                    new Accounttype[]
                    {
                        new Accounttype("Standard Saving", 0.75m){ AtId = -1},
                        new Accounttype("Standard Saving", 3.69m){ AtId = -2},
                        new Accounttype("Standard Saving", 1.25m){ AtId = -3}

                    });
            });





            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PRIMARY");

                entity.ToTable("client");

                entity.Property(e => e.CId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("c_id");

                entity.Property(e => e.CBirthdate)
                    .HasColumnName("c_birthdate");

                entity.Property(e => e.CFirstname)
                    .HasMaxLength(50)
                    .HasColumnName("c_firstname");

                entity.Property(e => e.CHomeaddress)
                    .HasMaxLength(255)
                    .HasColumnName("c_homeaddress");

                entity.Property(e => e.CLastname)
                    .HasMaxLength(50)
                    .HasColumnName("c_lastname");

                /*       THIS WAS AN EXTRA KEY FROM XAMPP APPARENTLY, DON'T NEED IT.
                 *       entity.HasOne(d => d.CIdNavigation)
                           .WithOne(p => p.Client)
                           .HasForeignKey<Client>(d => d.CId)
                           .OnDelete(DeleteBehavior.ClientSetNull)
                           .HasConstraintName("client_ibfk_1");
                */
                entity.HasData(
                   new Client[]
                   {
                        new Client ("Borat","Sagdiyev", DateTime.Parse("04-19-1965"), "12345-123 St North, Cincinatti, OH, 87542"){CId=-1},                      
                        new Client ("Zac", "Ingram", new DateTime (1968, 12, 31), "456 Pecanwood Way"){CId=-2},
                        new Client ("Charles", "Sheen", new DateTime (1968, 12, 31),"789 Maplewood Way"){CId=-3},
                        new Client ("Callie", "Whittington", new DateTime (1968, 12, 31),  "012 Cedarwood Way"){CId=-4}

                   });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
