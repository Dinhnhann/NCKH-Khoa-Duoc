$(document).ready(function () {
    CKEDITOR.replace("Noidungtomtat");
    CKEDITOR.replace("Noidungchitiet");
    allowedContent: true,
    $("#selectImg").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#linkImg").val(fileUrl);
        };
        finder.popup();
    });
});