$(document).ready(function () {
    //Add to table
    $(".btn-info").click(function () {
        var html_element = document.createElement("tr");
        var employee_email_val = $('#employee_email_address').val();
        var employee_fullName_val = $('#employee_full_name').val();
        var employee_role_val = $('#employee_role').val();
        var employee_responsibilities_val = $('#employee_responsibilities').val();


        html_element.innerHTML = "<td>" + employee_email_val + "</td>" +
            "<td>" + employee_fullName_val + "</td>" +
            "<td>" + employee_role_val + "</td>" +
            "<td>" + employee_responsibilities_val + "</td>" +
            "<td><button type='button' class='btn btn-dark btn-sm btn-block'>Delete</button></td>";

        $("tbody").append(html_element);

    });
});

// Search member from the table
$("#myInput").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("#myTable tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
});

//Delete the current row
$(document).on("click", ".btn-dark", function () {
    $(this).parents('tr').remove();
})

// Calculate the date
$("#end_date").focusout(function () {
    var project_start_date = $("#start_date").val();
    var project_end_date = $("#end_date").val();

    // Define as new date
    var diffence_in_of_days = new Date($("#end_date").val()) - new Date($("#start_date").val());
    // Miliseconds
    var milliseconds_per_day = 1000 * 60 * 60 * 24;

    var number_of_days = diffence_in_of_days / milliseconds_per_day

    $("#project_duration").html("Your project is due in <b>" + number_of_days + "</b> Days");
    $("#project_duration").addClass("duration");
})
//creating project
// For the createProjectForm.html
$(document).ready(function () {

    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-success').addClass('btn-default');
            $item.addClass('btn-success');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    allNextBtn.click(function () {
        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid) nextStepWizard.removeAttr('disabled').trigger('click');
    });

    $('div.setup-panel div a.btn-success').trigger('click');
});

$(document).on('ready', function () {
    $("#input-25").fileinput({
        language: 'nl'
    });
});