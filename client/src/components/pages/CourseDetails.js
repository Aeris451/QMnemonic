import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

const CourseDetails = () => {
  const { id } = useParams();
  const [course, setCourse] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`/api/course/${id}`);
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setCourse(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, [id]);

  if (!course) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h2>Course Details</h2>
      <p>ID: {course.id}</p>
      <p>Name: {course.name}</p>
      <p>Language: {course.language}</p>
      {/* Render other details as needed */}
    </div>
  );
};

export default CourseDetails;
