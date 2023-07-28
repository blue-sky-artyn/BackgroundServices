using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common.Model.ExternalRelation
{

    public partial class ModuleInformation
    {
        public ModuleInformation()
        {
            ModuleDependency = new ModuleDependency();
            ModuleRelation = new List<ModuleRelation>();
            ModuleRelationExtension = new List<ModuleRelationExtension>();
            ModuleExternalRelation = new List<ModuleExternalRelation>();
            ModuleAvailability = new List<ModuleAvailability>();
            ModuleAvailabilityTime = new List<ModuleAvailabilityTime>();
            ModuleGoals = new List<ModuleGoal>();
        }
        [NotMapped]

        public List<Module> ModuleRelationModule { get; set; }
        [NotMapped]

        public List<ModuleRelation> ModuleRelation { get; set; }
        
        [NotMapped]

        public ModuleDependency ModuleDependency { get; set; }
        [NotMapped]

        public List<ModuleValueExtension> ModuleValueExtension { get; set; }
        [NotMapped]

        public ModuleValue ModuleValue { get; set; }
        [NotMapped]

        public List<ModuleUsage> ModuleUsage { get; set; }
        [NotMapped]

        public List<ModuleUnitConversion> ModuleUnitConversion { get; set; }
        [NotMapped]

        public ModuleImage ModuleImage { get; set; }
        [NotMapped]

        public List<ModuleRelationExtension> ModuleRelationExtension { get; set; }
        [NotMapped]

        public List<ModuleExternalRelation> ModuleExternalRelation { get; set; }
        [NotMapped]

        public List<ModuleExternalExtension> ModuleExternalExtension { get; set; }
        [NotMapped]

        public List<ModuleAvailability> ModuleAvailability { get; set; }
        [NotMapped]

        public List<ModuleAvailabilityTime> ModuleAvailabilityTime { get; set; }
        [NotMapped]

        public List<ModuleAvailabilityDays> ModuleAvailabilityDays { get; set; }
        [NotMapped]
        public List<ModuleRelationTimeSlot> ModuleRelationTimeSlot { get; set; }
        [NotMapped]
        public List<ModuleStockChange> ModuleStockChange { get; set; }
        [NotMapped]

        public ModuleCore ModuleCore1 { get; set; }
        [NotMapped]

        public List<ModuleGoal> ModuleGoals { get; set; }
        [NotMapped]

        public string ModuleCode { get; set; }
        [NotMapped]

        public string ModuleFirstName { get; set; }
        [NotMapped]

        public string ModuleSecondName { get; set; }
        [NotMapped]

        public string Comment { get; set; }
        [NotMapped]

        public string ModuleTypeSystemId { get; set; }
        [NotMapped]

        public Nullable<Boolean> IsActive { get; set; }
        [NotMapped]

        public Nullable<Boolean> Status { get; set; }
        [NotMapped]

        public string CreatedTenantId { get; set; }
        [NotMapped]

        public string ParentId { get; set; }
        //[NotMapped]
        //public Module Module
        //{
        //    get
        //    {
        //        Architect.Infra.Common.InternalWrapper tmpWrapper =
        //            new Architect.Infra.Common.InternalWrapper();
        //        Module tmpResult = new ObjectModel.Module();
        //        tmpWrapper.ObjectClone(tmpResult, this);
        //        return tmpResult;
        //    }
        //}
    }
}
