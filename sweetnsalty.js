let sweet = 0;
let salty = 0;
let sweetNsalty = 0;
let myArray = new Array();
var tempArray = new Array();

for (i = 1; i < 1000; i++) {
  if (i % 3 == 0 && i % 5 == 0) {
    myArray.push("Sweet -n- Salty");
    sweetNsalty++;
  } else if (i % 5 == 0) {
    myArray.push("salty");
    salty++;
  } else if (i % 3 == 0) {
    myArray.push("sweet");
    sweet++;
  } else {
    myArray.push(i);
  }
}

for (i = 0; i < myArray.length; i++) {
  tempArray.push(myArray[i]);
  if (tempArray.length == 20) {
    console.log(tempArray.toString());
    tempArray = [];
  }
}
console.log(tempArray.toString());

console.log(`Sweet appeared ${sweet} times out of 1000.`);
console.log(`Salty appeared ${salty} times out of 1000.`);
console.log(`SweetnSalty appeared ${sweetNsalty} times out of 1000.`);