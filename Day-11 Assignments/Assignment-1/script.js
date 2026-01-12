//Task-1
let title=document.getElementById('pageTitle')
title.innerHTML='Customer Insurance Overview';

//Task-2
let list=document.getElementsByTagName('li');
for(let i=0;i<list.length;i++){
    list[i].style.border="2px solid black"
    list[i].style.marginBottom="10px"
}
console.log(list.length);

//Task-3
let policies=document.getElementsByClassName('policy');
for(let i=0;i<policies.length;i++){
    policies[i].style.color="blue";
    policies[i].classList.add('highlight')
    policies[i].style.border="1px solid black"
}

//Task-4
let customer1=document.querySelector('.customer').textContent;
let allcustomers=document.querySelectorAll('.customer');
let lastcustomer=allcustomers[allcustomers.length-1];
lastcustomer.classList.add('active')
console.log(customer1);
for(let i=0;i<allcustomers.length;i++){
    console.log(allcustomers[i].textContent)
}

//Task-5
let countOfForms=document.forms.length;
let countOfImages=document.images.length;
let alllinks=document.links
for(let i=0;i<alllinks.length;i++){
    alllinks[i].innerHTML="More Info";
}
console.log(countOfForms);
console.log(countOfImages);

//Task-6
let newcustomer=document.createElement('li');
newcustomer.innerHTML="Ramana - Life";
newcustomer.classList.add('customer');
let lists=document.getElementById('customerList');
lists.appendChild(newcustomer);

//Task-7
const textInputs = document.querySelectorAll('input[type="text"]');
for(let i=0;i<textInputs.length;i++){
    textInputs[i].style.backgroundColor="yellow";
    textInputs[i].placeholder="Enter Full Name"
}

//Task-8
const elements = document.querySelectorAll('.customer.active');

elements.forEach(el => {
    el.style.color = "darkgreen";
    el.innerHTML += " (Priority Customer)";
});

//Task-9
// Descendant selector: selects ALL li inside #customerList (any depth)
const descendantLis = document.querySelectorAll('#customerList li');

// Child selector: selects ONLY direct child li of #customerList
const childLis = document.querySelectorAll('#customerList > li');

// Log results
console.log("Descendant <li> elements:", descendantLis);
console.log("Direct child <li> elements:", childLis);

// Log counts to clearly see the difference
console.log("Descendant count:", descendantLis.length);
console.log("Child count:", childLis.length);


//Task-10
const evenCustomers = document.querySelectorAll('.customer:nth-child(even)');
evenCustomers.forEach(el => {
    el.style.backgroundColor = 'lightgray';
});

const oddCustomers = document.querySelectorAll('.customer:nth-child(odd)');
oddCustomers.forEach(el => {
    el.style.backgroundColor = 'lightblue';
});

//Task-11
const form = document.forms["enquiryForm"];

for (let i = 0; i < form.elements.length; i++) {
    if (form.elements[i].tagName === "INPUT") {
        console.log(form.elements[i].name);
    }
}

form.querySelector('input[type="submit"], button[type="submit"]').disabled = true;

//Task-12
// HTMLCollection (LIVE)
const policiesByClass = document.getElementsByClassName('policy');

// NodeList (STATIC)
const policiesByQuery = document.querySelectorAll('.policy');

console.log("Initial HTMLCollection length:", policiesByClass.length);
console.log("Initial NodeList length:", policiesByQuery.length);

const newPolicy = document.createElement('div');
newPolicy.className = 'policy';
newPolicy.innerText = 'New Policy Added';

document.body.appendChild(newPolicy);

console.log("After adding new policy:");
console.log("HTMLCollection length:", policiesByClass.length);
console.log("NodeList length:", policiesByQuery.length);


//Task-13
const customers = document.querySelectorAll('.customer');

customers.forEach(customer => {
    const text = customer.textContent;

    if (text.includes("Life")) {
        customer.style.backgroundColor = "lightgreen";
    }

    if (text.includes("Vehicle")) {
        customer.style.display = "none";
    }
});

//Task-14
const customerItems = document.querySelectorAll('.customer');

customerItems.forEach(item => {
    item.addEventListener('click', function () {
        const parentUl = this.closest('ul');
        parentUl.style.border = "2px solid black";
    });
});

//Task-15
const exceptFirstpolicies = document.querySelectorAll('p.policy:not(:first-of-type)');


exceptFirstpolicies.forEach(policy => {
    policy.style.fontStyle = "italic";
    policy.textContent = "✔ " + policy.textContent;
});
