
const plans = [
  { name: "Health Insurance", base: 3000, coverage: "Up to 10L" },
  { name: "Life Insurance", base: 5000, coverage: "Up to 15L" },
  { name: "Vehicle Insurance", base: 2000, coverage: "Up to 5L" },
  { name: "Home Insurance", base: 4000, coverage: "Up to 20L" }
];

const customers = [];


const plansDiv = document.getElementById("plans");
plans.map(p => {
  plansDiv.innerHTML += `
    <div class="
      insur text-white p-4 rounded
      shadow
      transition-all duration-300 ease-in-out
      hover:shadow-xl
      hover:-translate-y-1
      hover:scale-[1.02]
      cursor-pointer
    ">
      <h3 class="font-bold">${p.name}</h3>
      <p>Base Premium: ₹${p.base}</p>
      <p>Coverage: ${p.coverage}</p>
      <button class="mt-2 bg-blue-700 text-white px-3 py-1 rounded">Enroll</button>
    </div>`;
});


const coverage = document.getElementById("coverage");
const coverageValue = document.getElementById("coverageValue");
coverage.oninput = () => coverageValue.textContent = coverage.value;

function calculatePremium(age, policy, coverage) {
  let base = policy === "Health" ? 3000 : policy === "Life" ? 5000 : 2000;
  let premium = base + (coverage - 1) * 500;
  if (age > 45) premium *= 1.2;
  return Math.round(premium);
}


function renderTable(data) {
  const tbody = document.getElementById("customerTable");
  tbody.innerHTML = "";

  data.map(c => {
    tbody.innerHTML += `
      <tr class="text-center border-t">
        <td class="p-2">${c.name}</td>
        <td>${c.age}</td>
        <td>${c.policyType}</td>
        <td>${c.coverage}L</td>
        <td>₹${c.premium}</td>
      </tr>`;
  });

  document.getElementById("totalCustomers").textContent = customers.length;
  document.getElementById("totalPremium").textContent = "₹" + customers.reduce((t, c) => t + c.premium, 0);
}

document.getElementById("customerForm").addEventListener("submit", function (event) {
  event.preventDefault();

  let isValid = true;

  const fields = [
    { id: "name", msg: "Name is required" },
    { id: "age", msg: "Valid age is required", check: v => v > 0 },
    { id: "email", msg: "Email is required" },
    { id: "policyType", msg: "Policy type is required" }
  ];

  document.querySelectorAll(".error").forEach(err => {
    err.textContent = "";
    err.classList.add("hidden");
  });

  fields.forEach(f => {
    const input = document.getElementById(f.id);
    const errorEl = input.parentElement.querySelector(".error");
    const value = input.value.trim();

    const valid = f.check ? f.check(Number(value)) : value !== "";

    if (!valid) {
      errorEl.textContent = f.msg;
      errorEl.classList.remove("hidden");
      isValid = false;
    }
  });

  if (!isValid) return;

  const age = Number(document.getElementById("age").value);
  const policyType = document.getElementById("policyType").value;
  const coverageVal = Number(document.getElementById("coverage").value);

  const premium = calculatePremium(age, policyType, coverageVal);

  customers.push({
    id: Date.now(),
    name: document.getElementById("name").value.trim(),
    age,
    policyType,
    coverage: coverageVal,
    premium
  });

  renderTable(customers);
  event.target.reset();
  document.getElementById("coverageValue").textContent = "1";
});

document.getElementById("filterPolicy").addEventListener("change", filterAndSearch);
document.getElementById("searchName").addEventListener("input", filterAndSearch);

function filterAndSearch() {
  const policy = document.getElementById("filterPolicy").value;
  const search = document.getElementById("searchName").value.toLowerCase();

  const filtered = customers.filter(c =>
    (policy === "All" || c.policyType === policy) &&
    c.name.toLowerCase().includes(search)
  );

  renderTable(filtered);
}