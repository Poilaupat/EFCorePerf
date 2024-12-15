using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Business
{
    public class Transaction
    {
        public long Id { get; set; }
        public long IdRequest { get; set; }
        public string BankCode { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; } = new List<Cheque>();
        public virtual ICollection<Deposit> Deposits { get; set; } = new List<Deposit>();
    }
}
