const firstname = document.getElementById('firstname');
const lastname = document.getElementById('lastname');
const email = document.getElementById('email');
const username = document.getElementById('username');
const btnChange = document.getElementById('btn_change');
const btnSave = document.getElementById('btn_save');


//Choose Image and Display Image
let selectedFile;

document.getElementById('fileInput').addEventListener('change', (event) => {
    selectedFile = event.target.files[0];
    if (selectedFile) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const previewImage = document.getElementById('imagePreview');
            previewImage.src = e.target.result;
            previewImage.style.display = 'block';
        };
        reader.readAsDataURL(selectedFile);
    }
});


btnSave.addEventListener('click', () => {
    $.ajax({
        type: "POST",
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        url: '/Profile/UpdateUser',
        data: JSON.stringify({
            UserName: username.value,
            FirstName: firstname.value,
            LastName: lastname.value,
            fileImage: selectedFile
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.success) {
                alert(response.message);
            }
        },
        error: function (error) {
            alert('An error occurred:' + error.responseText);
        }
    });
});
