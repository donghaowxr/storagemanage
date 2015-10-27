var RegOrLogin = {
    //注册密码最小长度
    pwdmin: 6,
    //初始化页面
    initPage: function () {
        this.onClick();
    },
    //切换快速登录
    switLogin: function () {
        $('#switch_login').removeClass("switch_btn_focus").addClass('switch_btn');
        $('#switch_qlogin').removeClass("switch_btn").addClass('switch_btn_focus');
        $('#switch_bottom').animate({ left: '0px', width: '70px' });
        $('#qlogin').css('display', 'none');
        $('#web_qr_login').css('display', 'block');
    },
    //切换快速注册
    switReg: function () {
        $('#switch_login').removeClass("switch_btn").addClass('switch_btn_focus');
        $('#switch_qlogin').removeClass("switch_btn_focus").addClass('switch_btn');
        $('#switch_bottom').animate({ left: '154px', width: '70px' });
        $('#qlogin').css('display', 'block');
        $('#web_qr_login').css('display', 'none');
    },
    //注册用户名为空
    regUserNameIsNull: function () {
        $('#user').focus().css({
            border: "1px solid red",
            boxShadow: "0 0 2px red"
        });
        $('#userCue').html("<font color='red'><b>×用户名不能为空</b></font>");
    },
    //注册用户名长度必须在4-16个字符之间
    regUserNameLen: function () {
        $('#user').focus().css({
            border: "1px solid red",
            boxShadow: "0 0 2px red"
        });
        $('#userCue').html("<font color='red'><b>×用户名位4-16字符</b></font>");
    },
    //注册密码最小长度不得小于6
    regPasswordLen: function () {
        $('#passwd').focus();
        $('#userCue').html("<font color='red'><b>×密码不能小于" + RegOrLogin.pwdmin + "位</b></font>");
    },
    //注册时验证两次密码是否一样
    regPasswordIsSam: function () {
        $('#passwd2').focus();
        $('#userCue').html("<font color='red'><b>×两次密码不一致！</b></font>");
    },
    //注册post
    regPost: function () {
        var regData = {
            username: $('#user').val(),
            password: $('#passwd').val()
        }
        $.post('/Login/regPost', regData, function (res) {
            if (res.msg == 'SUCCESS') {
                $('#userCue').html("<font color='green'><b>√注册成功</b></font>");
            }
            if (res.msg == 'FAIL') {
                $('#userCue').html("<font color='red'><b>×注册失败</b></font>");
            }
        });
    },
    //点击事件绑定
    onClick: function () {
        //点击注册按钮
        $('#reg').on('click', function (e) {
            if ($('#user').val() == "") {
                RegOrLogin.regUserNameIsNull();
                return false;
            }
            if ($('#user').val().length < 4 || $('#user').val().length > 16) {
                RegOrLogin.regUserNameLen();
                return false;
            }
            if ($('#passwd').val().length < RegOrLogin.pwdmin) {
                RegOrLogin.regPasswordLen();
                return false;
            }
            if ($('#passwd2').val() != $('#passwd').val()) {
                RegOrLogin.regPasswordIsSam();
                return false;
            }
            RegOrLogin.regPost();
        });
        //点击登录按钮
        $('#login').on('click', function (e) {
            alert(RegOrLogin.loginUsername);
        });
        //点击快速登录按钮
        $('#switch_qlogin').on('click', function (e) {
            RegOrLogin.switLogin();
        });
        //点击快速注册按钮
        $('#switch_login').on('click', function (e) {
            RegOrLogin.switReg();
        });
    }
}