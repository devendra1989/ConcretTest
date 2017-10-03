$(function () {
    $(".pro-range-filter").asRange({
        range: true,
        limit: true,
        step: 100,
        min: 1,
        max: 3000,
        tip: {
            active: 'onMove'
        }
    });

    $('.createFilter').on('click', function () {
        debugger
        var params = getUrlVars();
        var features = $('.feature-data:checked').map(function () { return this.value; }).get().join(',')
        var brands = $('.brand-data:checked').map(function () { return this.value; }).get().join(',')
        var merchant = $('.merchant-data:checked').map(function () { return this.value; }).get().join(',')
        var rangValue = $('.range-data').asRange('val');
        params.page = 1;
        redefineFilter(params.page, features, merchant, brands, rangValue[0], rangValue[1]);
    });

    $('#btnSeach').on('click', function () {
          
        var search = $('#txtSearch').val();
        var params = getUrlVars();
        redefineFilter(params.page, '', '', '', null, null, search);
    });

});