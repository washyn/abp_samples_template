(function ($) {
    $(function () {
        setTimeout(function () {
            // 
            var $saveButton = $('.formPassword');
            var $formFileCert = $('.formFileCert');
            
            $saveButton.on('submit', function(e) {
                e.preventDefault();
                let formData = $saveButton.serializeFormToObject();
                console.log(formData);
                abp.ajax({
                    type: 'POST',
                    url: '/billing-certificate/password',
                    data: JSON.stringify(formData),
                    success() {
                        $(document).trigger("AbpSettingSaved");
                    },
                    error() {
                        abp.notify.warn("Error al cambiar contrasena.");
                    },
                });
            });

            $formFileCert.on('submit', function(e) {
                e.preventDefault();
                $formFileCert.ajaxSubmit({
                    success() {
                        $(document).trigger("AbpSettingSaved");
                    },
                    error() {
                        abp.notify.warn("Error al subir archivo.");
                    },
                });
            });
        }, 200);
    });
})(jQuery);