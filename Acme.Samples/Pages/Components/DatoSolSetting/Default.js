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

        $("#Password").attr("type", "password");
        
        $("#PasswordVisibilityButton").click(function (e) {
            let button = $(this);
            let passwordInput = button.parent().find("input");
            if (!passwordInput) {
                return;
            }

            if (passwordInput.attr("type") === "password") {
                passwordInput.attr("type", "text");
            }
            else {
                passwordInput.attr("type", "password");
            }

            let icon = button.find("i");
            if (icon) {
                icon.toggleClass("fa-eye-slash").toggleClass("fa-eye");
            }
        });
        
    });
})(jQuery);
