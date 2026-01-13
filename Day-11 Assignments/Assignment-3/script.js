function showResult(resultId, message) {
  const resultBox = document.getElementById(resultId);
  const p = document.createElement("p");
  p.textContent = message;
  resultBox.appendChild(p);
}

//Exercise-1
let bdy1=document.querySelector("body");
let btn=document.querySelector(".paypremium");
let paypremdiv=document.querySelector('.paymentSection')
function handleClick(e){
    showResult("result1", `Clicked on ${e.currentTarget.tagName} element`);
}
bdy1.addEventListener('click',handleClick)
paypremdiv.addEventListener("click",handleClick);
btn.addEventListener("click",handleClick);

// Output
// You clicked on  BUTTON  element
// You clicked on  DIV  element
// You clicked on  BODY  element

//Exercise-2
let viewPolicies=document.querySelector(".viewPolicies");
let policyContainer=document.querySelector('.policyContainer');
function parentHandleClick(e){
     showResult("result2", `Clicked on ${e.currentTarget.tagName} element`);
}
document.body.addEventListener('click',parentHandleClick,true);
policyContainer.addEventListener("click",parentHandleClick,true);
viewPolicies.addEventListener("click",parentHandleClick);
//Output
// You clicked on  BODY  element
// You clicked on  DIV  element
// You clicked on  BUTTON  element

//Exercise-3
let policyCard=document.querySelector('.policy-card');
let deleteBtn=document.querySelector('#deleteBtn');

policyCard.addEventListener('click',(event)=>{
    event.stopPropagation();
    showResult("result3", "Navigating to policy details");
})

deleteBtn.addEventListener('click',(event)=>{
    event.stopPropagation();
    showResult("result3", "Policy deleted");
})
//Output
//Without stopPropogation
// Navigating To Policy Details
// Deleting Policy
//With stopPropogation
// Deleting Policy

//Exercise-4
let tablerow=document.querySelectorAll('.tablerow');
let approveClaim=document.querySelector('.approveClaim');

for(let row of tablerow){
row.addEventListener('click',(e)=>{
    e.stopPropagation();
    showResult("result4", "Opening claim details");
})
}

approveClaim.addEventListener('click',(e)=>{
    e.stopPropagation();
    showResult("result4", "Claim approved");
})
//Output
//Without Stop Propogation
// Claim Approved
// Opening Claim Details

//With Stop Propogation
// Opening Claim Details
