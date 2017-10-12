function pageFilter(data, page) {
    pageNumber = page;
    debugger;
    redefineFilter(page, features, merchant, brands, minValue, maxValue, searchKey);
   
}

function redefineFilter(page, features, merchant, brands, minPrice, maxPrice, searchKey) {
    var productFilter = {};
    productFilter.PageNumber = page;
    productFilter.MinPriceFilter = minPrice;
    productFilter.MaxPriceFilter = maxPrice;
    productFilter.MerchantNameFilter = merchant;
    productFilter.BrandNameFilter = brands;
    productFilter.FeatureFilter = features;
    productFilter.Filter = searchKey;
    $('.img-loader').show();
    $.ajax({
        url: baseurl + 'Home/Product',
        type: 'POST',
        cache: false,
        contentType: 'application/json',
        data: JSON.stringify(productFilter),
        success: function (result) {
            debugger;
            $('#product-list').html(result);
            $('.img-loader').hide();
        }, error: function (xhr, status, error) {
            $('.img-loader').hide();
        }
    });
}