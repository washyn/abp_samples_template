(function ($) {
    $(function () {
        $("#formSol").on('submit', function (event) {
            event.preventDefault();

            if (!$(this).valid()) {
                return;
            }

            var formData = $(this).serializeFormToObject();
            
            acme.samples.services.datosSol.update(formData)
                .then(function (res) {
                    $(document).trigger("AbpSettingSaved");
                });
            abp.log.debug(formData)
        });
    });
})(jQuery);
