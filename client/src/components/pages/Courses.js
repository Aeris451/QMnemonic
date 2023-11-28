import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { useNavigate, useParams } from 'react-router-dom';

const CourseCard = styled.div`
  border: 1px solid #ccc;
  padding: 10px;
  margin: 10px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  cursor: pointer;
  transition: background-color 0.3s;

  &:hover {
    background-color: #f0f0f0;
  }

  &.selected {
    background-color: #d3e0ea;
  }
  width: 250px;
`;

const LanguageList = styled.ul`
  list-style-type: none;
  padding: 0;
  width: 200px;
`;

const LanguageItem = styled.li`
  cursor: pointer;
  padding: 10px;
  border-bottom: 1px solid #ccc;

  &:hover {
    background-color: #f0f0f0;
  }
`;

const Courses = () => {
  const { langCode } = useParams(); // Extract the langCode from the URL
  const [coursesData, setCoursesData] = useState({});
  const [selectedCourseId, setSelectedCourseId] = useState(null);
  const navigate = useNavigate();
  const [languages, setLanguages] = useState([]);

  useEffect(() => {
    fetch(`/api/courses/language/${langCode}`) // Use the dynamic langCode
      .then((response) => response.json())
      .then((data) => setCoursesData(data));
  }, [langCode]); // Add langCode to the dependency array

  useEffect(() => {
    fetch('/api/courses/language')
      .then((response) => response.json())
      .then((data) => setLanguages(data.$values)); // Use data.$values here
  }, []);
  

  const handleCardClick = (courseId) => {
    setSelectedCourseId(courseId);
    navigate(`/course/${courseId}`);
  };

  const handleLanguageClick = (languageCode) => {
    navigate(`/courses/${languageCode}`);
  };

  return (
    <div style={{ display: 'flex' }}>
      <LanguageList>
        {languages.map((language) => (
          <LanguageItem key={language.languageCode} onClick={() => handleLanguageClick(language.languageCode)}>
            {language.languageName}
          </LanguageItem>
        ))}
      </LanguageList>
      <div>
        {coursesData.$values && (
          <ul
            style={{
              display: 'flex',
              flexWrap: 'wrap',
            }}
          >
            {coursesData.$values.map((course) => (
              <CourseCard
                key={course.courseId}
                className={selectedCourseId === course.courseId ? 'selected' : ''}
                onClick={() => handleCardClick(course.courseId)}
              >
                <h3>{course.name}</h3>
                <p>{course.shortDescription}</p>
              </CourseCard>
            ))}
          </ul>
        )}
      </div>
    </div>
  );
};

export default Courses;
