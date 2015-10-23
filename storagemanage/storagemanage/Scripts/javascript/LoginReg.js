/*
*快速注册和快速登录切换
*/
var RegorLogin = {
    //快速登录和快速注册按钮切换
    regorLoginOnClick: function () {
        $('#switch_qlogin').click(function () {
            $('#switch_login').removeClass("switch_btn_focus").addClass('switch_btn');
            $('#switch_qlogin').removeClass("switch_btn").addClass('switch_btn_focus');
            $('#switch_bottom').animate({ left: '0px', width: '70px' });
            $('#qlogin').css('display', 'none');
            $('#web_qr_login').css('display', 'block');
        });
        $('#switch_login').click(function () {
            $('#switch_login').removeClass("switch_btn").addClass('switch_btn_focus');
            $('#switch_qlogin').removeClass("switch_btn_focus").addClass('switch_btn');
            $('#switch_bottom').animate({ left: '154px', width: '70px' });

            $('#qlogin').css('display', 'block');
            $('#web_qr_login').css('display', 'none');
        });
        if (this.getParam("a") == '0') {
            $('#switch_login').trigger('click');
        }
    },
    //根据参数名获得该参数 pname等于想要的参数名 
    getParam: function () {
        var params = location.search.substr(1); // 获取参数 平且去掉？ 
        var ArrParam = params.split('&');
        if (ArrParam.length == 1) {
            //只有一个参数的情况 
            return params.split('=')[1];
        }
        else {
            //多个参数参数的情况 
            for (var i = 0; i < ArrParam.length; i++) {
                if (ArrParam[i].split('=')[0] == pname) {
                    return ArrParam[i].split('=')[1];
                }
            }
        } 
    }
}

/*
*用户注册
*/
var UserReg = {
    userName: $('#user').val(),
    password: $('#passwd').val(),
    pwdmin:6,
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
            if ($('#passwd').val().length < this.pwdmin) {
                UserRegEx.passwordLen();
                return false;
            }
            if ($('#passwd2').val() != $('#passwd').val()) {
                UserRegEx.passwordIsSam();
                return false;
            }
            RegPost.regSubmit();
        });
    }
}

/*
*注册post
*/
var RegPost = {
    regSubmit: function () {
        var url = '';
        $.post('/Login/GetUrl', '', function (res) {
            url = res.url;
        });
        if (url != '') {
            alert(url);
        }
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
    RegorLogin.regorLoginOnClick();
    UserReg.onClick();
});