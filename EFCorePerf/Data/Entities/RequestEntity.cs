using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data.Entities
{
    [Table("T_REQUEST")]
    public class RequestEntity
    {
        public long Id { get; set; }

        public virtual ICollection<TransactionEntity> Transactions { get; set; } = new List<TransactionEntity>();
    }
}
