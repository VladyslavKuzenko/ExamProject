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