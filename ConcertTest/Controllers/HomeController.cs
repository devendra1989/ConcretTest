using ConcertTest.Common;
using ConcertTest.DataAccess;
using ConcertTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConcertTest.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index(int page = Pagination.Page, string features = "", string merchant = "", string brand = "", int minPrice = Prices.MinPrice, int maxPrice = Prices.MaxPrice, string searchkey = "")
        public ActionResult Index()
        {
            ProductRepository productRepository = new ProductRepository();
            try
            {
                var filterDataList = productRepository.GetFilerData();
                ViewBag.FeatureList = filterDataList.FeatureList;
                ViewBag.BrandList = filterDataList.BrandList;
                ViewBag.MerchantList = filterDataList.MerchantList;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.FeatureList = new List<FeatureModel>();
                ViewBag.BrandList = new List<BrandModel>();
                ViewBag.MerchantList = new List<MerchantModel>();
                return View(new List<ProductModel>());
                throw;
            }
        }


        public ActionResult ProductDetail(int id)
        {
            ProductRepository productRepository = new ProductRepository();
            try
            {
                var productDetail = productRepository.ProductDeatil(id);
                return View(productDetail);
            }
            catch (Exception)
            {
                return View(new ProductDetailModel());
                throw;
            }

        }

        public ActionResult Product(ProductFilter productFilter)
        {
            ProductRepository productRepository = new ProductRepository();
            try
            {
                productFilter.PageNumber = productFilter.PageNumber > 0 ? productFilter.PageNumber : Pagination.Page;
                productFilter.PageSize = Pagination.PageSize;
                productFilter.FeatureFilter = string.IsNullOrEmpty(productFilter.FeatureFilter) ? "" : productFilter.FeatureFilter;
                productFilter.MerchantNameFilter = string.IsNullOrEmpty(productFilter.MerchantNameFilter) ? "" : productFilter.MerchantNameFilter;
                productFilter.BrandNameFilter = string.IsNullOrEmpty(productFilter.BrandNameFilter) ? "" : productFilter.BrandNameFilter;
                productFilter.MinPriceFilter = productFilter.MinPriceFilter > 0 ? productFilter.MinPriceFilter : Prices.MinPrice;
                productFilter.MaxPriceFilter = productFilter.MaxPriceFilter== productFilter.MinPriceFilter || productFilter.MaxPriceFilter==0 ? Prices.MaxPrice : productFilter.MaxPriceFilter;
                productFilter.Filter = string.IsNullOrEmpty(productFilter.Filter) ? "" : productFilter.Filter;
                productFilter.NameFilter = "";

                //var filterDataList = productRepository.GetFilerData();
                //ViewBag.FeatureList = filterDataList.FeatureList;
                //ViewBag.BrandList = filterDataList.BrandList;
                //ViewBag.MerchantList = filterDataList.MerchantList;
                var productList = productRepository.GetProducts(productFilter);
                productList.Page = productFilter.PageNumber;
                productList.TotalPages = (int)Math.Ceiling((double)productList.TotalCount / Pagination.PageSize);
                productList.ProductFilter = productFilter;
                return PartialView("_Product", productList);
            }
            catch (Exception ex)
            {
                ViewBag.FeatureList = new List<FeatureModel>();
                ViewBag.BrandList = new List<BrandModel>();
                ViewBag.MerchantList = new List<MerchantModel>();
                return View(new List<ProductModel>());
                throw;
            }
        }
    }
}