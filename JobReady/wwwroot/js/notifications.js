
const maindiv = document.querySelector(".height-fix");

window.addEventListener("load", () => {

    maindiv.style.height = document.body.scrollHeight + "px";
})

$(document).ready(function () {

    $('.category').click(function () {
        var category = $(this).data('category');
        $('.category-notification').hide();
        $('.' + category + '-notification').show();
    });
});

