using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlickbookEcommerceService.Common.Model.ExternalRelation;
using Newtonsoft.Json;

namespace KlickbookEcommerceService.Common.Model
{
    public class BaseObject : ICloneable
    {
        public virtual string creator { get; set; }
        public virtual DateTime createdate { get; set; }
        public virtual string modifier { get; set; }
        public virtual DateTime modifydate { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class CoreObject : ICloneable
    {

        public virtual DateTime? CreatedOn { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime? UpdatedOn { get; set; }

        public virtual string? UpdatedBy { get; set; }

        public virtual string? RowStatusSystemId { get; set; }

        public virtual string Tenant { get; set; }
        [JsonIgnore]
        public virtual byte[]? RowSignature { get; set; }
        [JsonIgnore]
        public virtual byte[]? RowVersion { get; set; } 

        public void Creator(string PCreartor)
        {
            this.CreatedBy = PCreartor;
            this.CreatedOn = DateTime.Now;
        }
        public void Modifier(string PModifier)
        {
            this.UpdatedBy = PModifier;
            this.UpdatedOn = DateTime.Now;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    
    public partial class Module : CoreObject
    {
        public static string MyEntityName { get { return "Module"; } }
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int64 ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, Tenant }; } }

        public string? ParentId { get; set; }
   
        [Key]
        public string ModuleId { get; set; }
        public override string Tenant { get; set; }

        public string? ModuleCode { get; set; }

        public string? ModuleFirstName { get; set; }

        public string? ModuleSecondName { get; set; }

        public string? ModuleTypeSystemId { get; set; }
        [NotMapped]

        public Nullable<bool> IsActive { get; set; }

        public string? Comment { get; set; }

        public string? CreatedTenantId { get; set; }

        public Nullable<int> Priority { get; set; }
    }
    
    public partial class ModuleInvoice : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInvoice"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleInvoiceId }; } }

        [NotMapped]
        public decimal ID { get; set; }

        [Key]
        public string ModuleInvoiceId { get; set; }

        public string ModuleId { get; set; }

        public string PaymentMode { get; set; }

        public string InvoiceType { get; set; }

        public string TransactionType { get; set; }

        public string TransactionCode { get; set; }

        public string Currency { get; set; }

        public string DiscountType { get; set; }

        public Nullable<decimal> Discount { get; set; }

        public Nullable<decimal> GrandTotal { get; set; }

        public Nullable<decimal> TotalAmount { get; set; }

        public Nullable<decimal> Tax { get; set; }

        public Nullable<System.DateTime> InvoiceDate { get; set; }

        public string ReasonForDiscount { get; set; }

        public Nullable<bool> IsSpotDiscount { get; set; }

        public string CashierId { get; set; }

        public string BillDiscountPromotionId { get; set; }

        public string LoyaltyPointsPromotionId { get; set; }

        public string UserTillSessionId { get; set; }

        public string ClientId { get; set; }

        public string ReasonForHold { get; set; }

        public string OriginalInvoiceId { get; set; }

        public Nullable<decimal> LayawayPaidTotal { get; set; }

        public Nullable<decimal> LayawayGrandTotal { get; set; }

        public Nullable<decimal> LayawayTotalAmount { get; set; }

        public Nullable<decimal> LayawayTax { get; set; }

        public Nullable<DateTime> ExpiryDateForHold { get; set; }

        public Nullable<decimal> BillDiscountAmount { get; set; }

        public Nullable<decimal> PromotionalOfferAmount { get; set; }

        public Nullable<decimal> SubtotalAmount { get; set; }

        public string PromotionName { get; set; }

        public string PromotionCode { get; set; }

        public Nullable<bool> Nonrefundable { get; set; }

        public Nullable<decimal> FullDiscount { get; set; }

        public Nullable<decimal> FullPromotionAmount { get; set; }
        public Nullable<bool> Settled { get; set; }
        public string SettledInvoiceId { get; set; }
        public string VoyageId { get; set; }
        public string VoyageName { get; set; }
        public string VoyageCode { get; set; }
        public string VoyagePortId { get; set; }
        public string VoyagePortName { get; set; }
    }
    
    public partial class ModuleInvoiceDetail : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInvoiceDetail"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleInvoiceDetailId }; } }

        [NotMapped]
        public decimal ID { get; set; }

        public string ModuleInvoiceId { get; set; }

        [Key]
        public string ModuleInvoiceDetailId { get; set; }

        public string TargetModuleId { get; set; }

        public string Currency { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public string DiscountType { get; set; }

        public Nullable<decimal> Discount { get; set; }

        public string ReasonForDiscount { get; set; }

        public Nullable<decimal> Quantity { get; set; }

        public Nullable<decimal> Price { get; set; }

        public string VariantId { get; set; }

        public string UOMId { get; set; }

        public string FootprintId { get; set; }

        public Nullable<decimal> Tax { get; set; }

        public string ResourceId { get; set; }

        public string PromotionalOfferId { get; set; }

        public string MiscellaneousMasterId { get; set; }

        public string ModuleTypeSystemId { get; set; }

        public string OriginalInvoiceDetailId { get; set; }

        public Nullable<decimal> PaidAmount { get; set; }

        public Nullable<decimal> BillTax { get; set; }

        public Nullable<decimal> PromotionalOfferAmount { get; set; }

        public string AppointmentId { get; set; }

        public string CouponOfferId { get; set; }

        public Nullable<decimal> CouponOfferAmount { get; set; }

        public Nullable<int> Series { get; set; }

        public Nullable<int> MinimumIntervalGap { get; set; }

        public Nullable<int> FrequencyLimit { get; set; }

        public string FrequencyType { get; set; }

        public string MinimumIntervalType { get; set; }

        public string TimeLineType { get; set; }

        public int? StaffEarnedPoints { get; set; }

        public int? CustomerEarnedPoints { get; set; }

        public string AppointmentInvoiceDetailId { get; set; }

        public Nullable<decimal> ActualAmount { get; set; }

        public Nullable<decimal> ActualTax { get; set; }

        public Nullable<decimal> CommissionAmount { get; set; }

        public string AppointmentInvoiceItemDetailId { get; set; }

        public Nullable<decimal> UOMConvFactor { get; set; }

        public string ItemName { get; set; }

        public string ItemCode { get; set; }

        public string VariantName { get; set; }

        public string UOMName { get; set; }

        public string FootprintName { get; set; }

        public string PromotionName { get; set; }

        public string PromotionCode { get; set; }

        public string CouponCode { get; set; }

        public string CouponName { get; set; }

        public Nullable<bool> Nonrefundable { get; set; }

        public string ResourceName { get; set; }

        public Nullable<bool> Refunded { get; set; }

        public string UsageTypeId { get; set; }

        public Nullable<decimal> FullPrice { get; set; }

        public Nullable<decimal> FullDiscount { get; set; }

        public Nullable<bool> PrepaidOrder { get; set; }
        public Nullable<bool> PrepaidUsed { get; set; }
        public Nullable<decimal> FullPromotion { get; set; }
        public Nullable<decimal> FullCoupon { get; set; }
        public Nullable<decimal> PrepaidPrice { get; set; }
        public Nullable<decimal> PrepaidUsedAmount { get; set; }
        public Nullable<bool> DynamicFee { get; set; }
        public string PrepaidInvoiceDetailId { get; set; }
        public string SecondaryName { get; set; }
        public string AutoGratuityId { get; set; }
        public Nullable<decimal> AutoGratuityValue { get; set; }
        public Nullable<bool> AutoGratuityFixed { get; set; }
        public Nullable<bool> AutoGratuityEach { get; set; }
        public Nullable<decimal> AutoGratuityAmount { get; set; }
        public Nullable<decimal> AutoGratuityTax { get; set; }
    }

    public partial class ModuleInvoiceItemDetail : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInvoiceItemDetail"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleInvoiceItemDetailId }; } }

        [NotMapped]
        public decimal ID { get; set; }

        public string ModuleInvoiceDetailId { get; set; }

        [Key]
        public string ModuleInvoiceItemDetailId { get; set; }

        public string ModuleTypeSystemId { get; set; }

        public string TargetModuleId { get; set; }

        public string ServiceId { get; set; }

        public string PackageId { get; set; }

        public string VariantId { get; set; }

        public string FootPrintId { get; set; }

        public string ServiceRoleId { get; set; }

        public string ResourceId { get; set; }

        public Nullable<System.DateTime> StartDateTime { get; set; }

        public Nullable<System.DateTime> EndDateTime { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public Nullable<decimal> Tax { get; set; }

        public string ModuleItemStatus { get; set; }

        public Nullable<decimal> ModuleItemValue { get; set; }

        public string ModuleItemNumber { get; set; }

        public Nullable<System.DateTime> ExpiryDate { get; set; }

        public string OldItemNumber { get; set; }

        public Nullable<System.DateTime> OldExpiryDate { get; set; }

        public string ClientId { get; set; }

        public string UnitTypeId { get; set; }

        public int? Quantity { get; set; }

        public int? DisplayOrder { get; set; }

        public int? TimeDelay { get; set; }

        public string ResourceTypeId { get; set; }

        public string PointsTypeId { get; set; }

        public string CommissionTypeId { get; set; }

        public int? PointsValue { get; set; }

        public decimal? CommissionPercentage { get; set; }

        public decimal? CommissionFixedAmount { get; set; }

        public int? StaffEarnedPoints { get; set; }

        public decimal? Ratio { get; set; }

        public decimal? UOMConvFactor { get; set; }

        public string ItemName { get; set; }

        public string ItemCode { get; set; }

        public string FootprintName { get; set; }

        public string UOMName { get; set; }

        public decimal? TaxPercentage { get; set; }

        public string ResourceName { get; set; }

        public string VariantName { get; set; }

        public string UsageTypeId { get; set; }

        public decimal? CommissionAmount { get; set; }

        public decimal? CommissionExtra { get; set; }

        public bool? Cancelled { get; set; }

        [NotMapped]
        public string updateTargetId { get; set; }
    }
    
    public partial class ModuleInvoicePaymentReceipt : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInvoicePaymentReceipt"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { PaymentReceiptId }; } }

        [NotMapped]
        public decimal ID { get; set; }

        [Key]
        public string PaymentReceiptId { get; set; }

        public string ModuleInvoiceID { get; set; }

        public string ReceiptNumber { get; set; }

        public string CurrencyId { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public Nullable<decimal> OrderTotal { get; set; }

        public Nullable<decimal> AmountPaid { get; set; }

        public Nullable<decimal> Balance { get; set; }

        public Nullable<decimal> DonationAmount { get; set; }

        public Nullable<decimal> GratuityAmount { get; set; }

        public Nullable<decimal> AutoGratuityTotal { get; set; }

        public Nullable<decimal> ReturnBackAmount { get; set; }

        public Nullable<int> EarnedPoints { get; set; }

        public string ClientId { get; set; }

        public Nullable<decimal> TaxTotal { get; set; }

    }

    public partial class ModuleInvoicePaymentReceiptDetail : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInvoicePaymentReceiptDetail"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { PaymentReceiptDetailId }; } }

        [NotMapped]
        public decimal ID { get; set; }

        [Key]
        public string PaymentReceiptDetailId { get; set; }

        public string PaymentReceiptId { get; set; }

        public string CurrencyId { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public string TenderTypeId { get; set; }

        public string TenderTypeModuleId { get; set; }

        public string GiftCardNo { get; set; }

        public string ClientId { get; set; }

        public string ChequeNo { get; set; }

        public Nullable<int> UsedPoints { get; set; }

        public string Notes { get; set; }
    }
    
    public partial class ModuleInvoicePaymentOther : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInvoicePaymentOther"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleInvoicePaymentOtherId }; } }

        [NotMapped]
        public decimal ID { get; set; }

        [Key]
        public string ModuleInvoicePaymentOtherId { get; set; }

        public string PaymentReceiptId { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public string StaffId { get; set; }

        public string OrganizationMasterId { get; set; }

        public string ClientId { get; set; }

        public string ChangeReturnTypeSystemId { get; set; }

        public string ChangeReturnTypeModuleId { get; set; }

    }

    public partial class ModuleValue : CoreObject
    {
        public static string MyEntityName { get { return "ModuleValue"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleValueId, Tenant }; } }
        [Key]
        public string ModuleValueId { get; set; }

        public override string Tenant { get; set; }

        public string ModuleId { get; set; }

        public string ModuleValueTypeSystemId { get; set; }

        public Nullable<System.DateTime> StartEffectiveDate { get; set; }

        public Nullable<System.DateTime> EndEffectiveDate { get; set; }

        public Nullable<decimal> Price { get; set; }

        public string ModuleCostTypeSystemId { get; set; }

        public Nullable<decimal> Cost { get; set; }
    }

    public partial class ModuleValueExtension : CoreObject
    {
        public static string MyEntityName { get { return "ModuleValueExtension"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleValueExtensionId, Tenant }; } }

        public string ModuleValueId { get; set; }

        [Key]
        public string ModuleValueExtensionId { get; set; }

        public override string Tenant { get; set; }

        public string ModuleId { get; set; }

        public string UnitTypeId { get; set; }

        public Nullable<System.DateTime> StartEffectiveDate { get; set; }

        public Nullable<System.DateTime> EndEffectiveDate { get; set; }

        public Nullable<decimal> Price { get; set; }

        public Nullable<decimal> Cost { get; set; }

        public Nullable<bool> OverrideMembership { get; set; }

        public string FootprintId { get; set; }

        public string PriceUpdateId { get; set; }

        public Nullable<bool> IsBasePrice { get; set; }

        public string CostTypeId { get; set; }

        public Nullable<bool> IsLocked { get; set; }

        public Nullable<decimal> Different { get; set; }

        public Nullable<bool> SUN { get; set; }

        public Nullable<bool> MON { get; set; }

        public Nullable<bool> TUE { get; set; }

        public Nullable<bool> WED { get; set; }

        public Nullable<bool> THU { get; set; }

        public Nullable<bool> FRI { get; set; }

        public Nullable<bool> SAT { get; set; }

        public Nullable<TimeSpan> StartTime { get; set; }

        public Nullable<TimeSpan> EndTime { get; set; }

        public Nullable<bool> AllDay { get; set; }

        public string VariantId { get; set; }
        public Nullable<bool> IsIndependent { get; set; }
    }

    public partial class ModuleInformation : CoreObject
    {
        public static string MyEntityName { get { return "ModuleInformation"; } }

        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }
        [Key]

        public string ModuleId { get; set; }

        public override string Tenant { get; set; }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, Tenant }; } }

        public Nullable<bool> RetailUsage { get; set; }

        public Nullable<bool> ProfessionalUsage { get; set; }

        public Nullable<bool> NotForResale { get; set; }

        public string BarCode { get; set; }

        public string Sku { get; set; }

        public Nullable<decimal> Width { get; set; }

        public Nullable<decimal> WeightedCost { get; set; }

        public Nullable<bool> Component { get; set; }

        public Nullable<bool> LoyaltyPoints { get; set; }

        public Nullable<bool> PrintLabel { get; set; }

        public Nullable<decimal> EstimatedHours { get; set; }

        public Nullable<bool> OnlyForMembers { get; set; }

        public Nullable<bool> IsAvailableOnlineToPublic { get; set; }

        public Nullable<bool> IsPrintableInClientCard { get; set; }

        public Nullable<bool> IsPointsExempt { get; set; }

        public Nullable<bool> IsPushedFromHeadOffice { get; set; }

        public Nullable<bool> IsAvailableForPackage { get; set; }

        public Nullable<decimal> MaxBookingAllowed { get; set; }

        public Nullable<int> OnHandQuantity { get; set; }

        public string BinLocation { get; set; }

        public Nullable<int> MinOrderLevel { get; set; }

        public Nullable<int> MaxOrderLevel { get; set; }

        public Nullable<int> ReOrderLevel { get; set; }

        public Nullable<short> RepeatPackage { get; set; }

        public Nullable<bool> Bookable { get; set; }

        public string StaffCardNumber { get; set; }

        public Nullable<short> Priority { get; set; }

        public Nullable<DateTime> PostedDate { get; set; }

        public string EmployeeID { get; set; }

        public Nullable<int> DisplayOrder { get; set; }

        public Nullable<decimal> ReplacementCost { get; set; }

        public Nullable<int> Validity { get; set; }

        public string Instructions { get; set; }

        public string AccountNumber { get; set; }

        public string GLAccountNumber { get; set; }

        public Nullable<bool> CommissionOnFullPrice { get; set; }

        public Nullable<System.DateTime> StartDate { get; set; }

        public Nullable<System.DateTime> EndDate { get; set; }

        public Nullable<decimal> Percentage { get; set; }

        public int? NoOfRoles { get; set; }

        public int? Points { get; set; }

        public int? RolePriority { get; set; }

        public decimal? SplitCommission { get; set; }

        public bool? InheritTax { get; set; }

        public bool? InheritProduct { get; set; }

        public Nullable<bool> IsRecurring { get; set; }

        public string ReferenceNo { get; set; }

        public string DocumentNo { get; set; }

        public Nullable<decimal> GrossValue { get; set; }

        public Nullable<decimal> TotalExpenses { get; set; }

        public Nullable<decimal> NetValue { get; set; }

        public Nullable<System.DateTime> DocumentDate { get; set; }

        public Nullable<bool> IsComplete { get; set; }

        public Nullable<bool> IsDefault { get; set; }

        public Nullable<decimal> PaymentAmount { get; set; }

        public Nullable<bool> AutoTimeInOut { get; set; }

        public Nullable<decimal> QuotaFactor { get; set; }

        public Nullable<bool> ServiceTiersRetroactive { get; set; }

        public Nullable<bool> RetailTiersRetroactive { get; set; }

        public Nullable<decimal> EstimatedServiceGoalAmount { get; set; }

        public Nullable<decimal> EstimatedRetailGoalAmount { get; set; }


        public string SupplierReferenceNo { get; set; }

        public Nullable<System.DateTime> ReceiptDate { get; set; }

        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }

        public Nullable<System.DateTime> PaymentDueOn { get; set; }

        public Nullable<decimal> TotalTax { get; set; }

        public Nullable<decimal> TotalDiscounts { get; set; }

        public Nullable<int> TotalNumberOfItems { get; set; }

        public Nullable<decimal> RestrictionGap { get; set; }

        public string ActivityNotes { get; set; }

        public string TotalExpense { get; set; }

        public string TotalNetValue { get; set; }

        public string ReasonComment { get; set; }

        //  public Nullable<System.DateTime> BusinessDate { get; set; }
        public Nullable<bool> IsIncrease { get; set; }

        // public Nullable<System.DateTime> ActivatedDate { get; set; }

        public Nullable<bool> IsLocked { get; set; }

        public Nullable<System.DateTime> ClosedDate { get; set; }

        public Nullable<decimal> OpeningFloat { get; set; }

        public Nullable<decimal> PettyCash { get; set; }

        public Nullable<decimal> ExpectedAmount { get; set; }

        public Nullable<decimal> ActualAmount { get; set; }

        public Nullable<decimal> Difference { get; set; }

        public string Reason { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public Nullable<decimal> ExchangeRate { get; set; }

        public Nullable<decimal> Denomination { get; set; }

        public Nullable<decimal> Quantity { get; set; }

        public int? Repeaton { get; set; }

        public int? NoofOccurrences { get; set; }

        public Nullable<Boolean> SUN { get; set; }

        public Nullable<Boolean> MON { get; set; }

        public Nullable<Boolean> TUE { get; set; }

        public Nullable<Boolean> WED { get; set; }

        public Nullable<Boolean> THU { get; set; }

        public Nullable<Boolean> FRI { get; set; }

        public Nullable<Boolean> SAT { get; set; }

        public string ModuleTemplateTitle { get; set; }

        public string ModuleTemplateBody { get; set; }

        public byte[] ImageFile { get; set; }

        public Nullable<int> WeekOfMonth { get; set; }

        public string DayOfWeek { get; set; }

        public Nullable<DateTime> ScheduleStart { get; set; }

        public Nullable<DateTime> ScheduleEnd { get; set; }

        public Nullable<TimeSpan> ScheduleTime { get; set; }

        public string ScheduleType { get; set; }

        public string CampaignType { get; set; }

        public string AnswerType { get; set; }

        public string AnswerName { get; set; }

        public string ModuleTemplateMetadata { get; set; }

        public string ModuleTemplateContent { get; set; }

        public string ModuleSegmentationId { get; set; }

        public string EmailSubject { get; set; }

        public string ImageUrl { get; set; }

        public Nullable<Boolean> Twitter { get; set; }

        public Nullable<Boolean> Facebook { get; set; }

        public Nullable<Boolean> LinkedIn { get; set; }

        public Nullable<bool> IsCommissionExempt { get; set; }

        public Nullable<bool> DepositRequired { get; set; }

        public Nullable<decimal> DepositAmount { get; set; }

        public Nullable<bool> OverrideCommission { get; set; }

        public Nullable<bool> OverridePoints { get; set; }

        public Nullable<bool> HigherCommission { get; set; }

        public Nullable<bool> IsGroupBooking { get; set; }

        public Nullable<bool> IsMultipleRequired { get; set; }

        public Nullable<int> LayoutOrder { get; set; }

        public Nullable<bool> IsAllDay { get; set; }

        public Nullable<bool> AnyDay { get; set; }

        public Nullable<bool> AnyStaff { get; set; }

        public Nullable<bool> ArrivedAtWorkStatus { get; set; }

        public DateTime? ScheduledIn { get; set; }

        public DateTime? ScheduledOut { get; set; }

        public DateTime? ActuallyIn { get; set; }

        public DateTime? ActuallyOut { get; set; }

        public Nullable<TimeSpan> StartTime { get; set; }

        public Nullable<TimeSpan> EndTime { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public Nullable<Int64> StartNo { get; set; }

        public Nullable<Int64> EndNo { get; set; }

        public Nullable<Int64> LastNo { get; set; }

        public Nullable<int> CodeLength { get; set; }

        public Nullable<bool> PadZero { get; set; }

        public Nullable<decimal> LoyaltyConfigurationQuantity { get; set; }

        public Nullable<decimal> LoyaltyPointConfigured { get; set; }

        public Nullable<decimal> MinRedemptionPoint { get; set; }

        public Nullable<decimal> PointsToRedemption { get; set; }

        public Nullable<decimal> RedemptionAmount { get; set; }

        public string TemplateHtml { get; set; }

        public string TemplateJson { get; set; }

        public int? RepeatEvery { get; set; }

        public string Frequency { get; set; }

        public int? MonthOfYear { get; set; }

        public string EndType { get; set; }

        public string SenderEmail { get; set; }

        public string SenderPhone { get; set; }

        public string SurveyTitle { get; set; }

        public string SurveyDescription { get; set; }

        public string JSON { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public bool? ResourceRequired { get; set; }

        public bool? StaffRequired { get; set; }

        public bool? ResourceRoleRequired { get; set; }

        public bool? StaffRoleRequired { get; set; }

        public bool? IsMinimumInterval { get; set; }

        public int? MinimumIntervalGap { get; set; }

        public bool? IsFrequency { get; set; }

        public int? FrequencyGap { get; set; }

        public bool? IsSeries { get; set; }

        public int? Columns { get; set; }

        public int? Height { get; set; }

        public decimal? HorizontalSpacing { get; set; }

        public decimal? MarginBottom { get; set; }

        public decimal? MarginLeft { get; set; }

        public decimal? MarginRight { get; set; }

        public decimal? MarginTop { get; set; }

        public int? RowsTwo { get; set; }

        public decimal? VerticalSpacing { get; set; }

        public string ShortCloseReason { get; set; }

        public string ShortCloseComment { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public bool? IsBundle { get; set; }

        public int? StaffPointsValue { get; set; }

        public int? CustomerPointsValue { get; set; }

        public decimal? StaffCommissionValue { get; set; }

        public bool? CustomRoleCommission { get; set; }

        public bool? CustomRolePoints { get; set; }

        public bool? CustomerOverridePoints { get; set; }

        public bool? IsIndividual { get; set; }
    }

    public partial class ModuleAvailability : CoreObject
    {
        public static string MyEntityName { get { return "ModuleAvailability"; } }
        [NotMapped]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleAvailabilityId, Tenant }; } }

        public string ModuleId { get; set; }

        [Key]
        public string ModuleAvailabilityId { get; set; }

        public override string Tenant { get; set; }

        public System.DateTime? Date { get; set; }

        public bool? Available { get; set; }

        public Nullable<System.TimeSpan> FromTime { get; set; }

        public Nullable<System.TimeSpan> ToTime { get; set; }

        public string BoosterTypeSystemId { get; set; }

        public Nullable<decimal> BoosterFactor { get; set; }

        public string TimeSlotTypeId { get; set; }

        public int? DayOfWeek { get; set; }

        public bool? IsAlwaysAvailable { get; set; }
    }
}

namespace KlickbookEcommerceService.Common.Model

{
    public partial class ModuleDependency : CoreObject
    {
        public static string MyEntityName { get { return "ModuleDependency"; } }

        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }
        [Key]

        public string ModuleId { get; set; }
        public override string Tenant { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, Tenant }; } }
        public string Comment { get; set; }

        //public string ServiceCategoryMasterId { get; set; }

        //public string PackageCategoryMasterId { get; set; }

        public string TaskStatusSystemId { get; set; }

        public string TaskPriorityId { get; set; }

        public string BrandMasterId { get; set; }

        public string ProductCategoryMasterId { get; set; }

        public string StyleMasterId { get; set; }

        public string RetailPackageSourceMasterId { get; set; }

        public string DepartmentMasterId { get; set; }

        public string SubCategoryMasterId { get; set; }

        public string ColorMasterId { get; set; }

        public string SizeMasterId { get; set; }

        public string TimeIntervalTypeSystemId { get; set; }

        public string StaffLoyaltyPointId { get; set; }

        public string UserID { get; set; }

        public string PostedUserId { get; set; }

        public string StaffPayDetailId { get; set; }

        public string ValidityTypeID { get; set; }

        public string MembershipTypeId { get; set; }

        public string CostingMethodId { get; set; }

        public string DefaultUnitTypeId { get; set; }

        public string POFormatMasterId { get; set; }

        public string CurrencyId { get; set; }

        public string PromotionTypeSystemId { get; set; }

        public string TaxApplyTypeSystemId { get; set; }

        public string ServiceRoleMasterId { get; set; }

        public string ResourceCategoryMasterId { get; set; }

        public string TransferTypeId { get; set; }

        public string FromTenant { get; set; }

        public string ToTenant { get; set; }

        public string ReferenceTypeId { get; set; }

        public string TransferStatusSystemId { get; set; }

        public string TransferModeSystemId { get; set; }

        public string ServicePricingTypeSystemId { get; set; }

        public string PhysicalStockStatusSystemId { get; set; }

        public string UsageTypeSystemId { get; set; }

        public string OnlineBookingOptionSystemId { get; set; }

        public string PaymentBasisTypeId { get; set; }

        public string TitleTypeMasterId { get; set; }

        public string GenderMasterId { get; set; }


        public string PurchaseOrderId { get; set; }

        public string SupplierId { get; set; }

        public string SupplierAddressId { get; set; }

        public string GRNStatusId { get; set; }

        public string DocumentLocation { get; set; }

        public string ReasonMasterId { get; set; }

        public string BusinessDayStatusId { get; set; }

        public string ClosedBy { get; set; }

        public string FlowStatusId { get; set; }

        public string PaymentReceiptDetailId { get; set; }

        public string UserTillSessionId { get; set; }

        public string GRNId { get; set; }

        public string MarketingScheduleTypeSystemId { get; set; }

        public string ScheduleEndTypeSystemId { get; set; }

        public string MonthlyTypeId { get; set; }

        public string SurveyId { get; set; }

        public string AppointmentTemplateTypeId { get; set; }

        public string SegmentationId { get; set; }

        public string TriggerId { get; set; }

        public string ContactListId { get; set; }

        public string CampaignId { get; set; }

        public string ServiceRoleTypeId { get; set; }

        public string SplitCommissionTypeMasterId { get; set; }

        public string TrackingTypeMasterId { get; set; }

        public string ClientId { get; set; }

        public string ServiceId { get; set; }

        public string FootprintId { get; set; }

        public string TimeAvailabilityOptionId { get; set; }

        public string DocumentTypeMasterId { get; set; }

        public string TenderTypeMasterId { get; set; }

        public string LoyaltyUserSystemId { get; set; }

        public string LoyaltyPointAttributeGroupSystemId { get; set; }

        public string LoyaltyPointAttributeSystemId { get; set; }

        public string ProfileId { get; set; }

        public string DataTypeSystemId { get; set; }

        public string ScheduleFrequencyTypeSystemId { get; set; }

        public string OptionTypeId { get; set; }

        public string SelectedModuleTypeId { get; set; }

        public string DataListTypeId { get; set; }

        public string LabelLayoutMasterId { get; set; }

        public string MinimumIntervalTypeSystemId { get; set; }

        public string FrequencyTypeSystemId { get; set; }

        public string LabelLayoutId { get; set; }

        public string CustomerPointsTypeSystemId { get; set; }

        public string StaffPointsTypeSystemId { get; set; }

        public string StaffCommissionTypeSystemId { get; set; }

        public string SegmentationTypeId { get; set; }

        public string GroupTypeId { get; set; }
    }

    public partial class ModuleRelation : CoreObject
    {
        public static string MyEntityName { get { return "ModuleRelation"; } }
 
        [NotMapped]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, Tenant }; } }
        [Key]
        public string ModuleRelationId { get; set; }

        public override string Tenant { get; set; }

        public string ModuleRelationTypeSystemId { get; set; }

        public string ModuleId { get; set; }

        public string ParentId { get; set; }

        public string TargetModuleId { get; set; }

        public Nullable<bool> RelationExtend { get; set; }
    }

    public partial class ModuleRelationExtension : CoreObject
    {
        public static string MyEntityName { get { return "ModuleRelationExtension"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleRelationExtensionId, Tenant }; } }

        [Key]
        public string ModuleRelationExtensionId { get; set; }
        public string ModuleRelationId { get; set; }
        public override string Tenant { get; set; }

        // public string PropertyDataTypeSystemId { get; set; }

        public Nullable<bool> OverrideMembership { get; set; }

        public string AttributeName { get; set; }

        public string AttributeValue { get; set; }

        public string Comment { get; set; }

        public Nullable<System.TimeSpan> TotalTimeTaken { get; set; }

        public Nullable<short> NumOfRole { get; set; }

        public Nullable<short> RolePriority { get; set; }

        public Nullable<decimal> SplitCommission { get; set; }

        public Nullable<int> Points { get; set; }

        public string ServiceRoleMasterId { get; set; }

        public string ResourceId { get; set; }

        public Nullable<bool> IsDefault { get; set; }

        public Nullable<decimal> Quantity { get; set; }

        public Nullable<decimal> Cost { get; set; }

        public Nullable<decimal> Price { get; set; }

        public string UnitTypeId { get; set; }

        public Nullable<decimal> DiscountPercentage { get; set; }

        public Nullable<decimal> BillAmountRange { get; set; }

        public Nullable<byte> BillDiscountType { get; set; }

        public Nullable<decimal> DiscountAmount { get; set; }

        public string ConditionTypeSystemId { get; set; }

        public Nullable<int> XSideQuantity { get; set; }

        public Nullable<int> YSideQuantity { get; set; }

        public Nullable<decimal> Discount { get; set; }

        public string PromotionDiscountSystemId { get; set; }

        public Nullable<decimal> PromotionPrice { get; set; }

        public Nullable<byte> BuyXGetYAreaType { get; set; }

        public string TimeLineTypeSystemId { get; set; }

        public string TimeDelay { get; set; }

        public Nullable<short> DisplayOrder { get; set; }

        public string ModuleCostTypeSystemId { get; set; }

        public Nullable<decimal> ProfessionalQuantity { get; set; }

        public Nullable<decimal> NetValue { get; set; }

        public Nullable<decimal> RetailQuantity { get; set; }

        public string BaseUnitTypeId { get; set; }

        public Nullable<decimal> BaseUOMQuantity { get; set; }

        public Nullable<decimal> StockInHand { get; set; }

        public Nullable<decimal> Variance { get; set; }

        public string ReasonForAdjustment { get; set; }

        public Nullable<bool> Ignored { get; set; }

        public Nullable<decimal> UOMQuantity { get; set; }

        public string BarCode { get; set; }

        public Nullable<bool> IsValid { get; set; }

        public Nullable<decimal> FromAmount { get; set; }

        public Nullable<decimal> ToAmount { get; set; }

        public Nullable<decimal> Commission { get; set; }


        public Nullable<decimal> RetailQuanity { get; set; }

        public Nullable<decimal> RegularPrice { get; set; }

        public Nullable<decimal> DealPrice { get; set; }

        public Nullable<decimal> DiscountValue { get; set; }

        public Nullable<decimal> GRNUOMId { get; set; }

        public Nullable<int> GRNUOMQuanity { get; set; }

        public Nullable<bool> IsPosted { get; set; }

        public Nullable<decimal> Percentage { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public string Description { get; set; }

        public string StockEntryTypeId { get; set; }

        public string RetailSourceTypeId { get; set; }

        public Nullable<bool> InheritFromPO { get; set; }

        public string DeliveryLocationId { get; set; }

        public Nullable<bool> CreateInChild { get; set; }

        public Nullable<bool> ApplyAll { get; set; }

        public string FootprintId { get; set; }

        public string FromSeasonPeriodMasterId { get; set; }

        public string ToSeasonPeriodMasterId { get; set; }

        public Nullable<decimal> LoyaltyConfigurationQuantity { get; set; }

        public Nullable<decimal> LoyaltyPointConfigured { get; set; }

        public string DataTypeSystemId { get; set; }

        public string FilterTypeSystemId { get; set; }

        public string Value { get; set; }

        public string AndOr { get; set; }

        public Nullable<int> GroupIndex { get; set; }

        public string ConditionId { get; set; }

        public Nullable<int> RunAfterDays { get; set; }

        public Nullable<bool> Recurring { get; set; }

        public string EndType { get; set; }

        public int? NumOfOccurrences { get; set; }

        public DateTime? ScheduleEnd { get; set; }

        public string Question { get; set; }

        public string TypeId { get; set; }

        public bool? IsAnswerType { get; set; }

        public bool? IsCustomize { get; set; }

        public int? Count { get; set; }

        public Nullable<DateTime> StartTime { get; set; }

        public Nullable<DateTime> DueDate { get; set; }

        public string PostedUserId { get; set; }

        public string ItemInputTypeSystemId { get; set; }

        public decimal? ConversionFactor { get; set; }

        public string TXNID { get; set; }

        public Nullable<bool> SUN { get; set; }

        public Nullable<bool> MON { get; set; }

        public Nullable<bool> TUE { get; set; }

        public Nullable<bool> WED { get; set; }

        public Nullable<bool> THU { get; set; }

        public Nullable<bool> FRI { get; set; }

        public Nullable<bool> SAT { get; set; }

        public Nullable<TimeSpan> StartTimeSpan { get; set; }

        public Nullable<TimeSpan> EndTimeSpan { get; set; }

        public string VariantId { get; set; }

        public string UsageTypeId { get; set; }

    }

    public partial class ModuleExternalRelation : CoreObject
    {
        public static string MyEntityName { get { return "ModuleExternalRelation"; } }

        [NotMapped]
        public decimal ID { get; set; }

        public string ModuleRelationId { get; set; }

        public override string Tenant { get; set; }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, ModuleExternalRelationId, Tenant }; } }

        [NotMapped]
        public string[] RelationKey { get { return new string[] { ModuleId, ModuleRelationId, Tenant }; } }
        
        public string ModuleId { get; set; }

        public Nullable<bool> RelationExtend { get; set; }

        public string ServiceCategoryMasterId { get; set; }

        public string PackageCategoryMasterId { get; set; }

        public string SupplierCategoryMasterId { get; set; }

        [Key]
        public string ModuleExternalRelationId { get; set; }

        public string TransferExpenseTypeId { get; set; }

        public string CertificationTypeId { get; set; }

        public string ModuleExternalRelationTypeId { get; set; }

        public string ExpenseMasterId { get; set; }

        //public string ScheduleTypeId { get; set; }
        public string StaffRoleMasterId { get; set; }

        public string ResourceRoleMasterId { get; set; }

        public string ClientId { get; set; }

        public string StaffId { get; set; }

        public string TenderTypeId { get; set; }

        public string TenderTypeModuleId { get; set; }

        public string GemTypeSystemId { get; set; }

        public string ImageId { get; set; }

        public string MarketingSocialMediaId { get; set; }

        public string CurrencyDenominationId { get; set; }

        public string PostedUserId { get; set; }

        public string ModuleNoteTypeMasterId { get; set; }

        public string SourceTypeId { get; set; }

        public string StaffDepartmentMasterId { get; set; }
    }

    public partial class ModuleAvailabilityTime : CoreObject
    {
        public static string MyEntityName { get { return "ModuleAvailabilityTime"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleAvailabilityTimeId }; } }
        [Key]
        public string ModuleAvailabilityTimeId { get; set; }

        public string ModuleAvailabilityId { get; set; }

        public string ModuleAvailabilityTypeId { get; set; }

        public Nullable<System.TimeSpan> FromTime { get; set; }

        public Nullable<System.TimeSpan> ToTime { get; set; }

        public Nullable<System.DateTime> SignedIn { get; set; }

        public Nullable<System.DateTime> SignedOut { get; set; }

        public Nullable<bool> ArrivedAtWork { get; set; }

        public Nullable<int> SignInCount { get; set; }

        public Nullable<int> SignOutCount { get; set; }
    }

    public partial class ModuleGoal : CoreObject
    {
        public static string MyEntityName { get { return "ModuleGoal"; } }
        [NotMapped]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleGoalId, Tenant }; } }

        public string ModuleId { get; set; }

        public override string Tenant { get; set; }

        [Key]
        public string ModuleGoalId { get; set; }

        public string ModuleGoalTypeId { get; set; }

        public string ParentId { get; set; }

        public Nullable<int> Year { get; set; }

        public Nullable<short> Month { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public Nullable<decimal> Amount { get; set; }

        public string Comment { get; set; }
    }

    public partial class ModuleRelationTimeSlot : CoreObject
    {
        public static string MyEntityName { get { return "ModuleRelationTimeSlot"; } }
        [NotMapped]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }

        public string ModuleRelationTimeSlotId { get; set; }

        public string ModuleRelationId { get; set; }

        public Nullable<System.TimeSpan> FromTime { get; set; }

        public Nullable<System.TimeSpan> ToTime { get; set; }

        public string TimeSlotTypeId { get; set; }
    }

    public class ModuleStockChange : CoreObject
    {

        [NotMapped]
        public decimal ID { get; set; }
        public static string MyEntityName { get { return "ModuleStockChange"; } }

        [NotMapped]
        public string[] Key { get { return new string[] { StockAdjustmentId, ModuleId, Tenant, UnitTypeId, UsageTypeId, VariantId }; } }

        [Key, Column(Order = 0)]

        public string StockAdjustmentId { get; set; }
        [Key, Column(Order = 1)]

        public string ModuleId { get; set; }
        [Key, Column(Order = 2)]

        public override string Tenant { get; set; }
        [Key, Column(Order = 3)]

        public string UnitTypeId { get; set; }
        [Key, Column(Order = 4)]

        public string UsageTypeId { get; set; }
        [Key, Column(Order = 5)]

        public string VariantId { get; set; }
        [Key, Column(Order = 6)]

        public string BarCode { get; set; }

        public decimal? QuantityChange { get; set; }

        public string Reason { get; set; }

    }

    public partial class ModuleUsage : CoreObject
    {
        public static string MyEntityName { get { return "ModuleUsage"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, Tenant, ModuleUsageId }; } }
        [Key]
        public string ModuleUsageId { get; set; }

        public string ModuleId { get; set; }

        public string UsageTypeSystemId { get; set; }

        public string BinLocation { get; set; }

        public Nullable<int> MinOrderLevel { get; set; }

        public Nullable<int> MaxOrderLevel { get; set; }

        public Nullable<int> ReOrderLevel { get; set; }

        public string ModuleVariantId { get; set; }

        public bool? IsDefault { get; set; }

        public bool? NotForSale { get; set; }

        [Key]
        public override string Tenant { get; set; }
    }

    public partial class ModuleUnitConversion : CoreObject
    {
        public static string MyEntityName { get { return "ModuleUnitConversion"; } }

        [NotMapped]
        public decimal ID { get; set; }

        [NotMapped]
        public string[] Key { get { return new string[] { ModuleId, Tenant, ModuleUnitConversionId }; } }

        [Key]
        public string ModuleUnitConversionId { get; set; }

        public string ModuleId { get; set; }

        public string UnitTypeId { get; set; }

        public decimal? ConversionFactor { get; set; }

        public Nullable<decimal> SalesPrice { get; set; }

        [NotMapped]
        public Nullable<bool> IsActive { get; set; }

        public string BarCode { get; set; }

        public Nullable<bool> IsBaseUOM { get; set; }

        public string Tenant { get; set; }

        public string ModuleVariantId { get; set; }
    }

    public partial class ModuleImage : CoreObject
    {
        public static string MyEntityName { get { return "ModuleImage"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleImageId, Tenant }; } }
        [Key]
        public string ModuleImageId { get; set; }

        public string ModuleId { get; set; }

        public string ImageId { get; set; }

        public Nullable<bool> IsDefault { get; set; }

        public string ImageURL { get; set; }
        public string Tenant { get; set; }
    }

    public partial class ModuleExternalExtension : CoreObject
    {
        public static string MyEntityName { get { return "ModuleExternalExtension"; } }
        [NotMapped]
        public string[] Key { get { return new string[] { ModuleExternalExtensionId, Tenant }; } }
        [NotMapped]
        public decimal ID { get; set; }

        public override string Tenant { get; set; }

        [Key]
        public string ModuleExternalExtensionId { get; set; }

        public string ModuleExternalRelationId { get; set; }

        public Nullable<decimal> ExpenseAmount { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }

        public string Percentage { get; set; }

        public string Amount { get; set; }

        public string ScheduleName { get; set; }

        public int ScheduleValue { get; set; }

        public Nullable<bool> InheritFromPO { get; set; }

        public Nullable<decimal> CountedAmount { get; set; }

        public Nullable<decimal> ExpectedAmount { get; set; }

        public string Color { get; set; }

        //public Nullable<bool> FilterOption { get; set; }

        //public Nullable<bool> AppointmentOption { get; set; }

        //public Nullable<bool> SDROption { get; set; }

        //public Nullable<bool> WalkInOption { get; set; }

        //public Nullable<bool> PayOption { get; set; }

        //public Nullable<bool> RequireResource { get; set; }

        public Nullable<int> DisplayOrder { get; set; }

        //public Nullable<bool> ScheduledTime { get; set; }

        public Nullable<bool> IsVisible { get; set; }

        public Nullable<int> Time { get; set; }

        public Nullable<bool> IsDefault { get; set; }

        public string Value { get; set; }

        public string FilterTypeSystemId { get; set; }

        public string Operator { get; set; }

        public Nullable<int> Count { get; set; }

        public Nullable<Boolean> IsBold { get; set; }

        public Nullable<int> FontSize { get; set; }

        public string FontType { get; set; }

        public Nullable<decimal> HorizPosition { get; set; }

        public Nullable<Boolean> IsItalic { get; set; }

        public Nullable<decimal> VertPosition { get; set; }

        public Nullable<int> BarcodeHeight { get; set; }

        public Nullable<int> BarcodeWidth { get; set; }

        public Nullable<bool> BarcodeDisplayValue { get; set; }

        public string BarcodeTextAlign { get; set; }

        public string BarcodeTextPosition { get; set; }

        public Nullable<DateTime> PostedDate { get; set; }

        public string ReplyTo { get; set; }

        public string OptionId { get; set; }

        public string SourceId { get; set; }

        public string ActionId { get; set; }

        public string AfterActionId { get; set; }

        public string Icon { get; set; }
    }

    public partial class ModuleAvailabilityDays : CoreObject
    {
        public static string MyEntityName { get { return "ModuleAvailabilityDays"; } }

        [NotMapped]
        public decimal ID { get; set; }

        public string ModuleAvailabilityDaysId { get; set; }

        public string ModuleId { get; set; }

        public string WeekDaysSystemTypeId { get; set; }
    }

    public partial class ModuleCore : CoreObject
    {
        public static string MyEntityName { get { return "ModuleCore"; } }
        [NotMapped]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal ID { get; set; }
        [Key, Column(Order = 0)]

        public string ModuleId { get; set; }
        [Key, Column(Order = 1)]

        public override string Tenant { get; set; }

        public string ModuleCoreId { get; set; }

        public string Comment { get; set; }

        public string ClientId { get; set; }

        public string ClientMemberId { get; set; }

        public string LoyaltyPointId { get; set; }

        public string TemplateId { get; set; }
    }
}
namespace KlickbookEcommerceService.Common.Model
{
    public partial class XChargeResponse
    {
        public static string MyEntityName { get { return "XChargeResponse"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { XCTRANSACTIONID, TENANT }; } }
        [Key]
        public string XCTRANSACTIONID { get; set; }
        public string TENANT { get; set; }
        public string ACCOUNT { get; set; }
        public string ACCOUNTTYPE { get; set; }
        public string AMOUNT { get; set; }
        public string APPROVALCODE { get; set; }
        public string APPROVEDAMOUNT { get; set; }
        public string AVSRESULT { get; set; }
        public string CASHBACKAMOUNT { get; set; }
        public string CLERK { get; set; }
        public string CONTACTLESS { get; set; }
        public string DESCRIPTION { get; set; }
        public string EXPIRATION { get; set; }
        public string MISC { get; set; }
        public string NAME { get; set; }
        public string RECEIPT { get; set; }
        public string RESULT { get; set; }
        public string SWIPED { get; set; }
        public string TIPAMOUNT { get; set; }
        public string XCACCOUNTID { get; set; }
        public string TYPE { get; set; }
        public string RECEIPTNO { get; set; }
    }

    public partial class MonerisResponse
    {
        public static string MyEntityName { get { return "MonerisResponse"; } }

        [NotMapped]
        public decimal ID { get; set; }
        [NotMapped]
        public string[] Key { get { return new string[] { ReceiptId, TENANT }; } }
        [Key]
        public string ReceiptId { get; set; }
        public string TENANT { get; set; }
        public string Completed { get; set; }
        public string TransType { get; set; }
        public string Error { get; set; }
        public string InitRequired { get; set; }
        public string SafIndicator { get; set; }
        public string ResponseCode { get; set; }
        public string ISO { get; set; }
        public string LanguageCode { get; set; }
        public string PartialAuthAmount { get; set; }
        public string AvailableBalance { get; set; }
        public string TipAmount { get; set; }
        public string EMVCashBackAmount { get; set; }
        public string SurchargeAmount { get; set; }
        public string ForeignCurrencyAmount { get; set; }
        public string ForeignCurrencyCode { get; set; }
        public string BaseRate { get; set; }
        public string ExchangeRate { get; set; }
        public string Pan { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public string AccountType { get; set; }
        public string SwipeIndicator { get; set; }
        public string FormFactor { get; set; }
        public string CvmIndicator { get; set; }
        public string ReservedField1 { get; set; }
        public string ReservedField2 { get; set; }
        public string AuthCode { get; set; }
        public string InvoiceNumber { get; set; }
        public string EMVEchoData { get; set; }
        public string ReservedField3 { get; set; }
        public string ReservedField4 { get; set; }
        public string Aid { get; set; }
        public string AppLabel { get; set; }
        public string AppPreferredName { get; set; }
        public string Arqc { get; set; }
        public string TvrArqc { get; set; }
        public string Tcacc { get; set; }
        public string TvrTcacc { get; set; }
        public string Tsi { get; set; }
        public string TokenResponseCode { get; set; }
        public string Token { get; set; }
        public string LogonRequired { get; set; }
        public string EncryptedCardInfo { get; set; }
        public string TransDate { get; set; }
        public string TransTime { get; set; }
        public string Amount { get; set; }
        public string ReferenceNumber { get; set; }
        public string TransId { get; set; }
        public string TimedOut { get; set; }
        public string CloudTicket { get; set; }
        public string TxnName { get; set; }
        public string Message { get; set; }
        public string receiptUrl { get; set; }
        public string Receipt { get; set; }
        public string ReceiptClient { get; set; }
        public string RECEIPTNO { get; set; }
    }
}