function checkelig() {
    event.preventDefault();

    let oldError = document.querySelectorAll(".error");
    oldError.forEach(error => {
        error.remove();
    });

    let successMsg = document.querySelector(".success");
    successMsg.textContent = "";   // clear old success

    let fullname = document.querySelector(".fullName");
    let email = document.querySelector(".email");
    let phoneno = document.querySelector(".phoneNo");
    let reqType = document.querySelector(".reqType");
    let polType = document.querySelector(".polType");
    let message = document.querySelector(".message");
    let rating = document.querySelector('input[name="rating"]:checked');

    let isValid = true;

    if (fullname.value.length === 0) {
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Full Name Required";
        fullname.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    if (email.value.length === 0) {
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Email Required";
        email.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    if (phoneno.value.length === 0 || phoneno.value.length < 10) {
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Valid Phone Number Required";
        phoneno.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    if (reqType.value === "") {
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Request Type Required";
        reqType.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    if (polType.value === "") {
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Policy Type Required";
        polType.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    if (message.value.length < 10) {
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Message must be at least 10 characters";
        message.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    if (rating === null) {
        let ratingDiv = document.querySelector(".rating");
        let ptag = document.createElement("p");
        ptag.className = "error";
        ptag.textContent = "Rating Required";
        ratingDiv.insertAdjacentElement("afterend", ptag);
        isValid = false;
    }

    /* ✅ TASK REQUIREMENT */
    if (isValid) {
        successMsg.textContent =
            "Thank you! Your enquiry has been successfully submitted.";
        document.querySelector(".form").reset();
    }
}
