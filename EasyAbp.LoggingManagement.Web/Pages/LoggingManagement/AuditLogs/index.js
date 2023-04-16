$(function () {

    var l = abp.localization.getResource('EasyAbpLoggingManagement');

    // var service = easyAbp.loggingManagement.systemLogs.systemLog;
    var service = easyAbp.loggingManagement.web.easyAbp.loggingManagement.systemLogs.auditLog;
    var detailModal = new abp.ModalManager(abp.appPath + 'LoggingManagement/AuditLogs/DetailModal');
    let $form = $("#formQuery");
    
    function getQueryData() {
        let formData = $form.serializeFormToObject();
        abp.log.debug(formData);
        return formData.queryModel;
    }
    
    var dataTable = $('#AuditLogTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "desc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, getQueryData),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Detail'),
                                action: function (data) {
                                    abp.log.debug(data);
                                    detailModal.open({id: data.record.id});
                                }
                            },
                            {
                                text: l('DetailPage'),
                                action: function (data) {
                                    window.location = "/LoggingManagement/AuditLogs/Detail?id=" + data.record.id;
                                }
                            }
                        ]
                }
            },
            {
                title: 'Execution time',
                data: "executionTime",
                render: function (data) {
                    return abp.libs.datatables.defaultRenderers.datetime(data);
                }
            },
            {
                title: 'Execution duration',
                data: "executionDuration"
            },
            {
                title: 'Usuario',
                data: "userName" },
            {
                title: 'Success',
                // sortable: false,
                data: "exceptions",
                render: function (data) {
                    if (data){
                        return abp.libs.datatables.defaultRenderers.boolean(false);
                    }
                    return abp.libs.datatables.defaultRenderers.boolean(true);
                }
            },
           
            {
                title: 'Url',
                data: "url",
                render: function (data) {
                    return abp.utils.truncateStringWithPostfix(data, 50)
                }
            },
            {
                title: 'Ip cliente',
                data: "clientIpAddress"
            },
            // {
            //     title: 'Tenant',
            //     data: "tenantName" 
            // },
            // {
            //     title: 'Navegador',
            //     data: "browserInfo",
            //     render: function (data) {
            //         return abp.utils.truncateStringWithPostfix(data, 30)
            //     }
            // },
        ]
    }));

    
    $('#clear-button').click(function (e) {
        // not works
        // $(".auto-complete-select").trigger("reset").trigger("change");
        // $("#QueryModel_UserId").trigger("reset").trigger("change");
        // $selectEl.val('');
        // $selectEl.trigger('reset.select2');
        // $selectEl.trigger('change.select2');
        // $selectEl.val('');
        // $selectEl.trigger('reset.select2');
        // $selectEl.trigger('change.select2');
        // let $selectEl = $('#QueryModel_UserId');
        // let $selectEl = $('#auto-complete-select');
        // $selectEl.val('');
        // $selectEl.trigger('reset.select2');
        // $selectEl.trigger('change.select2');
        $form.resetForm();
        dataTable.ajax.reload();
    })
    $('#search-button').click(function (e) {
        dataTable.ajax.reload()
    })
});