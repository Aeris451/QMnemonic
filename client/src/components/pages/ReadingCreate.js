import React, { useState } from 'react';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { Button, Form, Container } from 'react-bootstrap';


const ReadingCreate = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const { courseId } = useParams();

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const quizData = {
                Name: name,
                Description: description,
                CourseId: parseInt(courseId),
            };
            await axios.post('/api/courses/createreading', quizData);
            window.location = `/course/${courseId}`;
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Container className="course-create">
            <h1>Create reading</h1>
            <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formQuizName" className="form-group">
                    <Form.Label className="form-label">Name:</Form.Label>
                    <Form.Control type="text" className="form-control" value={name} onChange={(e) => setName(e.target.value)} required />
                </Form.Group>
                <Form.Group controlId="formQuizDescription" className="form-group">
                    <Form.Label className="form-label">Description:</Form.Label>
                    <Form.Control as="textarea" className="form-control" value={description} onChange={(e) => setDescription(e.target.value)} required />
                </Form.Group>
                <Button variant="primary" type="submit" className="add-button">Submit</Button>
            </Form>
        </Container>
    );
};


export default ReadingCreate;
