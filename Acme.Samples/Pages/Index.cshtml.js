(function ($) {
    $(function () {
        uploadInput = document.querySelector('#fileImageInput');
        image = document.querySelector('#imageToChange');
        butonSave = document.querySelector('#saveButton');
        butonRestoreDefault = document.querySelector('#restoreDefault');
        cropper = '';
        
        function destroyCroperIfExists() {
            if(typeof cropper !== 'string'){
                cropper.destroy();
            }
        }
        
        uploadInput.addEventListener('change', e => {
            if (e.target.files.length) {
                destroyCroperIfExists();
                const reader = new FileReader();
                reader.onload = function(event) {
                    console.log("loaded")
                    image.src = this.result;
                    cropper = new Cropper(image, {
                        aspectRatio: 1,
                        viewMode: 1,
                    });
                };
                reader.readAsDataURL(e.target.files[0]);
            }
        });
        
        butonSave.addEventListener('click', e => {
            e.preventDefault();
            cropper.getCroppedCanvas().toBlob(function (blob) {
                let formData = new FormData();
                formData.append("file", blob, uploadInput.files[0].name);
                abp.ajax({
                    type: 'POST',
                    url: '/account/profile-picture-file',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success() {
                        abp.notify.success("Upload success.");
                    },
                    error() {
                        abp.notify.warn("Upload error.");
                    },
                });
            });
        });
        
    });
})(jQuery);