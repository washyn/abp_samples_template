(function(){
    abp.log.debug("init");
})();

$(function () {
    // var l = abp.localization.getResource('Billing');
    // acme.samples.pages.catalogEntity.getListParents
    // # TODO: terminar el add child editar child y mejoras
    // mejorar agergando el displayOrder
    
    var service = acme.samples.pages.catalogEntity;
    var createModal = new abp.ModalManager(abp.appPath + 'CatalogCreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'CatalogEditModal');
    var $subItemTitle =  $('#SubItem');
    var filter = {
        code:null  
    };
    
    var dataTable = $('#catalogTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        lengthChange: false,
        pageLength: 12,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, filter),
        columnDefs: [
            // {
            //     rowAction: {
            //         items:
            //             [
            //                 {
            //                     text: l('Edit'),
            //                     visible: abp.auth.isGranted('Billing.Categoria.Update'),
            //                     action: function (data) {
            //                         editModal.open({ id: data.record.id });
            //                     }
            //                 },
            //                 {
            //                     text: l('Delete'),
            //                     visible: abp.auth.isGranted('Billing.Categoria.Delete'),
            //                     confirmMessage: function (data) {
            //                         return l('CategoriaDeletionConfirmationMessage', data.record.id);
            //                     },
            //                     action: function (data) {
            //                         service.delete(data.record.id)
            //                             .then(function () {
            //                                 abp.notify.info(l('SuccessfullyDeleted'));
            //                                 dataTable.ajax.reload();
            //                             });
            //                     }
            //                 }
            //             ]
            //     }
            // },
            // {
            //     title: l('CategoriaNombre'),
            //     data: "nombre"
            // },
            // {
            //     title: l('CategoriaDescripcion'),
            //     data: "descripcion"
            // },
            
            {
                title: "Code",
                data: "code",
            },
            {
                title: "Description",
                data: "description",
            },
            // {
            //     title: "Grouper",
            //     data: "grouper",
            // },
            // {
            //     title: "Parent Code",
            //     data: "parentCode",
            // },
            {
                title: "Extra Description",
                data: "extraDescription",
            },
            {
                title: "Display Order",
                data: "displayOrder",
            },
            {
                title: "Opciones",
                orderable: false,
                render: function (item, arg, data) {
                    abp.log.debug("item")
                    abp.log.debug(item)
                    abp.log.debug("arg")
                    abp.log.debug(arg)
                    abp.log.debug("data")
                    abp.log.debug(data)
                    
                    let editBtn = `<button class="btn btn-sm btn-outline-warning editRow" data-id="${data.id}" data-code="${data.code}">Editar</button>`
                    let verDa = "";
                    let agregarr = "";
                    if (!data.parentCode){
                        verDa = `<button class="btn btn-sm btn-outline-success showDetaile" data-code="${data.code}">Ver</button>`;
                        // agregarr = `<button class="btn btn-sm btn-outline-secondary addItem" data-code="${data.code}">Agregar</button>`;
                    }
                    return `${editBtn} ${verDa} ${agregarr}`;
                }
            },
        ]
    }));

    $(document).on('click', '.showDetaile', function (element) {
        let $codigo = $(this);
        abp.log.debug($codigo)
        filter.code = $codigo.data("code")
        abp.log.debug($codigo.data("code"))
        dataTable.ajax.reload()
    });

    $(document).on('click', '.editRow', function (element) {
        let $codigo = $(this);
        let id = $codigo.data("id")
        editModal.open({id:id})
    });
    
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    
    $('#NewButton').click(function (e) {
        e.preventDefault();
        // ParentCode
        // Grouper
        createModal.open({parentCode: filter.code});
    });
    $('#TopButton').click(function (e) {
        e.preventDefault();
        filter.code = null;
        dataTable.ajax.reload()
    });
   
});

