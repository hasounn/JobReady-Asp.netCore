window.addEventListener('DOMContentLoaded', function () {
    var container = document.querySelector('.dark-main-bg');

    if (container.scrollHeight > container.clientHeight) {
        container.style.setProperty('height', 'fit-content', 'important')
    }
});

$(".letter").each(function () {
    this.setAttribute("style", "height: 40px;overflow-y:scroll;");
}).on("input", function () {
    this.style.height = 40 + "px";
    this.style.height = (this.scrollHeight) + "px";
});