var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#usageTable').DataTable({
        "ajax": { url: '/admin/usage/getall' },
        aaSorting: [[6, 'desc']],
        "columns": [
            {
                data: 'dateTime',
                render: function (data) {
                    var dateTime = new Date(data);
                    return dateTime.toLocaleDateString();
                },
                width: "10%"
            },
            {
                data: 'dateTime', render: function (data) {
                    var dateTime = new Date(data);
                    return dateTime.toLocaleTimeString();
                },
                width: "12%"
            },
            { data: 'guest', width: "10%" },
            { data: 'project', width: "20%" },
            { data: 'type', width: "13%" },
            { data: 'label', width: "12%" },
            { data: 'dateTime', width: "25%" }
        ]
    });
}
