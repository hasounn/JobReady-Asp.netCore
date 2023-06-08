const like = document.querySelector(".like"),
    share = document.querySelector(".share"),
    report = document.querySelector(".report");


like.addEventListener("click", () => {
    const path = like.querySelector(".like-button-path");
    const text = like.querySelector("p");
    console.log("Like");
    if (path.getAttribute("fill") === "#FE1F1F") {
        path.setAttribute("fill" ,"none");
        path.setAttribute("stroke","#525657");
        text.textContent = "Like";
        text.style.color = "#525657";
    } else {
        path.setAttribute("fill" , "#FE1F1F");
        path.setAttribute("stroke" , "#FE1F1F");
        text.textContent = "Liked";
        text.style.color = "#FE1F1F";
    }
})

$(".reportText").each(function () {
    this.setAttribute("style", "height: 40px;overflow-y:hidden;");
}).on("input", function () {
    this.style.height = 40 + "px";
    this.style.height = (this.scrollHeight) + "px";
});