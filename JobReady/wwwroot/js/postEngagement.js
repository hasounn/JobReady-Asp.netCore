const likes = document.querySelectorAll(".like"),
    comments = document.querySelectorAll(".comment"),
    shares = document.querySelectorAll(".share"),
    reports = document.querySelectorAll(".report"),
    items = document.querySelectorAll('[id^="modalToggler-"]');;


likes.forEach(like => {like.addEventListener("click", () => {
        const path = like.querySelector(".like-button-path");
        const text = like.querySelector("p");
        const postId = like.querySelector("#postId").value
        if (path.getAttribute("fill") === "#FE1F1F") {
            $.ajax({
                type: "POST",
                url: '/Post/UnlikePost',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(postId),
                dataType: "json",
                success: function (response) {
                        path.setAttribute("fill", "none");
                        path.setAttribute("stroke", "#525657");
                        text.textContent = response;
                        text.style.color = "#525657";
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
                    path.setAttribute("fill", "#FE1F1F");
                    path.setAttribute("stroke", "#FE1F1F");
                        text.textContent = response;
                        text.style.color = "#FE1F1F";
                },
                error: function (xhr, status, error) {
                    // Handle error
                    alert("An error occurred: " + error);
                }
            })
        }
    })
})

comments.forEach(comment => {
    comment.addEventListener("click", () => {
        const postIdComment = comment.querySelector(".postIdComment").value;
        const modal = document.querySelector("#postModal-" + postIdComment);
        const submitBtn = modal.querySelector(".send-button");
        const allComments = modal.querySelector(".comments-wrapper");
        const commentCount = comment.querySelector(".comment-count");
        let inputComment = modal.querySelector("#comment");
        $.ajax({
            type: "GET",
            url: '/Post/GetPostComments?postId=' + postIdComment,
            success: function (response) {
                if (response.length > 0) {
                    response.forEach(c => {
                        // Check if the comment already exists before appending
                        const existingComment = allComments.querySelector(`.user-comment .the-comment[data-comment-id="${c.id}"]`);
                        if (!existingComment) {
                            const usercDiv = document.createElement("div");
                            const innerDiv = document.createElement("div");
                            usercDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "justify-content-between", "gap-2", "mb-2");
                            innerDiv.classList.add("d-flex", "flex-row", "align-items-center", "gap-2");
                            const img = document.createElement("img");
                            img.setAttribute("src", "/Profile/GetProfilePicture/?userId=" + c.createdBy.id)
                            img.classList.add("user-comment-img", "rounded-circle");
                            innerDiv.appendChild(img);
                            const div = document.createElement("div");
                            div.classList.add("d-flex", "flex-column");
                            const p1 = document.createElement("p");
                            const p2 = document.createElement("p");
                            p1.classList.add("user-name");
                            p2.classList.add("the-comment");
                            p1.textContent = c.createdBy.username;
                            p2.textContent = c.content;
                            // Add a data attribute to the comment element to identify it uniquely
                            p2.setAttribute("data-comment-id", c.id);
                            div.appendChild(p1);
                            div.appendChild(p2);
                            innerDiv.appendChild(div);
                            const ptime = document.createElement("p");
                            ptime.classList.add("time-comment");
                            ptime.textContent = c.postedOn;
                            usercDiv.appendChild(innerDiv);
                            usercDiv.appendChild(ptime);
                            allComments.appendChild(usercDiv);
                        }
                    });
                }
            },
            error: function (res) {
                // Handle error
                console.error(res.responseText);
            }
        });
        submitBtn.addEventListener("click", () => {
            if (inputComment.value.trim() != "") {
                var details = {
                    Id: postIdComment,
                    Content: inputComment.value
                };

                $.ajax({
                    type: "POST",
                    url: '/Post/Comment',
                    data: JSON.stringify(details),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                            const usercDiv = document.createElement("div");
                            const innerDiv = document.createElement("div");
                            usercDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "justify-content-between", "gap-2","mb-4");
                            innerDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "gap-2");
                            const img = document.createElement("img");
                            img.setAttribute("src", "/Profile/GetProfilePicture/?userId=" + response.value)
                            img.classList.add("user-comment-img", "rounded-circle");
                            innerDiv.appendChild(img);
                            const div = document.createElement("div");
                            div.classList.add("d-flex", "flex-column");
                            const p1 = document.createElement("p");
                            const p2 = document.createElement("p");
                            p1.classList.add("user-name");
                            p2.classList.add("the-comment");
                            p2.setAttribute("data-comment-id", response.commentId);
                            p1.textContent = response.name;
                            p2.textContent = inputComment.value;
                            div.appendChild(p1);
                            div.appendChild(p2);
                            innerDiv.appendChild(div);
                            const ptime = document.createElement("p");
                            ptime.classList.add("time-comment");
                            ptime.textContent = response.postedOn;
                            usercDiv.appendChild(innerDiv);
                            usercDiv.appendChild(ptime);
                            allComments.appendChild(usercDiv);
                            inputComment.value = "";
                            commentCount.textContent = response.total;
                    },
                    error: function (res) {
                        // Handle error
                        console.error(res.responseText);
                    }
                });
            }
        })
        inputComment.addEventListener("keyup", (e) => {
            e.preventDefault();
            if (e.key == "Enter") {

            if (inputComment.value.trim() != "") {
                var details = {
                    Id: postIdComment,
                    Content: inputComment.value
                };

                $.ajax({
                    type: "POST",
                    url: '/Post/Comment',
                    data: JSON.stringify(details),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                            const usercDiv = document.createElement("div");
                            const innerDiv = document.createElement("div");
                            usercDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "justify-content-between", "gap-2","mb-4");
                            innerDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "gap-2");
                            const img = document.createElement("img");
                            img.setAttribute("src", "/Profile/GetProfilePicture/?userId=" + response.value)
                            img.classList.add("user-comment-img","rounded-circle");
                            innerDiv.appendChild(img);
                            const div = document.createElement("div");
                            div.classList.add("d-flex", "flex-column");
                            const p1 = document.createElement("p");
                            const p2 = document.createElement("p");
                            p1.classList.add("user-name");
                            p2.classList.add("the-comment");
                            p2.setAttribute("data-comment-id", response.commentId);
                            p1.textContent = response.name;
                            p2.textContent = inputComment.value;
                            div.appendChild(p1);
                            div.appendChild(p2);
                            innerDiv.appendChild(div);
                            const ptime = document.createElement("p");
                            ptime.classList.add("time-comment");
                            ptime.textContent = response.postedOn;
                            usercDiv.appendChild(innerDiv);
                            usercDiv.appendChild(ptime);
                            allComments.appendChild(usercDiv);
                            inputComment.value = "";
                            commentCount.textContent = response.total;
                    },
                    error: function (res) {
                        // Handle error
                        console.error(res.responseText);
                    }
                });
                }
            }
        })
    })
})

items.forEach(post => {
    post.addEventListener("click", () => {
        const postIdComment = post.getAttribute("id").split("-")[1];
        const modal = document.querySelector("#postModal-" + postIdComment);
        const submitBtn = modal.querySelector(".send-button");
        const allComments = modal.querySelector(".comments-wrapper");
        let inputComment = modal.querySelector("#comment");
        $.ajax({
            type: "GET",
            url: '/Post/GetPostComments?postId=' + postIdComment,
            success: function (response) {
                if (response.length > 0) {
                        console.log(response)
                    response.forEach(c => {
                        // Check if the comment already exists before appending
                        const existingComment = allComments.querySelector(`.user-comment .the-comment[data-comment-id="${c.id}"]`);
                        if (!existingComment) {
                            const usercDiv = document.createElement("div");
                            const innerDiv = document.createElement("div");
                            usercDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "justify-content-between", "gap-2","mb-4");
                            innerDiv.classList.add("d-flex", "flex-row", "align-items-center", "gap-2");
                            const img = document.createElement("img");
                            img.setAttribute("src", "/Profile/GetProfilePicture/?userId=" + c.createdBy.id)
                            img.classList.add("user-comment-img", "rounded-circle");
                            innerDiv.appendChild(img);
                            const div = document.createElement("div");
                            div.classList.add("d-flex", "flex-column");
                            const p1 = document.createElement("p");
                            const p2 = document.createElement("p");
                            p1.classList.add("user-name");
                            p2.classList.add("the-comment");
                            p1.textContent = c.createdBy.username;
                            p2.textContent = c.content;
                            // Add a data attribute to the comment element to identify it uniquely
                            p2.setAttribute("data-comment-id", c.id);
                            div.appendChild(p1);
                            div.appendChild(p2);
                            innerDiv.appendChild(div);
                            const ptime = document.createElement("p");
                            ptime.classList.add("time-comment");
                            ptime.textContent = c.postedOn;
                            usercDiv.appendChild(innerDiv);
                            usercDiv.appendChild(ptime);
                            allComments.appendChild(usercDiv);
                        }   
                    });
                }
            },
            error: function (res) {
                // Handle error
                console.error(res.responseText);
            }
        });
        submitBtn.addEventListener("click", () => {
            if (inputComment.value.trim() != "") {
                var details = {
                    Id: postIdComment,
                    Content: inputComment.value
                };

                $.ajax({
                    type: "POST",
                    url: '/Post/Comment',
                    data: JSON.stringify(details),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        const usercDiv = document.createElement("div");
                        const innerDiv = document.createElement("div");
                        usercDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "justify-content-between", "gap-2","mb-4");
                        innerDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "gap-2");
                        const img = document.createElement("img");
                        img.setAttribute("src", "/Profile/GetProfilePicture/?userId=" + response.value)
                        img.classList.add("user-comment-img", "rounded-circle");
                        innerDiv.appendChild(img);
                        const div = document.createElement("div");
                        div.classList.add("d-flex", "flex-column");
                        const p1 = document.createElement("p");
                        const p2 = document.createElement("p");
                        p1.classList.add("user-name");
                        p2.classList.add("the-comment");
                        p2.setAttribute("data-comment-id", response.commentId);
                        p1.textContent = response.name;
                        p2.textContent = inputComment.value;
                        div.appendChild(p1);
                        div.appendChild(p2);
                        innerDiv.appendChild(div);
                        const ptime = document.createElement("p");
                        ptime.classList.add("time-comment");
                        ptime.textContent = response.postedOn;
                        usercDiv.appendChild(innerDiv);
                        usercDiv.appendChild(ptime);
                        allComments.appendChild(usercDiv);
                    },
                    error: function (res) {
                        // Handle error
                        console.error(res.responseText);
                    }
                });
            }
        })
        inputComment.addEventListener("keyup", (e) => {
            e.preventDefault();
            if (e.key == "Enter") {
                console.log(inputComment.value.trim() != "");

                if (inputComment.value.trim() != "") {
                    var details = {
                        Id: postIdComment,
                        Content: inputComment.value
                    };

                    $.ajax({
                        type: "POST",
                        url: '/Post/Comment',
                        data: JSON.stringify(details),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            const usercDiv = document.createElement("div");
                            const innerDiv = document.createElement("div");
                            usercDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "justify-content-between", "gap-2","mb-4");
                            innerDiv.classList.add("user-comment", "d-flex", "flex-row", "align-items-center", "gap-2");
                            const img = document.createElement("img");
                            img.setAttribute("src", "/Profile/GetProfilePicture/?userId=" + response.value)
                            img.classList.add("user-comment-img", "rounded-circle");
                            innerDiv.appendChild(img);
                            const div = document.createElement("div");
                            div.classList.add("d-flex", "flex-column");
                            const p1 = document.createElement("p");
                            const p2 = document.createElement("p");
                            p1.classList.add("user-name");
                            p2.classList.add("the-comment");
                            p2.setAttribute("data-comment-id", response.commentId);
                            p1.textContent = response.name;
                            p2.textContent = inputComment.value;
                            div.appendChild(p1);
                            div.appendChild(p2);
                            innerDiv.appendChild(div);
                            const ptime = document.createElement("p");
                            ptime.classList.add("time-comment");
                            ptime.textContent = response.postedOn;
                            usercDiv.appendChild(innerDiv);
                            usercDiv.appendChild(ptime);
                            allComments.appendChild(usercDiv);
                            inputComment.value = "";
                        },
                        error: function (res) {
                            // Handle error
                            console.error(res.responseText);
                        }
                    });
                }
            }
        })
    })
})



$(".reportText").each(function () {
    this.setAttribute("style", "height: 40px;overflow-y:hidden;");
}).on("input", function () {
    this.style.height = 40 + "px";
    this.style.height = (this.scrollHeight) + "px";
});