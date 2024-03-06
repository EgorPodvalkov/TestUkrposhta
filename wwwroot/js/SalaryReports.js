$(() => {
    onLoadScript();
});

function onLoadScript() {
    loadTable();
    setOnEnterButtonPress();
}

function setOnEnterButtonPress() {
    const enterKey = 13;
    $(document).on('keypress', function (e) {
        if (e.which == enterKey) {
            // if in filter section
            let focusFilterSection = $("#filter-section").find(':focus').length != 0;
            if (focusFilterSection) {
                onFilterButtonClick();
            }
        }
    });
}

function loadTable(filter) {
    let table = $("#table-section");

    // If table not found do nothing
    if (!table) {
        console.warn("Table #table-section not found");
        return;
    }

    $.ajax({
        url: '/GetSalaryReportsTableView',
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

function onUpdateButtonClick() {
    let filter = getFilter();
    if (filter) {
        loadTable(filter);
    }
}

function onDownloadButtonClick() {
    let filter = getFilter();
    const fileName = "SalaryReport.txt";
    $.ajax({
        url: '/GetSalaryReportsTxtFile',
        method: 'post',
        dataType: 'html',
        headers: { "Content-Type": "application/json" },
        data: JSON.stringify(filter),
        success: (data) => {
            var blob = new Blob([data], { type: "application/octetstream" });

            var url = window.URL || window.webkitURL;
            link = url.createObjectURL(blob);
            var a = $("<a />");
            a.attr("download", fileName);
            a.attr("href", link);
            $("body").append(a);
            a[0].click();
            $("body").remove(a);
        }
    });
    onUpdateButtonClick();
}

function getFilter() {
    var positionID = $("#filter-position").val();
    var departamentID = $("#filter-departament").val();

    return {
        positionID: positionID,
        departamentID: departamentID,
    }
}
