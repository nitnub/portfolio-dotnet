var dataTable;

$(document).ready(function () {
    loadDataTable();
    $('#update_modal').modal('show');
})

function loadDataTable() {
    dataTable = $('#projTable').DataTable({
        "ajax": { url: '/admin/projects/getall' },
        "columns": [
            { data: 'order', width: "5%" },
            { data: 'title', width: "10%" },
            { data: 'description', width: "30%" },
            { data: 'gitUrl', width: "10%" },
            { data: 'demoUrl', width: "10%" },
            { data: 'image', width: "10%" },
            { data: 'imageAltText', width: "10%" },
            { data: 'videos.length', width: "5%" },
            { data: 'port', width: "5%" },
            { data: 'active', render: visibleIcon , width: "5%" },
            {
                data: { id: 'id', title: 'title', videos: "videos" },
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/projects/upsert?id=${data.id}" class="btn btn-success mx-2">Edit</a>
                            <a onClick=verifyDelete('${encode(data)}') class="btn btn-danger mx-2">Delete</a>
                        </div>`
                },
                width: "10%"
            }

        ]
    });
}



function visibleIcon(active) {

    var color = active ? 'text-primary' : '';
    var icon = active ? 'bi-eye-fill' : 'bi-eye-slash';
    
    return `
        <div class="grid-icon ${color}">
            <i class="bi ${icon}"></i>
        </div>`
}

//function verifyDelete(obj) {
//    data = decode(obj);
//    $('.delete-modal').modal('toggle');
//    $('.modal-body').html(`Permanently delete <b>${data.title}</b>?`);
//    $('.modal-footer').html(`
//        <a onClick=verifyDelete('${encode(data)}') class="btn btn-secondary mx-2">Cancel</a>
//        <a href="/admin/project/delete?id=${data.id}" class="btn btn-danger mx-2">Delete</a>`);
//}

//function closeDeleteModal() {

//}



function verifyDelete(obj) {
    data = decode(obj);
    $('.delete-modal').modal('show');
    $('.modal-body').html(`Permanently delete <b>${data.title}</b>?`);
    $('.modal-footer').html(`
        <a onClick=closeDeleteModal('${encode(data)}') class="btn btn-secondary mx-2">Cancel</a>
        <a href="/admin/projects/delete?id=${data.id}" class="btn btn-danger mx-2">Delete</a>`);
}

function closeDeleteModal() {
    console.log("check!");
    $('.delete-modal').modal('hide');
}

function encode(obj) {
    return encodeURIComponent(JSON.stringify(obj));
}

function decode(obj) {
    return JSON.parse(decodeURIComponent(obj));
}
