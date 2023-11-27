import React, { useState } from 'react';
import axios from 'axios';

const CourseForm = () => {
  const [courseName, setCourseName] = useState('');
  const [languageId, setLanguageId] = useState('');
  const [description, setDescription] = useState('');
  const [shortDescription, setShortDescription] = useState('');

  const handleCreateCourse = async () => {
    try {
      const response = await axios.post('api/courses/create', {
        name: courseName,
        languageId: parseInt(languageId, 10),
        description,
        shortDescription,
      });

      console.log('Course created:', response.data);
    } catch (error) {
      console.error('Error creating course:', error);
    }
  };

  return (
    <div>
      <h2>Create Course</h2>
      <div>
        <label>Course Name:</label>
        <input
          type="text"
          value={courseName}
          onChange={(e) => setCourseName(e.target.value)}
        />
      </div>
      <div>
        <label>Language ID:</label>
        <input
          type="text"
          value={languageId}
          onChange={(e) => setLanguageId(e.target.value)}
        />
      </div>
      <div>
        <label>Description:</label>
        <textarea
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
      </div>
      <div>
        <label>Short Description:</label>
        <textarea
          value={shortDescription}
          onChange={(e) => setShortDescription(e.target.value)}
        />
      </div>
      <button onClick={handleCreateCourse}>Create Course</button>
    </div>
  );
};

export default CourseForm;
