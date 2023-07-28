using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace EcommerceSync.Models
{
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

    public class TranslationAttribute
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Attribute
    {
        public Attribute()
        {
            translations = new List<TranslationAttribute>();
        }
        public bool visible { get; set; }
        public int position { get; set; }
        public string type { get; set; }
        public bool is_color { get; set; }
        public List<TranslationAttribute> translations { get; set; }
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
        public double? weight { get; set; }
        public string amount { get; set; }
        public List<Inventory> inventory { get; set; }
        public List<TranslationInventory> translations { get; set; }
        public List<Attribute> attributes { get; set; }
    }

    public class ProductViewModel
    {
        public string ProductID { get; set; }
        public string ColorAtributeID { get; set; }
        public string SizeAtributeID { get; set; }
        public string WidthAtributeID { get; set; }
        public string BrandAttributeID { get; set; }
        public string ColorOptionAtributeID { get; set; }
        public string SizeOptionAtributeID { get; set; }
        public string WidthOptionAtributeID { get; set; }
        public string BrandOptionAttributeID { get; set; }
        public string WidthOptionValueAtrributeID { get; set; }
        public string SizeOptionValueAtributeID { get; set; }
        public string CategoryID { get; set; }
        public string VariantID { get; set; }
    }

    public class TimerViewModel
    {
        public Int64 Id { get; set; }
        public System.Threading.Timer timer { get; set; }
    }

    public class GiftCardViewModel
    {
        public string CardID { get; set; }
        public string GCID { get; set; }
        public string CardType { get; set; }
        public bool Enabled { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientName { get; set; }
        public string Message { get; set; }
        public float Amount { get; set; }
        public float Balance { get; set; }
        public double AddDate { get; set; }
        public bool Used { get; set; }
    }

    
    public class SettingsViewModel
    {
        public string SETTINGSID { get; set; }
        public Nullable<Int64> CLOUDSTOREID { get; set; }
        public string EcommerceURL { get; set; }
        public string EcommerceSalesPersonCode { get; set; }
        public string STOREID { get; set; }
        public string GuestClientProfileEmail { get; set; }
        public string StoreName { get; set; }
        public string SizeName { get; set; }
        public string ColorName { get; set; }
        public string WidthName { get; set; }
        public int ColorEnabled { get; set; }
        public string ColorNA { get; set; }
        public string StoreType { get; set; }
    }

    public class MQInventViewModel
    {
        [DataMember]
        public Nullable<Int64> ID { get; set; }
        [DataMember]
        public Nullable<Int64> CLOUDSTOREID { get; set; }
        [DataMember]
        public string INVENTID { get; set; }
        [DataMember]
        public string GRIDDET1ID { get; set; }
        [DataMember]
        public string GRIDDET2ID { get; set; }
        [DataMember]
        public string GRIDID { get; set; }
        [DataMember]
        public string STOREID { get; set; }
        [DataMember]
        public string CATEGORY { get; set; }
        [DataMember]
        public string DEPARTMENT { get; set; }
        [DataMember]
        public string CODE { get; set; }
        [DataMember]
        public string PRODUCT { get; set; }
        [DataMember]
        public string COLOR { get; set; }
        [DataMember]
        public string SIZE { get; set; }
        [DataMember]
        public string WIDTH { get; set; }
        [DataMember]
        public Nullable<Int32> QUANTITY { get; set; }
        [DataMember]
        public string PRICE { get; set; }
        [DataMember]
        public string DESCRIPTION { get; set; }
        [DataMember]
        public string BRAND { get; set; }
        [DataMember]
        public string COMMENT { get; set; }
        [DataMember]
        public Nullable<bool> STATUS { get; set; }
        [DataMember]
        public Nullable<bool> AVLONLN { get; set; }
        [DataMember]
        public string EXTENDDESC { get; set; }
        [DataMember]
        public Nullable<double> WEIGHT { get; set; }
    }

    public class attribute_translations
    {
        public int label_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public string code { get; set; }
    }

    public class attribute_option_translations
    {
        public int label_id { get; set; }
        public int id { get; set; }
        public string name { get; set; }        
        public string code { get; set; }
    }

    public class attribute_values_select
    {
        public int id { get; set; }
        public int attribute_option_id { get; set; }
        public int product_id { get; set; }
        public int attribute_id { get; set; }
        public string position { get; set; }
        public string priceModifier { get; set; }
        public string priceModifierType { get; set; }
        public string weightModifier { get; set; }
        public string weightModifierType { get; set; }
        public string defaultValue { get; set; }
    }

}
