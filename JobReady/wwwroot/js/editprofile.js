const maindiv = document.querySelector(".height-fix"),
    divs = document.querySelector(".all-divs"),
    items = document.querySelectorAll('[id^="editExperienceModal-"]');

window.addEventListener("load", () => {
    if (divs.children.length > 0) {
        maindiv.style.height = document.body.scrollHeight + "px";
    } else {
        maindiv.style.height = "100vh";
    }
})

$(".about-textarea").each(function () {
    this.setAttribute("style", "height:" + (this.scrollHeight) + "px; overflow-y:auto;");
}).on("input", function () {
    this.style.height = "auto";
    this.style.height = (this.scrollHeight) + "px";
}).on("keydown", function (e) {
    if (e.keyCode === 8 || e.keyCode === 46) { // Check if backspace or delete key is pressed
        setTimeout(() => {
            this.style.height = "auto";
            this.style.height = (this.scrollHeight) + "px";
        }, 0);
    }
});

$('.textarea-description').each(function () {
    this.setAttribute("style", "height: 40px; overflow-y:auto;");
}).on("input", function () {
    this.style.height = "auto";
    this.style.height = (this.scrollHeight) + "px";
}).on("keydown", function (e) {
    if (e.keyCode === 8 || e.keyCode === 46) { // Check if backspace or delete key is pressed
        setTimeout(() => {
            this.style.height = "auto";
            this.style.height = (this.scrollHeight) + "px";
        }, 0);
    }
});

function isWorking(arg){
    if (arg.checked == true) {
        arg.parentElement.children[1].value = "true";
        arg.parentElement.parentElement.children[6].children[1].setAttribute("disabled", "true");
    } else {
        arg.parentElement.children[1].value = "false";
        arg.parentElement.parentElement.children[6].children[1].removeAttribute("disabled");
    }
}

items.forEach(item => {
    const isCurrent = item.children[1].querySelector("#isCurrentlyWorking"),
        endDate = item.children[1].querySelector("#endDate");

        if (isCurrent.value = "true") {
            endDate.setAttribute("disabled", "true");
        } else{
            endDate.removeAttribute("disabled");
        }
    })