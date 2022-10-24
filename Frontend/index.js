function Pet(){
    this.Name = '',
    this.Nickname = '',
    this.Age = 1,
    this.Type = '',
    this.DateCreated = Date.now(),
    this.TimeOrdered = '',
    this.DayOrdered = ''
};

const petAddForm = document.querySelector('.pet-form');

const petNickname = document.getElementById('nickname');
const petName = document.getElementById('name');
const petAge = document.getElementById('age');
const petType = document.getElementById('type');
const petTime = document.getElementById('time');
const petDay = document.getElementById('day');
const petTable = document.querySelector('.table-body');

const petCount = document.getElementById('pet-count');

petCount.innerText = 'Number of appointments: ' + countPets();

petAddForm.addEventListener('submit', function(){
    if(petName.value != '' && petNickname.value != '' && petAge.value != 0 && petType.value != ''){
        let newPet = new Pet();
        const dateTime = Date.now().toString();
        newPet.Name = petName.value;
        newPet.Nickname = petNickname.value;
        newPet.Age = petAge.value;
        newPet.Type = petType.value;
        newPet.TimeOrdered = petTime.value;
        newPet.DayOrdered = petDay.value;
        localStorage.setItem(dateTime, JSON.stringify(newPet));
    }
    else{
        alert("Some fields are empty!");
    }
    petName.value = '';
    petNickname.value = '';
    petAge.value = 1;
    petType.value = '';
});

function displayData(){
    for (var i = 0; i < localStorage.length; i++){
        const object = JSON.parse(localStorage.getItem(localStorage.key(i)));

        const newTr = document.createElement('tr');
        petTable.appendChild(newTr);

        const tdName = document.createElement('td');
        const tdNickname = document.createElement('td');
        const tdAge = document.createElement('td');
        const tdType = document.createElement('td');
        const tdDateCreated = document.createElement('td');
        const tdTimeOrdered = document.createElement('td');
        const tdDayOrdered = document.createElement('td');
        const tdButton = document.createElement('td');

        const button = document.createElement('button');

        newTr.appendChild(tdName);
        tdName.innerText = object.Name;

        newTr.appendChild(tdNickname);
        tdNickname.innerText = object.Nickname;

        newTr.appendChild(tdAge);
        tdAge.innerText = object.Age;

        newTr.appendChild(tdType);
        tdType.innerText = object.Type;

        newTr.appendChild(tdTimeOrdered);
        tdTimeOrdered.innerText = object.TimeOrdered;

        newTr.appendChild(tdDayOrdered);
        tdDayOrdered.innerText = object.DayOrdered;

        newTr.appendChild(tdDateCreated);
        tdDateCreated.innerText = object.DateCreated;

        newTr.appendChild(tdButton);
        tdButton.append(button);
        button.innerText = "Finish";
        button.onclick = () => {
            localStorage.removeItem(object.DateCreated);
            petTable.innerHTML = '';
            petCount.innerText = 'Number of appointments: ' + countPets();
            displayData();
        }
    }
}

function countPets(){
    let counter = localStorage.length;
    return counter;
}

displayData();
