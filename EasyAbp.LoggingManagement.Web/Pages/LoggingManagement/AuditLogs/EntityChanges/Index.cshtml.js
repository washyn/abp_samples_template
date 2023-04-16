$(function () {

    var l = abp.localization.getResource('EasyAbpLoggingManagement');

    // var service = easyAbp.loggingManagement.systemLogs.systemLog;
    var service = easyAbp.loggingManagement.web.easyAbp.loggingManagement.systemLogs.entityChange;
    // var detailModal = new abp.ModalManager(abp.appPath + 'LoggingManagement/AuditLogs/DetailModal');
    let $form = $("#formQuery");

    function getQueryData() {
        let formData = $form.serializeFormToObject();
        abp.log.debug(formData);
        return formData.filter;
    }

    var dataTable = $('#EntityChangesTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        // order: [[1, "desc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, getQueryData),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            // {
                            //     text: l('Detail'),
                            //     action: function (data) {
                            //         abp.log.debug(data);
                            //         // detailModal.open({id: data.record.id});
                            //     }
                            // },
                            {
                                text: l('DetailPage'),
                                action: function (data) {
                                    window.location = `/LoggingManagement/AuditLogs/EntityChanges/Details?entityId=${data.record.entityId}&entityTypeFullName=${data.record.entityTypeFullName}`;
                                }
                            }
                        ]
                }
            },
            {
                orderable: false,
                title: 'Entity Id',
                data: "entityId"
            },
            {
                orderable: false,
                title: 'Nombre de tipo de entidad',
                data: 'entityTypeFullName'
            },
            {
                orderable: false,
                title: 'Cambio mas reciente',
                data: "changeTime",
                render: function (data) {
                    return abp.libs.datatables.defaultRenderers.datetime(data);
                }
            },
            // {
            //     orderable: false,
            //     title: 'Tipo de cambio',
            //     data: 'changeType',
            //     render: function (data) {
            //         typeChanges = {
            //             0: 'Created',
            //             1: 'Updated',
            //             2: 'Deleted'
            //         }
            //         return typeChanges[data];
            //     }
            // },
            // 
            {
                orderable: false,
                title: 'cantidad de cambios',
                data: 'cantidadCambios'
            },
        ]
    }));


    $('#clear-button').click(function (e) {
        $form.resetForm();
        dataTable.ajax.reload();
    })
    
    $('#search-button').click(function (e) {
        dataTable.ajax.reload()
    })
    $('#searchButton').click(function (e) {
        dataTable.ajax.reload()
    })
});