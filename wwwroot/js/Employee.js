var card;

$(() => {
    onLoadScript();
});

function onLoadScript() {
    loadEmployeeTable();
    setOnEnterButtonPress();
    card = $("#employee-card").dialog({
        classes: {
            "ui-dialog": "card"
        },
        autoOpen: false,
        title: 'Employee card',
        width: 700,
        height: 'auto',
        modal: true,
    });
}

function loadEmployeeTable(filter) {
    let table = $("#employee-section");

    // If table not found do nothing
    if (!table) {
        console.warn("Table #employee-section not found");
        return;
    }

    $.ajax({
        url: '/GetEmployeesTableView',
        // if has filter use post method
        method: filter ? 'post' : 'get',
        dataType: 'html',
        headers: { "Content-Type": "application/json" },
        data: JSON.stringify(filter),
        success: (data) => {
            table.html(data);
        }
    });
}

function onFilterButtonClick() {
    let filter = getFilter();
    if (filter) {
        loadEmployeeTable(filter);
    }
}

function setOnEnterButtonPress() {
    const enterKey = 13;
    $(document).on('keypress', function (e) {
        if (e.which == enterKey) {
            // if employee card opened
            let isCardOpened = card.dialog("isOpen");
            if (isCardOpened) {
                onCardButtonSaveClick();
                return;
            }

            // if in filter section
            let focusFilterSection = $("#filter-section").find(':focus').length != 0;
            if (focusFilterSection) {
                onFilterButtonClick();
            }
        }
    });
}

function getFilter() {
    var minSalary = $("#filter-min-salary").val();
    var maxSalary = $("#filter-max-salary").val();

    if (!minSalary)
        minSalary = null;
    if (!maxSalary)
        maxSalary = null;

    if (minSalary && maxSalary && minSalary > maxSalary) {
        alert("Warn, bad filter - min salary bigger than max salary");
        return;
    }

    var fullname = $("#filter-fullname").val();
    if (!fullname)
        fullname = null;

    var positionID = $("#filter-position").val();
    var departamentID = $("#filter-departament").val();

    return {
        fullname: fullname,
        minSalary: minSalary,
        maxSalary: maxSalary,
        positionID: positionID,
        departamentID: departamentID,
    }
}

function onEmployeeEditButtonClick(employeeID) {
    openEmplyeeCard(employeeID);
}

function openEmplyeeCard(employeeID) {
    card.dialog("option", "title", 'Employee card №' + employeeID);
    card.dialog("option", "buttons",
        [
            {
                text: "Save",
                click: () => onCardButtonSaveClick(employeeID)
            }
        ]);

    $.ajax({
        url: '/GetEmployee/' + employeeID,
        method: 'get',
        dataType: 'json',
        success: (employee) => {
            if (employee.error) {
                console.log(employee.error);
                return;
            }
            console.log(employee);
            fillCard(employee);
            card.dialog("open");
        }
    });
}

function fillCard(employee) {
    // regular
    $("#employee-card-fullname").val(employee.fullName);
    $("#employee-card-salary").val(employee.salary);
    $("#employee-card-phone").val(employee.phoneNumber);
    $("#employee-card-address").val(employee.address);

    // date
    $("#employee-card-birthdate").val(parseDate(employee.birthDate));
    $("#employee-card-hiredate").val(parseDate(employee.hireDate));

    // dropdownlist
    $(`#employee-card-departament`).removeAttr('selected');
    $(`#employee-card-departament option[value=${employee.departamentID}]`).attr('selected', 'selected');
    $(`#employee-card-position`).removeAttr('selected');
    $(`#employee-card-position option[value=${employee.positionID}]`).attr('selected', 'selected');
}
function parseDate(date) {
    return date.split('T')[0];
}

function onCardButtonSaveClick(employeeID) {
    saveEmployee(employeeID);
}

function saveEmployee(employeeID) {
    var employee = getEmployeeFromCard(employeeID);
    console.log(employee);
    $.ajax({
        url: '/SaveEmployee/' + employeeID,
        method: 'put',
        dataType: 'json',
        headers: { "Content-Type": "application/json" },
        data: JSON.stringify(employee),
        success: (data) => {
            console.log(data, card);
            if (data.error) {
                console.log(data.error);
                return;
            }
            console.log(data, card);

            // refresh table
            onFilterButtonClick();

            card.dialog("close");
        }
    });
}

function getEmployeeFromCard(employeeID) {
    return {
        ID: employeeID,
        fullName: $("#employee-card-fullname").val(),
        salary: $("#employee-card-salary").val(),
        phoneNumber: $("#employee-card-phone").val(),
        address: $("#employee-card-address").val(),
        birthDate: $("#employee-card-birthdate").val(),
        hireDate: $("#employee-card-hiredate").val(),
        departamentID: $("#employee-card-departament").val(),
        positionID: $("#employee-card-position").val(),
    }
}
