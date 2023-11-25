// CourseDetails.js
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import QuizForm from './QuizForm';

const CourseDetails = () => {
  const { id } = useParams();
  const [course, setCourse] = useState(null);
  const [quizzes, setQuizzes] = useState([]);
  const [showQuizForm, setShowQuizForm] = useState(false);

  const fetchCourseDetails = async () => {
    try {
      const courseResponse = await fetch(`/api/course/${id}`);
      const courseData = await courseResponse.json();
      setCourse(courseData);

      const quizzesResponse = await fetch(`/api/course/${id}/quizzes`);
      const quizzesData = await quizzesResponse.json();
      setQuizzes(quizzesData);
    } catch (error) {
      console.error('Error fetching course details:', error);
    }
  };

  useEffect(() => {
    fetchCourseDetails();
  }, [id]);

  const handleCreateQuizClick = () => {
    setShowQuizForm(true);
  };

  return (
    <div>
      <h2>Course Details</h2>
      {course && (
        <div>
          <h3>{course.name}</h3>
          <p>Language: {course.language}</p>
          {/* Display other course details */}
        </div>
      )}

      {/* Render "Create Quiz" button */}
      <button onClick={handleCreateQuizClick}>Create Quiz</button>

      {/* Conditionally render QuizForm */}
      {showQuizForm && <QuizForm courseId={id} />}

      {/* Display quizzes */}
      <h3>Quizzes</h3>
      <ul>
        {quizzes.map((quiz) => (
          <li key={quiz.id}>{/* Display quiz details */}</li>
        ))}
      </ul>
    </div>
  );
};

export default CourseDetails;
