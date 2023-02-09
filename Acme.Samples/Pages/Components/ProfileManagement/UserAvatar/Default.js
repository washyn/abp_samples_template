$(function () {
    let $form = $("#formUpload");
    let $buttom = $("#SaveButton");
    $form.on('submit', function (event) {
        event.preventDefault();
        let $thisElement = $(this);
        // if (!$(this).valid()) {
        //     return;
        // }
        //
        // $thisElement.ajaxSubmit({
        //     url: logoPathRequest,
        // });
        


        $thisElement.ajaxSubmit({
            url:"/account/profile-picture-file"
        });
        // setTimeout(function () {
        //     window.location.reload();
        // },250)
        abp.log.debug("test")
        abp.notify.info("Enviado")
    });

    $buttom.on('click', function (eve) {
        eve.preventDefault();

        $form.ajaxSubmit({
            url:"/account/profile-picture-file"
        });
        setTimeout(function () {
            window.location.reload();
        },250)
        abp.log.debug("test")
        abp.notify.info("Enviado")
    });
    
});