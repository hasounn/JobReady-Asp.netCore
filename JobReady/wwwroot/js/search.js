const maindiv = document.querySelector(".height-fix"),
searchDiv = document.querySelector(".searchDiv");

window.addEventListener("load", () => {
    if (searchDiv.children.length > 0) {
        maindiv.style.height = document.body.scrollHeight + "px";
    } else {
        maindiv.style.height = "100vh";
    }
});