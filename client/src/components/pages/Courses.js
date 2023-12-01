import React, { useState, useEffect } from 'react';
import styled from 'styled-components';
import { useNavigate, useParams } from 'react-router-dom';

const CenteredContainer = styled.div`
margin: 30px 10px;
  display: flex;
  justify-content: center;
  align-items: center;
`;

const Container = styled.div`
  display: flex;
  width: 80%;
  flex-wrap: wrap; /* Allow flex items to wrap to the next line */
`;

const LanguageContainer = styled.div`
  flex: 1; /* Take up all available space in a row */
  min-width: 200px; /* Minimum width for the language list */
`;

const Title = styled.h2`
  margin-bottom: 15px;
`;

const LanguageList = styled.ul`
  list-style: none;
  padding: 0;
  margin: 0;
`;

const LanguageItem = styled.li`
  cursor: pointer;
  margin-bottom: 10px;
  
  border-radius: 10px;
  
  &:hover {
    background: rgb(220, 166, 17);
  }
`;

const CourseList = styled.ul`
  justify-content: center;
  display: flex;
  flex-wrap: wrap;
  padding: 0;
  margin: 0;
  flex: 3; 
`;

const CourseCard = styled.li`
  cursor: pointer;
  list-style: none;
  margin-right: 0px;
  margin-bottom: 10px;
  padding: 10px;
  border-radius: 20px;
  width: 220px; /* Fixed width for each course card */
  &:hover {
    background: rgb(220, 166, 17);
  }

  &.selected {
    border-color: #007bff;
  }
`;

const CourseImage = styled.img`
  width: 100%;
  height: 150px;
  object-fit: cover;
  border-radius: 10px;
`;

const CourseTitle = styled.h3`
  margin-top: 10px;
`;

const CourseDescription = styled.p`

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
    <CenteredContainer>
      <Container>
        <LanguageContainer>
          <Title>Select<br /> Language</Title>
          <LanguageList>
            {languages.map((language) => (
              <LanguageItem key={language.languageCode} onClick={() => handleLanguageClick(language.languageCode)}>
                {language.languageName}
              </LanguageItem>
            ))}
          </LanguageList>
        </LanguageContainer>
        <CourseList>
          {coursesData.$values && (
            <>
              {coursesData.$values.map((course) => (
                <CourseCard
                  key={course.courseId}
                  className={selectedCourseId === course.courseId ? 'selected' : ''}
                  onClick={() => handleCardClick(course.courseId)}
                >
                  <CourseImage src={course.imageUrl} alt={course.name} />
                  <CourseTitle>{course.name}</CourseTitle>
                  <CourseDescription>{course.shortDescription}</CourseDescription>
                </CourseCard>
              ))}
            </>
          )}
        </CourseList>
      </Container>
    </CenteredContainer>
  );
};

export default Courses; 