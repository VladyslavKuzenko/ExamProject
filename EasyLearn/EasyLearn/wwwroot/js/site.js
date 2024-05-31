var navLinks = document.getElementsByClassName('nav-link1');
var openLibraries = document.getElementsByClassName('openLibrary');
if (navLinks.length > 0) {
    for (var i = 0; i < navLinks.length; i++) {
        navLinks[i].addEventListener('click', function () {
            if (openLibraries.length > 0 && openLibraries[0].style.visibility === 'visible') {
                for (var j = 0; j < openLibraries.length; j++) {
                    openLibraries[j].style.visibility = 'hidden';
                }
            } else {
                for (var j = 0; j < openLibraries.length; j++) {
                    openLibraries[j].style.visibility = 'visible';
                }
            }
        });
    }
}

var addButtons = document.getElementsByClassName('add-button');
var openAddButtons = document.getElementsByClassName('openAddButton');
if (addButtons.length > 0) {
    for (var i = 0; i < addButtons.length; i++) {
        addButtons[i].addEventListener('click', function () {
            if (openAddButtons.length > 0 && openAddButtons[0].style.visibility === 'visible') {
                for (var j = 0; j < openAddButtons.length; j++) {
                    openAddButtons[j].style.visibility = 'hidden';
                }
            } else {
                for (var j = 0; j < openAddButtons.length; j++) {
                    openAddButtons[j].style.visibility = 'visible';
                }
            }
        });
    }
}

document.getElementById('toggleButtonik').addEventListener('click', function () {
    this.classList.toggle('active');
});


document.addEventListener('DOMContentLoaded', () => {
    const divSets = document.querySelectorAll('.div-set1');
    const prevBtn = document.getElementById('prev-btn');
    const nextBtn = document.getElementById('next-btn');

    let currentSet = 0;

    function showDivSet(index) {
        divSets.forEach((divSet, i) => {
            divSet.style.display = i === index ? 'flex' : 'none';
        });
    }

    prevBtn.addEventListener('click', () => {
        if (currentSet > 0) {
            currentSet--;
            showDivSet(currentSet);
        }
    });

    nextBtn.addEventListener('click', () => {
        if (currentSet < divSets.length - 1) {
            currentSet++;
            showDivSet(currentSet);
        }
    });

    showDivSet(currentSet);
});



document.getElementById('openModal').addEventListener('click', function () {
    document.getElementById('modalBackdrop').classList.add('visible');
    document.getElementById('popupModal').classList.add('visible');
});

document.getElementById('modalBackdrop').addEventListener('click', function () {
    document.getElementById('modalBackdrop').classList.remove('visible');
    document.getElementById('popupModal').classList.remove('visible');
});

var passwordVisible = false;

document.getElementById('togglePassword').addEventListener('click', function () {
    var passwordField = document.getElementById('passwordField');
    passwordVisible = !passwordVisible; 

    if (passwordVisible) {
        passwordField.type = 'text';
        this.style.backgroundImage = "url('../images/not-visible.png')";
    } else {
        passwordField.type = 'password';
        this.style.backgroundImage = "url('../images/visual.png')";
    }
});



document.getElementById('openModal1').addEventListener('click', function () {
    document.getElementById('modalBackdrop').classList.add('visible');
    document.getElementById('popupModal1').classList.add('visible');
});

document.getElementById('modalBackdrop').addEventListener('click', function () {
    document.getElementById('modalBackdrop').classList.remove('visible');
    document.getElementById('popupModal1').classList.remove('visible');
});

var passwordVisible = false;

document.getElementById('togglePassword1').addEventListener('click', function () {
    var passwordField = document.getElementById('passwordField1');
    passwordVisible = !passwordVisible;

    if (passwordVisible) {
        passwordField.type = 'text';
        this.style.backgroundImage = "url('../images/not-visible.png')";
    } else {
        passwordField.type = 'password';
        this.style.backgroundImage = "url('../images/visual.png')";
    }
});


function displayImage(event) {
    var file = event.target.files[0];
    if (file) {
        var reader = new FileReader();
        reader.onload = function (e) {
            var profileImageReg = document.querySelector('.profile-image-reg');
            profileImageReg.style.backgroundImage = 'url(' + e.target.result + ')';
        }
        reader.readAsDataURL(file);
    }
}

function deleteImage() {
    var profileImageReg = document.querySelector('.profile-image-reg');
    profileImageReg.style.backgroundImage = 'url(../images/user.png)'; 
}