//Declarations
const step = document.querySelectorAll(".step");
const formSteps = document.querySelectorAll(".form-step");
const tick1 = document.querySelectorAll(".tick");
const accountType = document.querySelector("#accountType");
const nextBtn = document.querySelector(".btn-next");
const prevBtn = document.querySelector(".btn-prev");
const submitBtn = document.querySelector(".btn-submit");
const textarea = document.querySelector("#headline");
const hcompany = document.querySelector("#hcompany");
const fileInput = document.querySelector("#fileInput");
const fileInput1 = document.querySelector("#fileInput1");
const fileHandler = document.querySelector(".file-handler");
const fileHandler1 = document.querySelector(".file-handler1");
let active = 1;

//Event Listeners
nextBtn.addEventListener("click", (e) => {
    e.preventDefault();
    active++;
    if (active > step.length) {
        active = step.length;
    }
    updateProgress();
});
prevBtn.addEventListener("click", (e) => {
    e.preventDefault();
    active--;
    if (active < 1) {
        active = 1;
    }
    updateProgress();
});

textarea.addEventListener("keyup", e => {
    textarea.style.height = "20px";
    let scHeight = e.target.scrollHeight;
    textarea.style.height = `${scHeight}px`;
});

hcompany.addEventListener("keyup", e => {
    hcompany.style.height = "20px";
    let scHeight = e.target.scrollHeight;
    hcompany.style.height = `${scHeight}px`;
});

fileHandler.addEventListener("click", () => {
    fileInput.click();
})

fileHandler1.addEventListener("click", () => {
    fileInput1.click();
})

//Functions
const changeColorTick = () => {
        tick1.forEach(tick => {
            if (tick.parentElement.classList.contains("activatedStep")) {
                const pathElements = tick.querySelectorAll('path');
                // Loop through each path element and change the stroke color
                pathElements.forEach(path => {
                    path.style.stroke = '#B87333';
                });
            } else if (tick.parentElement.classList.contains("doneStep")) {
                const pathElements = tick.querySelectorAll('path');
                // Loop through each path element and change the stroke color
                pathElements.forEach(path => {
                    path.style.stroke = '#139BE4';
                });
            } else {
                const pathElements = tick.querySelectorAll('path');
                // Loop through each path element and change the stroke color
                pathElements.forEach(path => {
                    path.style.stroke = '#535657';
                });
            }
        })
    };

const updateProgress = () => {
    step.forEach((s, i) => {
        if (i == (active - 1)) {
            s.classList.remove("doneStep");
            s.classList.add("activatedStep");
            changeColorTick();
            if (accountType.value == "company" && i === step.length - 1) {
                formSteps[i + 1].classList.add("active-step");
                
            } else {
                formSteps[i].classList.add("active-step");
            }
        } else {
            if (i < active - 1) {
                s.classList.remove("activatedStep");
                s.classList.add("doneStep");
                changeColorTick();
                formSteps[i].classList.remove("active-step");
            } else {
                s.classList.remove("activatedStep");
                s.classList.remove("doneStep");
                changeColorTick();
                formSteps[i].classList.remove("active-step");
                if (i === step.length - 1 && accountType.value === "company") {
                    formSteps[i+1].classList.remove("active-step");
                }
            }
        }
    })

    if (active === 1) {
        prevBtn.disabled = true;
    } else if (active === step.length) {
        nextBtn.disabled = true;
    } else {
        nextBtn.disabled = false;
        prevBtn.disabled = false;
    }
}

const previewImage = (arg, c) => {
    var previewImage = document.querySelector("."+c);
    if (arg === "fileInput") {
        var file = fileInput.files[0];
    } else if (arg === "fileInput1") {
        var file = fileInput1.files[0];
    }

    var reader = new FileReader();
    reader.onload = function (e) {
        previewImage.src = e.target.result;
    };
    reader.readAsDataURL(file);
}

const changeSelected = (arg) => {
    removeSelections();
    arg.children[0].classList.add("selected");
    accountType.value = arg.children[1].textContent.toLowerCase();
}
const removeSelections = () => {
    const choices = document.querySelectorAll(".choice");

    choices.forEach(choice => {
        choice.classList.remove("selected");
    })
}

//Calls
changeColorTick();