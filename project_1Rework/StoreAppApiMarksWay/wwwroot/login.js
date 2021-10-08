
const loginform = document.querySelector("#loginform");


loginform.addEventListener('submit', (e) => {
	e.preventDefault();
	const fname = loginform.fname.value;
	const lname = loginform.lname.value;

	//GET fetch request
	fetch(`/api/Customers/login/${fname}/${lname}`)
		.then(res => {
			if (!res.ok) {
				console.log('unable to login the user')
				alert("We did not find you in the database please register if you wish to continue or enter an exisiting account")
				throw new Error(`Network response was not ok (${res.status})`);
			}
			return res.json();
		})
		.then(res => {
			console.log(res);
			sessionStorage.setItem('user', JSON.stringify(res));
			// the below are all valid ways to get the values back from the storage object.
			console.log(sessionStorage.getItem('user'));
			console.log(sessionStorage.user);
			console.log(sessionStorage['user']);
			//sessionStorage.clear()

			location.href = "goal.html";
		})
		.catch(err => console.log(`There was an error ${err}`));
});