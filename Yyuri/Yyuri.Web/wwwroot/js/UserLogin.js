
//check password
function oninputPassWordLogin() {
    var password = $("#UserLoginModal input[name='Password']").val();
    if (password.length == 0) {
        PresentClosableBootstrapAlert("#alert_label_password_login", "warning", "Vui lòng nhập mật khẩu!");
    } else {
        CloseAlert("#alert_label_password_login");
        if (password.length < 6 || !/\d/.test(password)) {
            PresentClosableBootstrapAlert("#alert_label_password_login", "warning", "Mật khẩu phải có ít nhất 6 ký tự và có ít nhất một chữ số('0' - '9').");
        } else {
            CloseAlert("#alert_label_password_login");
        }
    }
}

function oninputEmailLogin() {
    var email = $("#UserLoginModal input[name = 'Email']").val();
    var re = /\S+@\S+\.\S+/;
    if (email.length == 0) {
        PresentClosableBootstrapAlert("#alert_label_email_login", "warning", "Vui lòng nhập địa chỉ Email!");
    } else {
        CloseAlert("#alert_label_email_login");
        if (!re.test(email)) {
            PresentClosableBootstrapAlert("#alert_label_email_login", "warning", "Địa chỉ Email không đúng định dạng!");
        } else {
            CloseAlert("#alert_label_email_login");
        }
    }
};

$(function () {
    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {

        var url = "Account/Login";

        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name = 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');
        var re = /\S+@\S+\.\S+/;

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };

        //check null email
        if (email.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_email_login", "warning", "Vui lòng nhập Email");
            return;
        } else {
            CloseAlert("#alert_label_email_login");
        }

        //check format email
        if (!re.test(email)) {
            PresentClosableBootstrapAlert("#alert_label_email_login", "warning", "Địa chỉ Email không đúng định dạng");
            return;
        } else {
            CloseAlert("#alert_label_email_login");
        }

        //check null password
        if (password.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_password_login", "warning", "Vui lòng nhập mật khẩu");
            return;
        } else {
            CloseAlert("#alert_label_password_login");
        }

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#UserLoginModal").html(data);

                    userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

                    var form = $("#UserLoginForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);
                    
                }
                else {
                    location.href = 'Home/Index';

                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});