async function displayUsers(item){
    await fetch('https://696721e0bbe157c088b0f52a.mockapi.io/insuranceapi/insurance')
.then(res=>res.json())
.then(data=>{
    let resultdiv=document.querySelector('.resultdiv');
    resultdiv.innerHTML="";
    for(let i=0;i<data.length;i++){
        resultdiv.innerHTML+=`<div class="card">
        <h3>${data[i].policyNumber}</h3>
        <h3>${data[i].policyHolder}</h3>
        <h3>${data[i].policyType}</h3>
        <h3>${data[i].premium}</h3>
        <h3>${data[i].duration}</h3>
        <button class="edit-btn" onclick="editPolicy('${data[i].id}')">Edit</button>
        <button class="delete-btn" onclick="deletePolicy('${data[i].id}')">Delete</button>
        </div>` 
    }
})
.catch(err=>console.log(err))
}

displayUsers();

async function addelement() {
  const message = document.getElementById("message");
  message.textContent = "";
  message.className = "message";

  const policyData = {
    policyNumber: policyNumber.value,
    policyHolder: policyHolder.value,
    policyType: policyType.value,
    premium: Number(premium.value),
    duration: duration.value,
    coverageAmount: Number(coverageAmount.value),
    status: statusApp.value,
    startDate: startDate.value
  };

  try {
    let url = "https://696721e0bbe157c088b0f52a.mockapi.io/insuranceapi/insurance";
    let method = "POST";

    if (editPolicyId) {
      url += `/${editPolicyId}`;
      method = "PUT";
    }

    const res = await fetch(url, {
      method,
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(policyData)
    });

    if (!res.ok) throw new Error("Request failed");

    await res.json();

    message.textContent = editPolicyId
      ? "Policy updated successfully!"
      : "Policy added successfully!";
    message.classList.add("success");

    policyForm.reset();
    document.querySelector("button").innerText = "Add Policy";
    editPolicyId = null;

    displayUsers();

  } catch (err) {
    console.error(err);
    message.textContent = "Something went wrong. Try again.";
    message.classList.add("error");
  }
}


let editPolicyId = null;

async function editPolicy(id) {
  try {
    const res = await fetch(
      `https://696721e0bbe157c088b0f52a.mockapi.io/insuranceapi/insurance/${id}`
    );

    const data = await res.json();
    
    document.getElementById("policyNumber").value = data.policyNumber;
    document.getElementById("policyHolder").value = data.policyHolder;
    document.getElementById("policyType").value = data.policyType;
    document.getElementById("premium").value = data.premium;
    document.getElementById("duration").value = data.duration;
    document.getElementById("coverageAmount").value = data.coverageAmount;
    document.getElementById("statusApp").value = data.status;
    document.getElementById("startDate").value = data.startDate;

    editPolicyId = id;
    
    document.querySelector("#policyForm button").innerText = "Update Policy";

    document.getElementById("message").textContent = "";

    window.scrollTo({ top: 0, behavior: "smooth" });

  } catch (error) {
    console.error("Error fetching policy:", error);
  }
}

async function deletePolicy(id) {
  const message = document.getElementById("message");
  message.textContent = "";
  message.className = "message";

//   if (!confirm("Are you sure you want to delete this policy?")) return;

  try {
    const res = await fetch(
      `https://696721e0bbe157c088b0f52a.mockapi.io/insuranceapi/insurance/${id}`,
      {
        method: "DELETE"
      }
    );

    if (!res.ok) throw new Error("Delete failed");

    message.textContent = "Policy deleted successfully!";
    message.classList.add("success");

    displayUsers(); 
  } catch (err) {
    console.error(err);
    message.textContent = "Error deleting policy";
    message.classList.add("error");
  }
}
