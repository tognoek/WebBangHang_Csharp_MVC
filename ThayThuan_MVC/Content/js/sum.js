const Subtotal = document.querySelector('.Subtotal')
const Total = document.querySelector('.Total')
var List = document.getElementsByClassName("cart__total")
var ListBt = document.getElementsByClassName("qtybtn")
var sum = 0
for (var i = 0; i < List.length; i++){
    var Val = Number(List[i].innerHTML.substring(2, List[i].innerHTML.length - 2))
    sum = sum + Val
}
Subtotal.innerHTML = "$ " + sum + ".0"
Total.innerHTML = "$ " + parseInt(sum * 90 / 100) + ".0"

for (var i = 0; i < ListBt.length; i++){
    ListBt[i].addEventListener('click', function () {
        var sum = 0
        var List = document.getElementsByClassName("cart__total")
        for (var T = 0; T < List.length; T++){
            var Val = Number(List[T].innerHTML.substring(2, List[T].innerHTML.length - 2))
            sum = sum + Val
            Subtotal.innerHTML = "$ " + sum + ".0"
            Total.innerHTML = "$ " + parseInt(sum * 90 / 100) + ".0"
        }
    })
}
