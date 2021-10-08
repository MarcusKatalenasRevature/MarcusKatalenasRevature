window.onload = function () {
    //console.log('Something');
    console.log(sessionStorage.getItem('user'));
    let user = JSON.parse(sessionStorage.getItem('user'));
    document.getElementById("place1").innerHTML = `Welcome ${user.fname} ${user.lname} !<br>Please select a store below! < br >`;
    //document.getElementById("place1").innerHTML = `Welcome`;
    //List the stores as buttons

    //document.getElementById("place1").innerHTML += <br>Name: ${user.fname};

	const button = document.createElement('button');
	const buttonSelector = document.querySelector('button');

	(function () {
		fetch("/api/Stores")
			.then(res => res.json())
			.then(data => {
				console.log(data)
				const lop = document.querySelector('#storeList');
				for (let x = 0; x < data.length; x++) {
					lop.innerHTML += `<p>The Store is ${data[x].storeId} ${data[x].storeName} ${data[x].storeLocation}.</p>`;
					lop.appendChild(SelectButton);
				}
			});
	})();
}

