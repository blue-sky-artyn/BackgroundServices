using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common.Model.ExternalRelation
{
    public partial class Module
    {
        [NotMapped]
        public ModuleInvoice ModuleInvoice { get; set; }
    }
}
