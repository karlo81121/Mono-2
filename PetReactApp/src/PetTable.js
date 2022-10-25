import React, { useState, useEffect }  from 'react';
import './petTable.css';
import jsonData from './data.json';
import AddPetForm from './AddPetForm';

function PetTable() {

    const [petData, setPetData] = useState(jsonData);

    const tableRows = petData.map((props) => {
        return (
          <tr>
            <td>{props.Name}</td>
            <td>{props.Nickname}</td>
            <td>{props.Age}</td>
            <td>{props.Type}</td>
            <td>{props.TimeOrdered}</td>
            <td>{props.DayOrdered}</td>
            <td><button className="finish-button">Finish</button></td>
          </tr>
        );
    });

    const addRows = (data) => {
        const totalPets = petData.length;
        data.id = totalPets + 1;
        const updatedPetData = [...petData];
        updatedPetData.push(data);
        setPetData(updatedPetData);
    };

    return (
        <div className="table-container">
            <table className="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Nickname</th>
                        <th>Age</th>
                        <th>Type</th>
                        <th>Time Ordered</th>
                        <th>Day Ordered</th>
                        <th>Finish Appointment</th>
                    </tr>
                </thead>
                    <tbody>{tableRows}</tbody>
            </table>
            <AddPetForm func={addRows} />
        </div>
    );
}

export default PetTable;
