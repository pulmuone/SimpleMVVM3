using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMVVM.Models
{
    public class InboundModel
    {
        public string InvoiceNumber { get; set; }
        public string InboundDate { get; set; }
        public string VenderCode { get; set; }
        public string VenderName { get; set; }
        public string Remark { get; set; }

    }
}
