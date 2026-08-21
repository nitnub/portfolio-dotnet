var dataTable;

$(document).ready(function () {
    loadDataTable();
    $('#update_modal').modal('show');
})

function loadDataTable() {
    dataTable = $('#logoTable').DataTable({
        // "ajax": { url: '/admin/projects/getall' },
        "ajax": { url: '/admin/logos/getall' },
        "columns": [
            { data: 'id', width: "5%" },
            { data: 'name', width: "10%" },
            { data: 'html', width: "15%" },
            // { data: null, width: "20%" },
            // {
            //     // data: { id: 'id', title: 'title', videos: "videos" },
            //     data: { html: 'html' },
            //     render: function (data) {
            //         return data.html;
            //     },
            //     width: "25%"
            // },
            // { data: 'gitUrl', width: "10%" },
            // { data: 'demoUrl', width: "10%" },
            // { data: 'image', width: "10%" },
            // { data: 'imageAltText', width: "10%" },
            // { data: 'videos.length', width: "5%" },
            // { data: 'port', width: "5%" },
            // { data: 'active', render: visibleIcon , width: "5%" },
            {
                // data: { id: 'id', title: 'title', videos: "videos" },
                // data: { id: 'id' },
                render: () => '', // render an empty column
                width: "75%"
            },
            
            
            {
                // data: { id: 'id', title: 'title', videos: "videos" },
                data: { id: 'id' },
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/logos/upsert?id=${data.id}" class="btn btn-success ">Edit</a>
                            <a onClick=verifyLogoDelete('${encode(data)}') class="btn btn-danger ">Delete</a>
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

function verifyLogoDelete(obj) {
    data = decode(obj);
    $('.delete-modal').modal('show');
    $('.modal-body').html(`Permanently delete <b>${data.title}</b>?`);
    $('.modal-footer').html(`
        <a onClick=closeDeleteModal('${encode(data)}') class="btn btn-secondary mx-2">Cancel</a>
        <a href="/admin/logos/delete?id=${data.id}" class="btn btn-danger mx-2">Delete</a>`);
}

function closeDeleteModal() {
    $('.delete-modal').modal('hide');
}

function encode(obj) {
    return encodeURIComponent(JSON.stringify(obj));
}

function decode(obj) {
    return JSON.parse(decodeURIComponent(obj));
}
