const textarea = document.querySelector("#msgText");


textarea.addEventListener("input", resizeTextboxOnOverflow('msgText'));
textarea.style.height = "40px";
function resizeTextboxOnOverflow(textboxId) {
    const textbox = document.getElementById(textboxId);
    const originalHeight = '40';

    function resizeTextbox() {
        const previousValue = textbox.value;
        textbox.value = '';
        textbox.style.height = '';
        textbox.style.height = (textbox.scrollHeight + 2) + 'px';
        textbox.value = previousValue;
    }

    function handleOverflow() {
        resizeTextbox();
        textbox.addEventListener('input', function () {
            if (textbox.value === '') {
                textbox.style.height = originalHeight + 'px';
            } else if (textbox.scrollHeight > textbox.clientHeight) {
                resizeTextbox();
            }
        });
    }

    handleOverflow();
}