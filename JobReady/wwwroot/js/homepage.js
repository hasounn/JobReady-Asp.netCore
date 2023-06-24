const maindiv = document.querySelector(".height-fix"),
    posts = document.querySelector(".posts"),
    layoutMainDiv = document.querySelector(".navbar"),
    filterNewsItem = document.querySelectorAll(".filter-news-item");

window.addEventListener("load", () => {
    if (posts.children.length > 3) {
        maindiv.style.height = document.body.scrollHeight + "px";
        maindiv.style.paddingBottom = "20px";
    } else {
        maindiv.style.height = maindiv.style.height = document.body.scrollHeight + "px";
        maindiv.style.paddingBottom = "0px";
    }

    if ((window.screen.width < 1024 && window.screen.width > 1000) ||
        (window.screen.width <= 1000 && window.screen.width >= 769)) {
        maindiv.style.paddingTop = layoutMainDiv.offsetHeight + 5 + "px";
    }
    else if (window.screen.width <= 768) {
        maindiv.style.paddingTop = 12 + "px";
    }
    else if (window.screen.width >= 1024) {
        maindiv.style.paddingTop = 0;
    }
})

filterNewsItem.forEach(item => {
    item.addEventListener("click", () => {
        removeActiveItems();
        item.classList.add("active");
    })
})

const removeActiveItems = () => {
    filterNewsItem.forEach(item => {
        item.classList.remove("active");
    })
}