using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data.Entities
{
    [Table("T_DEPOSIT")]
    public class DepositEntity
    {
        public long Id { get; set; }
        [Column("id_transaction")]
        public long IdTransaction { get; set; }
        public decimal Amount { get; set; }

        public virtual TransactionEntity Transaction { get; set; }
    }
}
