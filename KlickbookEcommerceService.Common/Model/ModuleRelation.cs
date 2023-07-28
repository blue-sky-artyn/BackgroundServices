using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common.Model.ExternalRelation
{
    public partial class ModuleRelation
    {
        [NotMapped]
        public List<ModuleRelationExtension> ModuleRelationExtension { get; set; }
        [NotMapped]
        public List<ModuleRelationTimeSlot> ModuleRelationTimeSlot { get; set; }
        [NotMapped]
        public List<ModuleStockChange> ModuleStockChange { get; set; }
        [NotMapped]
        public ModuleInformation TargetModule { get; set; }
    }
}
