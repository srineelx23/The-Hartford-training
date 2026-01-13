
//Task-1
var data;
async function getUsers()
{
    try{
    const response=await fetch('./data.json')
    data=await response.json();
    console.log(data);
    }
    catch(error){
        console.log(error);
    }
}
//Task-2
async function renderPolicies(){
    try{
        await getUsers();
        let container=document.querySelector('.policiesList');
        if(container.innerHTML.trim() === ""){
        for(let i=0;i<data.length;i++){
        container.innerHTML+=`<div class="flex-item">${data[i].name}
        <p>${data[i].type}</p>
        <p>${data[i].premium}</p>
        <p>${data[i].duration}</p>
        <p>${data[i].status}</p></div>`;
        }
    }
        console.log("data has been appended");
    }
    catch(error){
        console.log(error);
    
    }
}

//Task-3
async function filterPolicies(type){
    await getUsers();
    console.log("filterPolicies is called");
    console.log(type);
    const filteredPolicies=data.filter(p=>p.type===type);
    console.log(filteredPolicies);
    let container=document.querySelector('.filteredPolicies')
    container.innerHTML="";
    for(let i=0;i<filteredPolicies.length;i++){
        container.innerHTML+=`<div class="flex-item">${filteredPolicies[i].name}
        <p>${filteredPolicies[i].type}</p>
        <p>${filteredPolicies[i].premium}</p>
        <p>${filteredPolicies[i].duration}</p>
        <p>${filteredPolicies[i].status}</p></div>`;
    }
}

//Task-4
async function calculateTotalPremium() {
  try {
    await getUsers();

    const totalPremium = data.reduce((sum, policy) => {
      if (policy.status === "Active") {
        if (typeof policy.premium !== "number" || policy.premium < 0) {
          throw new Error("Premium calculation error");
        }
        return sum + policy.premium;
      }
      return sum;
    }, 0);

    let amount=document.querySelectorAll(".amount")
    amount[0].innerHTML =
      `<h1>Total amount is $${totalPremium}</h1>`;
    amount[1].innerHTML =
      `<h1>Total amount is $${totalPremium}</h1>`;

  } catch (error) {
    let amount=document.querySelectorAll(".amount")
    amount[0].innerHTML =
      `<h1 style="color:red">${error.message}</h1>`;
      amount[1].innerHTML =
      `<h1 style="color:red">${error.message}</h1>`;
  }
}

//Task-5
async function appDiscount(){
    await getUsers();
    const discountPolicies=data.map((p)=>{
        if(p.premium > 10000){
            return{
            ...p,
            premium:p.premium-(p.premium*0.1)
            }
        }
        return p;
    })
    let container=document.querySelector('.discountedPolicies');
    container.innerHTML="";
    for(let i=0;i<discountPolicies.length;i++){
        container.innerHTML+=`<div class="flex-item">${discountPolicies[i].name}
        <p>${discountPolicies[i].type}</p>
        <p>${discountPolicies[i].premium}</p>
        <p>${discountPolicies[i].duration}</p>
        <p>${discountPolicies[i].status}</p></div>`;
    }
}

//Task-6
async function approvePolicy(){
    setTimeout(()=>{
        let resultdiv=document.querySelector('.result');
        resultdiv.innerHTML+=`<p class="resultdiv">Policy Approved After 2 Seconds</p>`;
    },2000)
}


//Task-7
function purchasePolicy(policyName) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (policyName) {
        resolve(`${policyName} policy purchased successfully`);
      } else {
        reject("Please select a policy before purchasing");
      }
    }, 2000);
  });
}

async function handlePurchase() {
  const policy = document.getElementById("policySelect").value;
  const resultDiv = document.querySelector(".purchase-result");

  resultDiv.className = "purchase-result loading";
  resultDiv.textContent = "Processing purchase...";

  try {
    const msg = await purchasePolicy(policy);
    resultDiv.className = "purchase-result success";
    resultDiv.textContent = msg;
  } catch (err) {
    resultDiv.className = "purchase-result error";
    resultDiv.textContent = err;
  }
}

//Task-8
async function checkPolicyById() {
  const id = Number(document.getElementById("policyIdInput").value);
  const output = document.querySelector(".error-output");
  await getUsers();
  try {
    const policy = data.find(p => p.id === id);
    if (!policy) {
      throw new Error("Invalid Policy ID");
    }
    output.innerHTML = `<p class="success-msg">Policy Found: ${policy.name}</p>`;
  } catch (error) {
    output.innerHTML = `<p class="error-msg">${error.message}</p>`;
  }
}

// API Failure simulation
async function simulateApiFailure() {
  const output = document.querySelector(".error-output");
  output.innerHTML = "Loading...";

  try {
    const res = await fetch("./wrongfile.json"); // intentional failure
    if (!res.ok) {
      throw new Error("API Failure: Unable to fetch policies");
    }
  } catch (error) {
    output.innerHTML = `<p class="error-msg">${error.message}</p>`;
  }
}

