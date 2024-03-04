
$(document).ready(function () {
    console.log("bio", bio);
    if (bio == undefined || bio.text.length < 10) return;
 
    var picDiv = document.getElementsByClassName('bio-pic')[0]; 
    var introDiv = document.getElementsByClassName('intro')[0]; 

    picDiv.innerHTML = `
        <img src="img/bio/${bio.image}"
            class="img-fluid img-top"
            alt="${bio.imageAltText}" />
        <p class="image-description" >
            ${bio.imageFooter}
        </p>`
    introDiv.innerHTML = bio.text;


})



function Navigate(url) {
    console.log("Successful T1", url);
    console.log("Successful T2", typeof url);
    //var data = JSON.stringify({ data: "sampleTestData" });
    $.ajax({
        type: 'POST',
        //url: `/guest/home/TestClickAction/inSlug`,
        //url: `/guest/home/TestClickAction/${data}`,
        url: `/guest/home/GuestAction`,
        contentType: "application/json",
        data: JSON.stringify({ Url: url }),
        //data: "afefefefaewf",
        //data: {
        //    test1: "data"
        //},

        success: function (data) {
            console.log("Successful data send...");
        }
    })
}