
//check password
function oninputPassWordRegister() {
    var password = $("#UserRegistrationModal input[name='Password']").val();
    if (password.length == 0) {
        PresentClosableBootstrapAlert("#alert_label_password_register", "warning", "Vui lòng nhập mật khẩu!");
    } else {
        CloseAlert("#alert_label_password_register");
        if (password.length < 6 || !/\d/.test(password)) {
            PresentClosableBootstrapAlert("#alert_label_password_register", "warning", "Mật khẩu phải có ít nhất 6 ký tự và có ít nhất một chữ số('0' - '9').");
        } else {
            CloseAlert("#alert_label_password_register");
        }
    }
};

function oninputEmailRegister() {
    var email = $("#UserRegistrationModal input[name = 'Email']").val();
    var re = /\S+@\S+\.\S+/;
    if (email.length == 0) {
        PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Vui lòng nhập địa chỉ Email!");
    } else {
        CloseAlert("#alert_label_email_register");
        if (!re.test(email)) {
            PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Địa chỉ Email không đúng định dạng!");
        } else {
            CloseAlert("#alert_label_email_register");
        }
    }
};

$(function () {
    //check UserNameExists
    $("#UserRegistrationModal input[name = 'Email']").blur(function () {
        var email = $("#UserRegistrationModal input[name = 'Email']").val();
        if (email.length > 0) {
            var urlcheckemail = "Account/UserNameExists?userName=" + email;
            $.ajax({
                type: "GET",
                url: urlcheckemail,
                success: function (data) {
                    if (data == true) {
                        PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Địa chỉ email này đã được đăng ký!");
                    }
                    else {
                        CloseAlert("#alert_label_email_register");
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                    PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", errorText);
                    console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
                }
            });
        }       
    });

    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);

    function onUserRegisterClick()
    {
        var url = "Account/RegisterUser";
        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();
        var hoten = $("#UserRegistrationModal input[name='HoTen']").val();
        var email = $("#UserRegistrationModal input[name='Email']").val();
        var password = $("#UserRegistrationModal input[name='Password']").val();
        var code = $("#UserRegistrationModal input[name='EmailCode']").val();
        var re = /\S+@\S+\.\S+/;
        var countT = 0;

        // check null hoten
        if (hoten.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_hoten_register", "warning", "Vui lòng nhập họ tên!");
            countT++
        } else {
            CloseAlert("#alert_label_hoten_register");
        }

        //check null email
        if (email.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Vui lòng nhập Email!");
            countT++
        } else {
            CloseAlert("#alert_label_email_register");
        }

        //check format email
        if (!re.test(email)) {
            PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Địa chỉ Email không đúng định dạng!");
            countT++
        } else {
            CloseAlert("#alert_label_email_register");
        }

        //check null password
        if (password.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_password_register", "warning", "Vui lòng nhập mật khẩu!");
            countT++
        } else {
            CloseAlert("#alert_label_password_register");
        }

        //check password
        if (password.length < 6 || !/\d/.test(password)) {
            PresentClosableBootstrapAlert("#alert_label_password_register", "warning", "Mật khẩu phải có ít nhất 6 ký tự và có ít nhất một chữ số('0' - '9').");
            countT++
        } else {
            CloseAlert("#alert_label_password_register");
        }

        //check null code email
        if (code.length == 0) {
            PresentClosableBootstrapAlert("#alert_label_emailcode_register", "warning", "Vui lòng mã xác thực!");
            countT++
        } else {
            CloseAlert("#alert_label_emailcode_register");
        }

        //check already exist email
        //var urlcheckemail = "Account/UserNameExists?userName=" + email;
        //if (!checkAlreadyExistEmail(urlcheckemail)) {
        //    countT++;
        //}

        //check send code
        
        if (document.getElementById('EmailCode').style.display == "none") {
            PresentClosableBootstrapAlert("#alert_label_emailcodeinput_register", "warning", "Vui lòng trượt để nhận mã Email!");
            countT++
        } else {
            CloseAlert("#alert_label_emailcodeinput_register");
        }

        // Check Verification Email
        //var urkCheckVerification = "Account/CheckVerificationEmail?email=" + email + "&code=" + code;
        //if (!CheckVerificationEmail(urkCheckVerification)) {
        //    countT++
        //}

        //Regist

        if (countT == 0) {
            var user = {
                __RequestVerificationToken: antiForgeryToken,
                HoTen: hoten,
                Email: email,
                Password: password,
                Code: code,
                AcceptUserAgreement: true
            };
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

                    PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", errorText);

                    console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
                }

            });
        }
    }
});

//function CheckVerificationEmail(urkCheckVerification) {
//    var check = false;
//    $.ajax({
//        type: "POST",
//        url: urkCheckVerification,
//        success: function (data) {
//            if (data == true) {
//                PresentClosableBootstrapAlert("#alert_label_emailcode_register", "warning", "Mã xác nhận không hợp lệ!");
//                check = false;
//            }
//            else {
//                CloseAlert("#alert_label_emailcode_register");
//                check = true;
//            }
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
//            PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", errorText);
//            console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
//        }
//    });
//    return check;
//}

//function checkAlreadyExistEmail(urlcheckemail) {
//    var check = false;
//    $.ajax({
//        type: "POST",
//        url: urlcheckemail,
//        success: function (data) {
//            if (data == true) {
//                PresentClosableBootstrapAlert("#alert_label_email_register", "warning", "Địa chỉ email này đã được đăng ký!");
//                check = false;
//            }
//            else {
//                CloseAlert("#alert_label_email_register");
//                check = true;
//            }
//        },
//        error: function (xhr, ajaxOptions, thrownError) {
//            var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
//            PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", errorText);
//            console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
//        }
//    });

//    return check;
//}
