using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common
{
    public class ProductListingViewModel
    {
        public decimal Cost { get; set; } = 0;
        public string Sku { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Quantity { get; set; } = 0;
        public string UnitTypeId { get; set; }
        public decimal DiscountPercentage { get; set; } = 0;
        public decimal RegularPrice { get; set; } = 0;
        public decimal DiscountValue { get; set; } = 0;
        public decimal ConversionFactor { get; set; }
        public string TXNID { get; set; }
        public UInt64 IsPosted { get; set; }
        public string GRNStatusId { get; set; }
        public string ModuleId { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

    public class InventoryCategoryDetails
    {
        public string ModuleId { get; set; }
        public string ModuleFirstName { get; set; }
        public string ModuleCode { get; set; }
        public string BrandMasterId { get; set; }
        public string ProductCategoryMasterId { get; set; }
        public string StyleMasterId { get; set; }
        public string DepartmentMasterId { get; set; }
        public string SubCategoryMasterId { get; set; }
        public string DefaultUnitTypeId { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; } = 0;
        public DateTime StartEffectiveDate { get; set; }
        public DateTime? EndEffectiveDate { get; set; }
    }
    public class StockInventoryReportViewModel
    {
        public string ModuleId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        //public string Supplier { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        //public string SubCategory { get; set; }
        //public string Style { get; set; }
        //public string Department { get; set; }
        //public string Sku { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal OnHand { get; set; } = 0;
        //public decimal Min { get; set; }
        //public decimal Max { get; set; }
        //public decimal Cost { get; set; } = 0;
        //public decimal AverageCost { get; set; }
        //public decimal CostOfGoodsOnHand { get; set; }
        public decimal PriceOfGoodsOnHand { get; set; }
    }

    public class StockInventoryReportMainViewModel
    {
        public List<StockInventoryReportViewModel> ProductList { get; set; } = new List<StockInventoryReportViewModel>();
        public decimal TotalOnHand { get; set; }
        //public decimal CostOfGoodsOnHand { get; set; }
        public decimal PriceOfGoodsOnHand { get; set; }
    }

    //public class AverageCostPerItem
    //{
    //    public string ModuleId { get; set; }
    //    public string UnitTypeId { get; set; }
    //    public string TAXNID { get; set; }
    //    public decimal Cost { get; set; } = 0;
    //    public decimal Count { get; set; } = 0;
    //}


    public class ProductListingQuantityViewModel
    {
        public string ModuleId { get; set; }
        public decimal Quantity { get; set; } = 0;
        //public decimal Cost { get; set; } = 0;
        public string VariantName { get; set; }
        public string ProductName { get; set; }
    }

}
