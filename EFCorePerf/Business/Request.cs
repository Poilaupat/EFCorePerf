using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Business
{
    public class Request
    {
        public long Id { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
