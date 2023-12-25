// Function: Save Cars to local storage:
const saveCars = (carList) => {
    localStorage.setItem('Cars',JSON.stringify(carList))
}

// Function: Get saved Cars from local storage:
const getSavedCars = () => {
        //get JSON notes from local storage
        const carsJSON = localStorage.getItem('Cars')
        // try-catch used just in case the file in local storage is not JSON
        try {
        // Check if not null, convert JSON back to array & return. 
        // Else, return empty array
        return carsJSON !== null ? JSON.parse(carsJSON) : []
        } catch(e){
            return []
    }
}

  
  const saveCar = async (car) => {
    try {
      // Send an HTTP POST request to save a car to the server
      const response = await fetch('http://localhost:3000/cars', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(car),
      });
  
      if (response.ok) {
        console.log('Car saved successfully');
      } else {
        console.error('Failed to save car to the server');
      }
    } catch (error) {
      console.error('Error saving car:', error);
    }
  };
  

// Function: Remove a car:
const removeCar = (id, carList) => {
    let carIndex = carList.findIndex((car) => car.id === id);
    if (carIndex > -1) {
        carList.splice(carIndex,1);
        saveCars(carList);
        renderCars(carList);
    } else {
        console.log("Car ID is not found.");
    }
}

// Function: Selection Sort cars:
function sortCars(carList){
    for(let i=0; i < carList.length-1; i++){
        let min = i;
        for(let j=i+1; j< carList.length; j++){
            if (carList[j].price < carList[min].price) {
                min = j;
            }
        }
        // Swap the current latest with the new latest car:
        if (min != i){
            let temp = carList[i];
            carList[i] = carList[min];
            carList[min] = temp;
        }
    }
};

// Function: Add new car:
function addNewCar(carList) {
    // Select Category Type:
    let selectedCategory = "none"; 
    // Update the activity selector:
    document.querySelector('#category').addEventListener('change', (e) => {
        selectedCategory = e.target.value;
    });
    // Get the form inputs and plug them in the object car:
    document.querySelector('#add-new-form').addEventListener('submit', function (e) {
        e.preventDefault();
        // Create an object for the new car:
        let car = {
            id: uuidv4(),
            name: document.getElementById("productName").value,
            catergory: selectedCategory,
            price: document.getElementById("price").value,
            deleted: false,
        };
        // Add the new car to the array & save to local storage:
        carList.push(car);
        saveCars(carList);
        // Reset form after submitting:
        document.getElementById("add-new-form").reset();
        // Render car:
        carList= getSavedCars();
        renderCars(carList);
    });  
}

// Function: Handle delete button:
function handleDeleteButton(id, carList) {
    let deleteButton=document.querySelector(`#deleteButton-${id}`);
    deleteButton.addEventListener('click',() => {
        let deletedCar = carList.find((car) => car.id === id);
        deletedCar.deleted = true;
        removeCar(id, carList);
    });
}

// Function: Generate DOM for each new car:
function generateCarDOM(car, carList) {
    // row content HTML:
    const rowContent = `
    <td>${car.id}</td>
    <td>${car.name}</td>
    <td>${car.catergory}</td>
    <td>$ ${car.price}</td>
    <td>
        <button class="btn btn-danger" id="deleteButton-${car.id}">Delete</button>
    </td>`
    // create a new row:
    const newRow = document.createElement('tr');
    // add the row content HTML into the new row:
    newRow.innerHTML= rowContent;
    // add the new row to the table:
    document.querySelector('#table-body').appendChild(newRow);
    handleDeleteButton(car.id, carList);
}

function renderCars(carList) {
    sortCars(carList);
    // clear DOM of the table:
    document.querySelector('#table-body').innerHTML="";
    // loop thru the list and add the rows into the table:
    carList.forEach((car) => {
        generateCarDOM(car, carList);
    });
}


