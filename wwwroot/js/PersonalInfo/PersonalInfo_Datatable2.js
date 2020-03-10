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
		})   	
        .then(data => {
			console.log("data="+data);
			for (i = 0; i < data.length; i++){
				console.log("firstname="+data[i].firstName);
			}
        })
}

