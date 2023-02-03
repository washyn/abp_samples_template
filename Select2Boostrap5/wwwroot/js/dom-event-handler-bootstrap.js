(function ($) {

    abp.dom = abp.dom || {};

    abp.dom.initializers = abp.dom.initializers || {};
    
    abp.dom.initializers.initializeAutocompleteSelects = function ($autocompleteSelects) {
        if ($autocompleteSelects.length) {
            $autocompleteSelects.each(function () {
                let $select = $(this);
                let url = $(this).data("autocompleteApiUrl");
                let displayName = $(this).data("autocompleteDisplayProperty");
                let displayValue = $(this).data("autocompleteValueProperty");
                let itemsPropertyName = $(this).data("autocompleteItemsProperty");
                let filterParamName = $(this).data("autocompleteFilterParamName");
                let selectedText = $(this).data("autocompleteSelectedItemName");
                let parentSelector = $(this).data("autocompleteParentSelector");
                let allowClear = $(this).data("autocompleteAllowClear");
                let placeholder = $(this).data("autocompletePlaceholder");
                if (allowClear && placeholder == undefined) {
                    placeholder = " ";
                }

                if (!parentSelector && $select.parents(".modal.fade").length === 1) {
                    parentSelector = ".modal.fade";
                }
                let name = $(this).attr("name");
                let selectedTextInputName = name + "_Text";
                let selectedTextInput = $('<input>', {
                    type: 'hidden',
                    id: selectedTextInputName,
                    name: selectedTextInputName,
                });
                if (selectedText != "") {
                    selectedTextInput.val(selectedText);
                }
                selectedTextInput.insertAfter($select);
                $select.select2({
                    ajax: {
                        url: url,
                        dataType: "json",
                        delay: 250,
                        cache: true,
                        data: function (params) {
                            let query = {};
                            query[filterParamName] = params.term;
                            return query;
                        },
                        processResults: function (data) {
                            let retVal = [];
                            let items = data;
                            if (itemsPropertyName) {
                                items = data[itemsPropertyName];
                            }

                            items.forEach(function (item, index) {
                                retVal.push({
                                    id: item[displayValue],
                                    text: item[displayName]
                                })
                            });
                            return {
                                results: retVal
                            };
                        }
                    },
                    width: '100%',
                    dropdownParent: parentSelector ? $(parentSelector) : $('body'),
                    theme: 'bootstrap-5',
                    language: abp.localization.currentCulture.cultureName ?? "en",
                    allowClear: allowClear,
                    placeholder: {
                        id: '-1',
                        text: placeholder
                    }
                });
                $select.on('select2:select', function (e) {
                    selectedTextInput.val(e.params.data.text);
                });
            });
        }
    }
    
    $(function () {
        abp.dom.initializers.initializeAutocompleteSelects($('.auto-complete-select'));
    });
})(jQuery);