var bioText = document.getElementById('bio-text')
var bioPreview = document.getElementById('bio-preview')
var imgPreview = document.getElementsByClassName('bio-pic')[0]; 
var imgAltText = document.getElementById('image-alt-text'); 
var imgFooter = document.getElementById('image-footer'); 
    
bioText.addEventListener("change", updatePreview);
$(document).ready(function () {
    updatePreview();
})

function updatePreview() {
    imgPreview.innerHTML = `
        <img src="/img/bio/${bio.image}"
            class="img-fluid img-top"
            alt="${imgAltText.value}" />
        <p class="image-description" >
            ${imgFooter.value}
        </p>`

    bioPreview.innerHTML = bioText.value;
}
