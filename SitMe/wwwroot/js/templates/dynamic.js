export function generateCard(reservation) {
    return `<div class="card mb-3">
                <img class="card-img-top" src="./reservationphoto.jpg" alt="Card image cap">
                <div class="card-body">
                    <h5 class="card-title">
                        <b id="">${reservation.restaurantName}</b>
                    </h5>
                    <p class="card-text">${reservation.address}
                        <br>${reservation.time}<br>${reservation.guests}
                    </p>
                    <a href="#" class="card-link">Cancel</a>
                    <a href="#" class="card-link">Change</a>
                    <a href="#" class="card-link">Restaurant profile</a>
                </div>
            </div>`;
}

export function showUserAccountDetails(accountData) {
    return `<form id="account" class="needs-validation" novalidate="" name="account">
                <div class="col-md-6 mb-3">
                  <label for="firstName">First name</label>
                  <input type="text" class="form-control" id="firstName" placeholder="" value="${accountData.firstName}" required="">
                  <div class="invalid-feedback">
                    Valid first name is required.
                  </div>
                </div>
                <div class="col-md-6 mb-3">
                  <label for="lastName">Last name</label>
                  <input type="text" class="form-control" id="lastName" placeholder="" value="${accountData.lastName}" required="">
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
                  <input type="text" class="form-control" id="phoneNumber" placeholder="" required="" value="${accountData.phoneNumber}">
                  <div class="invalid-feedback" style="width: 100%;">
                    Your phone number is required to confirm your reservation.
                  </div>
                </div>
              </div>
              <div class="col-md-6 mb-3">
                <label for="email">Email <span class="text-muted">(Optional)</span></label>
                <input type="email" required class="form-control" id="email" placeholder="" value="${accountData.email}">
                <div class="invalid-feedback">
                  Please enter a valid email address for shipping updates.
                </div>
              </div>
              <br>
              <input type="button" form="account" class="btn btn-primary btn-sn btn-block" style="background-color: #8D55C6;  
              border: none;
              color: white;
              padding: 15px 32px;
              text-align: center;
              font-size: 16px;
              width: 30%;
              font-weight: bold;" type="submit">Save</input>
            </form>`;
}

export function showReservationHistory(reservationHistory) {
    return `
        <div>
        <ul>
          <li><h6><b>${reservationHistory.restaurantName} </b>    ${reservationHistory.city}</h6>
          <h6>${reservationHistory.date}  |  ${reservationHistory.time}  |  ${reservationHistory.nrOfGuests} 
</h6 ></li >
        </ul>
      </div>`;
}