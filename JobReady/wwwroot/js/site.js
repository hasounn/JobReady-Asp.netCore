const home = document.querySelector("#home-nav"),
    search = document.querySelector("#search-nav"),
    notifs = document.querySelector("#notifs-nav"),
    post = document.querySelector("#post-nav"),
    settings = document.querySelector("#settings-nav"),
    profile = document.querySelector("#profile-nav"),
    navItems = document.querySelectorAll(".nav-item");;

window.addEventListener("load", () => {
    removeAllActives();
    let url = window.location.href;
    if (url.includes("Home")) {
        home.classList.add("active");
    } else if (url.includes("Search")) {
        search.classList.add("active");
    } else if (url.includes("Notifications")) {
        notifs.classList.add("active");
    } else if (url.includes("Post")) {
        post.classList.add("active");
    } else if (url.includes("Settings")) {
        settings.classList.add("active");
    } else if (url.includes("Profile")) {
        profile.classList.add("active");
    } else {
        home.classList.add("active");
    }
})

const removeAllActives = () => {
    navItems.forEach(item => {
        item.classList.remove("active");
    })
}

navItems.forEach(item => {
    item.addEventListener("click", (e) => {
        e.preventDefault(); // Prevent the default link behavior
        const active = document.querySelector(".active");
        active.classList.add('fade-out'); // Add the fade-out class to initiate the animation
        const a = item.querySelector("a"); //select the <a> in the item
        setTimeout(function () {
            window.location.href=a.href; // Navigate to the link's href after a delay
        }, 200); // Adjust the duration of the fade-out animation (in milliseconds) and the delay before changing the href as needed
    });
})