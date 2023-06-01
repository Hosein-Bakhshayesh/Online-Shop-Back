var btn = document.getElementById("btn-active");
var login = document.getElementById("login");
var register = document.getElementById("register");

function Register()
{
    btn.style.left = "110px";
    login.style.display = "none";
    register.style.display = "block";
}

function Login()
{
    btn.style.left = "0px";
    login.style.display = "block";
    register.style.display = "none";
}