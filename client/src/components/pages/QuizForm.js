import React, { useState } from 'react';
import axios from 'axios';

const QuizForm = () => {
  const [quizTitle, setQuizTitle] = useState('');
  const [courseId, setCourseId] = useState('');

  const handleCreateQuiz = async () => {
    try {
      const response = await axios.post('api/courses/createquiz', {
        title: quizTitle,
        courseId: parseInt(courseId, 10),
      });

      console.log('Quiz created:', response.data);
    } catch (error) {
      console.error('Error creating quiz:', error);
    }
  };

  return (
    <div>
      <h2>Create Quiz</h2>
      <input
        type="text"
        placeholder="Quiz Title"
        value={quizTitle}
        onChange={(e) => setQuizTitle(e.target.value)}
      />
      <input
        type="text"
        placeholder="Course ID"
        value={courseId}
        onChange={(e) => setCourseId(e.target.value)}
      />
      <button onClick={handleCreateQuiz}>Create Quiz</button>
    </div>
  );
};

export default QuizForm;
