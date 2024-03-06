
$(document).ready(function () {
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
    console.log(`navigate => ${url}`)
    $.ajax({
        type: 'POST',
        url: `/guest/home/GuestAction`,
        contentType: "application/json",
        data: JSON.stringify({ Url: url })
    })
}