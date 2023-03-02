(function ($) {
    $(function () {
        setTimeout(function () {
            var $saveButton = $('#SaveButton');
            var imageLogo = document.getElementById('logoImage');
            var uploadInput = document.getElementById('formFile');
            var cropperReference = '';

            function destroyCroperIfExists() {
                if(typeof cropperReference !== 'string'){
                    cropperReference.destroy();
                }
            }

            uploadInput.addEventListener('change', e => {
                if (e.target.files.length) {
                    destroyCroperIfExists();
                    const reader = new FileReader();
                    reader.onload = function(event) {
                        console.log("loaded")
                        imageLogo.src = this.result;
                        cropperReference = new Cropper(imageLogo, {
                            aspectRatio: 1,
                            viewMode: 1,
                        });
                    };
                    reader.readAsDataURL(e.target.files[0]);
                }
            });

            $saveButton.on('click', function(e) {
                e.preventDefault();
                if (uploadInput.files.length){
                    cropperReference.getCroppedCanvas({ width: 120, height: 120 }).toBlob(function (blob) {
                        let formData = new FormData();
                        formData.append("logo", blob, uploadInput.files[0].name);
                        abp.ajax({
                            type: 'POST',
                            url: '/logo',
                            data: formData,
                            processData: false,
                            contentType: false,
                            success() {
                                window.location.reload();
                            },
                            error() {
                                abp.notify.warn("Upload error.");
                            },
                        });
                    });
                }else{
                    abp.notify.warn("Select one file first.");
                }
            });
        }, 200);
    });
})(jQuery);