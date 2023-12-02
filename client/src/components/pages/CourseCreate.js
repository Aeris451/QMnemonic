import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Form, Row, Col, Button } from 'react-bootstrap';
import './CourseCreate.css';

const CourseCreate = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [shortDescription, setShortDescription] = useState('');
  const [languageId, setLanguageId] = useState(1);

  useEffect(() => {
    axios.get('/api/courses/language').then((response) => {
      setLanguages(response.data.$values);
    });
  }, []);

  const [languages, setLanguages] = useState([]);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const course = {
      Name: name,
      Description: description,
      ShortDescription: shortDescription,
      LanguageId: languageId,
      AuthorId: 1,
    };

    try {
      const response = await axios.post('/api/courses/create', course);
      console.log(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="course-create">
      <h1>Create Course</h1>

      <Form onSubmit={handleSubmit}>
        <Row>
          <Col>
            <Form.Label>Course Name:</Form.Label>
            <Form.Control
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
              placeholder="Enter course name"
            />
          </Col>
        </Row>

        <Row>
          <Col>
            <Form.Label>Language:</Form.Label>
            <Form.Select
              value={languageId}
              onChange={(event) => setLanguageId(event.target.value)}
            >
              {languages.map((language) => (
                <option key={language.id} value={language.id}>
                  {language.languageName}
                </option>
              ))}
            </Form.Select>
          </Col>
        </Row>

        <Form.Group controlId="description">
          <Form.Label>Course Description:</Form.Label>
          <Form.Control
            as="textarea"
            rows={3}
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            placeholder="Provide a detailed description of the course"
          />
        </Form.Group>

        <Row>
          <Col>
            <Form.Label>Short Description:</Form.Label>
            <Form.Control
              type="text"
              value={shortDescription}
              onChange={(e) => setShortDescription(e.target.value)}
              placeholder="Enter a concise description of the course"
            />
          </Col>
        </Row>

        <Button className="add-button" type="submit" variant="primary">
          Submit
        </Button>
      </Form>
    </div>
  );
};

export default CourseCreate;