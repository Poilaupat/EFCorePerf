using EFCorePerf.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data
{
    internal class DataContextLazy : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string cs = "Server=.;Database=Dev;Trusted_Connection=True;TrustServerCertificate=True;";
            options
                .UseLazyLoadingProxies()
                .UseSqlServer(cs);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RequestEntity>()
                .HasKey(x => x.Id);

            builder.Entity<TransactionEntity>()
                .HasKey(x => x.Id);
            builder.Entity<TransactionEntity>()
                .HasOne(x => x.Request)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.IdRequest);

            builder.Entity<DepositEntity>()
                .HasKey(x => x.Id);
            builder.Entity<DepositEntity>()
                .HasOne(x => x.Transaction)
                .WithMany(x => x.Deposits)
                .HasForeignKey(x => x.IdTransaction);

            builder.Entity<ChequeEntity>()
                .HasKey(x => x.Id);
            builder.Entity<ChequeEntity>()
                .HasOne(x => x.Transaction)
                .WithMany(x => x.Cheques)
                .HasForeignKey(x => x.IdTransaction);


            builder.Entity<ReasonEntity>()
                .HasKey(x => x.Id);
            builder.Entity<ReasonEntity>()
                .HasOne(x => x.Cheque)
                .WithOne(x => x.Reason)
                .HasForeignKey<ReasonEntity>(x => x.Id);

        }

        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<TransactionEntity> TransactionEntitys { get; set; }
        public DbSet<DepositEntity> Deposits { get; set; }
        public DbSet<ChequeEntity> Cheques { get; set; }
        public DbSet<ReasonEntity> Reasons { get; set; }
    }
}
