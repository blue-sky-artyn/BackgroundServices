using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common
{

    public partial class ProductsModel
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, tenant }; } }
        //Module
        public string tenant { get; set; }
        public string ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleFirstName { get; set; }
        public Nullable<DateTime> ModuleUpdate { get; set; }
        //ModuleVariant
        public string? VariantName { get; set; }
        public string? VariantBarcode { get; set; }
        public string? VariantSku { get; set; }
        public Nullable<UInt64> CustomizeUnit { get; set; }
        //ModuleUnitConversion
        public string? UnitTypeId { get; set; } //from masterdata
        public decimal ConversionFactor { get; set; }
        public string? UnitBarcode { get; set; }
        public Nullable<UInt64> IsBaseUOM { get; set; }
        //ModuleValueExtension
        public decimal Price { get; set; }
        public Nullable<DateTime> StartEffectiveDate { get; set; }
        public Nullable<DateTime> EndEffectiveDate { get; set; }
        public Nullable<decimal> Different { get; set; }
        public Nullable<UInt64> SUN { get; set; }
        public Nullable<UInt64> MON { get; set; }
        public Nullable<UInt64> TUE { get; set; }
        public Nullable<UInt64> WED { get; set; }
        public Nullable<UInt64> THU { get; set; }
        public Nullable<UInt64> FRI { get; set; }
        public Nullable<UInt64> SAT { get; set; }
        public Nullable<TimeSpan> StartTime { get; set; }
        public Nullable<TimeSpan> EndTime { get; set; }
        public Nullable<UInt64> AllDay { get; set; }
        //ModeuleDependancy
        public string? BrandMasterId { get; set; } //from masterdata
        public string? ProductCategoryMasterId { get; set; } //from masterdata
        public string? StyleMasterId { get; set; } //from masterdata
        public string? DepartmentMasterId { get; set; } //from masterdata
        public string? SubCategoryMasterId { get; set; } //from masterdata
        public string? DefaultUnitTypeId { get; set; } // => ***** map with ModuleUnitConversion
    }

    public partial class ProductsModel
    {
        [JsonIgnore]
        public string? CLOUDSTOREID { get; set; }
        [JsonIgnore]
        public UInt64 Active { get; set; } = 1;
        [JsonIgnore]
        public UInt64 updaterow { get; set; } = 0;
        public UInt64 Removed{ get; set; } = 0;
        public Nullable<DateTime> RetrievedDate { get; set; }// = DateTime.UtcNow.Date;
        public Nullable<Int64> xcartId { get; set; }
        public string? Parent { get; set; }
        public void RetieveSet()
        {
            this.RetrievedDate = DateTime.Now;
        }
    }

    public class RemovedProductList
    {
        public string tenant { get; set; }
        public string ModuleId { get; set; }
        //public string clouadstoreid { get; set; }
    }

    #region TMP
    public class XCartMiddleModel
    {
        public string Tenant { get; set; }

        public string ModuleId { get; set; }
        public string ModuleVariantId { get; set; }
        public string moduleValueId { get; set; }
        public string ModuleValueExtensionId { get; set; }
        public string ModuleUnitConversionId { get; set; }
        public string ModuleUsageId { get; set; }
        //Module
        public string ModuleCode { get; set; }
        public string ModuleFirstName { get; set; }
        //ModuleInformation
        //public bool IsPointsExempt { get; set; }
        //public bool NotForResale { get; set; }
        //ModuleDependancy
        //public string BrandMasterId { get; set; }/*from masterdata*/
        public string ProductCategoryMasterId { get; set; }/*from masterdata*/
        public string SubCategoryMasterId { get; set; }/*from masterdata*/
        //public string DepartmentMasterId { get; set; }/*from masterdata*/
        //public string CostingMethodId { get; set; }/*systemtable [Specific Identification,First In, First Out,Last In, First Out,Average Cost]*/
        //public string StyleMasterId { get; set; }/*from masterdata*/
        public string DefaultUnitTypeId { get; set; }
        //ModuleVariant
        //public decimal Cost { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        //ModuleUsage
        //public string BinLocation { get; set; }
        public int MinOrderLevel { get; set; }
        public int MaxOrderLevel { get; set; }
        //public int ReOrderLevel { get; set; }
        public string UsageTypeSystemId { get; set; } /*systemtable [Retail,Professional]*/
        public bool IsDefault { get; set; }
        //ModuleUnitConversion
        public string UnitTypeId { get; set; }
        public string ConversionFactor { get; set; }
        public string IsBaseUOM { get; set; }
        //ModuleValueExtenion
        public string Price { get; set; }
        public string IsBasePrice { get; set; }
        public string StartEffectiveDate { get; set; }

        public bool Pushed { get; set; } = false;
        public DateTime RetrievedDate { get; set; } = DateTime.UtcNow.Date;

    }

    public class ProductVariantModel
    {
        public ProductVariantModel()
        {
            productunitconversion = new List<ProductUnitModel>();
        }

        public string ModuleVariantId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        //ModuleUsage
        public int MinOrderLevel { get; set; }
        public int MaxOrderLevel { get; set; }
        public bool IsDefault { get; set; }
        public List<ProductUnitModel> productunitconversion { get; set; }
    }

    public class ProductUnitModel
    {
        public string ModuleUnitConversionId { get; set; }
        public decimal SalesPrice { get; set; }
        public string IsBaseUOM { get; set; }
        public string UnitTypeId { get; set; } /*from msterdata*/
    }
    #endregion

    #region Category
    public class KBcategoryListModel
    {
        [Key]
        public Int64 ID { get; set; }
        public string tenant { get; set; }
        public string CLOUDSTOREID { get; set; }
        public string CategoryKey { get; set; }
        public string CatgoryDescription { get; set; }
        public UInt64 Active { get; set; } = 1;
        public UInt64 Removed { get; set; } = 0;
        public UInt64 Updated { get; set; } = 0;
        public string? NewValue { get; set; }
        public Nullable<Int64> CategoryId { get; set; }
    }
    public class XcartCategoryTranslationModel : ICloneable
    {
        public Int64 label_id { get; set; }
        [Key]
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 id { get; set; }
        public string name { get; set; }
        public string description { get; set; } = "";
        public string metaTags { get; set; } = "";
        public string metaDesc { get; set; } = "";
        public string metaTitle { get; set; } = "";
        public string code { get; set; } = "en";
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class XcartCategoriesModel
    {
        [Key]
        public Int64 category_id { get; set; }
        public Int64 parent_id { get; set; }
        public string ogMeta { get; set; } = "";
        public Boolean useCustomOG { get; set; } = false;
        public int csLastUpdate { get; set; } = 0;
        public Boolean demo { get; set; } = false;
        public string useClasses { get; set; } = "A";
        public int lpos { get; set; }
        public int rpos { get; set; }
        public Boolean enabled { get; set; } = true;
        public Boolean show_title { get; set; } = true;
        public int depth { get; set; } = 0;
        public int pos { get; set; }
        public string root_category_look { get; set; }
        public string metaDescType { get; set; } = "A";
        public Boolean xcPendingExport { get; set; } = true;

    }
    #endregion

    #region Products
    public class XcartProductTranslationModel
    {
        [Key]
        public Int64 label_id { get; set; }
        public Int64 id { get; set; }
        public string name { get; set; }
        public string description { get; set; } = "";
        public string briefDescription { get; set; } = "";
        public string metaTags { get; set; } = "";
        public string metaDesc { get; set; } = "";
        public string metaTitle { get; set; } = "";
        public string code { get; set; } = "en";
    }

    public partial class XcartProductsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 product_id { get; set; }
        public Nullable<int> product_class_id { get; set; }
        public Nullable<int> tax_class_id { get; set; }
        public string? ogMeta { get; set; }
        public Boolean useCustomOG { get; set; } = false;
        public Boolean participateSale { get; set; }=false;
        public string discountType { get; set; } = "sale_price";
        public decimal salePriceValue { get; set; } = 0;
        public int csLastUpdate { get; set; } = 0;
        public Boolean xcPendingBulkEdit { get; set; } = false;
        public Boolean freeShip { get; set; } = false;
        public Boolean shipForFree { get; set; }=false;
        public decimal freightFixedFee { get; set; }=0;
        public Boolean useAsSegmentCondition { get; set; } = false;
        public Boolean demo { get; set; } = false;
        public decimal price { get; set; }
        public string sku { get; set; }
        public Boolean enabled { get; set; } = true;
        public decimal weight { get; set; } = 0;
        public Boolean useSeparateBox { get; set; } = false;
        public decimal boxWidth { get; set; } =0;
        public decimal boxLength { get; set; } = 0;
        public decimal boxHeight { get; set; } = 0;
        public int itemsPerBox { get; set; } = 1;
        public Boolean free_shipping { get; set; } = false;
        public Boolean taxable { get; set; } = true;
        public string? javascript { get; set; }
        public long arrivalDate { get; set; } 
        public long date { get; set; }
        public long updateDate { get; set; }
        public Boolean needProcess { get; set; } = false;
        public Boolean inventoryEnabled { get; set; } = false;
        public int amount { get; set; }
        public Boolean lowLimitEnabledCustomer { get; set; } = false;
        public Boolean lowLimitEnabled { get; set; } = false;
        public int lowLimitAmount { get; set; } = 1;
        public Boolean attrSepTab { get; set; } = true;
        public string metaDescType { get; set; }="A";
        public int sales { get; set; } = 0;
        public Boolean xcPendingExport { get; set; } = false;
        public string entityVersion { get; set; } =Guid.NewGuid().ToString();
        public int rewardPoints { get; set; } = 0;
        public Boolean fixedRewardPoints { get; set; } = false;
    }

    public partial class XcartProductsModel
    {
        // CATEGORY
        public string categoryname { get; set; }
    }

    public class XcartCategoryProductModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 id { get; set; }
        public Int64 category_id { get; set; }
        public Int64 product_id { get; set; }
        public int orderby { get; set; } = 0;
        public int orderbyInProduct { get; set; } = 0;
    }

    public class Attribute_translations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 label_id { get; set; }
        public Int64 id { get; set; }
        public string name { get; set; }
        public string unit { get; set; } = "";
        public string code { get; set; } = "en";
    }

    public class Attributes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 id { get; set; }
        public Nullable<UInt32> product_class_id { get; set; }
        public Nullable<UInt32> attribute_group_id { get; set; }
        public Int64 product_id { get; set; }
        public Boolean visible { get; set; } = true;
        public int position { get; set; } = 0;
        public int decimals { get; set; } = 0;
        public string type { get; set; } = "S";
        public string addToNew { get; set; } = "";
    }

    public class Attribute_option_translations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 label_id { get; set; }
        public Int64 id { get; set; }
        public string name { get; set; }
        public string code { get; set; } = "en";
    }

    public class Attribute_options
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 id { get; set; }
        public Int64 attribute_id { get; set; }
        public Boolean addToNew { get; set; } = false;
        public int position { get; set; }
    }

    public class Attribute_values_select
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 id { get; set; }
        public Int64 attribute_option_id { get; set; }
        public Int64 product_id { get; set; }
        public Int64 attribute_id { get; set; }
        public Int64 position { get; set; }
        public decimal priceModifier { get; set; } = 0;
        public string priceModifierType { get; set; } = "a";
        public decimal weightModifier { get; set; } = 0;
        public string weightModifierType { get; set; } = "a";
        public Boolean defaultValue { get; set; } = false;
    }

    #endregion

}
