// https://stackoverflow.com/questions/25882999/set-focus-to-search-text-field-when-we-click-on-select-2-drop-down
$(function () {
    $(document).on('select2:open', () => {
        setTimeout(()=>{
            document.querySelector('.select2-search__field').focus();
        }, 100);
    });
});