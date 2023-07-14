window.onload = () => {
    var backlen = history.length;
    history.go(-backlen);
    window.location.href = window.location.href.split("Logout/")[0]+"Login/";
}