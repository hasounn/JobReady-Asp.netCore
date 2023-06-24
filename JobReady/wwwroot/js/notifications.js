
const maindiv = document.querySelector(".height-fix"),
    notificationList = document.getElementById("notification-list");

window.addEventListener("load", () => {

    if (notificationList.children.length > 4) { 
        maindiv.style.height = document.body.scrollHeight + "px";
    } else{
        maindiv.style.height = "100vh";
    }
})

    $('.category').click(function () {
        var category = $(this).data('category');
        $('.category-notification').hide();
        $('.' + category + '-notification').show();
    });

$(".letter").each(function () {
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