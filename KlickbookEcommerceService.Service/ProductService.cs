using KlickbookEcommerceService._helper;
using KlickbookEcommerceService.Common;
//using KlickbookEcommerceService.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
//using static KlickbookEcommerceService.Service.ProductService;


namespace KlickbookEcommerceService.Service
{

    public interface IProductService 
    {
        StockInventoryReportMainViewModel ProductListing(string tenant, DateTime date);

        List<ProductsModel> ProductList(string tenant, DateTime date);
        List<RemovedProductList> RemovedProductList(string tenant, DateTime date);

        List<ProductsModel> VariantList(string tenant, DateTime date);
        List<ProductsModel> UnitsList(string tenant, DateTime date);
   
    }

    public class ProductService : IProductService
    {
        //private readonly IServiceScopeFactory _scopeFactory;
        protected readonly MilanoBusinessContextService _context;
        protected readonly ITenantService _tenantService;
        protected readonly IMasterDataService _masterDataService;

        public ProductService(
            //IServiceScopeFactory scopeFactory, 
            ITenantService tenantService, 
            IMasterDataService masterDataService, 
            MilanoBusinessContextService milanoBusinessContextService
            )
        {
            _masterDataService = masterDataService;
            _tenantService = tenantService;
            _context = milanoBusinessContextService;

            //_scopeFactory = scopeFactory;
        }

        public StockInventoryReportMainViewModel ProductListing( string tenant, DateTime date )
        {
            try
            {
                #region without date concideration
                List<ProductListingViewModel> rawProductList = _context.ExecSQL<ProductListingViewModel>($@"
                select F.Cost,F.Sku,E.CreatedOn,E.Quantity,E.UnitTypeId,E.DiscountPercentage,E.RegularPrice,E.DiscountValue,E.ConversionFactor,E.TXNID,E.IsPosted,C.GRNStatusId,E.VariantId,F.ModuleId,B.DeliveryDate from module A
                left join moduleinformation B on A.ModuleId=B.ModuleId
                left join moduledependency C on A.ModuleId=C.ModuleId
                left join modulerelation D on A.ModuleId = D.ModuleId
                left join modulerelationextension E on D.ModuleRelationId = E.ModuleRelationId
                left join modulevariant F on F.ModuleVariantId=E.VariantId
                where  /* A.CreatedOn <= {date} and */  C.GRNStatusId='537799cd-8238-41f2-a2a1-8053fa6b47dc' and A.ModuleTypeSystemId='43fc6f3d-eaf2-40e9-8c79-aa7039dc3c43' and A.Tenant='{tenant}' and E.Quantity is not null;");

                List<ProductListingQuantityViewModel> rawProductQuantity = _context.ExecSQL<ProductListingQuantityViewModel>($@"select C.Cost,C.ModuleId,sum(B.QuantityChange) as Quantity,C.Name as VariantName,D.ModuleFirstName as ProductName from modulestockadjustment A 
                left join modulestockchange B on A.StockAdjustmentId = B.StockAdjustmentId
                left join modulevariant C on B.VariantId = C.ModuleVariantId
                left join module D on C.ModuleId = D.ModuleId
                where A.Tenant='{tenant}' and B.VariantId is not null and /* A.CreatedOn <='{date.ToStringSyntax()}' and */ A.StockStatusId  != '2719bee6-e273-4ca6-8103-9576dbb69a32'
                group by C.Cost,C.ModuleId,C.Name,D.ModuleFirstName;");

                List<InventoryCategoryDetails> rawInventoryCategoryDetails = _context.ExecSQL<InventoryCategoryDetails>($@"select D.ModuleId,D.ModuleFirstName,D.ModuleCode,E.BrandMasterId,E.ProductCategoryMasterId,E.StyleMasterId,E.DepartmentMasterId,E.SubCategoryMasterId,E.DefaultUnitTypeId,A.BarCode,C.Price,C.StartEffectiveDate,C.EndEffectiveDate from moduleunitconversion A
                left join modulevalue B on A.ModuleId=B.ModuleId
                left join modulevalueextension C on B.ModuleValueId=C.ModuleValueId /*and C.CreatedOn<='{date.ToStringSyntax()}'  */
                and (/*C.EndEffectiveDate<='{date.ToStringSyntax()}' or */ C.EndEffectiveDate is null)
                left join module D on A.ModuleId=D.ModuleId
                left join moduledependency E on D.ModuleId=E.ModuleId
                where A.Tenant='{tenant}'
                order by D.ModuleId,C.StartEffectiveDate;");
                #endregion

                #region with date concideration
                //                List<ProductListingViewModel> rawProductList = _context.ExecSQL<ProductListingViewModel>($@"
                //select F.Cost,F.Sku,E.CreatedOn,E.Quantity,E.UnitTypeId,E.DiscountPercentage,E.RegularPrice,E.DiscountValue,E.ConversionFactor,E.TXNID,E.IsPosted,C.GRNStatusId,E.VariantId,F.ModuleId,B.DeliveryDate from module A
                //left join moduleinformation B on A.ModuleId=B.ModuleId
                //left join moduledependency C on A.ModuleId=C.ModuleId
                //left join modulerelation D on A.ModuleId = D.ModuleId
                //left join modulerelationextension E on D.ModuleRelationId = E.ModuleRelationId
                //left join modulevariant F on F.ModuleVariantId=E.VariantId
                //where  A.CreatedOn <= '{date}' and C.GRNStatusId='537799cd-8238-41f2-a2a1-8053fa6b47dc' and A.ModuleTypeSystemId='43fc6f3d-eaf2-40e9-8c79-aa7039dc3c43' and A.Tenant='{tenant}' and E.Quantity is not null;");

                //                List<ProductListingQuantityViewModel> rawProductQuantity = _context.ExecSQL<ProductListingQuantityViewModel>($@"
                //select C.Cost,C.ModuleId,sum(B.QuantityChange) as Quantity,C.Name as VariantName,D.ModuleFirstName as ProductName from modulestockadjustment A 
                //left join modulestockchange B on A.StockAdjustmentId = B.StockAdjustmentId
                //left join modulevariant C on B.VariantId = C.ModuleVariantId
                //left join module D on C.ModuleId = D.ModuleId
                //where A.Tenant='{tenant}' and B.VariantId is not null and  A.CreatedOn <='{date}' and A.StockStatusId  != '2719bee6-e273-4ca6-8103-9576dbb69a32'
                //group by C.Cost,C.ModuleId,C.Name,D.ModuleFirstName;
                //            ");

                //                List<InventoryCategoryDetails> rawInventoryCategoryDetails = _context.ExecSQL<InventoryCategoryDetails>($@"
                //select D.ModuleId,D.ModuleFirstName,D.ModuleCode,E.BrandMasterId,E.ProductCategoryMasterId,E.StyleMasterId,E.DepartmentMasterId,E.SubCategoryMasterId,E.DefaultUnitTypeId,A.BarCode,C.Price,C.StartEffectiveDate,C.EndEffectiveDate from moduleunitconversion A
                //left join modulevalue B on A.ModuleId=B.ModuleId
                //left join modulevalueextension C on B.ModuleValueId=C.ModuleValueId and C.CreatedOn<='{date}'  
                //and (C.EndEffectiveDate<='{date}' or C.EndEffectiveDate is null)
                //left join module D on A.ModuleId=D.ModuleId
                //left join moduledependency E on D.ModuleId=E.ModuleId
                //where A.Tenant='{tenant}'
                //order by D.ModuleId,C.StartEffectiveDate;");
                #endregion

                var masterDataCategory = _masterDataService.GetTableDataByTenant(tenant, "ProductCategory");

                var masterDataBrand = _masterDataService.GetTableDataByTenant(tenant, "ProductBrand");

                List<StockInventoryReportViewModel> stockInventoryReportList = new List<StockInventoryReportViewModel>();

                foreach (var item in rawProductQuantity)
                {
                    if (stockInventoryReportList.Where(x => x.ModuleId == item.ModuleId).FirstOrDefault() == null)
                    {
                        var tempProduct = rawInventoryCategoryDetails.Where(x => x.ModuleId == item.ModuleId).FirstOrDefault();
                        decimal Price = 0;
                        var quantityProduct = rawProductQuantity.Where(x => x.ModuleId == item.ModuleId).FirstOrDefault();
                        //var product = rawProductList.Where(x => x.ModuleId == item.ModuleId).FirstOrDefault();
                        var priceList = rawInventoryCategoryDetails.Where(x => x.ModuleId == item.ModuleId).ToList().OrderByDescending(x => x.StartEffectiveDate).ToList();
                        if (priceList.Count > 0)
                        {
                            if (priceList[0].EndEffectiveDate == null)
                            {
                                Price = priceList[0].Price;
                            }
                            else
                            {
                                DateTime checkedDate = priceList[priceList.Count - 1].StartEffectiveDate;
                                Price = priceList[priceList.Count - 1].Price;
                                foreach (var filterPrice in priceList)
                                {
                                    if (filterPrice.StartEffectiveDate > checkedDate && (filterPrice.EndEffectiveDate == null || filterPrice.EndEffectiveDate > checkedDate))
                                    {
                                        Price = filterPrice.Price;
                                    }

                                }
                            }

                        }
                        StockInventoryReportViewModel temp = new StockInventoryReportViewModel()
                        {
                            //AverageCost = item.Cost,
                            Brand = masterDataBrand != null ? masterDataBrand.data.Where(x => x.Key == tempProduct.BrandMasterId).FirstOrDefault() != null ? masterDataBrand.data.Where(x => x.Key == tempProduct.BrandMasterId).FirstOrDefault().Description : "" : null,
                            Category = masterDataCategory != null ? masterDataCategory.data.Where(x => x.Key == tempProduct.ProductCategoryMasterId).FirstOrDefault() != null ? masterDataCategory.data.Where(x => x.Key == tempProduct.ProductCategoryMasterId).FirstOrDefault().Description : "" : null,
                            //Style = tempProduct.StyleMasterId,
                            //Department = tempProduct.DepartmentMasterId,
                            //SubCategory = tempProduct.SubCategoryMasterId,                        
                            Code = tempProduct.ModuleCode,
                            //Cost = item.Cost,
                            Description = tempProduct.ModuleFirstName,
                            OnHand = quantityProduct != null ? quantityProduct.Quantity : 0,
                            //Sku = product!=null?product.Sku:"",
                            ModuleId = item.ModuleId,
                            Price = Price
                        };

                        //temp.CostOfGoodsOnHand = temp.Cost * temp.OnHand;
                        temp.PriceOfGoodsOnHand = temp.Price * temp.OnHand;
                        stockInventoryReportList.Add(temp);
                    }

                }
                if (stockInventoryReportList.Count > 0)
                {
                    StockInventoryReportMainViewModel response = new StockInventoryReportMainViewModel
                    {
                        ProductList = stockInventoryReportList.OrderBy(x => x.Code).ToList(),
                        //CostOfGoodsOnHand = stockInventoryReportList.Sum(x => x.CostOfGoodsOnHand),
                        PriceOfGoodsOnHand = stockInventoryReportList.Sum(x => x.PriceOfGoodsOnHand),
                        TotalOnHand = stockInventoryReportList.Sum(x => x.OnHand)
                    };

                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ProductsModel> ProductList(string tenant, DateTime date)
        {
            try
            {
                List<ProductsModel> productlist = _context.ExecSQL<ProductsModel>($@"
                select M.tenant,M.ModuleId,(IF(M.UpdatedOn is not null,M.UpdatedOn,M.CreatedOn)) as ModuleUpdate,M.ModuleCode,M.ModuleFirstName,
                var.Name as VariantName,var.Barcode as VariantBarcode,var.Sku as VariantSku,var.CustomizeUnit,
                unit.UnitTypeId,unit.ConversionFactor,unit.BarCode as UnitBarcode,unit.IsBaseUOM,
                valext.Price,valext.StartEffectiveDate ,valext.EndEffectiveDate ,valext.Different ,valext.SUN,valext.MON,valext.TUE,valext.WED,valext.THU,valext.FRI,valext.SAT,valext.StartTime,valext.EndTime,valext.AllDay,
                D.BrandMasterId,D.ProductCategoryMasterId,D.StyleMasterId,D.DepartmentMasterId,D.SubCategoryMasterId,D.DefaultUnitTypeId
                    from module M
                        join moduleinformation info on M.ModuleId = info.ModuleId
                        left join modulevariant var on M.ModuleId = var.ModuleId and var.RowStatusSystemId='3afa800d-5eed-4c26-aa7b-afaf69ced3de'
                        left join moduleunitconversion unit on unit.ModuleId = var.ModuleId and unit.RowStatusSystemId='3afa800d-5eed-4c26-aa7b-afaf69ced3de'
                        left join modulevalueextension valext on M.ModuleId = valext.ModuleId and valext.UnitTypeId = unit.UnitTypeId and valext.RowStatusSystemId='3afa800d-5eed-4c26-aa7b-afaf69ced3de'
                        left join moduledependency D on D.ModuleId = M.ModuleId and D.RowStatusSystemId='3afa800d-5eed-4c26-aa7b-afaf69ced3de'
                            where M.Tenant = '{tenant}'
	                            and M.ModuleTypeSystemId = 'd2430ce9-780f-42c6-8aba-b46de089b3a3'     /* Product */
                                and M.RowStatusSystemId='3afa800d-5eed-4c26-aa7b-afaf69ced3de'
                                and (var.NotForSale is null or var.NotForSale = 0)
                                and (info.NotForResale is null or info.NotForResale = 0)
                                and (info.OnlyForMembers is null or info.OnlyForMembers = 0)
                                and (var.MembersOnly is null or var.MembersOnly = 0)
                                and valext.Price > 0
                                and valext.StartEffectiveDate <= '{date.ToStringSyntax()}'
                                and (if(valext.EndEffectiveDate is not null,valext.EndEffectiveDate >= '{date.ToStringSyntax()}',true))");

                //List<ProductsModel> productquantity = _context.ExecSQL<ProductsModel>(@$"select C.ModuleId,sum(B.QuantityChange) as Quantity,C.Name as VariantName,D.ModuleFirstName as ProductName 
                //    from modulestockadjustment A 
                //        left join modulestockchange B on A.StockAdjustmentId = B.StockAdjustmentId
                //        left join modulevariant C on B.VariantId = C.ModuleVariantId
                //        left join module D on C.ModuleId = D.ModuleId
                //            where A.Tenant = '{tenant}'
                //             /* and B.VariantId is not null */
                //                and A.StockStatusId  != '2719bee6-e273-4ca6-8103-9576dbb69a32'
                //                 group by C.Cost,C.ModuleId,C.Name,D.ModuleFirstName;");


                var ProductCategoryMasterId = _masterDataService.GetTableDataByTenant(tenant, "ProductCategory");
                var UnitTypeId = _masterDataService.GetTableDataByTenant(tenant, "ProductUOM");
                var BrandMasterId = _masterDataService.GetTableDataByTenant(tenant, "ProductBrand");
                var SubCategoryMasterId = _masterDataService.GetTableDataByTenant(tenant, "ProductSubCategory");
                var DepartmentMasterId = _masterDataService.GetTableDataByTenant(tenant, "ProductDepartment");
                var StyleMasterId = _masterDataService.GetTableDataByTenant(tenant, "ProductStyle");

                Parallel.ForEach(productlist, item =>
                {
                    if (item.ProductCategoryMasterId != null)
                    {
                        var desc = ProductCategoryMasterId.data.FirstOrDefault(key => key.Key.Equals(item.ProductCategoryMasterId));
                        if (desc != null)
                            item.ProductCategoryMasterId = desc.Description;
                    }

                    if (item.UnitTypeId != null)
                    {
                        var desc = UnitTypeId.data.FirstOrDefault(key => key.Key.Equals(item.UnitTypeId));
                        if (desc != null)
                            item.UnitTypeId = desc.Description;
                    }

                    if (item.DefaultUnitTypeId != null)
                    {
                        var desc = UnitTypeId.data.FirstOrDefault(key => key.Key.Equals(item.DefaultUnitTypeId));
                        if (desc != null)
                            item.DefaultUnitTypeId = desc.Description;
                    }

                    if (item.BrandMasterId != null)
                    {
                        var desc = BrandMasterId.data.FirstOrDefault(key => key.Key.Equals(item.BrandMasterId));
                        if (desc != null)
                            item.BrandMasterId = desc.Description;
                    }

                    if (item.SubCategoryMasterId != null)
                    {
                        var desc = SubCategoryMasterId.data.FirstOrDefault(key => key.Key.Equals(item.SubCategoryMasterId));
                        if (desc != null)
                            item.SubCategoryMasterId = desc.Description;
                    }

                    if (item.DepartmentMasterId != null)
                    {
                        var desc = DepartmentMasterId.data.FirstOrDefault(key => key.Key.Equals(item.DepartmentMasterId));
                        if (desc != null)
                            item.DepartmentMasterId = desc.Description;
                    }

                    if (item.StyleMasterId != null)
                    {
                        var desc = StyleMasterId.data.FirstOrDefault(key => key.Key.Equals(item.StyleMasterId));
                        if (desc != null)
                            item.StyleMasterId = desc.Description;
                    }
                });


                if (productlist.Count > 0)
                    return productlist;

                throw new AppException("With the provided info, list is empty.", StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<RemovedProductList> RemovedProductList(string tenant, DateTime date)
        {
            try
            {
                List<RemovedProductList> productremovedlist = _context.ExecSQL<RemovedProductList>($@"
                select M.tenant,M.ModuleId
                    from module M
                            where M.Tenant = '{tenant}'
	                            and M.ModuleTypeSystemId = 'd2430ce9-780f-42c6-8aba-b46de089b3a3'     /* Product */
                                and M.RowStatusSystemId='a01f0845-1468-49b3-8b3c-c1aea90d1ff5' /*removed*/ ;");

                if (productremovedlist.Count > 0)
                    return productremovedlist;

                throw new AppException("With the provided info, list is empty.", StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<ProductsModel> VariantList(string tenant, DateTime date)
        {
            try
            {
              //  List<ProductsModel> productlist = _context.ExecSQL<ProductsModel>($@"
              //  select M.Tenant,M.ModuleId,M.ModuleCode,M.ModuleFirstName, D.ProductCategoryMasterId,D.SubCategoryMasterId,D.DefaultUnitTypeId
              //  from module M
		            //join moduledependency D on M.ModuleId = D.ModuleId
			           // where M.tenant = '{tenant}' 
				          //  and M.ModuleTypeSystemId = 'd2430ce9-780f-42c6-8aba-b46de089b3a3' /* Product */
				          //  and M.RowStatusSystemId = '3afa800d-5eed-4c26-aa7b-afaf69ced3de'
              //              and D.RowStatusSystemId = '3afa800d-5eed-4c26-aa7b-afaf69ced3de'
              //              and (if(M.UpdatedOn is null, M.CreatedOn > '{date.ToStringSyntax()}',M.UpdatedOn > '{date.ToStringSyntax()}'))");

              //  if (productlist.Count > 0)
              //      return productlist;




                throw new AppException(StatusCodes.Status500InternalServerError.ToString(), "With the provided info, list is empty.");
                //throw new ArgumentNullException("With the provided info, list is empty.");
                //throw new Exception("With the provided info, list is empty.");
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<ProductsModel> UnitsList(string tenant, DateTime date)
        {
            try
            {
              //  List<ProductsModel> productlist = _context.ExecSQL<ProductsModel>($@"
              //  select M.Tenant,M.ModuleId,M.ModuleCode,M.ModuleFirstName, D.ProductCategoryMasterId,D.SubCategoryMasterId,D.DefaultUnitTypeId
              //  from module M
		            //join moduledependency D on M.ModuleId = D.ModuleId
			           // where M.tenant = '{tenant}' 
				          //  and M.ModuleTypeSystemId = 'd2430ce9-780f-42c6-8aba-b46de089b3a3' /* Product */
				          //  and M.RowStatusSystemId = '3afa800d-5eed-4c26-aa7b-afaf69ced3de'
              //              and D.RowStatusSystemId = '3afa800d-5eed-4c26-aa7b-afaf69ced3de'
              //              and (if(M.UpdatedOn is null, M.CreatedOn > '{date.ToStringSyntax()}',M.UpdatedOn > '{date.ToStringSyntax()}'))");

                //if (productlist.Count > 0)
                //    return productlist;




                throw new AppException(StatusCodes.Status500InternalServerError.ToString(), "With the provided info, list is empty.");
                //throw new ArgumentNullException("With the provided info, list is empty.");
                //throw new Exception("With the provided info, list is empty.");
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }

}
