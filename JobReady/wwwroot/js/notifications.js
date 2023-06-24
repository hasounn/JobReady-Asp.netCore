
const maindiv = document.querySelector(".height-fix"),
    notificationList = document.getElementById("notification-list");

window.addEventListener("load", () => {

    if (notificationList.children.length > 4) { 
        maindiv.style.height = document.body.scrollHeight + "px";
    } else{
        maindiv.style.height = "100vh";
    }
})


$(document).ready(function () {

    $('.category').click(function () {
        var category = $(this).data('category');
        $('.category-notification').hide();
        $('.' + category + '-notification').show();
    });
});

