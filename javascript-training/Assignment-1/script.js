const insuranceTypes = [
  {
    id: 1,
    type: "Health Insurance",
    coverage: "Medical expenses and hospitalization",
    riskLevel: "High",
    duration: "1 Year",
    popular: true
  },
  {
    id: 2,
    type: "Life Insurance",
    coverage: "Financial protection to family",
    riskLevel: "Medium",
    duration: "10 Years",
    popular: true
  },
  {
    id: 3,
    type: "Vehicle Insurance",
    coverage: "Damage or theft of vehicle",
    riskLevel: "Medium",
    duration: "1 Year",
    popular: true
  },
  {
    id: 4,
    type: "Travel Insurance",
    coverage: "Trip cancellations and medical emergencies",
    riskLevel: "Low",
    duration: "Trip Period",
    popular: false
  },
  {
    id: 5,
    type: "Home Insurance",
    coverage: "Damage to house and belongings",
    riskLevel: "Medium",
    duration: "5 Years",
    popular: false
  },
  {
    id: 6,
    type: "Pet Insurance",
    coverage: "Veterinary care and treatments",
    riskLevel: "Low",
    duration: "1 Year",
    popular: false
  }
];

/* ---------- INITIAL RENDER ---------- */
renderGrid(insuranceTypes);

/* ---------- RENDER FUNCTION ---------- */
function renderGrid(data) {
  const container = document.querySelector(".container");

  // Clear all cards first (important)
  const allCards = container.querySelectorAll(".grid-item");
  allCards.forEach(card => card.innerHTML = "");

  data.forEach(item => {
    const card = container.querySelector(`.grid-item-${item.id}`);

    if (!card) return;

    card.innerHTML = `
      <h3>${item.type}</h3>
      <p><strong>Coverage:</strong> ${item.coverage}</p>
      <p><strong>Risk Level:</strong> ${item.riskLevel}</p>
      <p><strong>Duration:</strong> ${item.duration}</p>
      <p><strong>Popular:</strong> ${item.popular ? "Yes" : "No"}</p>
    `;
  });
}

/* ---------- RESET ---------- */
function reset() {
  renderGrid(insuranceTypes);
}

/* ---------- SORT BY DURATION ---------- */
function sortDuration() {
  const sorted = [...insuranceTypes].sort((a, b) => {
    const durA = parseInt(a.duration) || 0;
    const durB = parseInt(b.duration) || 0;
    return durA - durB;
  });

  renderGrid(sorted);
}

/* ---------- FILTER POPULAR (EMPTY OTHERS) ---------- */
function filterPopular() {
  const popularOnly = insuranceTypes.filter(item => item.popular);
  renderGrid(popularOnly);
}

console.log("Hello, welcome to JavaScript training!");
