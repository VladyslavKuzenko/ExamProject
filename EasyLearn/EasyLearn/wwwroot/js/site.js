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