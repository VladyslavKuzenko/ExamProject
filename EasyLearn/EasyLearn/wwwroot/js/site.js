const menuToggle = document.getElementById('menu-toggle');
const mobileMenu = document.getElementById('mobile-menu');
const closeMenu = document.getElementById('close-menu');

menuToggle.addEventListener('click', function () {
    mobileMenu.classList.toggle('open');
});

closeMenu.addEventListener('click', function () {
    mobileMenu.classList.remove('open');
});

// Close menu on larger screens
window.addEventListener('resize', function () {
    if (window.innerWidth > 768) {
        mobileMenu.classList.remove('open');
    }
});


let currentSet = 1;
const maxSets = 2; // кількість наборів карток

document.querySelector('.right-btn').addEventListener('click', () => {
    document.querySelectorAll(`#set-${currentSet}`).forEach(card => {
        card.style.display = 'none'; // Приховуємо попередні блоки
    });
    currentSet = currentSet === maxSets ? 1 : currentSet + 1;
    document.querySelectorAll(`#set-${currentSet}`).forEach(card => {
        card.style.display = 'flex'; // Відображаємо нові блоки
    });
});

document.querySelector('.left-btn').addEventListener('click', () => {
    document.querySelectorAll(`#set-${currentSet}`).forEach(card => {
        card.style.display = 'none'; // Приховуємо попередні блоки
    });
    currentSet = currentSet === 1 ? maxSets : currentSet - 1;
    document.querySelectorAll(`#set-${currentSet}`).forEach(card => {
        card.style.display = 'flex'; // Відображаємо нові блоки
    });
});




// Функція для відкриття/закриття вікна
function togglePopup7() {
    var popup7 = document.getElementById('popup7');
    if (popup7.style.display === 'none' || popup7.style.display === '') {
        popup7.style.display = 'flex';
    } else {
        popup7.style.display = 'none';
    }
}




function togglePopup7() {
    var popup7 = document.getElementById('popup7');
    popup7.style.display = (popup7.style.display === 'none' || popup7.style.display === '') ? 'block' : 'none';
}

// Закриваємо вікно, якщо клікаємо за його межами
window.onclick = function (event) {
    var popup7 = document.getElementById('popup7');
    if (event.target !== document.querySelector('.btn7') && !popup7.contains(event.target)) {
        popup7.style.display = 'none';
    }
}