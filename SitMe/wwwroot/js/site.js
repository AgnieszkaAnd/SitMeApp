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
                //let filter = 'onclick = "FilterRestaurantsBy("' + this.innerHTML.toLowerCase().toString() + '")';
                ////this.classList.add(@'onclick = "FilterRestaurantsBy(\'{filter}\')');
                //this.classList.add(filter);

                //let prefix = 'onclick = "location.href=\'@Url.Action(\"FilterRestaurantsBy(\'';
                //let suffix = '\')", "Home")';
                //let filter = prefix + this.innerHTML.toLowerCase().toString() + suffix;
                let filter = this.innerHTML.toLowerCase().toString();
                $.ajax({
                    type: "GET",
                    url: "/Home/RestaurantListFilter/",
                    data: {
                        filterBy: filter
                    },
                    success: function (result) {
                        //alert(result);
                        var $detailDiv = $('#filteredRestaurants'),
                            url = $(this).data('url');

                        $.get(url, function (data) {
                            $detailDiv.replaceWith(result);
                        });
                    }
                });
            }
        })
    })
});


//let filters = document.getElementsByClassName('card');

//let accordeonButtons = document.getElementsByClassName('list-group-item');

const myAccount = document.querySelector('#my-account');
const myAccountHTML = `
<form class="needs-validation" novalidate>
    <div class="col-md-6 mb-3">
      <label for="firstName">First name</label>
      <input type="text" class="form-control" id="firstName" placeholder="" value="" required>
      <div class="invalid-feedback">
        Valid first name is required.
      </div>
    </div>
    <div class="col-md-6 mb-3">
      <label for="lastName">Last name</label>
      <input type="text" class="form-control" id="lastName" placeholder="" value="" required>
      <div class="invalid-feedback">
        Valid last name is required.
      </div>
    </div>
  <div class="col-md-6 mb-3">
    <label for="username">Phone number</label>
    <div class="input-group">
      <div class="input-group-prepend">
        <span class="input-group-text">+48</span>
      </div>
      <input type="text" class="form-control" id="phonenumber" placeholder="" required>
      <div class="invalid-feedback" style="width: 100%;">
        Your phone number is required to confirm your reservation.
      </div>
    </div>
  </div>
  <div class="col-md-6 mb-3">
    <label for="email">Email <span class="text-muted">(Optional)</span></label>
    <input type="email" class="form-control" id="email" placeholder="">
    <div class="invalid-feedback">
      Please enter a valid email address for shipping updates.
    </div>
  </div>
  <br>
  <button class="btn btn-primary btn-sn btn-block" 
  style="background-color: #8D55C6;  
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  font-size: 16px;
  width: 30%;
  font-weight: bold;" type="submit">Save</button>
</form>
`;

myAccount.addEventListener('click', () => {
    placeholder.innerHTML = myAccountHTML;
});

const upcomingReservations = document.querySelector('#upcoming-reservations');
    const upcomingReservationsHTML = `
    <div class="card mb-3">
    <img class="card-img-top" src="~/images/restaurant_pictures/reservationphoto.jpg" alt="Card image cap">
    <div class="card-body">
      <h5 class="card-title"><b>[Restaurant name]</b></h5>
      <p class="card-text">Adres: [Street, nr, City] <br> Time: [ xx:xx ] <br> Guests: [nr of ppl]</p>
      <a href="#" class="card-link">Cancel</a>
      <a href="#" class="card-link">Change</a>
      <a href="#" class="card-link">Restaurant profile</a>
    </div>
  </div>`;

upcomingReservations.addEventListener('click', () => {
    placeholder.innerHTML = upcomingReservationsHTML;
});

const reservationsHistory = document.querySelector('#reservations-history');
    const reservationsHistoryHTML = `
    <div>
    <ul>
      <li><h6><b>[Restsurant name]  |  [X] guests</b></h6>
      <h6>[Date] d/m/r  hour [xx:xx]</h6></li>
      <li><h6><b>[Restsurant name]  |  [X] guests</b></h6>
      <h6>[Date] d/m/r  hour [xx:xx]</h6></li>
      <li><h6><b>[Restsurant name]  |  [X] guests</b></h6>
      <h6>[Date] d/m/r  hour [xx:xx]</h6></li>
      <li><h6><b>[Restsurant name]  |  [X] guests</b></h6>
      <h6>[Date] d/m/r  hour [xx:xx]</h6></li>
      <li><h6><b>[Restsurant name]  |  [X] guests</b></h6>
      <h6>[Date] d/m/r  hour [xx:xx]</h6></li>
    </ul>
  </div>`;

    reservationsHistory.addEventListener('click', () => {
    placeholder.innerHTML = reservationsHistoryHTML;
});

const contactPreferences = document.querySelector('#contact-preferences');
    const contactPreferencesHTML = `
    <div>
    <h4>Contact by</h4>
    <hr class="mb-4">
    <div class="custom-control custom-checkbox">
      <input type="checkbox" class="custom-control-input" id="same-address">
      <label class="custom-control-label" for="same-address">phone</label>
    </div>
    <div class="custom-control custom-checkbox">
      <input type="checkbox" class="custom-control-input" id="save-info">
      <label class="custom-control-label" for="save-info">e-mail</label>
    </div>
    <br><br>
    <button class="btn btn-primary btn-sn btn-block" 
        style="background-color: #8D55C6;  
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        font-size: 16px;
        width: 30%;
        font-weight: bold;" type="submit">Save</button>
    </div>`;

contactPreferences.addEventListener('click', () => {
    placeholder.innerHTML = contactPreferencesHTML;
});