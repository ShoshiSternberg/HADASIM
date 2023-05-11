
/*פונקציה שבודקת למי שייכת הת.ז. ואם המייל תואם.*/
function checkTzAndMail() {
    var tz = parseInt(document.getElementById('form3Example3').value);
    var mail =document.getElementById('form3Example4').value;
    
       if (tz==325562221&&mail=="direct")
    window.location.assign("https://localhost:44305/Html/Entities.html");


}