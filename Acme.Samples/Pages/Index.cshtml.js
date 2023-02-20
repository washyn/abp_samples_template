(function(){
    let $button = $("#openButton");
    var modal = new abp.ModalManager({
        viewUrl: '/ModalSample'
    });

    $button.on("click", function (e) {
        e.preventDefault();
        modal.open();
    });
})();



$(function () {
    // var l = abp.localization.getResource("CmsKit");

    // var createModal = new abp.ModalManager(abp.appPath + "CmsKit/Tags/CreateModal");
    // var updateModal = new abp.ModalManager(abp.appPath + "CmsKit/Tags/EditModal");

    // var service = volo.cmsKit.admin.tags.tagAdmin;

    // var getFilter = function () {
    //     return {
    //         filter: $('#CmsKitTagsWrapper input.page-search-filter-text').val()
    //     };
    // };
    // abp.libs.datatables.createAjax(service.getList, getFilter);



    // $('#CmsKitTagsWrapper form.page-search-form').on('submit', function (e) {
    //     e.preventDefault();
    //     dataTable.ajax.reload();
    // });

    // $('#AbpContentToolbar button[name=NewButton]').on('click', function (e) {
    //     e.preventDefault();
    //     createModal.open();
    // });

    // createModal.onResult(function () {
    //     dataTable.ajax.reload();
    // });

    // updateModal.onResult(function () {
    //     dataTable.ajax.reload();
    // });
});