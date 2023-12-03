import './App.css';
import Navi from './components/navi.js'; 
import { Route, Routes } from 'react-router-dom';
import About from "./components/pages/about";
import Home from "./components/pages/home";
import AddQuestionToQuiz from "./components/pages/AddQuestionToQuiz";
import Courses from "./components/pages/Courses";
import Course from "./components/pages/Course";
import CourseCreate from './components/pages/CourseCreate.js';
import QuizCreate from './components/pages/QuizCreate.js';
import ReadingCreate from './components/pages/ReadingCreate.js';



function App() {


  return (
    
    <div className="App">
      <Navi />
      <Routes>
        <Route path="/about" element={<About />}/>
        <Route path="/addQuestion" element={<AddQuestionToQuiz />}/>
        <Route path="/courses/:langCode" element={<Courses />} />
        <Route path="/course/:id" element={<Course />} />
        <Route path="/createcourse" element={<CourseCreate />} />
        <Route path="/courses/:courseId/quizzes/add" element={<QuizCreate />} />
        <Route path="/courses/:courseId/readings/add" element={<ReadingCreate />} />
        <Route path="/" element={<Home />}/>
      </Routes>
    </div>
  );
}

export default App;
