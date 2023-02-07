(function ($) {
    $(function () {

        let logoPathRequest = "/logo/upload";
        
        $("#LogoSettingViewComponent").on('submit', function (event) {
            event.preventDefault();
            let $thisElement = $(this);
            if (!$(this).valid()) {
                return;
            }
            
            $thisElement.ajaxSubmit({
                url: logoPathRequest,
            });
            setTimeout(function () {
                window.location.reload();
            },250)
            abp.log.debug("test")
            abp.notify.info("Enviado")
        });
        
    });
})(jQuery);