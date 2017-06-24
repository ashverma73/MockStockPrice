
if (!String.prototype.supplant) {
    String.prototype.supplant = function (o) {
        return this.replace(/{([^{}]*)}/g,
            function (a, b) {
                var r = o[b];
                return typeof r === 'string' || typeof r === 'number' ? r : a;
            }
        );
    };
}



$(function () {
    var ticker = $.connection.stockPrice,
        up = '▲',
        down = '▼',
        rowTemplate = '<tr data-symbol="{Ticker}"><td>{Ticker}</td><td>{Name}</td><td>{PxLast}</td><td>{CurrentPrice}</td><td class="{DirectionTextClass}">{Chg}</td><td><span class="dir {DirectionClass}">{Direction}</span></td></tr>';
     // Start the connection
    $.connection.hub.start()
        .then(init)
        .then(function () {
            return true;
        })
    function init() {
        return ticker.server.reset().done(function (stocks) {
          //  $("#tblStocks tbody tr").remove();
            
        });
    }

    function formatStock(stock) {
        return $.extend(stock, {
            Direction: stock.Chg == 0 ? '' : stock.Chg >= 0 ? up : down,
            DirectionClass: stock.Chg === 0 ? 'even' : stock.Chg >= 0 ? 'up' : 'down',
            DirectionTextClass: stock.Chg === 0 ? 'even' : stock.Chg >= 0 ? 'upText' : 'downText'
        });
    }


    // Add client-side hub methods that the server will call
    $.extend(ticker.client, {
        updateStockPrice: function (stock) {
         //   $("#tblStocks tbody tr").remove();
            var displayStock = formatStock(stock),
                $row = $(rowTemplate.supplant(displayStock));
            $('#tblStocks tbody').find('tr[data-symbol=' + stock.Ticker + ']').replaceWith($row);
        
             
        },

        marketReset: function () {
            return init();
        }
    });

});
