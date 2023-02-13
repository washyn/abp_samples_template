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
