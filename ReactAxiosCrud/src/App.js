import './App.css';
import Projects from './AllProjects';
import SingleProject from './GetSingleProject';
import FilteredProjects from './GetFilteredProjects';

function App() {
  return (
    <div className="App">
      <h1 className='all-projects'>All projects</h1>
      <Projects />
      <h1 className='one-project'>Single project</h1>
      <SingleProject />
      <h1 className='filtered-project'>Filtered projects</h1>
      <FilteredProjects />
    </div>
  );
}

export default App;
