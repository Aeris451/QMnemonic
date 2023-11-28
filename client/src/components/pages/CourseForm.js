import React, { useState } from 'react';
import axios from 'axios';
import styled from 'styled-components';

const Form = styled.form`
    /* Dodaj tutaj swoje style */
`;

const Input = styled.input`
    /* Dodaj tutaj swoje style */
`;

const Button = styled.button`
    /* Dodaj tutaj swoje style */
`;

const CourseForm = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [shortDescription, setShortDescription] = useState('');
    const [languageId, setLanguageId] = useState(0);

    const handleSubmit = async (event) => {
        event.preventDefault();

        const course = {
            Name: name,
            Description: description,
            ShortDescription: shortDescription,
            LanguageId: languageId,
            AuthorId: 1
        };

        try {
            const response = await axios.post('/api/courses/create', course);
            console.log(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Input type="text" value={name} onChange={e => setName(e.target.value)} placeholder="Name" />
            <Input type="text" value={description} onChange={e => setDescription(e.target.value)} placeholder="Description" />
            <Input type="text" value={shortDescription} onChange={e => setShortDescription(e.target.value)} placeholder="Short Description" />
            <Input type="number" value={languageId} onChange={e => setLanguageId(e.target.value)} placeholder="Language ID" />
            <Button type="submit">Submit</Button>
        </Form>
    );
};

export default CourseForm;
