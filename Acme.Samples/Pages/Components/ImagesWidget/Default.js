abp.log.debug("initialize");

(function () {
    abp.widgets.ImagesWidget = function ($wrapper) {
        var _chart;
        var _latestFilters = {};
        abp.log.debug("$wrapper");
        abp.log.debug($wrapper);
        var getFilters = function () {
            // let objREs = $wrapper.find('.filterForm').serializeFormToObject();
            // abp.log.debug("widged filter")
            // abp.log.debug(objREs)
            // return objREs;
            return {};
        }

        var refresh = function (filters) {
            // _latestFilters = filters;
            // acme.samples.pages.components.userStatisticWidget.userStatistic
            // .getUserStatisticWidget(filters)
            //     .then(function (result) {
            //         abp.log.debug(result)
            //         abp.log.debug(result.data)
            //         let dataProcessed = {};
            //         $.each(result.data,function (key,value) {
            //             dataProcessed[abp.libs.datatables.defaultRenderers.date(key)] = value;
            //         });
            //         abp.log.debug("dataProcessed")
            //         abp.log.debug(dataProcessed)
            //         _chart.data = {
            //             datasets:[
            //                 {
            //                     data: dataProcessed,
            //                     label: 'Estadisticas de uso por dias',
            //                     backgroundColor: 'rgba(255, 132, 132, 1)'
            //                 }
            //             ]
            //         };
            //         _chart.update();
            //     });
        };

        var init = function (filters) {
            // _chart = new Chart($wrapper.find('.UserStatisticChart'),
            //     {
            //         type: 'bar',
            //     });
            // refresh(filters)
            //
            // $wrapper.find('.filterForm')
            //     .on('change', function () {
            //         refresh($.extend(_latestFilters, getFilters()));
            //     });
            // $wrapper.find('.filterForm')
            //     .on('submit', function () {
            //         refresh($.extend(_latestFilters, getFilters()));
            //     });
            //
            
            // let $form = $wrapper.find('#formUploadFile');
            // function validateAndSend() {
            //     if ($form.valid()){
            //         abp.log.debug("is valida")
            //         // $form.ajaxSubmit({url:"/files",type: "POST"});
            //         // $form.resetForm();
            //     }else{
            //         abp.log.debug("not valid")
            //     }
            // }
            //
            //
            // $form.on('submit', function (e) {
            //         e.preventDefault();
            //         validateAndSend();
            //     });
            //
            // let $upload = $wrapper.find('.uploadButton');
            // $upload.on('click', function (e) {
            //     e.preventDefault();
            //     validateAndSend();
            // });
            //
           
        };

        return {
            getFilters: getFilters,
            init: init,
            refresh: refresh
        };
    };
})();
