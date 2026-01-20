let message: string= "Hello world";
console.log(message);
let h1=document.createElement("h1");
h1.textContent=message;
document.body.appendChild(h1);

const h2 = document.querySelector('.header2') as HTMLElement | null;
if (h2) {
  h2.innerHTML = "This is the second header";
}
else{
    console.log("null")
}

console.log("hello world");