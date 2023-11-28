import React, { useState } from 'react';
import axios from 'axios';

const AddQuestionToQuiz = () => {
  const [quizId, setQuizId] = useState('');
  const [sContent, setSContent] = useState('');
  const [content, setContent] = useState('');
  const [annotations, setAnnotations] = useState('');
  const [answerContent, setAnswerContent] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();

    const data = {
      quizId,
      sContent,
      content,
      annotations,
      answerContent,
    };

    try {
      await axios.post('/api/quiz', data);
      alert('Question added successfully!');
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>Quiz ID:</label>
      <input type="number" value={quizId} onChange={(event) => setQuizId(event.target.value)} />

      <label>SContent:</label>
      <input type="text" value={sContent} onChange={(event) => setSContent(event.target.value)} />

      <label>Content:</label>
      <input type="text" value={content} onChange={(event) => setContent(event.target.value)} />

      <label>Annotations:</label>
      <input type="text" value={annotations} onChange={(event) => setAnnotations(event.target.value)} />

      <label>Answer Content:</label>
      <input type="text" value={answerContent} onChange={(event) => setAnswerContent(event.target.value)} />

      <button type="submit">Add Question</button>
    </form>
  );
};

export default AddQuestionToQuiz;