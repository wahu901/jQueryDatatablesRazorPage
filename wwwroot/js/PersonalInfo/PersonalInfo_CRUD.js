
var CreatePersonalInfo = function () {
    var url = "/PersonalInfoDialog/Create";
    $('#title').html("Create Personal Info");

    $("#PersonalInfoFormModelDiv").load(url, function () {
        $("#PersonalInfoFormModel").modal("show");

    });
};


var UpdatePersonalInfo = function (id) {
    var url = "/PersonalInfoDialog/Update?id=" + id;
    if (id > 0)
        $('#title').html("Update Personal Info");

    $("#PersonalInfoFormModelDiv").load(url, function () {
        $("#PersonalInfoFormModel").modal("show");

    });
};

$('body').on('click', "#btnSubmit", function () {
    console.log("debug 1");
    var myformdata = $("#PersonalInfoForm").serialize();

    console.log("debug 4");
    $.ajax({
        type: "POST",
        url: "/PersonalInfoDialog/Create",
        data: myformdata,
        success: function (result) {
            $("#PersonalInfoFormModel").modal("hide");
            
            swal.fire({
                title: "Alert!",
                text: result,
                type: "Success"
            }).then(function () {
                $('#tblPersonalInfo').DataTable().ajax.reload();
            });

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    console.log("debug 5");
});

var DeletePersonalInfo = function (id) {
    Swal.fire({
        title: 'Do you want to delete this item?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/PersonalInfo/Delete/" + id,
                success: function () {
                    Swal.fire({
                        title: 'Deleted!', text: 'Item has been deleted.',
                        icon: "success", closeOnConfirm: false,
                        onAfterClose: () => {
                            $('#tblPersonalInfo').DataTable().ajax.reload();
                        }
                    });
                }
            });
        }
    });
};



