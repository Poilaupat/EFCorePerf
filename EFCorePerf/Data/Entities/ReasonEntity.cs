using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Data.Entities
{
    [Table("T_REASON")]
    public class ReasonEntity
    {
        public long Id { get; set; }
        public string Comment { get; set; }

        public virtual ChequeEntity Cheque { get; set; }  
    }
}
