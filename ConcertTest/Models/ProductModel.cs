using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcertTest.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageString { get; set; }

    }
    public class ProductListModel
    {
        public List<ProductModel> ProductList { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
    }

    public class ProductDetailModel : ProductModel
    {
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string MerchantName { get; set; }
        public string FeatureName { get; set; }
    }

    public class FilterDataList
    {
        public List<BrandModel> BrandList { get; set; }
        public List<MerchantModel> MerchantList { get; set; }
        public List<FeatureModel> FeatureList { get; set; }
    }

    public class ProductFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int MinPriceFilter { get; set; }
        public int MaxPriceFilter { get; set; }
        public string NameFilter { get; set; }
        public string MerchantNameFilter { get; set; }
        public string BrandNameFilter { get; set; }
        public string FeatureFilter { get; set; }
        public string Filter { get; set; }
        public int TotalCount { get; set; }

    }


}