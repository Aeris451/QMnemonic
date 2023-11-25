// QuizForm.js
import React, { useState } from 'react';

const QuizForm = ({ courseId, onQuizAdded }) => {
  const [quizData, setQuizData] = useState({
    // Definiuj pola formularza, np. question, answer, itp.
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setQuizData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch(`/api/course/${courseId}/quiz`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(quizData),
      });

      if (response.ok) {
        // Wywołaj funkcję, aby zaktualizować stan quizów w komponencie nadrzędnym
        onQuizAdded();
        // Możesz również wyczyścić formularz lub przejść do innej strony, itp.
      } else {
        console.error('Failed to add quiz');
      }
    } catch (error) {
      console.error('Error adding quiz:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      {/* Dodaj pola formularza */}
      <button type="submit">Add Quiz</button>
    </form>
  );
};

export default QuizForm;
