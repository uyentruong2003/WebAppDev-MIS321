let uniAPI = 'http://universities.hipolabs.com/search';
let countryAPI = 'https://restcountries.com/v3.1/all?fields=name';
let chosenCountry = "";

// Fetch API from the given URL:
async function fetchAPI(url) {
    try{
        const response = await fetch(url);
        if (!response.ok) {
            throw new error("Network response is not ok");
        }else {
            const data = await response.json();
            return data;
        }
    } catch (error){
        console.log(error);
    }
}

// Load the data into the table:
async function generateTable() {
    document.getElementById('university-table').hidden = false;
    document.getElementById('no-result-msg').hidden = true;
    let tableBody = document.getElementById('table-body');
    let tableBodyHTML = '';
    tableBody.innerHTML = tableBodyHTML; //clear
    let universities = await fetchAPI(uniAPI);
        // if no country is entered:
        if (chosenCountry === ""){
            // print all
            universities.forEach(u => {
                tableBodyHTML += `
                    <tr>
                        <td>${u.name}</td>
                        <td>${u.web_pages[0]}</td>
                        <td>${u.country}</td>
                    </tr>`
            });
        // if a country is entered:
        } else {
            universities.forEach(u => {
                // only print the ones from the specified country
                if (u.country.toLowerCase() === chosenCountry.toLowerCase()) {
                    tableBodyHTML += `
                    <tr>
                        <td>${u.name}</td>
                        <td>${u.web_pages[0]}</td>
                        <td>${u.country}</td>
                    </tr>`
                }
            });
            // after looping thru the list but table is still blank --> not found country
            if (tableBodyHTML ==="") {
                document.getElementById('university-table').hidden = true;
                document.getElementById('no-result-msg').hidden = false;
            }
        }
    tableBody.innerHTML = tableBodyHTML;
}


generateTable();

document.getElementById('country-filter-button').addEventListener('click',(e) => {
    e.preventDefault();
    chosenCountry = document.getElementById('country-filter-input').value;
    // re-generate table whenever filter is added
    generateTable();
    
})


