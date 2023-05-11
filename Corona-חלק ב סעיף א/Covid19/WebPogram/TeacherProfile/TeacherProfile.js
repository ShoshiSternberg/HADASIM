function init() {
    var s = JSON.parse(sessionStorage.userObj);
    document.getElementById('nam').innerHTML = s.firstName + " " + s.lastName;
    document.getElementById('tzu').innerHTML = s.tz;

}