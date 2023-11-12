const searchInput = document.getElementById("search-input");
var sotrang = document.getElementsByClassName("trang");
const min = document.getElementById("minamount");
const max = document.getElementById("maxamount");

var search = document.querySelector(".search-model");
var sanpham = document.getElementsByClassName("sanpham");
var ten = document.getElementsByClassName("nameSp");
var gia = document.getElementsByClassName("giaSp");

var searchMn = document.querySelector(".searchMn");

searchInput.addEventListener("keydown", function(event) {
  if (event.key === "Enter") {
    // Thực hiện tìm kiếm ở đây
    key = searchInput.value
    event.preventDefault();
    document.cookie = "k=1"
    for (var t = 0; t < sotrang.length; t++){
        sotrang[t].classList.remove("toMau")
    }
    sotrang[0].classList.add("toMau")
    var sl = 0;
    for (var t = 0 ; t < sanpham.length ; t++){
        sanpham[t].classList.add("noSanpham1")
        sanpham[t].classList.remove("noSanpham")
        if (ten[t].innerHTML.includes(key) == true){
            sanpham[t].classList.remove("noSanpham1")
            var TF = true
            for (var r = 0; r < sanpham[t].classList.length; r++ ){
                if (sanpham[t].classList[r] === "noSanpham2"){
                    TF = false
                }
            }
            if (TF == true){
                sl = sl + 1
            }
        }
        if (sl > 9){
            sanpham[t].classList.add("noSanpham")
        }
    }
    search.style.display = "none"
  }
});

searchMn.addEventListener('click', function () {
    var minVl = parseInt(min.value.substring(1, min.value.length))
    var maxVl = parseInt(max.value.substring(1, max.value.length))
    document.cookie = "k=1"
    for (var t = 0; t < sotrang.length; t++){
        sotrang[t].classList.remove("toMau")
    }
    sotrang[0].classList.add("toMau")
    console.log(minVl, maxVl)
    var sl = 0
    for (var t = 0 ; t < sanpham.length ; t++){
        sanpham[t].classList.add("noSanpham2")
        sanpham[t].classList.remove("noSanpham")
        var giatien = parseInt(gia[t].innerHTML.substring(2, gia[t].innerHTML.length))
        if (minVl <= giatien && giatien <= maxVl){
            sanpham[t].classList.remove("noSanpham2")
            var TF = true
            for (var r = 0; r < sanpham[t].classList.length; r++ ){
                if (sanpham[t].classList[r] === "noSanpham1"){
                    TF = false
                }
            }
            if (TF == true){
                sl = sl + 1
            }
        }
        if (sl > 9){
            sanpham[t].classList.add("noSanpham")
        }
    }
})

