import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';
import { Card, Container, Button, Row, Col } from 'react-bootstrap';
import './Course.css'; // Import the CSS file

const Course = () => {
  const { id } = useParams();
  const [courseData, setCourseData] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios(`/api/courses/${id}`);
      setCourseData(result.data);
    };

    fetchData();
  }, [id]);

  if (!courseData) {
    return <div>Loading...</div>;
  }

  const quizzes = courseData.quizzes.$values;
  const readings = courseData.readings.$values;

  return (
    <Container className="course-container">
      <Row className="justify-content-md-center">
        <Col md="auto">

          <Container fluid className="course-info">
          <h1 className="course-title">{courseData.name}</h1>
          <p className="course-description">{courseData.description}</p>
          </Container>
          <h2>Quizzes
          <Button className="add-button" onClick={() => navigate(`/courses/${id}/quizzes/add`)}>Add quiz</Button></h2>
          <Row>
            {quizzes.map((quiz) => (
              <Col sm={4} md={3} lg={2} key={quiz.id} onClick={() => navigate(`/courses/${id}/quizzes/${quiz.id}`)}>
                <Card className="quiz-card">
                  <Card.Body>
                    <Card.Title>{quiz.name}</Card.Title>
                    <Card.Text>{quiz.description}</Card.Text>
                  </Card.Body>
                </Card>
              </Col>
            ))}
          </Row>

          <h2>Readings
          <Button className="add-button" onClick={() => navigate(`/courses/${id}/readings/add`)}>Add reading</Button></h2>
          <Row>
            {readings.map((reading) => (
              <Col sm={4} md={3} lg={2} key={reading.id} onClick={() => navigate(`/courses/${id}/readings/${reading.id}`)}>
                <Card className="reading-card">
                  <Card.Body>
                    <Card.Title>{reading.name}</Card.Title>
                  </Card.Body>
                </Card>
              </Col>
            ))}
          </Row>
        </Col>
      </Row>
    </Container>
  );
};

export default Course;
