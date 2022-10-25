import React, { useState } from 'react';
import './addPetForm.css';

function AddPetForm(props) {

    const[Name, setName] = useState('');
    const[Nickname, setNickname] = useState('');
    const[Age, setAge] = useState('');
    const[Type, setType] = useState('');
    const[TimeOrdered, setTimeOrdered] = useState('');
    const[DayOrdered, setDayOrdered] = useState('');

    const changeName = (event) => {
        setName(event.target.value);
    };
      
    const changeNickname = (event) => {
        setNickname(event.target.value);
    };

    const changeAge = (event) => {
        setAge(event.target.value);
    }

    const changeType = (event) => {
        setType(event.target.value);
    }

    const changeTimeOrdered = (event) => {
        setTimeOrdered(event.target.value);
    }

    const changeDayOrdered = (event) => {
        setDayOrdered(event.target.value);
    }

    const transferValue = (event) => {
        event.preventDefault();
        const val = {
          Name,
          Nickname,
          Age,
          Type,
          TimeOrdered,
          DayOrdered
        };

        localStorage.setItem(Date.now().toString(), JSON.stringify({
            Name: Name,
            Nickname: Nickname,
            Age: Age,
            Type: Type,
            TimeOrdered: TimeOrdered,
            DayOrdered: DayOrdered
        }));

        props.func(val);
        clearState();
    };

    const clearState = () => {
        setName('');
        setNickname('');
        setAge('');
        setType('');
        setTimeOrdered('');
        setDayOrdered('');
    };

    return (
        <div className="form-container">
            <b><p>Enter pet appointment: </p></b>
            <form className="pet-form" autoComplete="off">
                <input type="text" value={Name} placeholder="Name" onChange={changeName} />
                <input type="text" value={Nickname} placeholder="Nickname" onChange={changeNickname} />
                <input type="number" value={Age} placeholder="Age" onChange={changeAge} />
                <input type="text" value={Type} placeholder="Animal type" onChange={changeType} />
                <input type="text" value={TimeOrdered} placeholder="Time Ordered" onChange={changeTimeOrdered} />
                <input type="text" value={DayOrdered} placeholder="Day Ordered" onChange={changeDayOrdered} />
                <button className="add-pet-button" type="submit" onClick={transferValue}>Add pet</button>
            </form>
        </div>
    );
}

export default AddPetForm;
