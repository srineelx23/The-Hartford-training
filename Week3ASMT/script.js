const API_URL = "https://jsonplaceholder.typicode.com/users";

let accounts = [];

const accountsDiv = document.getElementById("accounts");
const loader = document.getElementById("loader");
const totalBalanceEl = document.getElementById("totalBalance");

function delay(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

function randomBalance() {
  return Math.floor(Math.random() * 40001) + 10000;
}

function save() {
  localStorage.setItem("accounts", JSON.stringify(accounts));
}

function updateTotal() {
  const total = accounts.reduce((sum, a) => sum + a.balance, 0);
  totalBalanceEl.textContent = `Total Bank Balance: ₹${total}`;
}



async function loadAccounts() {
  loader.style.display = "block";

  const stored = localStorage.getItem("accounts");
  if (stored) {
    accounts = JSON.parse(stored);
    render(accounts);
    loader.style.display = "none";
    return;
  }

  try {
    await delay(1200);
    const res = await fetch(API_URL);
    const data = await res.json();

    accounts = data.map(u => ({
      id: u.id,
      name: u.name,
      email: u.email,
      branch: u.address.city,
      balance: randomBalance(),
      transactions: []
    }));

    save();
    render(accounts);
  } catch {
    alert("Error fetching accounts");
  } finally {
    loader.style.display = "none";
  }
}



function render(list) {
  accountsDiv.innerHTML = "";

  list.forEach(acc => {
  const card = document.createElement("div");
card.className = "card";

let statusHTML = `<span class="status active">Active</span>`;

if (acc.balance < 0) {
  card.classList.add("negative");
  statusHTML = `<span class="status negative">⚠ Overdrawn</span>`;
} 
else if (acc.balance < 5000) {
  statusHTML = `<span class="status low">Low Balance</span>`;
}


   card.innerHTML = `
  ${statusHTML}
  <h3>${acc.name}</h3>
  <p><b>Account No:</b> ${acc.id}</p>
  <p><b>Email:</b> ${acc.email}</p>
  <p><b>Branch:</b> ${acc.branch}</p>
  <p><b>Balance:</b> ₹${acc.balance}</p>

  <button class="deposit" onclick="deposit(${acc.id})">Deposit</button>
  <button class="withdraw" onclick="withdraw(${acc.id})">Withdraw</button>
  <button class="history" onclick="history(${acc.id})">History</button>
  <button class="delete" onclick="remove(${acc.id})">Delete</button>
`;


    accountsDiv.appendChild(card);
  });

  updateTotal();
}



document.getElementById("search").addEventListener("input", e => {
  const value = e.target.value.toLowerCase();
  render(accounts.filter(a => a.name.toLowerCase().includes(value)));
});



function deposit(id) {
  const amt = +prompt("Enter deposit amount:");
  if (amt <= 0) return;

  const acc = accounts.find(a => a.id === id);
  acc.balance += amt;
  acc.transactions.push({ type: "Deposit", amt, time: new Date().toLocaleString() });

  save();
  render(accounts);
}

function withdraw(id) {
  const amt = +prompt("Enter withdrawal amount:");
  const acc = accounts.find(a => a.id === id);

  if (amt > acc.balance) {
    alert("Insufficient balance");
    return;
  }

  acc.balance -= amt;

  if (acc.balance < 5000) {
    acc.balance -= 200;
    alert("Minimum balance violated! ₹200 penalty applied");
  }

  acc.transactions.push({ type: "Withdraw", amt, time: new Date().toLocaleString() });

  save();
  render(accounts);
}

function history(id) {
  const acc = accounts.find(a => a.id === id);
  if (acc.transactions.length === 0) {
    alert("No transactions yet");
    return;
  }

  alert(
    acc.transactions
      .map(t => `${t.time} | ${t.type} ₹${t.amt}`)
      .join("\n")
  );
}



document.getElementById("createForm").addEventListener("submit", e => {
  e.preventDefault();

  const nameInput = document.getElementById("name").value;
  const emailInput = document.getElementById("email").value;
  const branchInput = document.getElementById("branch").value;

  const acc = {
    id: Date.now(),
    name: nameInput,
    email: emailInput,
    branch: branchInput,
    balance: 10000,
    transactions: []
  };

  accounts.push(acc);
  save();
  render(accounts);
  e.target.reset();
});



function remove(id) {
  if (!confirm("Delete this account?")) return;
  accounts = accounts.filter(a => a.id !== id);
  save();
  render(accounts);
}



function sortByBalance() {
  const sorted = [...accounts].sort((a, b) => b.balance - a.balance);
  render(sorted);
}



loadAccounts();
