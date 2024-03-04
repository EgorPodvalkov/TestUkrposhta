$(() => {
    onLoadScript();
});

function onLoadScript() {
    loadEmployeeTable();
    linkEnterToFilterButton();
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

function linkEnterToFilterButton() {
    const enterKey = 13;
    $(document).on('keypress', function (e) {
        if (e.which == enterKey) {
            const focusFilterSection = $("#filter-section").find(':focus').length != 0;
            if (focusFilterSection) {
                $("#filter-button").trigger("click");
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
