import './App.css';
import Header from './Header';
import PetTable from './PetTable';

function App() {
  return (
    <div className="App">
      <Header />
      <div className="table-form-container">
        <PetTable />
      </div>
    </div>
  );
}

export default App;
