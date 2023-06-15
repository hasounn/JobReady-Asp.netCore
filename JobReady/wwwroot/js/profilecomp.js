const maindiv = document.querySelector(".height-fix"),
    divs = document.querySelector(".all-divs");

window.addEventListener("load", () => {
    if (divs.children.length > 0) {
        maindiv.style.height = document.body.scrollHeight + "px";
    } else {
        maindiv.style.height = "100vh";
    }
})
