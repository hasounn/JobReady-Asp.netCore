const likes = document.querySelectorAll(".like"),
    shares = document.querySelectorAll(".share"),
    reports = document.querySelectorAll (".report");


likes.forEach(like => {like.addEventListener("click", () => {
        const path = like.querySelector(".like-button-path");
        const text = like.querySelector("p");
    const postId = document.querySelector("#postId").value
        if (path.getAttribute("fill") === "#FE1F1F") {
            $.ajax({
                type: "POST",
                url: '/Post/UnlikePost',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(postId),
                dataType: "json",
                success: function (response) {
                    if (response != false) {
                        path.setAttribute("fill", "none");
                        path.setAttribute("stroke", "#525657");
                        text.textContent = response;
                        text.style.color = "#525657";
                    }
                },
                error: function (xhr, status, error) {
                    // Handle error
                    alert("An error occurred: " + error);
                }
            })
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
                        text.textContent = response;
                        text.style.color = "#FE1F1F";
                    }
                },
                error: function (xhr, status, error) {
                    // Handle error
                    alert("An error occurred: " + error);
                }
            })
        }
    })
})


$(".reportText").each(function () {
    this.setAttribute("style", "height: 40px;overflow-y:hidden;");
}).on("input", function () {
    this.style.height = 40 + "px";
    this.style.height = (this.scrollHeight) + "px";
});