abp.log.debug("initialize");

(function () {
    abp.widgets.UserStatisticWidget = function ($wrapper) {
        var _chart;
        var _latestFilters = {};

        var getFilters = function () {
            let objREs = $wrapper.find('.filterForm').serializeFormToObject();
            return objREs;
        }

        var refresh = function (filters) {
            _latestFilters = filters;
            washyn.widgets.userStatistic.getUserStatisticWidget(filters)
                .then(function (result) {
                    let dataProcessed = {};
                    $.each(result.data,function (key,value) {
                        dataProcessed[abp.libs.datatables.defaultRenderers.date(key)] = value;
                    });
                    _chart.data = {
                        datasets:[
                            {
                                data: dataProcessed,
                                label: 'Estadisticas de uso por dias',
                                backgroundColor: 'rgba(255, 132, 132, 1)'
                            }
                        ]
                    };
                    _chart.update();
                });
        };

        var init = function (filters) {
            _chart = new Chart($wrapper.find('.UserStatisticChart'),
                {
                    type: 'bar',
                });
            refresh(filters)
            
            $wrapper.find('.filterForm')
                .on('change', function () {
                    refresh($.extend(_latestFilters, getFilters()));
                });
            $wrapper.find('.filterForm')
                .on('submit', function () {
                    refresh($.extend(_latestFilters, getFilters()));
                });

            $wrapper.find('.refreshButton')
                .on('click', function () {
                    refresh($.extend(_latestFilters, getFilters()));
                });
        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();
