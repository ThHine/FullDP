using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.Builder
{
    public class MyProductBuilder : IBuilder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
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
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public string CreatedBy { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public DateTime ModifiedDate { get; internal set; }

        public MyProductBuilder AddAlias(string alias)
        {
            Alias = alias;
            return this;
        }

        public MyProductBuilder AddDescription(string description)
        {
            Description = description;
            return this;
        }

        public MyProductBuilder AddDetail(string detail)
        {
            Detail = detail;
            return this;
        }

        public MyProductBuilder AddId(int id)
        {
            Id = id;
            return this;
        }

        public MyProductBuilder AddImage(string image)
        {
            Image = image;
            return this;
        }

        public MyProductBuilder AddIsActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public MyProductBuilder AddIsFeature(bool isFeature)
        {
            IsFeature = isFeature;
            return this;
        }

        public MyProductBuilder AddIsHome(bool isHome)
        {
            IsHome = isHome;
            return this;
        }

        public MyProductBuilder AddIsHot(bool isHot)
        {
            IsHot = isHot;
            return this;
        }

        public MyProductBuilder AddIsSale(bool isSale)
        {
            IsSale = isSale;
            return this;
        }

        public MyProductBuilder AddOriginalPrice(decimal originalPrice)
        {
            OriginalPrice = originalPrice;
            return this;
        }

        public MyProductBuilder AddPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public MyProductBuilder AddPriceSale(decimal? priceSale)
        {
            PriceSale = priceSale;
            return this;
        }

        public MyProductBuilder AddProductCategoryId(int productCategoryId)
        {
            ProductCategoryId = productCategoryId;
            return this;
        }

        public MyProductBuilder AddProductCode(string productCode)
        {
            ProductCode = productCode;
            return this;
        }

        public MyProductBuilder AddQuantity(int quantity)
        {
            Quantity = quantity;
            return this;
        }

        public MyProductBuilder AddSeoDescription(string seoDescription)
        {
            SeoDescription = seoDescription;
            return this;
        }

        public MyProductBuilder AddSeoKeywords(string seoKeywords)
        {
            SeoKeywords = seoKeywords;
            return this;
        }
        public MyProductBuilder AddCreatedBy(string createdBy)
        {
            CreatedBy = createdBy;
            return this;
        }
        public MyProductBuilder AddCreatedDate(DateTime createdDate)
        {
            CreatedDate = createdDate;
            return this;
        }

        public MyProductBuilder AddModifiedDate(DateTime modifiedDate)
        {
            ModifiedDate = modifiedDate;
            return this;
        }
        public MyProductBuilder AddSeoTitle(string seoTitle)
        {
            SeoTitle = seoTitle;
            return this;
        }

        public MyProductBuilder AddTitle(string title)
        {
            Title = title;
            return this;
        }

        public MyProductBuilder AddViewCount(int viewCount)
        {
            ViewCount = viewCount;
            return this;
        }

        public Product Build()
        {
            return new Product(Id, Title, Alias, ProductCode, Description, Detail, Image, OriginalPrice, Price, PriceSale, Quantity, ViewCount, IsHome, IsSale, IsFeature, IsHot, IsActive, ProductCategoryId, SeoTitle, SeoDescription, SeoKeywords, CreatedBy, CreatedDate, ModifiedDate);
        }

       
    }
}