const maindiv = document.querySelector(".height-fix"),
    divs = document.querySelector(".all-divs")
    instructors = document.querySelectorAll(".instructor");

window.addEventListener("load", () => {
    if (divs.children.length > 0) {
        maindiv.style.height = document.body.scrollHeight + "px";
    } else {
        maindiv.style.height = "100vh";
    }

    instructors.forEach(instructor => {
        const sendRequest = instructor.querySelector("#sendRequest");
        const instructorId = instructor.querySelector("#instructorId").value;
        console.log("clickedd");
        sendRequest.addEventListener("click", () => {
            $.ajax({
                type: "POST",
                url: "/Recommendation/AddRecommendation",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(instructorId),
                dataType: "json",
                success: function (response) {
                    sendRequest.textContent = "Sent!";
                    sendRequest.setAttribute("disabled", "true");
                },
                error: function (xhr, status, error) {
                    // Handle error
                    alert("An error occurred: " + error);
                }
            })
        })
    });
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

$(".about-textarea").each(function () {
    this.setAttribute("style", "height:" + (this.scrollHeight) + "px; overflow-y:auto;");
}).on("input", function () {
    this.style.height = "auto";
    this.style.height = (this.scrollHeight) + "px";
}).on("keydown", function (e) {
    if (e.keyCode === 8 || e.keyCode === 46) { // Check if backspace or delete key is pressed
        setTimeout(() => {
            this.style.height = "auto";
            this.style.height = (this.scrollHeight) + "px";
        }, 0);
    }
});