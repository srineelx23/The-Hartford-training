const customers = [
 { id: 1, name: "Ravi", age: 32, policy: "Health", premium: 4800, active: true },
 { id: 2, name: "Anita", age: 51, policy: "Life", premium: 12000, active: true },
 { id: 3, name: "Kiran", age: 28, policy: "Vehicle", premium: 3500, active: false },
 { id: 4, name: "Meena", age: 45, policy: "Health", premium: 6000, active: true },
 { id: 5, name: "Suresh", age: 60, policy: "Life", premium: 18000, active: false }
]; 

// Bug-1
// for (let i = 0; i <= customers.length; i++) {
//  console.log(customers[i].name);
// }

//Bug-1 corrected
// for (let i=0;i<customers.length;i++){
//     console.log(customers[i].name);
// }
//Explanation: An array has indices upto size(array)-1. index 'i' reaches size(array) which prints undefined


//Bug-2
// const activeCustomers = customers.filter((c) => {
//  c.active === true;
// });

// Bug-2 corrected
// const activeCustomers = customers.filter((c) => {
//   return c.active === true;
// });
// console.log(activeCustomers); 
//Explanation: filter expects an explicit return statement to be written to return objects or values from the array. Without return the filter does not return any values


//Bug-3
// const updatedPremiums = customers.map((c) => {
//  if (c.age >= 50) {
//  c.premium = c.premium * 1.1;
//  }
// }); 

//Bug-3 corrected
// const updatedPremiums = customers.map((c) => {
//  if (c.age >= 50) {
//     return { ...c, premium: c.premium * 1.1 };
//  } 
//  else{
//     return c;
//  }
// }); 
// console.log(updatedPremiums);
//Explanation:
// map() is used to transform each element of an array and MUST return a value
// for every iteration. In the buggy code, no value was returned, so map()
// produced an array of undefined values.
// Additionally, the code directly modified the original customer object,
// which violates immutability.


// //Bug-4
// const totalPremium = customers.reduce((total, c) => {
//  total + c.premium;
// }, 0); 

// Bug-4 corrected
// const totalPremium = customers.reduce((total, c) => {
//  return total + c.premium;
// }, 0); 
// console.log(totalPremium);
//Explanation:
// reduce() requires the callback function to return the updated accumulator
// value on every iteration. In the code the expression `total + c.premium`
// was evaluated but never returned.


//Bug-5
// console.log("Customer ${customers[0].name} has policy
// ${customers[0].policy}"); 

//Bug-5 corrected
// console.log(`Customer ${customers[0].name} has policy
// ${customers[0].policy}`); 
//Explanation: 
// Template literals in JavaScript require backticks (`) instead of double
// or single quotes.


// Bug-6
// const policyCount = customers.reduce((count, c) => {
//  count.policy = (count.policy || 0) + 1;
//  return count;
// }, {}); 

//Bug-6 corrected
// const policyCount = customers.reduce((count, c) => {
//  count[c.policy] = (count[c.policy] || 0) +1;
//  return count;
// }, {}); 
// console.log(policyCount);
//Explanation:
// The code used a fixed object key 'policy', which caused all customers
// to be counted under a single property instead of grouping them by policy type.


// Bug-7
// const customersWithRisk = customers.map((c) => {
//  let riskLevel;
//  if (c.age < 35) riskLevel = "Low";
//  if (c.age <= 50) riskLevel = "Medium";
//  else riskLevel = "High";
//  return { ...c, riskLevel };
// }); 

//Bug-7 corrected
// const customersWithRisk = customers.map((c) => {
//  let riskLevel;
//  if (c.age < 35) riskLevel = "Low";
//  else if (c.age <= 50) riskLevel = "Medium";
//  else riskLevel = "High";
//  return { ...c, riskLevel };
// }); 
//  console.log(customersWithRisk);
//Explanation:
// The buggy code used multiple independent if statements, which caused the
// riskLevel value to be overwritten when more than one condition evaluated
// to true.


// Bug-8
// let active = 0,
//  inactive = 0;
// for (const c in customers) {
//  if (c.active) active++;
//  else inactive++;
// } 

//Bug-8 corrected
// let active = 0,
//  inactive = 0;
// for (let c of customers) {
//  if (c.active) active++;
//  else inactive++;
// }
// console.log("active policies: "+active+"\ninactive policies: "+inactive);
//Explanation:
// The buggy code used a for...in loop, which iterates over array indexes
// instead of array elements. As a result, 'c' represented the index and
// not the customer object


// Bug-9
// const getLifeCustomers = () =>
//  customers.filter((c) => c.policy === "Life").map((c) =>
// c.name); 

//Bug-9 corrected 
// const getLifeCustomers = () =>{
//  return customers
//  .filter((c) => c.policy === "Life")
//  .map((c) =>
// c.name);
// }
// console.log(getLifeCustomers());
//Explanation:
// In the buggy code,
// the function relied on implicit return, which can easily break if braces
// are added.


// Bug-10
const sortedCustomers = customers.sort((a, b) => b.premium -
a.premium); 
console.log(sortedCustomers);
console.log(customers);