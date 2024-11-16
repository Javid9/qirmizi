function uploadCreateImage(file, id) {

    let myDropzone = new Dropzone("#" + id,
        {
            url: "/Upload/File?path=" + file,
            addRemoveLinks: true,
            uploadMultiple: false,
            success: function (file, responseText) {
                var fileUrl = JSON.parse(responseText.response);
                $("#image").val(`${fileUrl.path}/${fileUrl.fileName}`);
                file.previewElement.classList.add("dz-success");
            },
            error: function (file, response) {
                file.previewElement.classList.add("dz-error");
            },
            removedfile: function (file) {
                var path = $("#image").val();
                $.ajax({
                    type: "POST",
                    url: "/Upload/RemoveFile",
                    dataType: "json",
                    data: {path: path}
                });
                $("#image").val('');
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
}

function uploadEditImage(file, id){
    var imageUrl = $("#image").val();
    let myDropzone = new Dropzone("#"+id,
        {
            url: "/Upload/File?path="+file,
            addRemoveLinks: true,
            uploadMultiple: false,
            init: function () {
                var myDropzone = this;
                if (imageUrl != "") {
                    var mockFile = { name: `/files/${imageUrl}` };
                    myDropzone.emit("addedfile", mockFile);
                    myDropzone.emit("thumbnail", mockFile, `/files/${imageUrl}`);
                    myDropzone.emit("complete", mockFile);
                    myDropzone.files.push(mockFile);
                }

            },
            success: function (file, responseText) {
                var fileUrl = JSON.parse(responseText.response);
                $("#image").val(`${fileUrl.path}/${fileUrl.fileName}`);
                file.previewElement.classList.add("dz-success");
            },
            error: function (file, response) {
                file.previewElement.classList.add("dz-error");
            },
            removedfile: function (file) {
                var path = $("#image").val();
                $.ajax({
                    type: "POST",
                    url: "/Upload/RemoveFile",
                    dataType: "json",
                    data: { path: path }
                });
                $("#image").val('');
                var _ref;
                return (_ref = file.previewElement) != null ? _ref.parentNode.removeChild(file.previewElement) : void 0;
            }
        });
}