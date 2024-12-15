using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Business
{
    public class Deposit
    {
        public long Id { get; set; }
        public long IdTransaction { get; set; }
        public decimal Amount { get; set; }
    }
}
