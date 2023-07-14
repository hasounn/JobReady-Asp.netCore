const maindiv = document.querySelector(".height-fix"),
    searchDiv = document.querySelector(".searchDiv"),
    filterBtns = document.querySelectorAll(".filter-btn");


window.addEventListener("load", () => {
    if (searchDiv.children.length > 0) {
        maindiv.style.height = document.body.scrollHeight + "px";
    } else {
        maindiv.style.height = "100vh";
    }
});

filterBtns.forEach(btn => {
    btn.addEventListener("click", () => {
        $.ajax({
            type: "POST",
            url: '/Search/ApplyFilter',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ request: { SearchText: $(".search-input").val(), Type:btn.textContent } }),
            dataType: "json",
            success: function (response) {
            },
            error: function (xhr, status, error) {
                alert("An error occurred: " + error);
            }
        })
    })
})