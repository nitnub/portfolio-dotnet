var dataTable;

$(document).ready(function () {
    loadDataTable();
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
