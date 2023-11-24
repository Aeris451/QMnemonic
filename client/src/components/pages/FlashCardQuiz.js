import React, { useState } from 'react';
import './FlashCardQuiz.css';

const flashcardsData = [
  {
    question: '犬',
    answers: [
      { text: 'いぬ', isCorrect: true },
      { text: 'ねこ', isCorrect: false },
      { text: 'たぬき', isCorrect: false },
      { text: 'さる', isCorrect: false },
    ],
  },
  {
    question: '猫',
    answers: [
      { text: 'いぬ', isCorrect: false },
      { text: 'ねこ', isCorrect: true },
      { text: 'たぬき', isCorrect: false },
      { text: 'さる', isCorrect: false },
    ],
  },
];

function FlashcardQuiz() {
  const [currentCardIndex, setCurrentCardIndex] = useState(0);
  const [selectedAnswer, setSelectedAnswer] = useState(null);

  const handleAnswerSelection = (answer) => {
    setSelectedAnswer(answer);
  };

  const handleNextCard = () => {
    setSelectedAnswer(null);
    setCurrentCardIndex((prevIndex) => (prevIndex + 1) % flashcardsData.length);
  };

  const currentCard = flashcardsData[currentCardIndex];

  return (
    <div className="flashcard-container">
      <div className="flashcard">
        <h2 className="flashcard-question">{currentCard.question}</h2>
        <div className="flashcard-answers">
          {currentCard.answers.map((answer, index) => (
            <button
              key={index}
              className={`flashcard-answer ${selectedAnswer === answer ? (answer.isCorrect ? 'correct' : 'incorrect') : ''}`}
              onClick={() => handleAnswerSelection(answer)}
            >
              {answer.text}
            </button>
          ))}
        </div>
      </div>
      <div className="flashcard-buttons">
        <button className="next-card-button" onClick={handleNextCard}>
          Następna karta
        </button>
      </div>
    </div>
  );
}

export default FlashcardQuiz;
