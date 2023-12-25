// Get all pokemons:
async function fetchPokemonAPI() {
    try{
        const response = await fetch('https://pokeapi.co/api/v2/pokemon');
        if (!response.ok) {
            throw new error("Network response is not ok");
        }else {
            const data = await response.json();
            return data;
        }
    } catch (error){
        // console.log(error);
    }
}

// // Using '.then()':
// fetchPokemonAPI()
// .then((myPokemons) => {
//     pokemonList = myPokemons.results;
//     pokemonList.forEach(pokemon => {
//         console.log(pokemon.name);
//     });
// })
// .catch((error) => {
//     console.log(error);
// })


// Using 'async/await':
// Wait for the pokemons to be fetched and return a list of pokemons:
const getPokemons = async () => {
    try{
        let myPokemons = await fetchPokemonAPI();
        let pokemonList = myPokemons.results;
        pokemonList.forEach(pokemon => {
            // console.log(pokemon.name); //testing
        });
        return pokemonList;
    } catch (error) {
        // console.log(error);
    }
}

// Return the url of the corresponding pokemon
const getUrl = async (pokemonName) => {
    try{
        let myPokemons = await getPokemons();
        let pokemonIndex = myPokemons.findIndex((pokemon, index) => pokemon.name === pokemonName ? index : -1);
        return myPokemons[pokemonIndex].url;
    } catch{

    }
}

// Generate DOM:
const generatePokemonDOM = (pokemonName, pokemonUrl) => {
    let pokemonTable = document.querySelector('#table-body');
    let newRow = document.createElement('tr');
    const rowContent = `
    <td><p class="name-format text-center">${pokemonName}<p></td>
    <td class="text-center">
        <a class="btn btn-warning pokemon-button"  onclick="setLocal('${pokemonUrl}')" role="button" href="./info.html" id='${pokemonName}' api-url="${getUrl(pokemonName)}">Click Me!</a>
    </td>`
    newRow.innerHTML = rowContent;
    pokemonTable.appendChild(newRow);
}

function setLocal(url){
    localStorage.setItem('url', url)
}

//Populate Table:
async function handleOnLoad() {
    try{
        let pokemonList = await getPokemons();
        pokemonList.forEach((pokemon) => {
            generatePokemonDOM(pokemon.name, pokemon.url);
        })
    }catch (error) {
        // console.log(error);
    }
}

// search bar:
async function searchPokemon() {
    await handleOnLoad();
    document.querySelector('#searchBar').addEventListener('change', (e) => {
        let lookupValue = e.target.value;
        const table = document.getElementById('pokemon-table');
        const tbody = table.getElementsByTagName('tbody')[0];
        const rows = tbody.getElementsByTagName('tr');
        // loop thru the column name of the pokemon table:
        for (let i=0; i< rows.length; i++){
            const cell = rows[i].getElementsByTagName('td');
            const pokemonName = cell.textContent;
            if (pokemonName.includes(lookupValue)){
                console.log(pokemonName);
            }
        }
       
    });
}

// Function to loop through the name column
function loopThroughColumn(tableId, columnIndex) {
    const table = document.getElementById(tableId);
    const tbody = table.getElementsByTagName('tbody')[0];
    const rows = tbody.getElementsByTagName('tr');

    for (let i = 0; i < rows.length; i++) {
        const cell = rows[i].getElementsByTagName('td')[columnIndex];
        console.log(cell.textContent);
        // You can perform any desired action with the cell data here
    }
}