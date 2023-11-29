import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { useNavigate, useParams } from 'react-router-dom';
import './Courses.css';

const CourseCard = styled.div`

  padding: 10px;
  margin: 10px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  cursor: pointer;
  transition: background-color 0.3s;
  font-size: 14px;
  color: #333;

  &:hover {
    background: rgb(220, 166, 17);
  }

  &.selected {
    background: rgb(220, 166, 17);
  }
`;

const LanguageList = styled.ul`
  list-style-type: none;
  padding: 0;
  margin: 0 20px 0;

  border-radius: 8px;
  font-size: 14px;
  color: #333;
`;

const LanguageItem = styled.li`
  cursor: pointer;
  padding: 15px;
  border-bottom: 1px solid #ccc;
  border-radius: 10px;

  &:hover {
    background: rgb(220, 166, 17);
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
      <div style={{ margin: '0 10px' }}>
        <h2>Select<br /> Language</h2>
        <LanguageList>
          {languages.map((language) => (
            <LanguageItem key={language.languageCode} onClick={() => handleLanguageClick(language.languageCode)}>
              {language.languageName}
            </LanguageItem>
          ))}
        </LanguageList>
      </div>
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
                <img src={course.imageUrl} alt={course.name} style={{ width: '220px', height: '150px', objectFit: 'cover', borderRadius: '10px' }} />
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