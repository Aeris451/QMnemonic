import logo from './logo.svg';
import './App.css';
import Navi from './components/navi.js'; 
import { Route, Routes } from 'react-router-dom';
import About from "./components/pages/about";
import Home from "./components/pages/home";


function App() {
  return (
    
    <div className="App">
      <Navi />

      <Routes>
        <Route path="/about" element={<About />}/>
        <Route path="/" element={<Home />}/>
      </Routes>

      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
