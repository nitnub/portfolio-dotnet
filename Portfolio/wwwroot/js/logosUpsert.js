var newProjectLogoId = projectLogos != null ? Object.keys(projectLogos).length : 0;

function getLogoList(logos) {
    const nameComparator = (a, b) => a.name.localeCompare(b.name);

    console.log("Logos:");
    console.log(logos)
    return activitiesList
        .sort(nameComparator)
        .map(a => `<option value="${a.id}">${a.name}</option>`);
}


// var newProjectLogoId = logos != null ? Object.keys(logos).length : 0;


//   <div class="form-floating py-2 mx-1 col-6">
//     <select class="form-select" data-val="true" data-val-required="The TypeId field is required." id="Activities_${1}__Activity_TypeId" name="Activities[${1}].Activity.TypeId">
//          ${getLogoList(activitiesList)}
//     </select>
//     <label class="ms-2">Activity Type</label>
//     <span class="text-danger field-validation-valid" data-valmsg-for="Activities[${1}].Activity.TypeId" data-valmsg-replace="true"></span>
// </div>
//


function removeVideo_testing(id) {
    console.log("removeVideo called w/", id);
    $.ajax({
        url: `/Admin/Logos/Get/${id}`,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            if (data.success) {
                console.log(data);
                console.log(data);
                // $('.remove-video-' + id).remove();
                // $('.delete-video-modal').modal('hide');
                // newProjectLogoId--;
            }
        }
    })
}


function updateDisplayLogo(id) {
    // console.log(e);
    // $('.logo-select' + id).remove();
    const selection = $('.logo-select').attr('id');
    console.log(selection);
    console.log(`clicked... ${selection}`);

    const selectionId = $('#logo-select-' + id).val()
    console.log("Card ID = ", id);
    console.log("Selection ID = ", selectionId);
    $.ajax({
        url: `/Admin/Logos/Get/${selectionId}`,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            if (data.success) {
                $('#logo-preview-' + id).html(data.logo.html);
            }
        }
    })
}

function addLogo(projectId) {
    var logoGroup = document.getElementById('logoGroup')
    var div = document.createElement("div");

    div.setAttribute("class", "border form-group rounded-2 my-2 shadow bg-white p-2 remove-logo-new" + newProjectLogoId);

    div.innerHTML = `
<!--        <input hidden="" type="number" data-val="true" data-val-required="The Id field is required." id="logos_${newProjectLogoId}__Id" name="Logos[${newProjectLogoId}].Id" value="0"><input name="__Invariant" type="hidden" value="Logos[${newProjectLogoId}].Id">-->
        <input hidden="" type="number" data-val="true" data-val-required="The Id field is required." id="logos_${newProjectLogoId}__Id" name="Logos[${newProjectLogoId}].Id" value="0"><input name="__Invariant" type="hidden">
        
          <div class="border form-group rounded-2 my-2 shadow p-2"  style="background:white;">
<!--                                                <input asp-for="@Model.ProjectLogos[i].Id" hidden />-->
<!--                                                <input asp-for="@Model.ProjectLogos[i].ProjectId" hidden />-->
<!--                                                <input asp-for="@Model.ProjectLogos[i].LogoId" hidden />-->
                                            
                                            <div class="form-floating py-2 mx-1 col-6">
                                                <select class="form-select logo-select" data-val="true" onchange="updateDisplayLogo(newProjectLogoId);" data-val-required="The TypeId field is required." id="logo-select-${newProjectLogoId}" >
                                            
<!--                                                 @for (int j = 0; j < Model.Logos.Count; j++)-->
<!--                                                 {-->
<!--                                                     if (Model.ProjectLogos[i].LogoId == Model.Logos[j].Id)-->
<!--                                                     {-->
<!--                                                         <option value="@Model.Logos[j].Id" selected }>@Model.Logos[j].Name</option>;-->
<!--                                                     }-->
<!--                                                     else-->
<!--                                                     {-->
<!--                                                         <option value="@Model.Logos[j].Id"   }>@Model.Logos[j].Name</option>;-->
<!--                                                     }-->
<!--                                                     -->
<!--                                                     @* <option value="@Model.Logos[j].Id"  @{Model.ProjectLogos[i].LogoId == Model.Logos[j].Id ? "selected" : ""}  }>@Model.Logos[j].Name</option>; *@-->
<!--                                                     -->
<!--                                                 }-->
                                                 
                                                 </select>
                                                 <label class="ms-2">Label</label>
                                             </div>
                                            
             
                                            
                                    
                                         
                                                <div id="logo-preview-${newProjectLogoId}" data-toggle="tooltip" data-placement="top" title="@Model.ProjectLogos[i].Logo.Name" class="project-icon mx-2">
                                                    
<!--                                                    @Html.Raw(Model.ProjectLogos[i].Logo.HTML)-->
                                                </div>
                            

                                            <div class="form-floating py-2 col-12">
                                                <input asp-for="@Model.ProjectLogos[i].Priority" class="form-control border-1" />
                                                <label asp-for="@Model.ProjectLogos[i].Priority" class="ms-2 text-dark"></label>
                                                <span asp-validation-for="@Model.ProjectLogos[i].Priority" class="text-danger text!"></span>
                                            </div>

                       

                                                <div style="display: flex; justify-content:end">
                                                    <a class="link-dark" type="button" onclick="removeLogoConfirmation(@Model.ProjectLogos[i].Id)">Remove</a>
                                                </div>
                                           
        
        
        abdcc
        <div class="form-floating py-2 form col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The Title field is required." id="Videos_${newProjectLogoId}__Title" name="Videos[${newProjectLogoId}].Title" >
            <label class="ms-2 text-dark" for="Videos_${newProjectLogoId}__Title">Title</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newProjectLogoId}].Title" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The Description field is required." id="Videos_${newProjectLogoId}__Description" name="Videos[${newProjectLogoId}].Description" >
            <label class="ms-2 text-dark" for="Videos_${newProjectLogoId}__Description">Description</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newProjectLogoId}].Description" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The Tool Tip field is required." id="Videos_${newProjectLogoId}__ToolTip" name="Videos[${newProjectLogoId}].ToolTip" >
            <label class="ms-2 text-dark" for="Videos_${newProjectLogoId}__ToolTip">Tool Tip</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newProjectLogoId}].ToolTip" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="text" data-val="true" data-val-required="The URL field is required." id="Videos_${newProjectLogoId}__URL" name="Videos[${newProjectLogoId}].URL" >
            <label class="ms-2 text-dark" for="Videos_${newProjectLogoId}__URL">URL</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newProjectLogoId}].URL" data-valmsg-replace="true"></span>
        </div>

        <div class="form-floating py-2 col-12">
            <input class="form-control border-1" type="number" data-val="true" data-val-required="The Order field is required." id="Videos_${newProjectLogoId}__Order" name="Videos[${newProjectLogoId}].Order" value="${newProjectLogoId + 1}"><input name="__Invariant" type="hidden" value="${newProjectLogoId + 1}">
            <label class="ms-2 text-dark" for="Videos_${newProjectLogoId}__Order">Order</label>
            <span class="text-danger text! field-validation-valid" data-valmsg-for="Videos[${newProjectLogoId}].Order" data-valmsg-replace="true"></span>
        </div>

        <div class="form-check py-2 col-12">
            <input class="form-check-input border-1" type="checkbox" checked="checked" data-val="true" data-val-required="The Active field is required." id="Videos_${newProjectLogoId}__Active" name="Videos[${newProjectLogoId}].Active" value="true">
            <label class="form-check-label ms-2 text-dark" for="Videos_${newProjectLogoId}__Active">Active</label>
            <span class="text-danger field-validation-valid" data-valmsg-for="Videos[${newProjectLogoId}].Active" data-valmsg-replace="true"></span>
        </div>
        <div style="display: flex; justify-content:end">
            <a class="link-dark" type="button" onclick="removeNewVideo(${newProjectLogoId})">Remove</a>
        </div>`

    logoGroup.appendChild(div)

    // $('#logo-preview-' + id).html(data.logo.html);
    // $('#logo-preview-' + newProjectLogoId).html(logos[0].html);
    // "logo-preview-${newProjectLogoId}"
    
    for (let i = 0; i < logos.length; i++) {
        // let options = "<option > $(projectLogos[i].name)</option>"
        console.log(`<option > ${logos[i].name}</option>`);
        $('#logo-select-' + newProjectLogoId).append(`<option value="${logos[i].id}" > ${logos[i].name}</option>`);
        $('#logo-select-' + newProjectLogoId).trigger('change');
    }

    // set default preview
    $('#logo-preview-' + newProjectLogoId).html(logos[0].html);
    // "logo-preview-${newProjectLogoId}"

  
   
    console.log(`newProjectLogoId: ${newProjectLogoId}`);
    newProjectLogoId++;
}

function removeLogo(id) {
    console.log("removeLogo called w/", id);
    $.ajax({
        url: `/Admin/Projects/DeleteLogo/${id}`,
        type: 'DELETE',
        contentType: 'application/json',
        success: function (data) {
            if (data.success) {
                $('.remove-logo-' + id).remove();
                $('.delete-attribute-modal').modal('hide');
                newProjectLogoId--;
            }
        }
    })
}

function removeNewVideo(id) {
    $('.remove-video-new' + id).remove();
    newProjectLogoId--;
}

function removeLogoConfirmation(id) {
    console.log("in remove...");
    const logo = logos.find(l => l.id === id).logo;
    console.log(logo);
    console.log("in remove 2...");


    $('.delete-attribute-modal').modal('show');
    $('.modal-body').html(`Permanently delete logo "<b>${logo.name}</b>"?`);
    $('.modal-footer').html(`
        <a onClick=cancelRemoveLogo() class="btn btn-secondary mx-2">Cancel</a>
        <a onClick=removeLogo(${id}) class="btn btn-danger mx-2">Delete</a>`);
}

function cancelRemoveLogo() {
    $('.delete-attribute-modal').modal('hide');
}
