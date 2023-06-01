const eye = document.querySelector(".eye");
const inputPassword = document.querySelector("#password");

eye.addEventListener("click", () => {
    if (eye.src.includes("eye-slash")) {
        eye.src = "/icons/eye.svg";
        inputPassword.type = "password";
    }else{
        eye.src = "/icons/eye-slash.svg";
        inputPassword.type = "text"
    }
})