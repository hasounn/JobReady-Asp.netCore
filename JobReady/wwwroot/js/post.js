const file = document.querySelector("#image"),
    divFile = document.querySelector(".photo-video-choose"),
    imageWrapper = document.querySelector(".picture-wrapper");


$(".textarea-post").each(function () {
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

divFile.addEventListener("click", () => {
    file.click();
})

const previewImage = () => {
    var image = file.files[0];
    if (imageWrapper.children.length > 0) {
        imgUser = document.querySelector(".img-user");
        var reader = new FileReader();
        reader.onload = function (e) {
            imgUser.src = e.target.result;
        };
        reader.readAsDataURL(image);
    } else {
        let imageTag = document.createElement("img");
        imageTag.classList.add("img-user");
        var reader = new FileReader();
        reader.onload = function (e) {
            imageTag.src = e.target.result;
        };
        reader.readAsDataURL(image);
        imageWrapper.appendChild(imageTag);
    }
}