const divSet1 = document.getElementById('div-set-1');
const divSet2 = document.getElementById('div-set-2');
const prevBtn = document.getElementById('prev-btn');
const nextBtn = document.getElementById('next-btn');

// Функція для перегортання на div-set-2
nextBtn.addEventListener('click', function () {
    divSet1.style.display = 'none';
    divSet2.style.display = 'flex';
});

// Функція для перегортання на div-set-1
prevBtn.addEventListener('click', function () {
    divSet1.style.display = 'flex';
    divSet2.style.display = 'none';
});