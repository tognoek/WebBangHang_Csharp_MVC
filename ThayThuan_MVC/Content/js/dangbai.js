/**
 * 
 */


const img = document.querySelector(".imgsp")
console.log(img)
const inputFile = document.querySelector(".sImg")
console.log(inputFile)

inputFile.addEventListener("change", (e) => {
    const file = e.target.files[0];
    const fileUrl = URL.createObjectURL(file);
    console.log(fileUrl);
    img.src = fileUrl
    console.log(inputFile.files[0].name)
})