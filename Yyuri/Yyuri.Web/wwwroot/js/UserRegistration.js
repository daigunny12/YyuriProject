$(function () {

    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);

    function onUserRegisterClick()
    {
        var url = "Account/RegisterUser";
        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();
        var email = $("#UserRegistrationModal input[name='Email']").val();
        var urlcheckemail = "Account/UserNameExists?userName=" + email;
        var password = $("#UserRegistrationModal input[name='Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name='ConfirmPassword']").val();
        var re = /\S+@\S+\.\S+/;

        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            AcceptUserAgreement: true
        };

        
        //check null email
        if (email.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Vui lòng nhập Email");
            return;
        } else {
            CloseAlert("#alert_label_email_register");
        }

        //check format email
        if (!re.test(email)) {
            PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Địa chỉ Email không đúng định dạng");
            return;
        } else {
            CloseAlert("#alert_label_email_register");
        }

        //check null password
        if (password.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_password_register", "warning", "Vui lòng nhập mật khẩu");
            return;
        } else {
            CloseAlert("#alert_label_password_register");
        }

        //check password
        if (password.length < 6 || !/\d/.test(password)) {
            PresentClosableBootstrapAlert("#alert_label_password_register", "warning", "Mật khẩu phải có ít nhất 6 ký tự và có ít nhất một chữ số('0' - '9').");
            return;
        } else {
            CloseAlert("#alert_label_password_register");
        }

        // check password == confirmPassword
        if (password != confirmPassword || confirmPassword.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_confirmpassword_register", "warning", "Mật khẩu không khớp");
            return;
        } else {
            CloseAlert("#alert_label_confirmpassword_register");
        }

        //check already exist email
        $.ajax({
            type: "GET",
            url: urlcheckemail,
            success: function (data) {
                if (data == true) {
                    PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Địa chỉ email này đã được đăng ký");
                    return;
                }
                else {
                    CloseAlert("#alert_label_email_register");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }
        });


        //Regist
        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';

                if (hasErrors) {

                    $("#UserRegistrationModal").html(data);
                    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);
                    $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    location.href = '/Home/Index';
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }

        });
            
    }

});