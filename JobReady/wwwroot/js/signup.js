//Declarations
const step = document.querySelectorAll(".step");
const formSteps = document.querySelectorAll(".form-step");
const tick1 = document.querySelectorAll(".tick");
const accountType = document.querySelector("#accountType");
const nextBtn = document.querySelector(".btn-next");
const prevBtn = document.querySelector(".btn-prev");
const submitBtn = document.querySelector(".btn-submit");
const textarea = document.querySelector("#headline");
const fileInput = document.querySelector("#fileInput");
const fileHandler = document.querySelector(".file-handler");
const txtarea = document.querySelector(".form-three textarea");
const selectGender = document.querySelector(".form-three select");
let active = 1;
let selected = 0;

//Event Listeners
document.addEventListener("DOMContentLoaded", function () {
    var selectElement = document.getElementById("gender");
    selectElement.selectedIndex = -1; // Deselect any option by default
});

nextBtn.addEventListener("click", (e) => {
    e.preventDefault();
    active++;
    if (active > step.length) {
        active = step.length;
    }
    updateProgress();
    if (active === 2) {
        validateInputs("form-two");
    } else if (active === 3) {
            validateInputs("form-three");
            if(txtarea.value.trim() !== "") {
                validateTextarea(txtarea);
        }
    }
});

selectGender.addEventListener("click", () => { selected++; });

prevBtn.addEventListener("click", (e) => {
    e.preventDefault();
    active--;
    if (active < 1) {
        active = 1;
    }
    updateProgress();
    if (active === 2) {
        validateInputs("form-two");
    }
});

textarea.addEventListener("keyup", e => {
    textarea.style.height = "20px";
    let scHeight = e.target.scrollHeight;
    textarea.style.height = `${scHeight}px`;
});


fileHandler.addEventListener("click", () => {
    fileInput.click();
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
        if (i == (active - 1)) {;
            s.classList.remove("doneStep");
            s.classList.add("activatedStep");
            changeColorTick();
                formSteps[i].classList.add("active-step");
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
            }
        }
    })

    if (active === 1) {
        prevBtn.disabled = true;
        nextBtn.disabled = false;
    } else if (active === step.length) {
        nextBtn.disabled = true;
        submitBtn.disabled = true;
    } else if (active > 0) {
        nextBtn.disabled = true;
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
    document.querySelector("form").reset();
    accountType.value = arg.children[1].textContent;
}
const removeSelections = () => {
    const choices = document.querySelectorAll(".choice");

    choices.forEach(choice => {
        choice.classList.remove("selected");
    })
}

const validate = (input) => {
    if (input.validity.valid) {
        input.classList.remove('input-invalid');
    } else {
        input.classList.add('input-invalid');
    }

    if (input.type === "password" && input.getAttribute("id") == "confirmpwd") {
        validatePassword();
    }
}

const validateInputs = (formStep) => {
    const inputs = document.querySelectorAll("."+formStep+ " input");
    let count = 0;
    let length = inputs.length;
  
    inputs.forEach(input => {
        
        if (input.value.trim() !== "" && input.validity.valid) {
            count++;
        }
    });
    if (count == length) {
        if (active < 3) {
            nextBtn.disabled = false;
        } else if (active == 3 && validateSelect(".form-three select") && validateTextarea(".form-three textarea")) {
            submitBtn.disabled = false;
        } else {
            submitBtn.disabled = true;
        }
    } else {
        if (active === 1) {
            nextBtn.disabled = false;
        } else if (active < 3) {
            nextBtn.disabled = true;
        } else {
            submitBtn.disabled = true;
        }
    }
}

const validateTextarea = (arg) => {
    const select = typeof arg === 'string' ? document.querySelector(arg) : arg;
    if (arg.value.trim() !== "" && validateSelect(".form-three select")) {
        arg.classList.remove("input-invalid");
        if (typeof arg === 'string') {
            return true;
        } else {
            submitBtn.disabled = false;
        }
        
    } else {
        arg.classList.add("input-invalid");
        if (typeof arg === 'string') {
            return false;
        } else {
            submitBtn.disabled = true;
        }
    }
}

const validatePassword = () => {
    const pwd = document.querySelector("#pwd");
    const confirmpwd = document.querySelector("#confirmpwd");

    if (pwd.value === confirmpwd.value) {
        pwd.classList.remove("input-invalid");
        confirmpwd.classList.remove("input-invalid");
        validateInputs("form-two");
    } else {
        confirmpwd.classList.add("input-invalid");
        confirmpwd.classList.add("input-invalid");
        pwd.classList.add("input-invalid");
        nextBtn.disabled = true;
    }
}

const validateSelect = (arg) => {
    const select = typeof arg === 'string' ? document.querySelector(arg) : arg;
    if (selected > 0) {
        if (select.options[select.selectedIndex].value === "---") {
            select.parentElement.children[0].classList.add("input-invalid");
            if (typeof arg === 'string') {
                return false;
            } else {
                submitBtn.disabled = true;
            }
        } else {
            select.parentElement.children[0].classList.remove("input-invalid");
            select.parentElement.children[0].classList.add("valid");
            if (typeof arg === 'string') {
                return true;
            } else {
                submitBtn.disabled = false;
            }
        }
    }else{
        if (typeof arg === 'string') {
            return false;
        } else {
            submitBtn.disabled = true;
        }
    }
}


//Calls
changeColorTick();