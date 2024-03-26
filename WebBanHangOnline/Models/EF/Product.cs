using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.DesignPatterns.Builder;
using WebBanHangOnline.DesignPatterns.CreationalPatterns.Prototype;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract, ProductPrototype
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Alias { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        public int ProductCategoryId { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public ProductPrototype Clone()
        {
            var newProduct = new MyProductBuilder()
            .AddTitle(Title)
            .AddProductCode(ProductCode)
            .AddDescription(Description)
            .AddDetail(Detail)
            .AddImage(Image)
            .AddPrice(Price)
            .AddPriceSale(PriceSale)
            .AddQuantity(Quantity)
            .AddIsHome(IsHome)
            .AddIsSale(IsSale)
            .AddIsFeature(IsFeature)
            .AddIsHot(IsHot)
            .AddProductCategoryId(ProductCategoryId)
            .AddSeoTitle(SeoTitle)
            .AddSeoDescription(SeoDescription)
            .AddSeoKeywords(SeoKeywords)
            .AddCreatedBy(CreatedBy)
            .AddCreatedDate(CreatedDate)
            .AddModifiedDate(ModifiedDate)
            .AddAlias(Alias)
            .AddIsActive(IsActive)
            .AddViewCount(ViewCount)
            .AddOriginalPrice(OriginalPrice)
            .Build();
            return newProduct;
        }

        public Product(int id, string title, string alias, string productCode, string description, string detail, string image, decimal originalPrice, decimal price, decimal? priceSale, int quantity, int viewCount, bool isHome, bool isSale, bool isFeature, bool isHot, bool isActive, int productCategoryId, string seoTitle, string seoDescription, string seoKeywords, string createdBy, DateTime createdDate, DateTime modifiedDate)
        {
            Id = id;
            Title = title;
            Alias = alias;
            ProductCode = productCode;
            Description = description;
            Detail = detail;
            Image = image;
            OriginalPrice = originalPrice;
            Price = price;
            PriceSale = priceSale;
            Quantity = quantity;
            ViewCount = viewCount;
            IsHome = isHome;
            IsSale = isSale;
            IsFeature = isFeature;
            IsHot = isHot;
            IsActive = isActive;
            ProductCategoryId = productCategoryId;
            SeoTitle = seoTitle;
            SeoDescription = seoDescription;
            SeoKeywords = seoKeywords;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
        }
    }
}