
//we can call an IIFE to get a list of all the stores
(function () {
	fetch("/api/Stores")
		.then(res => res.json())
		.then(data => {
			console.log(data)
			const lop = document.querySelector('.listofStores');
			for (let x = 0; x < data.length; x++) {
				lop.innerHTML += `<p>The customer is ${data[x].storeName} ${data[x].storeLocation}.</p>`;
			}
		});
})();