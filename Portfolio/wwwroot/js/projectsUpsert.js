
var newId = videos != null ? Object.keys(videos).length : 0;

function addVideo(projectId) {
    var videoGroup = document.getElementById('videoGroup')
    var div = document.createElement("div");

    div.setAttribute("class", "border form-group rounded-2 my-2 shadow bg-white p-2 remove-video-new" + newId);

    div.innerHTML = `
        <input hidden="" type="number" data-val="true" data-val-required="The Id field is required." id="Videos_${newId}__Id" name="Videos[${newId}].Id" value="0"><input name="__Invariant" type="hidden" value="Videos[${newId}].Id">
        <input hidden="" type="number" data-val="true" data-val-required="The ProjectId field is required." id="Videos_${newId}__ProjectId" name="Videos[${newId}].ProjectId" value="${projectId}"><input name="__Invariant" type="hidden" value="Videos[${newId}].ProjectId">
        <div class="form-floating py-2 form col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The Title field is required." id="Videos_${newId}__Title" name="Videos[${newId}].Title" >
            <label class="ms-2 text-dark" for="Videos_${newId}__Title">Title</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newId}].Title" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The Description field is required." id="Videos_${newId}__Description" name="Videos[${newId}].Description" >
            <label class="ms-2 text-dark" for="Videos_${newId}__Description">Description</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newId}].Description" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The Tool Tip field is required." id="Videos_${newId}__ToolTip" name="Videos[${newId}].ToolTip" >
            <label class="ms-2 text-dark" for="Videos_${newId}__ToolTip">Tool Tip</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newId}].ToolTip" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The URL field is required." id="Videos_${newId}__URL" name="Videos[${newId}].URL" >
            <label class="ms-2 text-dark" for="Videos_${newId}__URL">URL</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newId}].URL" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="number" data-val="true" data-val-required="The Order field is required." id="Videos_${newId}__Order" name="Videos[${newId}].Order" value="${newId + 1}"><input name="__Invariant" type="hidden" value="${newId + 1}">
            <label class="ms-2 text-dark" for="Videos_${newId}__Order">Order</label>
            <span class="text-danger text! field-validation-valid" data-valmsg-for="Videos[${newId}].Order" data-valmsg-replace="true"></span>
        </div>

        <div class="form-check py-2 col-12">
            <input class="form-check-input border-1" type="checkbox" checked="checked" data-val="true" data-val-required="The Active field is required." id="Videos_${newId}__Active" name="Videos[${newId}].Active" value="true">
            <label class="form-check-label ms-2 text-dark" for="Videos_${newId}__Active">Active</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newId}].Active" data-valmsg-replace="true"></span>
        </div>
        <div style="display: flex; justify-content:end">
            <a class="link-dark" type="button" onclick="removeNewVideo(${newId})">Remove</a>
        </div>`

    videoGroup.appendChild(div)
    newId++;
}

function removeVideo(id) {
    console.log("removeVideo called w/", id);
    $.ajax({
        url: `/Admin/Projects/DeleteVideo/${id}`,
        type: 'DELETE',
        contentType: 'application/json',
        success: function (data) {
            if (data.success) {
                $('.remove-video-' + id).remove();
                $('.delete-video-modal').modal('hide');
                newId--;
            }
        }
    })
}

function removeNewVideo(id) {
    $('.remove-video-new' + id).remove();
    newId--;
}

function removeVideoConfirmation(id) {
    const video = videos.find(v => v.id === id);
    $('.delete-video-modal').modal('show');
    $('.modal-body').html(`Permanently delete video "<b>${video.title}</b>"?`);
    $('.modal-footer').html(`
        <a onClick=cancelRemoveVideo() class="btn btn-secondary mx-2">Cancel</a>
        <a onClick=removeVideo(${id}) class="btn btn-danger mx-2">Delete</a>`);
}

function cancelRemoveVideo() {
    $('.delete-video-modal').modal('hide');
}
