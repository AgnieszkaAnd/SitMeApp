import * as staticTemplates from './templates/static.js';
import * as dynamicTemplates from './templates/dynamic.js';


$(document).ready(
    function() { // TODO delete all document ready from site.js - here we need to define only methods,classes etc.
        //then from script in cshtml call those methods

        const apiUrl = 'http://localhost:3000';

        const placeholder = document.querySelector('.blog-post');

        const myAccountBtn = document.querySelector('#my-account');
        const upcomingReservationsBtn = document.querySelector('#upcoming-reservations');
        const reservationsHistoryBtn = document.querySelector('#reservations-history');
        const contactPreferencesBtn = document.querySelector('#contact-preferences');

        loadMyAccount();

        myAccountBtn.addEventListener('click',
            () => {
                placeholder.innerHTML = staticTemplates.myAccountHTML;
                loadMyAccount();
            });

        upcomingReservationsBtn.addEventListener('click',
            () => {
                placeholder.innerHTML = staticTemplates.upcomingReservationsHTML;
                loadReservations();
            });


        reservationsHistoryBtn.addEventListener('click',
            () => {
                placeholder.innerHTML = staticTemplates.reservationsHistoryHTML;
                loadHistoricalReservations();

            });

        contactPreferencesBtn.addEventListener('click',
            () => {
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
            alert('my account loading');
            const blogPost = document.querySelector('.blog-post');
            fetch(`${apiUrl}/users/${UserId}`)
                .then(response => response.json())
                .then(accountData => {
                    let html = '';
                    html += dynamicTemplates.showUserAccountDetails(accountData);
                    blogPost.innerHTML = html;

                    const form = document.querySelector('.needs-validation');
                    form.addEventListener('submit',
                        event => {
                            event.preventDefault();
                            const { firstName, lastName, phoneNumber, email } = form.elements;

                            const body = {
                                firstName: firstName.value,
                                lastName: lastName.value,
                                phoneNumber: phoneNumber.value,
                                email: email.value,
                            };
                            fetch(`${apiUrl}/users/${userID}`,
                                    {
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
                    history.forEach(
                        reservationHistory => html += dynamicTemplates.showReservationHistory(reservationHistory));
                    blogPost.innerHTML = html;
                })
        }
    });
