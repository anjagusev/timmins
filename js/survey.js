$(document).ready(function () {
    $(function () {
        $("#MsgBox").dialog({
            autoOpen: false,
            modal: true,
            width: "auto",
            height: "auto"
        });
    });
});
function showjQueryDialog() {
    //check to see how many checkboxes there are and how many of those are checked.
    $("#MsgBox").dialog("open");
    $('#MsgBox').parent().appendTo($("form:first"));
}
function closejQueryDialog() {
    $("#MsgBox").dialog("close");
}