using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common.Model.ExternalRelation
{
    public partial class ModuleInvoice
    {
        [NotMapped]
        public List<ModuleInvoiceDetail> ModuleInvoiceDetail { get; set; }
        [NotMapped]
        public ModuleInvoicePaymentReceipt ModuleInvoicePaymentReceipt { get; set; }
    }
}
