const like = document.querySelector(".like"),
    share = document.querySelector(".share"),
    report = document.querySelector(".report"),
    postId = document.getElementById("postId").value,
    countLikes = document.querySelector(".count-likes");


like.addEventListener("click", () => {
    const path = like.querySelector(".like-button-path");
    const text = like.querySelector("p");
    if (path.getAttribute("fill") === "#FE1F1F") {
        path.setAttribute("fill", "none");
        path.setAttribute("stroke", "#525657");
        text.textContent = "Like";
        text.style.color = "#525657";
    } else {
        $.ajax({
            type: "POST",
            url: '/Post/LikePost',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(postId),
            dataType: "json",
            success: function (response) {
                if (response != false) { 
                path.setAttribute("fill", "#FE1F1F");
                path.setAttribute("stroke", "#FE1F1F");
                text.textContent = "Liked";
                    text.style.color = "#FE1F1F";
                    countLikes.textContent = response;
                }
            },
            error: function (xhr, status, error) {
                // Handle error
                alert("An error occurred: " + error);
            }
        })
    }
})


$(".reportText").each(function () {
    this.setAttribute("style", "height: 40px;overflow-y:hidden;");
}).on("input", function () {
    this.style.height = 40 + "px";
    this.style.height = (this.scrollHeight) + "px";
});