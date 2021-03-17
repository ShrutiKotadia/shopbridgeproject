function Reset() {
    $('#inventoryId').val('');
    $('#Name').val('');
    $('#Description').val('');
    $('#Price').val('');
    $('#ImgPreview').attr('src', null);
    $('#header').val('Add Inventory');
}
function editInventory(id, imagename) {
    $('#inventoryId').val(id);
    $('#Name').val($('#hdnName_' + id).val());
    $('#Description').val($('#hdnDesc_' + id).val());
    $('#Price').val($('#hdnPrice_' + id).val());
    $('#ImgPreview').attr('src', '/images/' + imagename);
    $('#header').val('Edit Inventory');
    $('#ProdImage').rules('add', {
        required: false
    });
}

function deleteInventory(id) {
    if (confirm('Are you sure you want to delete it?')) {
        var lsRequest = {
            id: id
        };

        $.ajax({
            url: '/Home/Delete',
            method: "POST",
            data: lsRequest,
            success: function (result) {
                alert(result.message);
                if (result.success) {
                    $('#' + result.id).remove();
                }
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
    } return false;
}
function saveInventory() {
    if ($('#frmSave').valid()) {
        var fileUpload = $("#ProdImage").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        var lsRequest = {
            id: $('#inventoryId').val(),
            name: $('#Name').val(),
            desc: $('#Description').val(),
            price: $('#Price').val(),
            image: fileData,
        };

        $.ajax({
            url: '/Home/Save',
            method: "POST",
            data: lsRequest,
            success: function (result) {
                alert(result.message);
                if (result.success) {
                    window.location.href = window.location.href;
                }
            },
            error: function (err) {
                alert(err.statusText);
            }
        });
        return false;
    } else {
        event.preventDefault();
        return false;
    }
}