var addSp = document.getElementsByClassName("icon_bag_alt");
function deleteCookie(key) {
    document.cookie = key + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
}
for (var t = 0; t < addSp.length; t++){
    addSp[t].addEventListener('click', function () {
        
        var allCookies = document.cookie;
        var cookiesArray = allCookies.split(';');
        var maSp = this.classList[1]
        var k = 0
        var maSpck = "cart" + maSp + "="
        for (var i = 0; i < cookiesArray.length; i++) {
            var cookie = cookiesArray[i].trim();
                if (cookie.indexOf(maSpck) == 0) {
                    var value = cookie.substring(maSpck.length, cookie.length);
                    var decodedValue = decodeURIComponent(value);
                    k = parseInt(decodedValue)
                }
        }
        k = k + 1
        var ckSave = maSpck + k
        document.cookie = ckSave
        document.cookie = "add" + ckSave
        // console.log(ckSave)
    })
}/**
 * 
 */