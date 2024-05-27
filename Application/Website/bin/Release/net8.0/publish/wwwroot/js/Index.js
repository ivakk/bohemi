let currentImageIndex = 0;
const images = [
    "~/images/piano1.jpg",
    "~/images/piano2.jpg",
    "~/images/piano3.jpg"
];
const imgElement = document.getElementById("changing-image");

function changeImage() {
    imgElement.classList.remove('active');
    setTimeout(() => {
        currentImageIndex = (currentImageIndex + 1) % images.length;
        imgElement.src = images[currentImageIndex];
        imgElement.classList.add('active');
    }, 1500); // matches the transition duration
}

imgElement.classList.add('active');
setInterval(changeImage, 5000); // Change image every 5 seconds
