const firstname = document.getElementById('firstname');
const lastname = document.getElementById('lastname');
const email = document.getElementById('email');
const username = document.getElementById('username');
const fileImage = document.getElementById('fileInput');
const btnChange = document.getElementById('btn_change');
const btnSave = document.getElementById('btn_save');


//Choose Image and Display Image

document.getElementById('fileInput').addEventListener('change', (event) => {
    var fileInput = event.target.files[0];
    if (fileInput) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const previewImage = document.getElementById('imagePreview');
            previewImage.src = e.target.result;
            previewImage.style.display = 'block';
        };
        reader.readAsDataURL(fileInput);
    }
});


btnSave.addEventListener('click', () => {

});
