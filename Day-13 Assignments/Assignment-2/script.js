//Task-1
function validate() {
 let name = document.getElementById("username").value;
 if (name == "") {
 alert("Name required");
 }
} 

//Task-3
document.getElementById("btn").onclick = function () {
 alert("Clicked");
}; 

//Task-4
let age = 16;
if (age >= 18) {
 console.log("Eligible");
} else if (age < 18) {
 console.log("Not Eligible");
} 

//Task-5
function check() {
 let email = document.getElementById("email").value;
 console.log(email);
 if (email === "") {
 alert("Email required");
 }
} 

//Task-7
let pwd = "admin123";
let confirmPwd = "admin123";
if (pwd == confirmPwd) {
 console.log("Match");
} else {
    console.log("Mismatch");
} 

//Task-9
console.log("Start");
// alert("Hello")
console.log("End");

//Task-10
function submitForm() {
 if (terms.checked == false) {
 alert("Accept terms");
 return false;
 }
 return true;
} 

//Task-11
function validate() {
 let mobile = document.getElementById("mobile").value;
 if ((mobile.length = 10)) {
 alert("Valid");
 } else {
 alert("Invalid");
 }
 } 

 //Task-12
 function validateName() {
 let name = document.getElementById("policyName").value;
 if (name == "") {
 alert("Policy holder name required");
 }
} 

//Task-13
function checkPlan() {
 let plan = document.getElementById("plan").value;
 if ((plan == "Select Plan")) {
 alert("Please choose a plan");
 }
 } 

 //Task-14
 let policyNumber = 123456;
document.getElementById("policy").innerHTML = policyNumber; 

//Task-15
let claimAmount = "abc";

if (Number.isNaN(Number(claimAmount))) {
  alert("Invalid claim");
} else {
  alert("Valid claim");
}

//Task-16
let policyType = "Health";
if (policyType == "Health") {
console.log("Health Policy");
} 
//Task-17
let policies = ["Life", "Health", "Vehicle"];
let list = document.getElementById("list");

policies.forEach(function (policy) {
  list.innerHTML += `<li>${policy}</li>`;
});

//Task-18
let premium = "5000";

if (Number.isNaN(Number(premium))) {
  console.log("Invalid premium");
} else {
  console.log("Valid premium");
}