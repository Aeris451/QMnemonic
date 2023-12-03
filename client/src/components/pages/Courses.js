import React from 'react';
import { Card, Col, Container, Row } from 'react-bootstrap';
import { useNavigate, useParams } from 'react-router-dom';
import './Courses.css';

const Courses = () => {
  const { langCode } = useParams();
  const [coursesData, setCoursesData] = React.useState([]);
  const [selectedCourseId, setSelectedCourseId] = React.useState(null);
  const navigate = useNavigate();
  const [languages, setLanguages] = React.useState([]);
  const [page, setPage] = React.useState(1); 

  const fetchCourses = async (page) => {
    const response = await fetch(`/api/courses`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ languageCode: langCode, page: page })
    });
    const data = await response.json();
    setCoursesData(prevCourses => [...prevCourses, ...(data.$values || [])]); 
  };

  React.useEffect(() => {
    fetchCourses(page);
  }, [langCode, page]); 

  React.useEffect(() => {
    const handleScroll = () => {
      if (window.innerHeight + window.scrollY >= document.body.offsetHeight) {
        setPage(prevPage => prevPage + 1); 
      }
    };

    window.addEventListener('scroll', handleScroll);
    return () => window.removeEventListener('scroll', handleScroll);
  }, []);

  React.useEffect(() => {
    fetch('/api/courses/language')
      .then((response) => response.json())
      .then((data) => setLanguages(data.$values || [])); 
  }, []);

  const handleCardClick = (courseId) => {
    setSelectedCourseId(courseId);
    navigate(`/course/${courseId}`);
  };

  const handleLanguageClick = (languageCode) => {
    if (languageCode !== langCode) {
      setCoursesData([]); 
      setPage(1); 
      navigate(`/courses/${languageCode}`);
    }
  };

  return (
    <Container>
      <Row>
        <Col md={3}>
          <Card className="mb-3">
            <Card.Header>Select Language</Card.Header>
            <Card.Body>
              <ul style={{ listStyle: 'none', padding: 0, margin: 0 }}>
                {languages.map((language) => (
                  <li
                    key={language.languageCode}
                    style={{ cursor: 'pointer', marginBottom: 10 }}
                    onClick={() => handleLanguageClick(language.languageCode)}
                  >
                    {language.languageName}
                  </li>
                ))}
              </ul>
            </Card.Body>
          </Card>
        </Col>
        <Col md={9}>
          <Row>
            {coursesData && (
              <>
                {coursesData.map((course) => (
                  <Col key={course.courseId} md={4}>
                    <Card
                      className={selectedCourseId === course.courseId ? 'selected' : ''}
                      onClick={() => handleCardClick(course.courseId)}
                    >
                      <Card.Img variant="top" src={course.imageUrl} alt={course.name} />
                      <Card.Body>
                        <Card.Title>{course.name}</Card.Title>
                        <Card.Text>{course.shortDescription}</Card.Text>
                      </Card.Body>
                    </Card>
                  </Col>
                ))}
              </>
            )}
          </Row>
          <Row>
          </Row>
        </Col>
      </Row>
    </Container>
  );
};

export default Courses;
