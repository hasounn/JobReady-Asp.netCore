window.addEventListener('DOMContentLoaded', function () {
    var container = document.querySelector('.dark-main-bg');

    if (container.scrollHeight > container.clientHeight) {
        container.style.setProperty('height', 'fit-content', 'important')
    }
});