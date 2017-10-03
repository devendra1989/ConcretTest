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
        public ActionResult Index(int page = Pagination.Page, string features = "", string merchant = "", string brand = "", int minPrice = Prices.MinPrice, int maxPrice = Prices.MaxPrice, string searchkey = "")
        {
            ProductRepository productRepository = new ProductRepository();
            try
            {
                ProductFilter productFilter = new ProductFilter();
                productFilter.PageNumber = page;
                productFilter.PageSize = Pagination.PageSize;
                productFilter.FeatureFilter = features;
                productFilter.MerchantNameFilter = merchant;
                productFilter.BrandNameFilter = brand;
                productFilter.MinPriceFilter = minPrice;
                productFilter.MaxPriceFilter = maxPrice;
                productFilter.Filter = searchkey;
                //productFilter.NameFilter = "";

                var filterDataList = productRepository.GetFilerData();
                ViewBag.FeatureList = filterDataList.FeatureList;
                ViewBag.BrandList = filterDataList.BrandList;
                ViewBag.MerchantList = filterDataList.MerchantList;
                var productList = productRepository.GetProducts(productFilter);
                productList.Page = page;
                productList.TotalPages = (int)Math.Ceiling((double)productList.TotalCount / Pagination.PageSize);
                return View(productList);
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
    }
}