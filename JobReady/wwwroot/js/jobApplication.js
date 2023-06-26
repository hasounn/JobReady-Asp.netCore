window.addEventListener('DOMContentLoaded', function () {
    var container = document.querySelector('.dark-main-bg'),
        activeJob = document.getElementById("activeJob");

    if (container.scrollHeight > container.clientHeight) {
        container.style.setProperty('height', 'fit-content', 'important')
    }
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

activeJob.addEventListener("click", () => {
    $.ajax({
        type:"POST",
        url:"/JobApplication/UpdateStatus",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify($("#jobPostId").val()),
        dataType: "json",
        success: (response) => {
            $("#liveToast").toast("show");
            setTimeout(function() {
              $("#closeButton").click();
            }, 3000);
        },
        error: () => {
            alert("Something went wrong!");
        }
    })
})