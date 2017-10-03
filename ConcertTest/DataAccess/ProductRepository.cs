using ConcertTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using ConcertTest.Common;

namespace ConcertTest.DataAccess
{
    public class ProductRepository : DataConnection
    {
        public ProductListModel GetProducts(ProductFilter ProductFilter)
        {
            int totalCount;
            var parameters = new DynamicParameters();
            parameters.Add("@PageNumber", ProductFilter.PageNumber);
            parameters.Add("@PageSize ", ProductFilter.PageSize);
            parameters.Add("@MinPriceFilter", ProductFilter.MinPriceFilter);
            parameters.Add("@MaxPriceFilter", ProductFilter.MaxPriceFilter);
            //parameters.Add("@NameFilter", ProductFilter.NameFilter);
            parameters.Add("@MerchantNameFilter", ProductFilter.MerchantNameFilter);
            parameters.Add("@BrandNameFilter", ProductFilter.BrandNameFilter);
            parameters.Add("@FeatureFilter", ProductFilter.FeatureFilter);
            parameters.Add("@Filter", ProductFilter.Filter);
            parameters.Add("@TotalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection _connection = DapperConnection)
            {
                _connection.Open();
                var getdata = _connection.Query<ProductModel>(SPName.USP_GetProductList, parameters, commandType: CommandType.StoredProcedure).ToList();
                totalCount = parameters.Get<int>("@TotalCount");
                var getList = new ProductListModel
                {
                    ProductList = getdata,
                    TotalCount = totalCount
                };
                return getList;
            }
        }
        public FilterDataList GetFilerData()
        {
            var query = @"
                            Select Id,Name From Brand;
                            Select Id,Name From Merchant;
                            Select Id,Name From Features;
                        ";
            using (IDbConnection _connection = DapperConnection)
            {
                using (var multi = _connection.QueryMultiple(query))
                {

                    var data = new FilterDataList
                    {
                        BrandList = multi.Read<BrandModel>().ToList(),
                        MerchantList = multi.Read<MerchantModel>().ToList(),
                        FeatureList = multi.Read<FeatureModel>().ToList(),
                    };
                    return data;
                }
            }

        }

        public ProductDetailModel ProductDeatil(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (IDbConnection _connection = DapperConnection)
            {
                _connection.Open();
                var getdata = _connection.Query<ProductDetailModel>(SPName.USP_ProductDetail, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return getdata;
            }
        }


    }
}