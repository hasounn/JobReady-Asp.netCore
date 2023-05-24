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
const txtarea = document.querySelector(".form-three textarea");
const txtarea1 = document.querySelector(".form-four textarea");
let active = 1;

//Event Listeners
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
        if (accountType.value === "company") {
            validateInputs("form-four");
            if (txtarea1.value.trim() !== "") {
                validateTextarea(txtarea1);
            }
        } else {
            validateInputs("form-three");
            if(txtarea.value.trim() !== "") {
                validateTextarea(txtarea);
            }
        }
    }
});
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
        if (i == (active - 1)) {;
            s.classList.remove("doneStep");
            s.classList.add("activatedStep");
            changeColorTick();
            if (accountType.value == "company" && i === step.length - 1) {
                formSteps[i + 1].classList.add("active-step");
                
            } else {
                formSteps[i].classList.add("active-step");
            }
            if (accountType.value == "company" && i === 1) {
                const label = document.querySelector("label[for='Dob']");
                label.textContent = "Founded";
            } else {
                const label = document.querySelector("label[for='Dob']");
                label.textContent = "Date Of Birth";
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
    accountType.value = arg.children[1].textContent.toLowerCase();
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
    console.log('entered');
    const inputs = document.querySelectorAll("."+formStep+ " input");
    let count = 0;
    let length = inputs.length;
    if (formStep == "form-three" || formStep == "form-four") {
        length++;
    }
    inputs.forEach(input => {
        
        if (input.value.trim() !== "" && input.validity.valid) {
            count++;
        }
    });
    if (count == length) {
        if (active < 3) {
            nextBtn.disabled = false;
        } else {
            submitBtn.disabled = false;
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
    if (arg.value.trim() !== "") {
        arg.classList.remove("input-invalid");
        submitBtn.disabled = false;
    } else {
        arg.classList.add("input-invalid");
        submitBtn.disabled = true;
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


//Calls
changeColorTick();