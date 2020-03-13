getTable();
/////////
function getTable() {
    return fetch('./PersonalInfoPage?handler=DataTabelData',
        {
            method: 'get',
            headers: {
                'Content-Type': 'application/json;charset=UTF-8'
            }
        })
        .then(function (response) {
            if (response.ok) {
                return response.text();
            } else {
                throw Error('Response Not OK');
            }
        })
        .then(function (text) {
            try {
                return JSON.parse(text);
            } catch (err) {
                throw Error('Method Not Found');
            }
        })
        .then(function (responseJSON) {
            $(document).ready(function () {
                $('#tblPersonalInfo').DataTable({
                    data: responseJSON,
                    dom: 'lBfrtip',
                    buttons: [
                        'copy', 'csv', 'excel', 'pdf', 'print'
                    ],
                    columns: [
                        {
                            data: "id", name: "ID", autoWidth: true,
                            "render": function (data, type, row, meta) {
                                if (type === 'display') {
                                    data = '<a href="/PersonalInfoPage/Details?id=' + data + '">' + data + '</a>';
                                }
                                return data;
                            }
                        },
                        { data: "firstName", name: "FirstName", autoWidth: true },
                        { data: "lastName", name: "LastName", autoWidth: true },
                        {
                            data: "dateOfBirth",
                            name: "DateOfBirth",
                            autoWidth: true,
                            render: function (data) {
                                if (data != null) {
                                    var date = new Date(data);
                                    var month = date.getMonth() + 1;
                                    return (month.length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                                } else {
                                    return "";
                                }
                            }
                        },
                        { data: "city", name: "City", autoWidth: true },
                        { data: "country", name: "Country", autoWidth: true },
                        { data: "mobileNo", name: "MobileNo", autoWidth: true },
                        { data: "email", name: "Email", autoWidth: true },
                        {
                            data: null, render: function (data, type, row) {
                                return "<a href='#' class='btn btn-info btn-sm' onclick=UpdatePersonalInfo('" + row.ID + "');>Edit</a>";
                            }
                        },
                        {
                            data: null, render: function (data, type, row) {
                                return "<a href='#' class='btn btn-danger btn-sm' onclick=DeletePersonalInfo('" + row.ID + "'); >Delete</a>";
                            }
                        }
                    ],
                    columnDefs: [{
                        targets: [8, 9],
                        orderable: false,
                    }],
                    lengthMenu: [[10, 15, 15, 25, 25, 50, 100, 200], [10, 15, 15, 25, 25, 50, 100, 200]]
                });
            });
        })
}
