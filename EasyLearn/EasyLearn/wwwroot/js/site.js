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
