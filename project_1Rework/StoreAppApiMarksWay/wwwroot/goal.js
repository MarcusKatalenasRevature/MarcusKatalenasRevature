window.onload = function () {
	//console.log('Something');
	console.log(sessionStorage.getItem('user'));
	let user = JSON.parse(sessionStorage.getItem('user'));
	document.getElementById("place1").innerHTML = `Welcome ${user.fname} ${user.lname} !<br>Please select a store below! < br >`;
	//document.getElementById("place1").innerHTML = `Welcome`;
	//List the stores as buttons

	//document.getElementById("place1").innerHTML += <br>Name: ${user.fname};

	const button = document.createElement('button');

	myJsonCart = '{products :[]}';

	(function () {
		fetch("/api/Stores")
			.then(res => res.json())
			.then(data => {
				console.log(data)
				const lop = document.querySelector('#storeList');
				for (let x = 0; x < data.length; x++) {
					let SelectButton = button.cloneNode(false);
					SelectButton.innerText = 'Select';
					SelectButton.value = data[x].storeId;
					lop.innerHTML += `<p>The Store is ${data[x].storeId} ${data[x].storeName} ${data[x].storeLocation}.</p>`;
					lop.appendChild(SelectButton);
					console.log('Sucess');
					//Hopefully added the event listner to the button
				}
			})
			//add event handlers for each SELECTbutton made from the store
			.then(something => {
				var buttonSelectors = document.getElementsByTagName('button');
				for (let i = 0; i < buttonSelectors.length; i++) {
					let buttonhue = buttonSelectors[i];
					buttonhue.addEventListener('click', function () {

						//GET THE STOREID VALUE FROM THE BUTOnn AND make a storedsession of the storeid
						//Calls stores ID api get
						fetch(`/api/Stores/${buttonhue.value}`)
							.then(res => res.json())
							.then(res => {
								console.log(res)
								console.log(buttonhue.value) //prints the id of the store

								sessionStorage.setItem('store', JSON.stringify(res));

								sessionStorage.setItem('cart', JSON.stringify(myJsonCart));

								console.log(sessionStorage.store);

								location.href = "storePage.html";


								//const lop = document.querySelector('#productList');


								/*
								for (let x = 0; x < data.length; x++) {
									let AddButton = button.cloneNode(false);
									AddButton.innerText = 'Add';
									AddButton.nodeValue = data[x].productID;
									lop.innerHTML += `<p> ${data[x].productName} ${data[x].productPrice} </p>`;
									lop.appendChild(AddButton);
								}
								*/
							});
					});
                }	
			})
	})();

	
	/*
	//add aneventListner to each button on the page
	buttonSelector.addEventListener('click', function () {
		fetch("/api/Products")
			.then(res => res.json())
			.then(data => {
				console.log(data)
				const lop = document.querySelector('#productList');
				for (let x = 0; x < data.length; x++) {
					let AddButton = button.cloneNode(false);
					AddButton.innerText = 'Select';
					SelectButton.nodeValue = data[x].productID;
					lop.innerHTML += `<p> ${data[x].productName} ${data[x].price} </p>`;
				}
			});
	});

	GETS PRODUCTS BY THE SELECTED STORE
	fetch(`/api/Store/findProductList/${buttonhue.value}`)
							.then(res => res.json())
							.then(data => {
								console.log(data)
								console.log(buttonhue.value) //prints the id of the store
								const lop = document.querySelector('#productList');
								for (let x = 0; x < data.length; x++) {
									let AddButton = button.cloneNode(false);
									AddButton.innerText = 'Add';
									AddButton.nodeValue = data[x].productID;
									lop.innerHTML += `<p> ${data[x].productName} ${data[x].productPrice} </p>`;
									lop.appendChild(AddButton);
								}
							});
	*/
		
}




