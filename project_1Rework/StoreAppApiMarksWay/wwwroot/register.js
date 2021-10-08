
const loginform = document.querySelector("#registerform");


loginform.addEventListener('submit', (e) => {
	e.preventDefault();
	const fname1 = loginform.fname.value;
	const lname1 = loginform.lname.value;

	//GET fetch request
	fetch(`/api/Customers`, {
		method: 'POST',
		body: JSON.stringify({ fname: fname1, lname: lname1 }),
		headers: {
			'Content-Type': 'application/json'
		}
		})
		.then(res => {
			if (!res.ok) {
				console.log('unable to login the user')
				throw new Error(`Network response was not ok (${res.status})`);
			}
			return res.json();
		})
		.then(res => {
			
			location.href = "login.html";
		})
		.catch(err => console.log(`There was an error ${err}`));
});