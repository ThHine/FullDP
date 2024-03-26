using System;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.DesignPatterns.Builder
{
    interface IBuilder
    {
        MyProductBuilder AddId(int id);
        MyProductBuilder AddTitle(string title);
        MyProductBuilder AddAlias(string alias);
        MyProductBuilder AddProductCode(string productCode);
        MyProductBuilder AddDescription(string description);
        MyProductBuilder AddDetail(string detail);
        MyProductBuilder AddImage(string image);
        MyProductBuilder AddOriginalPrice(decimal originalPrice);
        MyProductBuilder AddPrice(decimal price);
        MyProductBuilder AddPriceSale(decimal? priceSale);
        MyProductBuilder AddQuantity(int quantity);
        MyProductBuilder AddViewCount(int viewCount);
        MyProductBuilder AddIsHome(bool isHome);
        MyProductBuilder AddIsSale(bool isSale);
        MyProductBuilder AddIsFeature(bool isFeature);
        MyProductBuilder AddIsHot(bool isHot);
        MyProductBuilder AddIsActive(bool isActive);
        MyProductBuilder AddProductCategoryId(int productCategoryId);
        MyProductBuilder AddSeoTitle(string seoTitle);
        MyProductBuilder AddSeoDescription(string seoDescription);
        MyProductBuilder AddSeoKeywords(string seoKeywords);
        MyProductBuilder AddCreatedBy(string createdBy);
        MyProductBuilder AddCreatedDate(DateTime CreatedDate);
        MyProductBuilder AddModifiedDate(DateTime modifiedDate);

        Product Build();
    }
}
