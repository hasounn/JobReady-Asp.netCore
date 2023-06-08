const file = document.querySelector("#image"),
    divFile = document.querySelector(".photo-video-choose"),
    imageWrapper = document.querySelector(".picture-wrapper");


$(".textarea-post").each(function () {
    this.setAttribute("style", "height:" + (this.scrollHeight) + "px;overflow-y:hidden;");
}).on("input", function () {
    this.style.height = 30+"px";
    this.style.height = (this.scrollHeight) + "px";
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