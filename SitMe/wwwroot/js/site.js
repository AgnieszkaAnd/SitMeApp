import * as staticTemplates from './templates/static.js';
import * as dynamicTemplates from './templates/dynamic.js';

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    let filterBox = document.getElementById('accordionExample');
    let filterGroup = Array.from(filterBox.children);
    let filters;

    let filtersArray;

    filterGroup.forEach(function (item) {

        filters = new Set();

        let subFilters = Array.from(item.querySelectorAll('a'));
        subFilters.forEach(function (filterSelector) {
            filterSelector.addEventListener('click', function () {
                if (this.classList.contains('active')) {
                    this.classList.remove('active');
                    filters.delete(this.innerHTML.toLowerCase().toString());

                    //debug
                    //console.log(this.innerHTML.toLowerCase().toString() + ' removed'); 

                } else {
                    this.classList.add('active');
                    filters.add(this.innerHTML.toLowerCase().toString());

                    //debug
                    //console.log(this.innerHTML.toLowerCase().toString() + ' added'); 
                }

                //debug
                //console.log('filters: ' + filters.toString());
                filters.forEach(function (item) {
                    console.log(item);
                });

                filterString = Array.from(filters).toString();
                console.log(filterString)

                $.ajax({
                    type: "GET",
                    url: "/Home/RestaurantListFilter",
                    data: { filterByTest: filterString },
                    success: function (result) {
                        //debug
                        //alert(result);
                        var detailDiv = $('#filteredRestaurants');//,
                        detailDiv.html(result);
                    }
                });

            })
        })
    });
});

// ----------------------------------------------------------

$(document).ready(function () {

    const apiUrl = 'http://localhost:3000';
    const userID = 2;

    const placeholder = document.querySelector('.blog-post');

    const myAccountBtn = document.querySelector('#my-account');
    const upcomingReservationsBtn = document.querySelector('#upcoming-reservations');
    const reservationsHistoryBtn = document.querySelector('#reservations-history');
    const contactPreferencesBtn = document.querySelector('#contact-preferences');

    loadMyAccount();

    myAccountBtn.addEventListener('click', () => {
        placeholder.innerHTML = staticTemplates.myAccountHTML;
        loadMyAccount();
    });

    upcomingReservationsBtn.addEventListener('click', () => {
        placeholder.innerHTML = staticTemplates.upcomingReservationsHTML;
        loadReservations();
    });


    reservationsHistoryBtn.addEventListener('click', () => {
        placeholder.innerHTML = staticTemplates.reservationsHistoryHTML;
        loadHistoricalReservations();

    });

    contactPreferencesBtn.addEventListener('click', () => {
        placeholder.innerHTML = staticTemplates.contactPreferencesHTML;
    });

    function loadReservations() {
        const blogPost = document.querySelector('.blog-post');
        fetch(`${apiUrl}/reservations`)
            .then(response => response.json())
            .then(reservations => {
                let html = '';
                reservations.forEach(reservation => html += dynamicTemplates.generateCard(reservation));
                blogPost.innerHTML = html;
            })
    }

    function loadMyAccount() {
        const blogPost = document.querySelector('.blog-post');
        fetch(`${apiUrl}/users/${userID}`)
            .then(response => response.json())
            .then(accountData => {
                let html = '';
                html += dynamicTemplates.showUserAccountDetails(accountData);
                blogPost.innerHTML = html;

                const form = document.querySelector('.needs-validation');
                form.addEventListener('submit', event => {
                    event.preventDefault();
                    const { firstName, lastName, phoneNumber, email } = form.elements;

                    const body = {
                        firstName: firstName.value,
                        lastName: lastName.value,
                        phoneNumber: phoneNumber.value,
                        email: email.value,
                    };
                    fetch(`${apiUrl}/users/${userID}`, {
                        method: "put",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify(body)
                    })
                        .then(res => res.json())
                        .then(res => {
                            console.log("Zmiana danych");
                            console.log(res);
                        })
                })
            })
    }

    function loadHistoricalReservations() {
        const blogPost = document.querySelector('.blog-post');
        fetch(`${apiUrl}/history`)
            .then(response => response.json())
            .then(history => {
                let html = '';
                history.forEach(reservationHistory => html += dynamicTemplates.showReservationHistory(reservationHistory));
                blogPost.innerHTML = html;
            })
    }
});