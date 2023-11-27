import React, { useState } from 'react';
import axios from 'axios';

const ReadingForm = () => {
  const [readingText, setReadingText] = useState('');
  const [courseId, setCourseId] = useState('');

  const handleCreateReading = async () => {
    try {
      const response = await axios.post('api/courses/createreading', {
        text: readingText,
        courseId: parseInt(courseId, 10),
      });

      console.log('Reading created:', response.data);
    } catch (error) {
      console.error('Error creating reading:', error);
    }
  };

  return (
    <div>
      <h2>Create Reading</h2>
      <textarea
        placeholder="Reading Text"
        value={readingText}
        onChange={(e) => setReadingText(e.target.value)}
      />
      <input
        type="text"
        placeholder="Course ID"
        value={courseId}
        onChange={(e) => setCourseId(e.target.value)}
      />
      <button onClick={handleCreateReading}>Create Reading</button>
    </div>
  );
};

export default ReadingForm;
