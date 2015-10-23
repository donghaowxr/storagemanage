/*
*用户注册
*/
var UserReg = {
    userName: $('#user').val(),
    password: $('#passwd').val(),
    onClick: function () {
        $('#reg').click(function () {
            if ($('#user').val() == "") {
                UserRegEx.userNameIsNull();
                return false;
            }
            if ($('#user').val().length < 4 || $('#user').val().length > 16) {
                UserRegEx.userNameLen();
                return false;
            }
            if ($('#passwd').val().length < pwdmin) {
                UserRegEx.passwordLen();
                return false;
            }
            if ($('#passwd2').val() != $('#passwd').val()) {
                UserRegEx.passwordIsSam();
                return false;
            }
        });
    }
}

/*
*用户注册post
*/
var UserRegPost = {
    submit: function () {
    }
}

/*
*用户注册异常处理
*/
var UserRegEx = {
    //用户名不能为空
    userNameIsNull: function () {
        $('#user').focus().css({
            border: "1px solid red",
            boxShadow: "0 0 2px red"
        });
        $('#userCue').html("<font color='red'><b>×用户名不能为空</b></font>");
    },

    //限制用户名在4-16个字符
    userNameLen: function () {
        $('#user').focus().css({
            border: "1px solid red",
            boxShadow: "0 0 2px red"
        });
        $('#userCue').html("<font color='red'><b>×用户名位4-16字符</b></font>");
    },

    //密码长度不能太短
    passwordLen: function () {
        $('#passwd').focus();
        $('#userCue').html("<font color='red'><b>×密码不能小于" + pwdmin + "位</b></font>");
    },

    //验证两次密码是否一致
    passwordIsSam: function () {
        $('#passwd2').focus();
        $('#userCue').html("<font color='red'><b>×两次密码不一致！</b></font>");
    }
}

$(function () {
    UserReg.onClick();
});