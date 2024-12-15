using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data.Entities
{
    [Table("T_CHEQUE")]
    public class ChequeEntity
    {
        public long Id { get; set; }
        [Column("id_transaction")]
        public long IdTransaction { get; set; }
        public string Z4 { get; set; }
        public string Z3 { get; set; }
        public string Z2 { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("bank_code")]
        public string BankCode { get; set; }
        public string Account {  get; set; }

        public virtual TransactionEntity Transaction { get; set; }
        public virtual ReasonEntity? Reason { get; set; }
    }
}
