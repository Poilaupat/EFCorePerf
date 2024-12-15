using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data.Entities
{
    [Table("T_TRANSACTION")]
    public class TransactionEntity
    {
        public long Id { get; set; }
        [Column("id_request")]
        public long IdRequest { get; set; }
        [Column("bank_code")]
        public string BankCode { get; set; }

        public virtual RequestEntity Request { get; set; }
        public virtual ICollection<ChequeEntity> Cheques { get; set; } = new List<ChequeEntity>();
        public virtual ICollection<DepositEntity> Deposits { get; set; } = new List<DepositEntity>();
    }
}
