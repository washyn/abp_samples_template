$(function () {
    var l = abp.localization.getResource('temp');
    var service = washyn.securityLogs.securityLog;
    var dataTable = $('#Table').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        lengthMenu: [ 10, 14,25, 50, 75, 100 ],
        pageLength: 14,
        lengthChange: false,
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                title: l('Ip'),
                data: "clientIpAddress",
            },
            {
                title: l('Navegador'),
                data: "browserInfo",
            },
            {
                title: l('Accion'),
                data: "action",
            },
            {
                title: l('Fecha'),
                data: "creationTime",
                dataFormat: "datetime"
            },
        ]
    }));
});
