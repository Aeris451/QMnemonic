import React, { useState } from 'react';

const CreateCourseComponent = () => {
  const [name, setName] = useState('');
  const [language, setLanguage] = useState('');
  const [createdCourseId, setCreatedCourseId] = useState(null);

  const handleCreateCourse = async () => {
    try {
      const response = await fetch('/api/Course', { // Używamy '/api' jako prefiksu, który został skonfigurowany w setupProxy.js
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          name: name,
          language: language,
          // Dodaj inne właściwości, które są wymagane przez CreateCourseCommand
        }),
      });

      if (response.ok) {
        const result = await response.json();
        setCreatedCourseId(result.courseId);
      } else {
        console.error('Błąd podczas tworzenia kursu:', response.statusText);
      }
    } catch (error) {
      console.error('Błąd podczas komunikacji z API:', error);
    }
  };

  return (
    <div>
      <h2>Utwórz nowy kurs</h2>
      <label>
        Nazwa kursu:
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </label>
      <label>
        Język kursu:
        <input
          type="text"
          value={language}
          onChange={(e) => setLanguage(e.target.value)}
        />
      </label>
      <button onClick={handleCreateCourse}>Utwórz kurs</button>
      {createdCourseId && (
        <p>Utworzono nowy kurs! Id: {createdCourseId}</p>
      )}
    </div>
  );
};

export default CreateCourseComponent;
