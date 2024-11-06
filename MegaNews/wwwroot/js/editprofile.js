const firstname = document.getElementById('firstname');
const lastname = document.getElementById('lastname');
const email = document.getElementById('email');
const username = document.getElementById('username');
const fileInput = document.getElementById('fileInput');
const previewImage = document.getElementById('imagePreview');
const btnChange = document.getElementById('btn_change');
const btnSave = document.getElementById('btn_save');
const deletefile = document.getElementById('delete_file');


//Choose Image and Display Image
var fileImage = null;

fileInput.addEventListener('change', (event) => {
    fileImage = event.target.files[0];

    if (fileImage) {
        const reader = new FileReader();
        reader.onload = function (e) {
            previewImage.src = e.target.result;
            previewImage.style.display = 'block';
        };
        reader.readAsDataURL(fileImage);
    }
});


btnSave.addEventListener('click', () => {
    var formData = new FormData();

    formData.append('UserName', username.value);
    formData.append('FirstName', firstname.value);
    formData.append('LastName', lastname.value);
    formData.append('fileInput', fileImage);

    $.ajax({
        url: '/Profile/UpdateUser',
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {
                alert(response.message);
            }
            else {
                alert(response.message);
            }
        },
        error: function (xhr, status, error) {
            alert('An error occurred:' + error.responseText);
        }
    });
});
