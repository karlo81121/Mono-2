import './App.css';
import Projects from './AllProjects';
import SingleProject from './GetSingleProject';
import FilteredProjects from './GetFilteredProjects';
import PostProject from './PostProject';
import DeleteProject from './DeleteProject';
import UpdateProject from './UpdateProject';

function App() {
  return (
    <div className="App">
      <h1 className='all-projects'>All projects: <i>GET</i></h1>
      <Projects />
      <h1 className='one-project'>Single project: <i>GETByID</i></h1>
      <SingleProject />
      <h1 className='filtered-project'>Filtered projects: <i>GET</i></h1>
      <FilteredProjects />
      <h1 className='post-project'>Post project: <i>POST</i></h1>
      <PostProject />
      <h1 className='delete-project'>Delete project: DELETE</h1>
      <DeleteProject />
      <h1 className='update-project'>Update project: UPDATE</h1>
      <UpdateProject />
    </div>
  );
}

export default App;
