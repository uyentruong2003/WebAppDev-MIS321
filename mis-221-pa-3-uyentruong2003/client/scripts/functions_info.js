let myUrl = localStorage.getItem('url')
// Get info of a pokemon:

async function fetchInfo(pokemonUrl) {
    try{
        const response = await fetch(pokemonUrl);
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
// get pokemon's name: 
const getPokemonName = async (pokemonUrl) => {
    try{
        let myPokemonInfo = await fetchInfo(pokemonUrl);
        let name = myPokemonInfo.name;
        console.log(name);
        return name;
    } catch (error) {
        console.log(error);
    }
}

// get the list of abilities given a pokemon:
const getAbilities = async (pokemonUrl) => {
    try{
        let myPokemonInfo = await fetchInfo(pokemonUrl);
        let abilities = myPokemonInfo.abilities;
        let abilityList=[];
        abilities.forEach((a) =>{
            abilityList.push(a.ability.name);
        })
        console.log(abilityList);
        return abilityList;
    } catch (error) {
        console.log(error);
    }
}

// get the list of moves given a pokemon:
const getMoves = async (pokemonUrl) => {
    try{
        let myPokemonInfo = await fetchInfo(pokemonUrl);
        let moves = myPokemonInfo.moves;
        let moveList=[];
        moves.forEach((m) =>{
            moveList.push(m.move.name);
        })
        console.log(moveList);
        return moveList;
    } catch (error) {
        console.log(error);
    }
}

// // get the height of a given pokemon:
// const getHeight = async (pokemonUrl) => {
//     try{
//         let myPokemonInfo = await fetchInfo(pokemonUrl);
//         let height = myPokemonInfo.height;
//         console.log(height);
//         return height;
//     } catch (error) {
//         console.log(error);
//     }
// }

// get the sprite image of a given pokemon:
const getImage = async (pokemonUrl) => {
    try{
        let myPokemonInfo = await fetchInfo(pokemonUrl);
        let imageUrl = myPokemonInfo.sprites.front_shiny;
        console.log(imageUrl);
        return imageUrl;
    } catch (error) {
        console.log(error);
    }
}

// generate DOM for the info card:
const generateCardDOM = async (pokemonUrl) => {
    try {
        const card = document.querySelector('#pokemon-card');
        const name = await getPokemonName(pokemonUrl);
        const imageUrl = await getImage(pokemonUrl);
        const abilities = await getAbilities(pokemonUrl);
        const moves = await getMoves(pokemonUrl);

        const cardContent = `
            <div class="card mb-3 mx-auto p-2 table-outline" style="max-width: 1000px; max-height:fit-content">
                <div class="row g-0">
                    <div class="col-md-4">
                        <img src="${imageUrl}" class="img-fluid rounded-start avatar" alt="${name}-image">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h3 class=" name-format">${name}</h3>
                            <!-- Abilities -->
                            <h5 class="card-text">Abilities:</h5>
                            <p>${abilities.join(', ')}</p>
                            <!-- Moves -->
                            <h5 class="card-text">Moves:</h5>
                            <p>${moves.join(', ')}</p>
                            <a class="btn btn-warning" role="button" href="./index.html">Go Back</a>
                        </div>
                    </div>
                </div>
            </div>`;
        card.innerHTML = cardContent;
    } catch (error) {
        console.log(error);
    }
};

generateCardDOM(myUrl);