using EFCorePerf.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data
{
    internal class Populator
    {
        private readonly DbContext _context;
        private readonly Random _random = new Random(); 

        public Populator(DbContext context)
        {

            _context = context;
        }

        public void PopulateDb(int nbtnx)
        {
            var request = new RequestEntity();

            for (int i = 0; i < nbtnx; i++)
            {
                request.Transactions.Add(CreateRandomTransaction());
            }

            _context.BulkInsert(new[] { request }, options => options.IncludeGraph = true);
        }

        private TransactionEntity CreateRandomTransaction()
        {
            var transaction = new TransactionEntity();
            transaction.BankCode = _random.Next(2) == 1 ? "22222" : "33333";
            transaction.Cheques.Add(CreateRandomCheque());
            return transaction;
        }

        private ChequeEntity CreateRandomCheque()
        {
            return new ChequeEntity
            {
                Z4 = _random.Next(1, 9999999).ToString().PadLeft(7, '0'),
                Z3 = _random.Next(1, 999999999).ToString().PadLeft(9, '0') + "908",
                Z2 = _random.Next(1, 999999999).ToString().PadLeft(12, '0'),
                CreationDate = DateTime.Now,
                Account = _random.Next(1, 999999999).ToString().PadLeft(11, '0'),
                BankCode = _random.Next(2) == 1 ? "99999" : "11111",
                Reason = _random.Next() < (Int32.MaxValue / 10) ? CreateRandomReason() : null
            };
        }

        private DepositEntity CreateRandomDeposit()
        {
            return new DepositEntity
            {
                Amount = (decimal)_random.Next(100, 50000) / 100m
            };
        }

        private ReasonEntity CreateRandomReason()
        {
            return new ReasonEntity
            {
                Comment = $"Random comment_{_random.Next(1, 9999999)}"
            };
        }
    }
}
