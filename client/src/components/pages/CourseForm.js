import React, { useState } from 'react';
import axios from 'axios';
import styled from 'styled-components';

const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f2f2f2;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
`;

const Input = styled.input`
  width: 50%;
  padding: 10px;
  margin-bottom: 10px;
  border: none;
  outline: none;
  border-radius: 10px;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: background-color 0.3s;

  &:focus {
    background-color: #e6e6e6;
  }
`;

const Button = styled.button`
  padding: 10px 20px;
  border: none;
  outline: none;
  border-radius: 10px;
  background-color: #007bff;
  color: #fff;
  font-weight: bold;
  cursor: pointer;
  transition: background-color 0.3s;

  &:hover {
    background-color: #0056b3;
  }
`;

const Description = styled.textarea`
  width: 50%;
  height: 200px;
  padding: 10px;
  margin-bottom: 10px;
  border: none;
  outline: none;
  border-radius: 10px;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: background-color 0.3s;

  &:focus {
    background-color: #e6e6e6;
  }
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
            <Description
                type="text"
                value={description}
                onChange={e => setDescription(e.target.value)}
                placeholder="Description"
            />
            <Input type="text" value={shortDescription} onChange={e => setShortDescription(e.target.value)} placeholder="Short Description" />
            <Input type="number" value={languageId} onChange={e => setLanguageId(e.target.value)} placeholder="Language ID" />
            <Button type="submit">Submit</Button>
        </Form>
    );
};

export default CourseForm;
