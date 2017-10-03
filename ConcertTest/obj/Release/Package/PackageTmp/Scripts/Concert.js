function pageFilter(data, page) {
    var params = getUrlVars();
    redefineFilter(page, params.features, params.merchant, params.brand, params.minPrice, params.maxPrice, params.searchKey);
}

function redefineFilter(page, features, merchant, brand, minPrice, maxPrice, searchKey) {
    var urlString = '';
    if (features != undefined && (features != "" || features != '')) {
        urlString += "&features=" + features;
    }
    if (merchant != undefined && (merchant != "" || merchant != '')) {
        urlString += "&merchant=" + merchant;
    }
    if (brand != undefined && (brand != "" || brand != '')) {
        urlString += "&brand=" + brand;
    }
    if (minPrice != null && (minPrice <= maxPrice)) {
        urlString += "&minPrice=" + minPrice;
    }
    if (maxPrice != null && (minPrice <= maxPrice)) {
        if (maxPrice > 1) {
            urlString += "&maxPrice=" + maxPrice;
        }
    }
    if (searchKey != undefined && (searchKey != "" || searchKey != '')) {
        urlString += "&searchkey=" + searchKey;
    }
    if (page == undefined || page == 0) {
        page = 1;
    }
      
    var url = baseurl + 'Home/Index?page=' + page + urlString;
    location.href = url;
}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function SetFilter() {
    var getFilterValues = getUrlVars();
    if (getFilterValues.features != undefined) {
        var fetArr = getFilterValues.features.split(',');
        $.each(fetArr, function (index, value) {
            $('#feature_' + value).prop('checked', true);
        });
    }

    if (getFilterValues.brand != undefined) {
        var brandArr = getFilterValues.brand.split(',');
        $.each(brandArr, function (index, value) {
            $('#brand_' + value).prop('checked', true);
        });
    }
    if (getFilterValues.merchant != undefined) {
          
        var merchantArr = getFilterValues.merchant.split(',');
        $.each(merchantArr, function (index, value) {
            $('#merchant_' + value).prop('checked', true);
        });
    }
}

function Pagination(totalPages, page) {

    $('#pagination-demo').twbsPagination({
        totalPages: totalPages,
        visiblePages: 5,
        startPage: page,
        onPageClick: pageFilter,
        initiateStartPageClick: false
    });
}