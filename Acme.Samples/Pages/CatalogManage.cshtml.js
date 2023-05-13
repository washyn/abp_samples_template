(function(){
    var addModal = new abp.ModalManager(abp.appPath + 'AddModal');
    var addChildModal = new abp.ModalManager(abp.appPath + 'AddChildModal');
    var $addButton = $("#addButton");
    $addButton.on('click', function (btn) {
        btn.preventDefault();
        addModal.open();
    });
    
    addModal.onResult(function () {
        window.location.reload();
    });
    
    
    
    $(document).on('click', '.addChild', function (element) {
        let elm = $(this);
        let code = elm.data("code");
        addChildModal.open({parentCode: code});
    });
    
    addChildModal.onResult(function () {
        window.location.reload();
    });
    
})();