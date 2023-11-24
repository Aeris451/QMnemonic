import React from 'react';
import './about.css';

import React, { useState, useEffect } from 'react';

const CourseList = () => {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const response = await fetch('/api/course'); // Upewnij się, że ścieżka jest odpowiednia
        const data = await response.json();
        setCourses(data);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false);
      }
    };

    fetchCourses();
  }, []);

  return (
    <div>
      <h1>Course List</h1>
      {loading ? (
        <p>Loading...</p>
      ) : (
        <ul>
          {courses.map((course) => (
            <li key={course.id}>{course.name}</li>
            // Dodaj inne właściwości, jeśli są potrzebne
          ))}
        </ul>
      )}
    </div>
  );
};

export default CourseList;
