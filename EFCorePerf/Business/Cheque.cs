using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf.Business

{
    public class Cheque
    {
        public long Id { get; set; }
        public long IdTransaction { get; set; }
        public string Z4 { get; set; }
        public string Z3 { get; set; }
        public string Z2 { get; set; }
        public DateTime CreationDate { get; set; }
        public string BankCode { get; set; }
        public string Account {  get; set; }

        public Reason? Reason { get; set; }
    }
}
