(function () {
    abp.widgets.ImagesWidget = function ($wrapper) {
        var widgetManager = $wrapper.data('abp-widget-manager');
        console.log("$wrapper");
        console.log($wrapper);
        console.log(widgetManager);
        
        var getFilters = function () {
            return {};
        }

        var addValidFormClass = function ($elementSelector) {
            $elementSelector.removeClass("is-invalid");
            $elementSelector.addClass("is-valid");
        };

        var addInValidFormClass = function ($elementSelector) {
            $elementSelector.removeClass("is-valid");
            $elementSelector.addClass("is-invalid");
        };
        
        // la libreria de validadion de form, debe tener un metodo interno que valida por elemento y no por form
        // esta expuesto el que valida form, pero internamente debe tener, 
        // TODO: usarlo...
        var validateForm = function () {
            let resultIsValid = true;
            $wrapper.find('.tableFooterForm input').each(function (item) {
                let $element = $(this);
                if (!$element.val()){
                    addInValidFormClass($element)
                    $element.focus();
                    resultIsValid = false;
                }else {
                    addValidFormClass($element)
                }
            });
            return resultIsValid;  
        };

        var isValidForm = function () {
            return true;
        };
        
        var buildFormData = function () {
            let formData = new FormData()
            $inputs = $wrapper.find('.tableFooterForm input').each(function (el) {
                $element = $(this);
                if ($element.attr("type") === "text"){
                    formData.append($element.prop("name"), $element.val());
                }
                if ($element.attr("type") === "file"){
                    element = $element.get(0);
                    file = element.files[0];
                    formData.append(element.name, file,file.name);
                }
            });
            return formData;
        }
        
        var submitForm = function () {
            abp.ajax({
                url: "/files",
                type: 'POST',
                data: buildFormData(),
                success: function (data) {
                    abp.notify.success("Archivo subido.");
                    widgetManager.refresh($wrapper);
                },
                error: function (e) {
                    abp.notify.error("Error al subir archivo.");
                },
                cache: false,
                contentType: false,
                processData: false
            });
        }
        
        var init = function () {
            
            $wrapper.find('.uploadButton')
                .on('click', function () {
                    let res = validateForm();
                    if (res){
                        submitForm();
                    }
                });

            $wrapper.find('.deleteFileItem').each(function (el) {
                $(this).on('click', function (event) {
                    event.preventDefault();
                    $currentElement = $(this);
                    console.log("$currentElement")
                    console.log($currentElement)
                    let fileId = $currentElement.data("fileId");
                    let fileName = $currentElement.data("fileName");
                    abp.message.confirm(fileName,"Esta seguro  de eliminar?", function (confirm) {
                        if (confirm){
                            deleteUrl = "/files/" + fileId;
                            abp.ajax({
                                url: deleteUrl,
                                type: 'DELETE',
                                success: function (data) {
                                    abp.log.debug("element for delete", fileId);
                                    widgetManager.refresh($wrapper);
                                    abp.notify.success("Eliminado correctamente.");
                                },
                                error: function (e) {
                                    abp.notify.error("Error al eliminar archivo.");
                                },
                                cache: false,
                                contentType: false,
                                processData: false
                            });
                        }
                    });
                });
            });
        };

        return {
            // getFilters: getFilters,
            init: init,
            // refresh: refresh
        };
    };
})();
