using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Common
{
    public class Translation
    {
        public string name { get; set; }
    }

    public class AttributeOption
    {
        public AttributeOption()
        {
            translations = new List<Translation>();
        }
        public List<Translation> translations { get; set; }
    }

    public class Attribute
    {
        public Attribute()
        {
            translations = new List<Translation>();
        }

        public bool visible { get; set; }
        public int position { get; set; }
        public string type { get; set; }
        public List<Translation> translations { get; set; }
        public List<AttributeOption> attribute_options { get; set; }
    }

    public class xCartAttributeResponse
    {
        public bool visible { get; set; }
        public int id { get; set; }
        public int position { get; set; }
        public int decimals { get; set; }
        public string type { get; set; }
        public string addToNew { get; set; }
    }
    public class Inventory
    {
        public string amount { get; set; }
    }

    public class TranslationInventory
    {
        public string name { get; set; }
        public string description { get; set; }
        public string briefDescription { get; set; }
    }
    public class XCartAddProduct
    {
        public XCartAddProduct()
        {
            inventory = new List<Inventory>();
            translations = new List<TranslationInventory>();
            attributes = new List<Attribute>();
        }
        public string name { get; set; }
        public string price { get; set; }
        public string sku { get; set; }
        public float? weight { get; set; }
        public string amount { get; set; }
        public List<Inventory> inventory { get; set; }
        public List<TranslationInventory> translations { get; set; }
        public List<Attribute> attributes { get; set; }
    }

    public class xCartLinkProductAttribute
    {
        public xCartProduct product { get; set; }
        public XCartId attribute { get; set; }
        public XCartId attribute_option { get; set; }

    }

    public class xCartProduct
    {
        public int product_id { get; set; }
    }
    public class XCartId
    {
        public int id { get; set; }
    }


    public class XCartMainAttributeViewModel
    {
        public XCartMainAttributeViewModel()
        {
            attribute = new List<Attribute>();
        }
        public List<Attribute> attribute { get; set; }
    }

    public class XCartAttributeViewModel
    {
        public XCartAttributeViewModel()
        {
            attribute_options = new List<AttributeOption>();
        }

        public List<AttributeOption> attribute_options { get; set; }
    }

    public class Parent
    {
        public string category_id { get; set; }
    }

    public class AddDepartment
    {
        public Parent parent { get; set; }
        public bool enabled { get; set; }
        public List<Translation> translations { get; set; }
    }

    [DataContract]
    public class UpdateOrderStatus
    {
        UpdateOrderStatus()
        {
            Orders = new List<int>();
        }
        [DataMember]
        public string CloudStoreId { get; set; }
        [DataMember]
        public List<int> Orders { get; set; }
    }


    public class Profile
    {
        public string gaClientId { get; set; }
        public object socialLoginProvider { get; set; }
        public object socialLoginId { get; set; }
        public object pictureUrl { get; set; }
        public int default_card_id { get; set; }
        public string pending_zero_auth { get; set; }
        public string pending_zero_auth_txn_id { get; set; }
        public string pending_zero_auth_status { get; set; }
        public string pending_zero_auth_interface { get; set; }
        public int rewardPoints { get; set; }
        public object conciergeUserId { get; set; }
        public string xpaymentsCustomerId { get; set; }
        public int profile_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string password_hint { get; set; }
        public string password_hint_answer { get; set; }
        public string passwordResetKey { get; set; }
        public int passwordResetKeyDate { get; set; }
        public int access_level { get; set; }
        public int cms_profile_id { get; set; }
        public string cms_name { get; set; }
        public int added { get; set; }
        public int first_login { get; set; }
        public int last_login { get; set; }
        public string status { get; set; }
        public string statusComment { get; set; }
        public string referer { get; set; }
        public string language { get; set; }
        public int last_shipping_id { get; set; }
        public int last_payment_id { get; set; }
        public bool anonymous { get; set; }
        public bool forceChangePassword { get; set; }
        public int dateOfLoginAttempt { get; set; }
        public int countOfLoginAttempts { get; set; }
        public string searchFakeField { get; set; }
        public bool xcPendingExport { get; set; }
        public string lastCheckoutEmail { get; set; }
    }

    public class OrigProfile
    {
        public string gaClientId { get; set; }
        public object socialLoginProvider { get; set; }
        public object socialLoginId { get; set; }
        public object pictureUrl { get; set; }
        public int default_card_id { get; set; }
        public string pending_zero_auth { get; set; }
        public string pending_zero_auth_txn_id { get; set; }
        public string pending_zero_auth_status { get; set; }
        public string pending_zero_auth_interface { get; set; }
        public int rewardPoints { get; set; }
        public object conciergeUserId { get; set; }
        public string xpaymentsCustomerId { get; set; }
        public int profile_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string password_hint { get; set; }
        public string password_hint_answer { get; set; }
        public string passwordResetKey { get; set; }
        public int passwordResetKeyDate { get; set; }
        public int access_level { get; set; }
        public int cms_profile_id { get; set; }
        public string cms_name { get; set; }
        public int added { get; set; }
        public int first_login { get; set; }
        public int last_login { get; set; }
        public string status { get; set; }
        public string statusComment { get; set; }
        public string referer { get; set; }
        public string language { get; set; }
        public int last_shipping_id { get; set; }
        public int last_payment_id { get; set; }
        public bool anonymous { get; set; }
        public bool forceChangePassword { get; set; }
        public int dateOfLoginAttempt { get; set; }
        public int countOfLoginAttempts { get; set; }
        public string searchFakeField { get; set; }
        public bool xcPendingExport { get; set; }
        public string lastCheckoutEmail { get; set; }
    }

    public class PaymentStatus
    {
        public int id { get; set; }
        public string code { get; set; }
        public int position { get; set; }
    }

    public class ShippingStatus
    {
        public int id { get; set; }
        public string code { get; set; }
        public int position { get; set; }
    }

    public class Event
    {
        public int event_id { get; set; }
        public int date { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public object data { get; set; }
        public string comment { get; set; }
        public object authorName { get; set; }
        public string authorIp { get; set; }
    }

    public class Item
    {
        public string categoryAdded { get; set; }
        public bool xpcFakeItem { get; set; }
        public bool xpaymentsEmulated { get; set; }
        public int item_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public double price { get; set; }
        public double itemNetPrice { get; set; }
        public double discountedSubtotal { get; set; }
        public int amount { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
    }

    public class Surcharge
    {
        public int id { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string @class { get; set; }
        public bool include { get; set; }
        public bool available { get; set; }
        public double value { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
    }

    public class PaymentTransaction
    {
        public int transaction_id { get; set; }
        public int date { get; set; }
        public string publicTxnId { get; set; }
        public string method_name { get; set; }
        public string method_local_name { get; set; }
        public string status { get; set; }
        public double value { get; set; }
        public string note { get; set; }
        public string type { get; set; }
        public string public_id { get; set; }
    }

    public class Currency
    {
        public int currency_id { get; set; }
        public string code { get; set; }
        public string symbol { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public int e { get; set; }
        public string decimalDelimiter { get; set; }
        public string thousandDelimiter { get; set; }
        public string roundUp { get; set; }
    }

    public class XCartDetails
    {
        public string fraud_status_xpc { get; set; }
        public string fraud_type_xpc { get; set; }
        public int fraud_check_transaction_id { get; set; }
        public bool is_zero_auth { get; set; }
        public double rewardPoints { get; set; }
        public double settledPoints { get; set; }
        public double redeemedPoints { get; set; }
        public double maxRedeemedPoints { get; set; }
        public bool pointsRewarded { get; set; }
        public bool pointsRedeemed { get; set; }
        public string mailchimpStoreId { get; set; }
        public string xpaymentsFraudStatus { get; set; }
        public string xpaymentsFraudType { get; set; }
        public int xpaymentsFraudCheckTransactionId { get; set; }
        public int order_id { get; set; }
        public int shipping_id { get; set; }
        public string shipping_method_name { get; set; }
        public string payment_method_name { get; set; }
        public string tracking { get; set; }
        public int date { get; set; }
        public int lastRenewDate { get; set; }
        public string notes { get; set; }
        public string adminNotes { get; set; }
        public string orderNumber { get; set; }
        public bool recent { get; set; }
        public bool xcPendingExport { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
        public List<object> usedCoupons { get; set; }
        public List<object> uspsShipment { get; set; }
        public List<object> rewardEvents { get; set; }
        public List<object> capostParcels { get; set; }
        public List<object> capostReturns { get; set; }
        public object capostOffice { get; set; }
        public object not_finished_order { get; set; }
        public object reviewKey { get; set; }
        public Profile profile { get; set; }
        public OrigProfile orig_profile { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public ShippingStatus shippingStatus { get; set; }
        public List<object> details { get; set; }
        public List<object> trackingNumbers { get; set; }
        public List<Event> events { get; set; }
        public List<Item> items { get; set; }
        public List<Surcharge> surcharges { get; set; }
        public List<PaymentTransaction> payment_transactions { get; set; }
        public Currency currency { get; set; }
    }

    public class GiftCard
    {
        public int card_id { get; set; }
        public string gcid { get; set; }
        public string card_type { get; set; }
        public bool enabled { get; set; }
        public string recipient_email { get; set; }
        public string recipient_address { get; set; }
        public string recipient_name { get; set; }
        public string message { get; set; }
        public string sender_signature { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }
        public string status { get; set; }
        public int add_date { get; set; }
        public int delivery_date { get; set; }
        public bool used { get; set; }
    }

    public class Order
    {
        public string fraud_status_xpc { get; set; }
        public string fraud_type_xpc { get; set; }
        public int fraud_check_transaction_id { get; set; }
        public bool is_zero_auth { get; set; }
        public double rewardPoints { get; set; }
        public double settledPoints { get; set; }
        public double redeemedPoints { get; set; }
        public double maxRedeemedPoints { get; set; }
        public bool pointsRewarded { get; set; }
        public bool pointsRedeemed { get; set; }
        public string mailchimpStoreId { get; set; }
        public string xpaymentsFraudStatus { get; set; }
        public string xpaymentsFraudType { get; set; }
        public int xpaymentsFraudCheckTransactionId { get; set; }
        public int order_id { get; set; }
        public int shipping_id { get; set; }
        public string shipping_method_name { get; set; }
        public string payment_method_name { get; set; }
        public string tracking { get; set; }
        public int date { get; set; }
        public int lastRenewDate { get; set; }
        public string notes { get; set; }
        public string adminNotes { get; set; }
        public string orderNumber { get; set; }
        public bool recent { get; set; }
        public bool xcPendingExport { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
    }

    public class XCartItem
    {
        public string categoryAdded { get; set; }
        public bool xpcFakeItem { get; set; }
        public bool xpaymentsEmulated { get; set; }
        public int item_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public double price { get; set; }
        public double itemNetPrice { get; set; }
        public double discountedSubtotal { get; set; }
        public int amount { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
        public GiftCard gift_card { get; set; }
        public List<object> capostParcelItems { get; set; }
        public List<object> capostReturnItems { get; set; }
        public object variant { get; set; }
        public object @object { get; set; }
        public Order order { get; set; }
        public List<object> surcharges { get; set; }
        public List<object> attributeValues { get; set; }
    }

    public class Card
    {
        public int card_id { get; set; }
        public string gcid { get; set; }
        public string card_type { get; set; }
        public bool enabled { get; set; }
        public string recipient_email { get; set; }
        public string recipient_address { get; set; }
        public string recipient_name { get; set; }
        public string message { get; set; }
        public string sender_signature { get; set; }
        public double amount { get; set; }
        public double balance { get; set; }
        public string status { get; set; }
        public int add_date { get; set; }
        public int delivery_date { get; set; }
        public bool used { get; set; }
    }

    public class XCartGiftCard
    {
        public int id { get; set; }
        public double value { get; set; }
        public string name { get; set; }
        public bool used { get; set; }
        public Order order { get; set; }
        public Card card { get; set; }
    }

}
