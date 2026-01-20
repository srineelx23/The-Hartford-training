var message = "Hello world";
console.log(message);
var h1 = document.createElement("h1");
h1.textContent = message;
document.body.appendChild(h1);
var h2 = document.querySelector('.header2');
if (h2) {
    h2.innerHTML = "This is the second header";
}
console.log("hello world");
