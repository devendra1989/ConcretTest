var features;
var brands;
var merchant;
var rangValue;
var pageNumber;
var minValue;
var maxValue;
var searchKey;


$(function () {

    $(".pro-range-filter").asRange({
        range: true,
        limit: true,
        step: 100,
        min: 1,
        max: 30000,
        tip: {
            active: 'onMove'
        }
    });

    $('.createFilter').on('click', function () {
        $('#txtSearch').val('');
        features = $('.feature-data:checked').map(function () { return this.value; }).get().join(',')
        brands = $('.brand-data:checked').map(function () { return this.value; }).get().join(',')
        merchant = $('.merchant-data:checked').map(function () { return this.value; }).get().join(',')
        rangValue = $('.range-data').asRange('val');
        minValue = rangValue[0];
        maxValue = rangValue[1];
        pageNumber = 1;
        redefineFilter(pageNumber, features, merchant, brands, minValue, maxValue, null);
    });

    $('#btnSeach').on('click', function () {
          
        var search = $('#txtSearch').val();
        features = $('.feature-data:checked').map(function () { return this.value; }).get().join(',')
        brands = $('.brand-data:checked').map(function () { return this.value; }).get().join(',')
        merchant = $('.merchant-data:checked').map(function () { return this.value; }).get().join(',')
        rangValue = $('.range-data').asRange('val');
        minValue = rangValue[0];
        maxValue = rangValue[1];
        pageNumber = 1;
        searchKey = search;
        redefineFilter(pageNumber, features, merchant, brands, minValue, maxValue, search);
    });

});