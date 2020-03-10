getTable();
/////////
function convertToDataSet(responseJSON) {
    //console.log(responseJSON);
    var returnList = [];
    var returnitem = [];
    for (var i = 0; i < responseJSON.length; i++) {
        //console.log(responseJSON[i]);
        returnitem = [];
        returnitem.push(responseJSON[i].id);
        returnitem.push(responseJSON[i].firstName);
        returnitem.push(responseJSON[i].dateOfBirth);
        returnitem.push(responseJSON[i].city);
        returnitem.push(responseJSON[i].country);
        returnitem.push(responseJSON[i].mobileNo);
        returnList.push(returnitem);
    }
    return returnList;
}

function getTable() {
    return fetch('./PersonalInfo?handler=DataTabelData',
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
            var dataSet = convertToDataSet(responseJSON);
            //console.log(dataSet);
            $(document).ready(function () {
                $('#tblPersonalInfo').DataTable({
                    data: dataSet,
                    "processing": true, // for show progress bar
                    "filter": true, // this is for disable filter (search box)
                    "orderMulti": false, // for disable multiple column at once
                    columns: [
                        { title: "ID" },
                        { title: "FirstName" },
                        {
                            "data": "DateOfBirth",
                            "name": "DateOfBirth",
                            "autoWidth": true,
                            "render": function (data) {
                                console.log("data=" + data);
                                var date = new Date(data);
                                var month = date.getMonth() + 1;
                                return (month.length > 1 ? month : "0" + month) + "/" + date.getDate() + "/" + date.getFullYear();
                            }
                        },
                        { title: "City" },
                        { title: "Country" },
                        { title: "MobileNo" },
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
                        
                    ]
                });
            });
        })
}

