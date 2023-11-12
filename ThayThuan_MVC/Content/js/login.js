var login = document.querySelector(".login");
var sigin = document.querySelector(".sigin");
var k = 0
var formLogin = document.querySelector(".login-box");
var h = 0
var formSigin = document.querySelector(".ctndankky");
function Run() {
    k = k + 1;
    if (k % 2 == 1) {
        formLogin.classList.add("Run")
        h = h + 1
        formSigin.classList.remove("Run")
    }
    else {
        formLogin.classList.remove("Run")
    }
}

function Run1(){
    h = h + 1;
    if (h % 2 == 1) {
        formSigin.classList.add("Run")
        k = k + 1
        formLogin.classList.remove("Run")
    }
    else {
        formSigin.classList.remove("Run")
    }
}

sigin.addEventListener('click', Run1);

login.addEventListener('click', Run);