using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common.Model.ExternalRelation
{
    public partial class ModuleInvoicePaymentReceipt
    {
        [NotMapped]
        public List<ModuleInvoicePaymentReceiptDetail> ModuleInvoicePaymentReceiptDetail { get; set; }
        [NotMapped]
        public List<ModuleInvoicePaymentOther> ModuleInvoicePaymentOther { get; set; }
        [NotMapped]
        public List<XChargeResponse> XChargeResponse { get; set; }
        [NotMapped]
        public List<MonerisResponse> MonerisResponse { get; set; }
    }
}
