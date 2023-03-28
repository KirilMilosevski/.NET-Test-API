using DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class DataContext : DbContext
    {
        private readonly string _connStr;

        public DataContext(DbContextOptions<DataContext> options)
        {
#pragma warning disable EF1001 // Internal EF Core API usage.
            SqlServerOptionsExtension sqlServerOptionsExtension = options.FindExtension<SqlServerOptionsExtension>();
#pragma warning restore EF1001 // Internal EF Core API usage.

            if (sqlServerOptionsExtension != null)
            {
                _connStr = sqlServerOptionsExtension.ConnectionString;
            }
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStr, providerOptions => providerOptions.CommandTimeout(60));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entiry =>
            {
                entiry.HasKey(e => e.Id);

                entiry.Property(e => e.FirstName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .IsRequired(false);

                entiry.Property(e => e.FirstName)
                .HasMaxLength(400)
                .IsUnicode(true)
                .IsRequired(false);

                entiry.Property(e => e.DOB)
                .HasColumnName("DateOfBirth")
                .HasColumnType("datetime")
                .IsRequired(false);

                entiry.Property(e => e.EnrollmentDate)
                .HasColumnName("EnrollmentDate")
                .HasColumnType("datetime")
                .IsRequired(false);

                entiry.Property(e => e.StudentIndex)
                .HasColumnName("StudentIndex")
                .HasColumnType("char(4)")
                .IsRequired(true);

                entiry.Property(e => e.GPA)
                .HasColumnName("GPA")
                .HasColumnType("decimal(3,2)")
                .IsRequired(false);

                entiry.Property(e => e.AddressId)
               .HasColumnName("AddressId")
               .HasColumnType("int")
               .IsRequired(true);

                entiry.HasOne(e => e.Address);
            });

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithMany(a => a.Students);

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Street)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.City)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.Country)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Address>()
                .HasMany(s => s.Students)
                .WithOne(a => a.Address);

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, City = "London", Street = "Frying Pan Road", Country = "UK" },
                new Address { Id = 2, City = "Cincinnati", Street = "Error Place", Country = "USA" },
                new Address { Id = 3, City = "Rome", Street = "Bad Route Road", Country = "Italy" },
                new Address { Id = 4, City = "Las Vegas", Street = "Pillow Talk Court", Country = "USA" },
                new Address { Id = 5, City = "Berlin", Street = "This Street", Country = "Germany" }
                );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Kessidy",
                    LastName = "Truman",
                    StudentIndex = "3516",
                    AddressId = 2,
                    Mail = "Kassidy.Truman@mail.com",
                    EnrollmentDate = DateTime.Today.AddYears(-3)
                },
                 new Student
                 {
                     Id = 2,
                     FirstName = "Christobel",
                     LastName = "Bezuidenhout",
                     StudentIndex = "1241",
                     AddressId = 5,
                     Mail = "Christobel.Bezuidenhout@mail.com",
                     EnrollmentDate = DateTime.Today.AddYears(-4)
                 },
               new Student
               {
                   Id = 3,
                   FirstName = "Kristel",
                   LastName = "Madison",
                   StudentIndex = "3121",
                   AddressId = 1,
                   Mail = "Kristel.Madison@mail.com",
                   EnrollmentDate = DateTime.Today.AddYears(-2)
               },
               new Student
               {
                   Id = 4,
                   FirstName = "Lyndsey",
                   LastName = "Albers",
                   StudentIndex = "1415",
                   AddressId = 3,
                   Mail = "Lyndsey.Albers@mail.com",
                   EnrollmentDate = DateTime.Today.AddYears(-1)
               },
               new Student
               {
                   Id = 5,
                   FirstName = "Alishia",
                   LastName = "Gabriels",
                   StudentIndex = "3717",
                   AddressId = 4,
                   Mail = "Alishia.Gabriels@mail.com",
                   EnrollmentDate = DateTime.Today.AddYears(-3)
               }
                );

        }
    }
}
