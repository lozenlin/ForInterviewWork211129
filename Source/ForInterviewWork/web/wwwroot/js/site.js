// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ConfirmDeleteDept(id, name, url) {
    $("#primaryDialogTitle").html("刪除確認");
    $("#primaryDialogBody").html(`是否確定要刪除部門[ ${name} ]?`);
    $("#primaryDialog").modal("show");

    $("#btnConfirmPrimary")
        .off("click")
        .on("click", function () {
            // post to server
            $.post(url, {
                id: id
            }, function (data) {
                if (data.b) {
                    location.reload(true);
                } else {
                    $("#primaryDialog").modal("hide");
                    ShowErrMsg(`刪除失敗! 原因:${data.err}`);
                }
            }).fail(function () {
                alert("post failed");
            });
        });
}

function ShowErrMsg(msg) {
    $("#primaryAlert #primaryAlertText").html(msg);
    $("#primaryAlert").show();
}

function HideElement(id) {
    $("#" + id).fadeOut("fast");
}