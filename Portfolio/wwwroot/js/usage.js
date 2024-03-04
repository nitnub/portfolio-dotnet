var dataTable;

$(document).ready(function () {
    loadDataTable();
  /*  $('#update_modal').modal('show');*/
})

function loadDataTable() {
    dataTable = $('#usageTable').DataTable({
        "ajax": { url: '/admin/usage/getall' },
        "columns": [
            { data: 'guest', width: "10%" },
            { data: 'project', width: "10%" },
            { data: 'type', width: "10%" },
            { data: 'label', width: "10%" },
            { data: 'dateTime', width: "25%" },
            { data: 'date', width: "5%" },
            { data: 'time', width: "10%" },
        ]
    });
}

/*block if loggedd in as admin*/

//function visibleIcon (data) {
//    if (data) {
//        return `
//            <div class="grid-icon text-primary">
//                <i class="bi bi-eye-fill"></i>
//            </div>`
//    }
//    else {
//        return `
//            <div class="grid-icon">
//                <i class="bi bi-eye-slash"></i>
//            </div>`
//    }
//}



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

//function encode(obj) {
//    return encodeURIComponent(JSON.stringify(obj));
//}

//function decode(obj) {
//    return JSON.parse(decodeURIComponent(obj));
//}
