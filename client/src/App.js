import logo from './logo.svg';
import './App.css';
import Navi from './components/navi.js'; 
import { Route, Routes } from 'react-router-dom';
import About from "./components/pages/about";
import Home from "./components/pages/home";
import AddQuestionToQuiz from "./components/pages/AddQuestionToQuiz";
import Courses from "./components/pages/Courses";
import Course from "./components/pages/Course";
import CourseForm from "./components/pages/CourseForm";



function App() {


  return (
    
    <div className="App">
      <Navi />
      <Routes>
        <Route path="/about" element={<About />}/>
        <Route path="/addQuestion" element={<AddQuestionToQuiz />}/>
        <Route path="/courses/:langCode" element={<Courses />} />
        <Route path="/course/:id" element={<Course />} />
        <Route path="/createcourse" element={<CourseForm />} />
        <Route path="/" element={<Home />}/>
      </Routes>
    </div>
  );
}

export default App;
