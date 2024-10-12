
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

let currentGroup = 0;  // Відстежуємо поточну групу

function updateView() {
    const boxes = document.querySelectorAll('.box');
    const leftBtn = document.querySelector('.left-btn');
    const rightBtn = document.querySelector('.right-btn');

    // Показуємо блоки залежно від поточної групи
    boxes.forEach((box, index) => {
        if (index >= currentGroup * 3 && index < (currentGroup + 1) * 3) {
            box.classList.remove('hidden');
        } else {
            box.classList.add('hidden');
        }
    });

    // Вимикаємо ліву кнопку, якщо ми на першій групі
    leftBtn.disabled = currentGroup === 0;

    // Вимикаємо праву кнопку, якщо ми на останній групі
    rightBtn.disabled = currentGroup === Math.floor(boxes.length / 3) - 1;
}

function nextGroup() {
    const totalGroups = Math.floor(document.querySelectorAll('.box').length / 3);
    if (currentGroup < totalGroups - 1) {
        currentGroup++;
        updateView();
    }
}

function prevGroup() {
    if (currentGroup > 0) {
        currentGroup--;
        updateView();
    }
}

// Початкова ініціалізація, викликаємо при завантаженні
updateView(); 



function toggleMobileMenu() {
    var menu = document.getElementById('mobileMenu');
    menu.classList.toggle('active');
}


// Закриття мобільного меню при кліку поза ним
window.onclick = function (event) {
    var menu = document.getElementById('mobileMenu');
    var button = document.querySelector('.mobile-menu-button');
    if (!menu.contains(event.target) && !button.contains(event.target)) {
        menu.classList.remove('active');
    }
}


