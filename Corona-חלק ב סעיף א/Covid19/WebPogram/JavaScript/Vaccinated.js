//הצגת טבלה של כל המחוסנים
function GetAllVaccinated() {
    var path = 'https://localhost:44305/api/Vaccinated/GetVaccinatedwithManufacturername';
    var mydiv = document.getElementById('table');
    mydiv.innerHTML = '';
    var body = document.getElementsByClassName("body")[0];
    var table = newFunction();
    table.className = "table table-hover";
    //כותרות לעמודות
    var thead = document.createElement("thead");
    var tr = document.createElement("tr");
    var th = document.createElement("th");
    th.innerHTML = "קוד פרטי התחסנות";
    tr.appendChild(th);
    th = document.createElement("th");

    th.innerHTML = "תעודת זהות מתחסן";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "קוד חיסון";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "תאריך קבלת החיסון";
    tr.appendChild(th);
    th = document.createElement("th");
    th.innerHTML = "ערוך והוסף";
    tr.appendChild(th);
    thead.appendChild(tr);
    table.appendChild(thead);

    //מיליוי מהמסד נתונים 
    axios.get(path).then(
        (response) => {
            console.log(response)
            var all_entitis = response.data;
            var tbody = document.createElement("tbody");
            tbody.id = "myTable";

            table.appendChild(tbody);
            body.appendChild(table);

            for (var i = 0; i < all_entitis.length; i++) {
                tr = document.createElement("tr")
                tr.className = "MyTblTr"
                tr.value = all_entitis[i][0]
                //עבור כל עמודה
                for (var j = 0; j < all_entitis[i].length; j++) {
                    td = document.createElement("td")
                    td.innerHTML = all_entitis[i][j]
                    tr.appendChild(td)
                    tbody.appendChild(tr);
                }
            }
            var td = document.createElement("td");
            td.innerHTML = '<a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a> <a class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a><a class="delete" title="Delete" data-toggle="tooltip"></a>';
            tr.appendChild(td);

            tr.onclick = "GetSupported()";
            tbody.appendChild(tr);
        },
        (error) => {
            console.log(error);
        }
    );

    function newFunction() {
        return document.createElement("table");
    }




}


$(document).ready(function () {


    $('[data-toggle="tooltip"]').tooltip();
    //var actions = $("table td:last-child").html();
    var actions = '<a class="add" title="Add" data-toggle="tooltip"><i class="material-icons">&#xE03B;</i></a> <a class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a><a class="delete" title="Delete" data-toggle="tooltip"></a>';
    // Append table with add row form on add new button click
    $(".add-new").click(function () {
        $(this).attr("disabled", "disabled");
        var index = $("table tbody tr:last-child").index();
        var row = '<tr>' +
            '<td><input type="text" class="form-control" name="phone" id="tz"></td>' +
            '<td><input type="text" class="form-control" name="name" id="name"></td>' +
            '<td><input type="text" class="form-control" name="name" id="lname"></td>' +
            '<td><input type="text" class="form-control" name="name" id="bitrh_date"></td>' +
            '<td><input type="text" class="form-control" name="phone" id="phone"></td>' +
            '<td><input type="text" class="form-control" name="phone" id="cell_phone"></td>' +
            '<td><input type="text" class="form-control" name="department" id="employee"></td>' +
            '<td><input type="text" class="form-control" name="name" id="city"></td>' +
            '<td><input type="text" class="form-control" name="name" id="street"></td>' +
            '<td><input type="text" class="form-control" name="department" id="street_num"></td>' +

            '<td>' + actions + '</td>' +
            '</tr>';
        $("table").append(row);
        $("table tbody tr").eq(index + 1).find(".add, .edit").toggle();
        $('[data-toggle="tooltip"]').tooltip();

    });

    // Add row on add button click
    $(document).on("click", ".add", function (event) {

        //var tz = event.currentTarget.parentElement.parentElement.children[0].children[0].value;
        //alert(tz);
        if (ValidateID(event.currentTarget.parentElement.parentElement.children[1].children[0].value) == false) {
            alert("תז שגויה");
            return;

        }
        var object = {
            entity_id: parseInt(event.currentTarget.parentElement.parentElement.children[1].children[0].value),
            vaccine_id: event.currentTarget.parentElement.parentElement.children[2].children[0].value,
            receiving_date: event.currentTarget.parentElement.parentElement.children[3].children[0].value
        }

        var p = 'https://localhost:44305/api/Vaccinated/AddVaccinated'

        const table = document.getElementById('myTable');


        const rows = Array.from(table.getElementsByTagName('tr'));


        let count = 0;


        rows.slice(0).map(row => {
            idCell = row.cells[1]; 
            id = parseInt(idCell.textContent);
            if (id === object.entity_id) {
                count = count + 1;
            }
        }
        );
        if (count >= 4)
            alert("בצעת 4 חיסונים אין אפשרות לבצע יותר")
        else {
        axios.post(p, object).then(
            (response) => {
                var res = response.data;
                if (res == true)
                    alert("הוספה בהצלחה");
                else
                    alert("אופסס");

            },
            (error) => {
                console.log(error);
            }
            );
        }



        var empty = false;
        var input = $(this).parents("tr").find('input[type="text"]');
        input.each(function () {
            if (!$(this).val()) {
                $(this).addClass("error");
                empty = true;
            } else {
                $(this).removeClass("error");
            }
        });

        $(this).parents("tr").find(".error").first().focus();

        if (!empty) {
            input.each(function () {
                $(this).parent("td").html($(this).val());
            });
            $(this).parents("tr").find(".add, .edit").toggle();
            $(".add-new").removeAttr("disabled");
        }






    });
    // Edit row on edit button click
    $(document).on("click", ".edit", function () {
        $(this).parents("tr").find("td:not(:last-child)").each(function () {
            $(this).html('<input type="text" class="form-control" value="' + $(this).text() + '">');
        });
        $(this).parents("tr").find(".add, .edit").toggle();
        $(".add-new").attr("disabled", "disabled");
    });


});


// DEFINE RETURN VALUES
var R_ELEGAL_INPUT = -1;
var R_NOT_VALID = -2;
var R_VALID = 1;

function ValidateID(IDnum) {
    //INPUT VALIDATION

    // Just in case -> convert to string

    // Validate correct input
    if ((IDnum.length > 9) || (IDnum.length < 5) || isNaN(IDnum))
        return false;

    // The number is too short - add leading 0000
    if (IDnum.length < 9) {
        while (IDnum.length < 9) {
            IDnum = '0' + IDnum;
        }
    }

    // CHECK THE ID NUMBER
    var mone = 0, incNum;
    for (var i = 0; i < 9; i++) {
        incNum = Number(IDnum.charAt(i));
        incNum *= (i % 2) + 1;
        if (incNum > 9)
            incNum -= 9;
        mone += incNum;
    }
    if (mone % 10 == 0)
        return true;
    else
        return false;
}

