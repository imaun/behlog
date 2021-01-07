using System;
using System.Collections.Generic;
using Behlog.Core.Models.System;
using Behlog.Core.Models.Enum;
using Behlog.Core.Models.Base;
using Behlog.Core.Models.Content;

namespace Behlog.Core.Models.Shop {

    public class Product: HasMetaData {

        public Product() {
            Posts = new HashSet<Post>();
            Orders = new HashSet<Order>();
            Meta = new HashSet<ProductMeta>();
            PriceHistory = new HashSet<ProductPrice>();
            Reviews = new HashSet<ProductReview>();
            Models = new HashSet<ProductModel>();
            BasketItems = new HashSet<BasketItem>();
        }

        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        #region Content
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// An Html or Markdown template that contains parameters and renders on runtime.
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Get or sets a value determines the type of description's body that renders in runtime.
        /// </summary>
        public PostBodyType BodyType { get; set; }

        #endregion

        /// <summary>
        /// Get or sets <see cref="Category"/> Id. If null, the product will uncategorized.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Determines that the product can be ordered or not.
        /// </summary>
        public bool Orderable { get; set; }

        /// <summary>
        /// Get or sets a value that shows the product can be pre ordered.
        /// </summary>
        public bool AvailableForPreOrder { get; set; }

        /// <summary>
        /// Get or sets the start date and time for product availability for pre order if <see cref="AvailableForPreOrder"/> is true.
        /// </summary>
        public DateTime? PreOrderStartDate { get; set; }

        /// <summary>
        /// Get or sets the finish date that the product will no longer available for pre order.
        /// </summary>
        public DateTime? PreOrderFinishDate { get; set; }

        public ProductStatus Status { get; set; }

        /// <summary>
        /// Get or sets product's cost.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// Get or sets sell price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Get or sets a value indicating the number of product available in store's stock.
        /// </summary>
        public int Stock { get; set; }
        
        /// <summary>
        /// Get or sets a value indicating stock Unit name of the product.
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// Get or sets a value that determines Tax percentage that will add to total price.
        /// </summary>
        public decimal? TaxPercent { get; set; }

        /// <summary>
        /// Get or sets a value indicating total Tax value that will add to total price of the product.
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// If true, Behlog will check stock value first, if <see cref="Stock"/> is zero, Order will not issued.
        /// </summary>
        public bool CheckStockBeforeOrder { get; set; }

        /// <summary>
        /// Get ot sets a valude indicating minimum <see cref="Stock"/> value for this product.
        /// </summary>
        public int? MinStock { get; set; }

        /// <summary>
        /// Get or sets a valude indicating the product is a digital downloadable product.
        /// </summary>
        public bool Downloadable { get; set; }

        /// <summary>
        /// Get or sets a valude that limit the number of times this digital product can be downloaded.
        /// Set to 0 to allow unlimited downloads.
        /// </summary>
        public int MaxDownloads { get; set; }

        /// <summary>
        /// The SKU is composed of an alphanumeric combination of eight-or-so characters. The characters are a code that the price, product details, and the manufacturer
        /// A stock-keeping unit (SKU) is a scannable bar code, most often seen printed on product labels in a retail store. 
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Get or sets a value indicating whether this product is new or not.
        /// </summary>
        public bool NewProduct { get; set; }

        /// <summary>
        /// Get or sets start date that this product will consider as a new product.
        /// </summary>
        public DateTime? NewProductStartDate { get; set; }

        /// <summary>
        /// Get or sets finish date that this product will no longer consider as a new product.
        /// </summary>
        public DateTime? NewProductFinishDate { get; set; }

        /// <summary>
        /// Gets or sets the product's weight.
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Get or sets the product's height.
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Get or sets the product's width.
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// Get or sets the product's size.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Get or sets the product's color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Get or sets the start date of product availability for sale. 
        /// If set, Before this date, product is not available for sale.
        /// </summary>
        public DateTime? AvailabilityStartDate { get; set; }

        /// <summary>
        /// Get or sets the finish date of product availibility for sale. 
        /// If set, After this date, product will no longer available for sale.
        /// </summary>
        public DateTime? AvailabilityFinishDate { get; set; }

        /// <summary>
        /// Get or sets a value that will be used in sorting.
        /// </summary>
        public int OrderNumber { get; set; }

        #region SEO Related

        /// <summary>
        /// Get or sets a value determines meta description that can be placed in meta 
        /// tag of the HTML document containing the product's detail.
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Get or sets a value determines meta robots that can be placed in meta tag 
        /// of the HTML document containing the product's detail.
        /// </summary>
        public string MetaRobots { get; set; }

        #endregion

        public int? VendorId { get; set; }

        public int? BrandId { get; set; }

        public int WebsiteId { get; set; }

        #endregion

        #region Navigations
        public Website Website { get; set; }
        public Category Category { get; set; }
        public Vendor Vendor { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductMeta> Meta { get; set; }
        public ICollection<ProductPrice> PriceHistory { get; set; }
        public ICollection<ProductReview> Reviews { get; set; }
        public ICollection<ProductModel> Models { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        #endregion 
    }
}
