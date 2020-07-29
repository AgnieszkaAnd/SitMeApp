// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let filterBox = document.getElementById('accordionExample');
let filterGroup = Array.from(filterBox.children);

filterGroup.forEach(function (item) {
    console.log(item);
    //Array.from(item.childNodes);

    let subFilters = Array.from(item.querySelectorAll('a'));
    subFilters.forEach(function(filterSelector) {
        filterSelector.addEventListener('click', function() {
            if (this.classList.contains('active')) {
                this.classList.remove('active');
            } else {
                this.classList.add('active');
            }
        })
    })

});

//let filters = document.getElementsByClassName('card');

//let accordeonButtons = document.getElementsByClassName('list-group-item');