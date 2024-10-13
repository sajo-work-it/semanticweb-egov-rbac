// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getPersonByNationalId() {
    
    national_id = document.getElementById("national_id").value
    $.ajax({
        url: "/PersonProfiles/getPersonByNationalId",
        //url: '@Url.Action("getPersonByNationalId", "PersonProfiles")',
        data: {

            id: national_id
        },
        method: "GET",
        success: function (jsonData) {
            document.getElementById("error").textContent = ""
            document.getElementById("full_name").value = jsonData.full_name
            document.getElementById("national_id").value = jsonData.national_id
            document.getElementById("gender").value = jsonData.gender
            document.getElementById("gender").checked = jsonData.gender
            document.getElementById("genderDisplay").textContent = jsonData.genderDisplay
            document.getElementById("address").value = jsonData.address
        },
        error: function () {
            document.getElementById("error").textContent = "لا يوجد مواطن يحمل هذا الرقم الوطني"
        }

    });
    return false;
}

function filterOfficers()
{

    per = document.getElementById("percentage").value
    $.ajax({
        url: "/Officers/healthConditionFiltered",
        data: {

            percentage: per
        },
        method: "GET"

    });
//    return false;
}

//$(document).ready(function () {
//    $("#filterOfficers-btn").click(function (event) {
//        event.preventDefault();
//        window.location.href = "@Url.Action("healthCondition", "Officers")" + "?percentage=" + $("#myInput").val();
//    });
//})
//function filterOfficers() {
//    var officers = document.getElementsByClassName("officerRow");
//    var ids = document.getElementsByClassName("officerId");
//    var percentage = document.getElementsByClassName("injury_percentage");
//    for (var i = 0; i < officers.length; i++) {

//    }
//}