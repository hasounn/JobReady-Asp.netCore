const skillSet = document.querySelector(".skillset");
const addSkillBtn = document.querySelector(".addSkillBtn");
const skillInput = document.getElementById("skillInput");
const closeBtn = document.querySelector(".close");

addSkillBtn.addEventListener("click", (e) => {
    addSkill(e);
});

const addSkill = (e) => {
    e.preventDefault();

    if (skillInput.value === "") {
        // No skill selected, handle the error
        alert("Please select a skill");
        return;
    }

    const skillId = skillInput.options[skillInput.selectedIndex].value+"";
    const skillText = skillInput.options[skillInput.selectedIndex].getAttribute(
        "data-value-text"
    );

    const p = document.createElement("p");
    p.classList.add("skillset-item");
    p.textContent = skillText;

    $.ajax({
        type: "POST",
        url: '/JobPost/AddSkill',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(skillId),
        dataType: "json",
        success: function (response) {
            // Handle success
            $.ajax({
                type: "POST",
                url: '/JobPost/FindSkill',
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(skillId),
                dataType: "json",
                success: function (response) {
                    // Handle success
                    alert(response);
                },
                error: function (xhr, status, error) {
                    // Handle error
                    alert("An error occurred: " + error);
                }
            });
        },
        error: function (xhr, status, error) {
            // Handle error
            alert("An error occurred: " + error);
        }
    });

    const modal = document.getElementById("addSkillModal");
    const bootstrapModal = bootstrap.Modal.getInstance(modal);
    bootstrapModal.hide();
};
