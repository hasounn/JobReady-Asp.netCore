const skillSet = document.querySelector(".skillset"),
    addSkillBtn = document.querySelector(".addSkillBtn"),
    skillInput = document.getElementById("skillInput"),
    closeBtn = document.querySelector(".close");


addSkillBtn.addEventListener("click", (e) => {
    addSkill(e);
});

skillInput.addEventListener("keyup", (e) => {
    if (e.key == "Enter") { addSkill(e); }
    
});

const addSkill = (e) => {
    e.preventDefault();
    let skill = skillInput.value;
    let p = document.createElement("p");
    p.classList.add("skillset-item");
    p.textContent = skill;
    if (skill !== "") {
        skillSet.appendChild(p);
    }
    closeBtn.click();
    skillInput.value = "";
}