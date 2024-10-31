const prevButton = document.querySelector('.btn-prev');
const nextButton = document.querySelector('.btn-next');
const sliderWrapper = document.querySelector('.slider-wrapper');
const cards = document.querySelectorAll('.slider-card');
const layoutUser = document.querySelector('.navigation__right--user');
const popup = document.getElementById('popup');
const overlay = document.getElementById('overlay');
const closePopup = document.getElementById('close_popup');
const bookMark = document.getElementById('book_mark');

/*Popup SignIn - SignUp*/

function ShowPopup() {
    popup.style.display = 'flex';
    overlay.style.display = 'block';
    document.body.classList.add('no-scroll');
}

function HidePopup() {
    popup.style.display = 'none';
    overlay.style.display = 'none';
    document.body.classList.remove('no-scroll');
}


layoutUser.addEventListener('click', () => {
    $.ajax({
        url: '/Home/CheckLoginStatus',
        method: 'GET',
        success: function (response) {
            if (!response.loggedIn) {
                ShowPopup();
            }
        },
        error: function (error) {
            alert('An error occurred:' + error.responseText);
        }
    });
});

closePopup.addEventListener('click', () => {
    HidePopup();
});


bookMark.addEventListener('click', () => {
    $.ajax({
        url: '/Home/CheckLoginStatus',
        method: 'GET',
        success: function (response) {
            if (!response.loggedIn) {
                ShowPopup();
            }
        },
        error: function (error) {
            alert('An error occurred:' + error.responseText);
        }
    });
});


/* Card Slider for Categories Post*/

const totalCards = cards.length;
let currentIndex = 0;
var cardsPerView = 5;

function updateSlider() {
    let slidePosition = currentIndex * (100 / cardsPerView);
    if (currentIndex >= totalCards - 4) {
        slidePosition = 0;
        currentIndex = 0;
    }

    sliderWrapper.style.transform = `translateX(-${slidePosition}%)`;
}

prevButton.addEventListener('click', () => {
    currentIndex = (currentIndex === 0) ? totalCards - 1 : currentIndex - 1;
    updateSlider();
});

nextButton.addEventListener('click', () => {
    currentIndex = (currentIndex === totalCards - 1) ? 0 : currentIndex + 1;
    updateSlider();
});

updateSlider();