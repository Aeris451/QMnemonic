import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styled from 'styled-components';






const FormContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  width: 500px;
  margin: 0 auto;
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  
`;

const FormLabel = styled.label`
  margin-top: 13px;
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
  color: #333;
`;

const FormInput = styled.input`
  margin-top: 10px;
  margin-bottom: 10px;
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 14px;
  color: #333;

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const FormSelect = styled.select`
  margin-top: 3px;
  width: 40%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 14px;
  color: #333;

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const FormDescription = styled.textarea`
  margin-top: 3px;
  width: 100%;
  height: 100px;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 14px;
  color: #333;

  &:focus {
    outline: none;
    border-color: #007bff;
  }
`;

const FormButton = styled.button`
  margin-top: 7px;
  padding: 10px 20px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-weight: bold;

  &:hover {
    background-color: #0056b3;
  }
`;

const CourseForm = () => {



  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [shortDescription, setShortDescription] = useState('');
  const [languageId, setLanguageId] = useState(1);


  useEffect(() => {
    axios.get('/api/courses/language')
      .then((response) => {
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

        <form onSubmit={handleSubmit}> {/* Moved onSubmit here */}
    <FormContainer >
      <FormLabel>Name your course:</FormLabel>
      <FormInput
        type="text"
        value={name}
        onChange={(e) => setName(e.target.value)}
        placeholder="Name"
      />

      <FormLabel>Select language:</FormLabel>
      <FormSelect
        id="language"
        value={languageId}
        onChange={(event) => {
          setLanguageId(event.target.value);
        }}
      >
        {languages.map((language) => (
          <option key={language.id} value={language.id}>
            {language.languageName}
          </option>
        ))}
      </FormSelect>

      <FormLabel>Description:</FormLabel>
      <FormDescription
        type="text"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        placeholder="Description"
      />

      <FormLabel>Short Description:</FormLabel>
      <FormInput
        type="text"
        value={shortDescription}
        onChange={(e) => setShortDescription(e.target.value)}
        placeholder="Short Description"
      />

      
      </FormContainer>
      <FormButton type="submit">Submit</FormButton>
      </form>

  );
};

export default CourseForm;
