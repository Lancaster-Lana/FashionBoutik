
if (typeof jQuery === "undefined") {
    throw new Error("jQuery plugins need to be before this file");
}

(function ($) {
    $.product = {};
    $.product.imageAttachments = { //$.extend(product.imageAttachments, {
        init: function () {
            $.product.imageAttachments.initUploadAttachmentPlugin();
            $.product.imageAttachments.initUploadAttachment();
            $.product.imageAttachments.initDeleteAttachment();

            var productId = $("#productId").val();
            $.product.imageAttachments.refreshAttachmentsList(productId);
        },

        initDeleteAttachment: function () {
            var btnDeleteAttachment = $(".delete-productAttachedFile");
            btnDeleteAttachment.unbind('click');
            btnDeleteAttachment.on('click', function (e) {
                var btnDeleteFile = $(this);
                var productId = $("#productId").val();
                var fileId = btnDeleteFile.attr("data-id");
                var fileName = btnDeleteFile.attr("data-value");
                swal({
                    title: 'Are you sure you want to proceed?',
                    text: '"' + fileName + '" will be deleted',
                    icon: "warning",
                    buttons: [
                        'No, cancel it!',
                        'Yes, I am sure!'
                    ],
                    dangerMode: true,
                    showCancelButton: true,
                    closeOnConfirm: true
                }).then(function (isConfirm) {
                    //var theModal = $(this).closest('.modal').find('form');
                    //theModal.modal("hide");

                    if (isConfirmed) {
                        $.ajax({
                            type: "post",
                            contentType: false,
                            processData: false,
                            url: "/Admin/Product/DeleteAttachedFile?productId=" + productId + "&fileId=" + fileId,
                            success: function (message) {
                                //abp.message.success("Attached file removed successfully!");
                                $.product.imageAttachments.refreshAttachmentsList(productId);
                            },
                            error: function () {
                                swal("An error occurred deleting file. If you continue to see this issue, please contact your system administrator.",
                                    "Error deleting attached file!", "error");
                            }
                        }).done(function () {

                        });
                    }
                });


                //abp.message.confirm(
                //   'Are you sure you want to proceed?','"' + fileName + '" will be deleted', 
                //   function (isConfirmed) {
                //       if (isConfirmed) {
                //           $.ajax({
                //               type: "post",
                //               contentType: false,
                //               processData: false,
                //               url: "/Admin/Product/DeleteAttachedFile?productId=" + productId + "&fileId=" + fileId,
                //               success: function (message) {
                //                   //abp.message.success("Attached file removed successfully!");
                //                   product.imageAttachments.refreshAttachmentsList(productId);
                //               },
                //               error: function () {
                //                   abp.message.warn(
                //                       "An error occurred deleting file. If you continue to see this issue, please contact your system administrator.",
                //                       "Error deleting attached file!");
                //               }
                //           }).done(function () {

                //           });
                //       }
                //   });

                //prevents the default behavior of the actual link (it will hit your controller action)
                return false;
            });
        },

        //init Formstone upload file plugin (upload.js). See https://formstone.it/components/upload/
        initUploadAttachmentPlugin: function () {

            var productId = 0;
            if ($("#productId"))
                productId = $("#productId").val();

            var actionUrl = "/Admin/Product/UploadAttachedFiles?productId=" + productId;

            //Call plugin upload file
            $(".upload").unbind('upload');
            $(".upload").upload({
                action: actionUrl,
                maxSize: 107374182400,
                accept: ".gif,.png,.jpg,.jpeg"
                //label: "Drag and Drop file",
                //beforeSend: onBeforeSend
            })
                .on("start.upload", onAttachmentStart)
                .on("filestart.upload", onAttachmentFileStart)
                .on("fileprogress.upload", onAttachmentFileProgress)
                .on("filecomplete.upload", onAttachmentFileComplete)
                .on("fileerror.upload", onAttachmentFileError)
                .on("complete.upload", onAttachmentComplete)
                .on("queued.upload", onAttachmentQueued);
            //.on("chunkstart.upload", onAttachmentChunkStart)
            //.on("chunkprogress.upload", onAttachmentChunkProgress)
            //.on("chunkcomplete.upload", onAttachmentChunkComplete)
            //.on("chunkerror.upload", onAttachmentChunkError)

            $(".filelist.queue").on("click", ".cancel", onUploadAttachmentCancel);
            $(".cancel_all").on("click", onUploadAttachmentCancelAll);


            function onAttachmentFileStart(e, file) {
                console.log("File Start!");
                $(this).parents("form").find(".filelist.queue")
                    .find("li[data-index=" + file.index + "]")
                    .find(".progress").text("0%");
            }

            function onAttachmentFileError(e, file, error) {
                console.log("File Error:" + error);

                $(this).parents("form").find(".filelist.queue")
                    .find("li[data-index=" + file.index + "]").addClass("error")
                    .find(".progress").text("Error: " + error);
            }

            function onAttachmentFileProgress(e, file, percent) {
                //console.log("File Progress");
                var $file = $(this).parents("form").find(".filelist.queue").find("li[data-index=" + file.index + "]");

                $file.find(".progress").text(percent + "%");
                $file.find(".bar").css("width", percent + "%");
            }

            //MAIN handler after file uploaded
            function onAttachmentFileComplete(e, file, response) {
                var productId = $("#productId").val();
                //Refresh uploaded files list
                $.product.imageAttachments.refreshAttachmentsList(productId);

                var result = JSON.parse(response);

                if (response.trim() === "" || result.error !== null) {
                    $(this).parents("form").find(".filelist.queue")
                        .find("li[data-index=" + file.index + "]").addClass("error")
                        .find(".progress").text(response.trim());
                } else {
                    var $target = $(this).parents("form").find(".filelist.queue").find("li[data-index=" + file.index + "]");
                    $target.find(".file").text(file.name);
                    $target.find(".progress").remove();
                    $target.find(".cancel").remove();
                    $target.appendTo($(this).parents("form").find(".filelist.complete")); //- NOTE: this will be added by refreshing AttachmentsList
                    //alert("File uploaded successfully!");
                }
            }

            function onAttachmentStart(e, files) {
                console.log("Start");
                $(this).parents("form").find(".filelist.queue")
                    .find("li")
                    .find(".progress").text("Waiting");
            }

            function onAttachmentQueued(e, files) {
                console.log("Queued");
                var html = '';
                for (var i = 0; i < files.length; i++) {
                    html += '<li data-index="' + files[i].index + '"><span class="content"><span class="file">' + files[i].name + '</span><span class="cancel">Cancel</span><span class="progress">Queued</span></span><span class="bar"></span></li>';
                }

                $(this).parents("form").find(".filelist.queue").append(html);
            }

            function onAttachmentComplete(e) {
                console.log("Uploaded!");
            }


            function onUploadAttachmentCancel(e) {
                console.log("Cancel");
                var index = $(this).parents("li").data("index");
                $(this).parents("form").find(".upload").upload("abort", parseInt(index, 10));
            }

            function onUploadAttachmentCancelAll(e) {
                console.log("Cancel All");
                $(this).parents("form").find(".upload").upload("abort");
            }
        },

        //TO be removed: simple file uploader (see button "Upload") without D&D
        initUploadAttachment: function () {
            var btnAttachFile = $(".upload-productAttachedFile");
            //btnAttachFile.unbind('click');
            btnAttachFile.on('click', function (e) {
                //alert('start upload');
                var fileUpload = $("[name=spf-files]").get(0);
                var productId = 0;
                if ($("#productId"))
                    productId = $("#productId").val();

                var files = fileUpload.files;
                if (files.length === 0) {
                    swal('Please select a file, then click Upload', 'You have not selected a file', 'error');
                    return false;
                }

                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }

                $.ajax({
                    type: "post",
                    url: "/Admin/Product/UploadAttachedFiles?productId=" + productId,
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (data) {
                        //abp.message.success("File uploaded successfully");
                        $("[name=spf-files]").val(""); //clear uploaded file

                        //Refresh list of attached files (load = html that url returns)
                        $.product.imageAttachments.refreshAttachmentsList(productId);
                    },
                    error: function () {
                        swal(
                            "An error occurred uploading your file. If you continue to see this issue, please contact your system administrator.",
                            "Error uploading file!", "error");
                    }
                }).done(function () {

                });
                //prevents the default behavior of the actual link (it will hit your controller action)
                return false;
            });
        },

        //Reload list of attached files (load = html that url returns)
        refreshAttachmentsList: function (productId) {
            var attachmentsList = $("#attachmentsList");
            if (productId && productId > 0) {
                var url = "/Admin/Product/AttachmentsList?productId=" + productId;
                $(attachmentsList).load(url,
                    function (responseText, statusText, xhr) {
                        if (statusText === "success") {
                            //and re-attach handlers after attached files list reloaded
                            $.product.imageAttachments.initDeleteAttachment();

                            //Refresh label of the Attachments ([cont])
                            var attacmentsCount = $("#attachmentsList ul[name='uploadedFiles'] > li").length;
                            $('label#attachmentsCount').each(function () {
                                $(this).text(attacmentsCount);
                            });
                        }
                    });
            }
        },
    };//);

})(jQuery);

(function () {
    $(function () {
        $.product.imageAttachments.init();
    });
})();

