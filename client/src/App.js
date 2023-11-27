import logo from './logo.svg';
import './App.css';
import Navi from './components/navi.js'; 
import { Route, Routes } from 'react-router-dom';
import About from "./components/pages/about";
import Home from "./components/pages/home";
import Quiz from "./components/pages/FlashCardQuiz";
import CreateCourse from "./components/pages/CreateCourse";
import CoursesList from "./components/pages/CoursesList";
import CourseForm from './components/pages/CourseForm';
import QuizForm from './components/pages/QuizForm';
import ReadingForm from './components/pages/ReadingForm';

function App() {
  return (
    
    <div className="App">
      <Navi />

      <Routes>
        <Route path="/about" element={<About />}/>
        <Route path="/quiz" element={<Quiz />}/>
        <Route path="/createcourse" element={<CreateCourse />}/>
        <Route path="/courses" element={<CoursesList />}/>
        <Route path="/course" element={<CourseForm />}/>
        <Route path="/quiz" element={<QuizForm />}/>
        <Route path="/reading" element={<ReadingForm />}/>
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
