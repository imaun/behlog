namespace Behlog.Storage.Core {
    /// <summary>
    /// Includes Database constants
    /// </summary>
    public static class DbConst {

        //Content
        public const string Comment_Table_Name = "Content.Comments";
        public const string File_Table_Name = "Content.Files";
        public const string Link_Table_Name = "Content.Links";
        public const string Post_Table_Name = "Content.Posts";
        public const string PostFile_Table_Name = "Content.Post_Files";
        public const string PostLike_Table_Name = "Content.Post_Likes";
        public const string PostMeta_Table_Name = "Content.Post_Meta";
        public const string PostTag_Table_Name = "Content.Post_Tags";
        public const string SectionGroup_Table_Name = "Content.SectionGroups";
        public const string Section_Table_Name = "Content.Sections";

        //Feature
        public const string Contact_Table_Name = "Feature.Contacts";
        public const string Form_Table_Name = "Feature.Forms";
        public const string FormField_Table_Name = "Feature.Form_Fields";
        public const string FormFieldItem_Table_Name = "Feature.Form_Field_Items";
        public const string FormFieldValue_Table_Name = "Feature.Form_Field_Values";
        public const string PostVisit_Table_Name = "Feature.Post_Visits";
        public const string WebsiteVisit_Table_Name = "Feature.Website_Visits";
        public const string Subscription_Table_Name = "Feature.Subscriptions";

        //Shop
        public const string Brand_Table_Name = "Shop.Brands";
        public const string Basket_Table_Name = "Shop.Baskets";
        public const string BasketItem_Table_Name = "Shop.Basket_Items";
        public const string Customer_Table_Name = "Shop.Customers";
        public const string Invoice_Table_Name = "Shop.Invoices";
        public const string Order_Table_Name = "Shop.Orders";
        public const string Payment_Table_Name = "Shop.Payments";
        public const string Product_Table_Name = "Shop.Products";
        public const string ProductMeta_Table_Name = "Shop.ProductMeta";
        public const string ProductModel_Table_Name = "Shop.Product_Models";
        public const string ProductPrice_Table_Name = "Shop.Product_Prices";
        public const string ProductReview_Table_Name = "Shop.Product_Reviews";
        public const string Shipping_Table_Name = "Shop.Shippings";
        public const string ShippingAddress_Table_Name = "Shop.Shipping_Addresses";
        public const string Vendor_Table_Name = "Shop.Vendors";

        //System
        public const string Category_Table_Name = "System.Categories";
        public const string City_Table_Name = "System.Cities";
        public const string Language_Table_Name = "System.Languages";
        public const string Layout_Table_Name = "System.Layouts";
        public const string Menu_Table_Name = "System.Menu_Items";
        public const string PostType_Table_Name = "System.PostTypes";
        public const string Tag_Table_Name = "System.Tags";
        public const string UserMeta_Table_Name = "System.UserMeta";
        public const string Website_Table_Name = "System.Websites";
        public const string WebsiteOptions_Table_Name = "System.Website_Options";
        public const string ErrorLogs_Table_Name = "System.ErrorLogs";
        public const string Currency_Table_Name = "System.Currencies";

        //Security
        public const string User_Table_Name = "Security.Users";
        public const string UserLogin_Table_Name = "Security.User_Logins";
        public const string UserClaim_Table_Name = "Security.User_Claims";
        public const string UserToken_Table_Name = "Security.User_Tokens";
        public const string UserRole_Table_Name = "Security.User_Roles";
        public const string Role_Table_Name = "Security.Roles";
        public const string RoleClaims_Table_Name = "Security.Role_Claims";
    }
}
