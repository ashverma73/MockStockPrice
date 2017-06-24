$(document).ready(function () {
    $("#txtTicker").autocomplete({
        source: function (request, response) {
            var param = { keyword: $('#txtTicker').val() };
            $.ajax({
                url: "Default.aspx/GetTickerList",
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    
                    response($.map(data.d, function (item) {
                        return {
                            value: item
                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        select: function (event, ui) {
            if (ui.item) {
                GetStockPrice(ui.item.value);
            }
        },
        minLength: 1
    });

 

});
     
function GetStockPrice(ticker) {
    
    $("#tblStocks tbody tr").remove();

    $.ajax({
        type: "POST",
        url: "Default.aspx/GetStockPrice",
        data: '{ticker: "' + ticker + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            ($.map(data.d, function (item) {
                var rowTemplate1 = '<tr data-symbol="{Ticker}"><td>{Ticker}</td><td>{Name}</td><td>{PxLast}</td><td>{CurrentPrice}</td><td>{Chg}</td><td><span class="dir {DirectionClass}">{Direction}</span> </td></tr>';
                    
                 $('#tblStocks tbody').append(rowTemplate1.supplant(item));
            }))
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}