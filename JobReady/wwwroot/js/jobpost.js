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
    let skill = skillInput.options[skillInput.selectedIndex].textContent;
    let p = document.createElement("p");
    p.classList.add("skillset-item");
    p.textContent = skill;
    if (skill !== "") {
        skillSet.appendChild(p);
        $.ajax({
            type: "POST",
            url: '@Url.Action("AddSkill", "JobPost")',
            contentType: "application/json; charset=utf-8",
            data: { skillId: skillInput.options[skillInput.selectedIndex].value },
            dataType: "json",
            success: function () { alert('Success'); },
            error: function () { alert('Error'); }
        });
    }
    closeBtn.click();
    skillInput.value = "";
}