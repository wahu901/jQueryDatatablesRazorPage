$(document).ready(function () {
    document.title = 'PersonalInfo DataTable';
    $("#tblPersonalInfo").DataTable({        
        paging: true,
        select: true,
        "order": [[0, "desc"]],

        "ajax": {
            "url": "./PersonalInfo?handler=DataTabelData",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "ID", "name": "ID", "autoWidth": true },
            { "data": "FirstName", "name": "FirstName", "autoWidth": true },
            {
                "data": "DateOfBirth",                
            },
            { "data": "City", "name": "City", "autoWidth": true },
            { "data": "Country", "name": "Country", "autoWidth": true },
            { "data": "MobileNo", "name": "MobileNo", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-info btn-sm' onclick=AddEditPersonalInfo('" + row.ID + "');>Edit</a>";
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger btn-sm' onclick=DeletePersonalInfo('" + row.ID + "'); >Delete</a>";
                }
            }
        ],

        'columnDefs': [{
            'targets': [6, 7],
            'orderable': false,
        }],
        "lengthMenu": [[10, 15, 25, 50, 100, 200], [10, 15, 25, 50, 100, 200]]
    });
});