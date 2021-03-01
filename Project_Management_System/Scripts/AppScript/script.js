$(document).ready(function($){
	$(".dropdown-button").dropdown();
    $('.modal').modal();
    $(".sn").hide();
    $(".signup-toggle").click(function () {
        $(this).hide();
        $(".signupForm").show(300);
		$(".policy").css("visibility","visible");
    });

    $(".signup-toggle").click(function () {
        $("#login_form").hide();
        $(".sn").show();
    });
    $(".sn").click(function () {
        $(this).hide();
        $("#login_form").show(300);
        $(".signup-toggle").show(300);
        $(".signupForm").hide(300);
        $(".policy").css("visibility", "visible");
    });
});