var formLogin = document.querySelector(".login-box");
var formSigin = document.querySelector(".ctndankky");

var cookieString = document.cookie;

var cookies = cookieString.split(';');
for (var i = 0; i < cookies.length; i++) {
  var cookie = cookies[i].trim();
  if (cookie.indexOf("logsig=") == 0) {
    var cookieValue = cookie.substring("logsig=".length, cookie.length);
    if (cookieValue == 1){
		formLogin.classList.add("Run")
	}
	if (cookieValue == 2){
		formSigin.classList.add("Run")
	}
    break;
  }
}
/**
 * 
 */