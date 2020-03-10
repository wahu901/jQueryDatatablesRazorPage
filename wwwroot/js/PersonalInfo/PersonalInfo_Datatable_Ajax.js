$(document).ready(function () {
    $.ajax({
        url: "/PersonalInfo?handler=DataTabelData",
        type: 'get',
        dataType: 'json',
        success: function (obj, textstatus) {
            $('#tblPersonalInfo').DataTable({
                destroy: true,
                data: obj,
                columns: [
                    { data: "id", name: "ID", autoWidth: true },
                    { data: "firstName", name: "FirstName", autoWidth: true },
                    {
                        data: "dateOfBirth",
                        name: "DateOfBirth",
                        autoWidth: true,
                        render: function (data) {
                            var date = new Date(data);
                            var month = date.getMonth() + 1;
                            return (month.length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                        }
                    },
                    { data: "city", name: "City", autoWidth: true },
                    { data: "country", name: "Country", autoWidth: true },
                    { data: "mobileNo", name: "MobileNo", autoWidth: true },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return "<a href='#' class='btn btn-info btn-sm' onclick=AddEditPersonalInfo('" + row.ID + "');>Edit</a>";
                        }
                    },
                    {
                        data: null,
                        render: function (data, type, row) {
                            return "<a href='#' class='btn btn-danger btn-sm' onclick=DeletePersonalInfo('" + row.ID + "'); >Delete</a>";
                        }
                    }
                ],
                columnDefs: [{
                    targets: [6, 7],
                    orderable: false,
                }],
                lengthMenu: [[10, 15, 25, 50, 100, 200], [10, 15, 25, 50, 100, 200]]
            })
        },
        error: function (obj, textstatus) {
            console.log(obj.msg);
        }
    })
})


