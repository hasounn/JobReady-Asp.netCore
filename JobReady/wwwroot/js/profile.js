const maindiv = document.querySelector(".height-fix"),
    divs = document.querySelector(".all-divs");

window.addEventListener("load", () => {
    if (divs.children.length > 0) {
        maindiv.style.height = "fit-content";
    } else {
        maindiv.style.height = "100vh";
    }
})

var tagCloud = TagCloud('.skills', skills, {

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
