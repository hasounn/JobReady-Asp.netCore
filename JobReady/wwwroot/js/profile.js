const maindiv = document.querySelector(".height-fix"),
    divs = document.querySelector(".all-divs"),
    userId = document.getElementById("userID").value;

window.addEventListener("load", () => {
    if (divs.children.length > 0) {
        maindiv.style.height = document.body.scrollHeight + "px";
    } else {
        maindiv.style.height = "100vh";
    }
})
const getSkills = () => {
    $.ajax({
        type: "GET",
        url: '/Profile/GetUserSkills',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(userId),
        dataType: "json",
        success: function (response) {
            return response;
        },
        error: function (xhr, status, error) {
            // Handle error
            alert("An error occurred: " + error);
        }
    });
}

var tagCloud = TagCloud('.skills', getSkills(), {

    // Sphere radius in px
    radius: 150,

    // animation speed
    // slow, normal, fast
    maxSpeed: 'normal',
    initSpeed: 'normal',

    // Rolling direction [0 (top) , 90 (left), 135 (right-bottom)] 
    direction: 135,

    // interaction with mouse or not [Default true (decelerate to rolling init speed, and keep rolling with mouse).]
    keep: true

});

// Giving color to each text in sphere
var color = '#77cfff ';
document.querySelector('.skills').style.color = color;


var carouselWidth = $('.carousel-inner').width();
var cardWidth = $(".carousel-item").width();
var scrollPosition = 0;
$('.carousel-control-next').on("click", () => {
    if (scrollPosition < (carouselWidth - (cardWidth * 0.25))) {
        scrollPosition = scrollPosition + cardWidth*0.95;
        $(".carousel-inner").animate({ scrollLeft: scrollPosition }, 800)
    }
})

$('.carousel-control-prev').on("click", () => {
    if (scrollPosition > 0) {
        scrollPosition = scrollPosition - cardWidth;
        $(".carousel-inner").animate({ scrollLeft: scrollPosition }, 800)
    }
})
