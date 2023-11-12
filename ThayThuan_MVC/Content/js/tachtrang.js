var sotrang = document.getElementsByClassName("trang");
var sanpham = document.getElementsByClassName("sanpham");
window.onload = function() {
    var allCookies = document.cookie;
    var k = 1;
var cookiesArray = allCookies.split(';');
for (var i = 0; i < cookiesArray.length; i++) {
  var cookie = cookiesArray[i].trim();
  if (cookie.indexOf("k=") == 0) {
    var value = cookie.substring("k=".length, cookie.length);
    var decodedValue = decodeURIComponent(value);
    k = parseInt(decodedValue)
  }
}
    var bg = (k-1) * 9;
    var ed = k * 9 - 1;
    sotrang[k-1].classList.add("toMau")
    if (ed >= sanpham.length){
        ed = sanpham.length - 1;
    }
    for (var t = bg ; t <= ed ; t++){
        sanpham[t].classList.remove("noSanpham")
    }
    for (var t = 0; t < sanpham.length; t++){
        if (t < bg || t > ed){
            sanpham[t].classList.add("noSanpham")
        }
    }
  }


// Lặp qua các phần tử và gán sự kiện "click"
for (var i = 0; i < sotrang.length; i++) {
    sotrang[i].addEventListener("click", function() {
    // Lấy giá trị trong thẻ và hiển thị nó
    var a = []
    for (var t = 0; t < sanpham.length; t++){
        var TF = true
        for (var r = 0; r < sanpham[t].classList.length; r++ ){
            if (sanpham[t].classList[r] === "noSanpham1" || sanpham[t].classList[r] === "noSanpham2"){
                TF = false
            }
        }
        if (TF == true){
            a.push(t)
        }
    }
    var k = parseInt(this.innerHTML);
    document.cookie = "k=" + k.toString()
    for (var t = 0 ; t < sotrang.length; t++){
        if (t - i != 0){
            sotrang[t].classList.remove("toMau")
        }
    }
    this.classList.add("toMau")
    var bg = (k-1) * 9;
    var ed = k * 9 - 1;
    if (ed >= a.length){
        ed = a.length - 1;
    }
    for (var t = 0 ; t < sanpham.length ; t++){
        sanpham[t].classList.remove("noSanpham")
    }
    for (var t = 0; t < sanpham.length; t++){
        var FT = true
        for (var r = 0 ; r < a.length; r++){
            if (t.toString() != a[r]){
                FT = false
            }
        }
        if (FT == true){
            sanpham[t].classList.add("noSanpham")
        }
    }
    for (var t = 0; t < a.length; t++){
        if (t < bg || t > ed){
            sanpham[parseInt(a[t])].classList.add("noSanpham")
        }
    }
  });
}
