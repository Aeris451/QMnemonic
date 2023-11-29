import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';

const CourseWrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
  background-color: #f2f2f2;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
`;

const Title = styled.h1`
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 20px;
  color: #333;
`;

const Description = styled.p`
  font-size: 16px;
  line-height: 1.5;
  margin-bottom: 20px;
  color: #333;
`;

const BoxContainer = styled.div`
  width: 400px;
  margin-bottom: 20px;
  background-color: #fff;

  padding: 20px;
  border-radius: 10px;
  color: #333;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
`;

const Box = styled.div`
  cursor: pointer;
  padding: 10px;
  border-bottom: 1px solid #ccc;
  border-radius: 10px;

  &:hover {
    background: rgb(220, 166, 17);
  }
`;

const Form = styled.form`
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Input = styled.input`
  width: 100%;
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

const Course = () => {
  const { id } = useParams();
  const [courseData, setCourseData] = useState(null);
  const navigate = useNavigate();

  const [newQuiz, setNewQuiz] = useState({ name: '', description: '', courseId: id });
  const [newReading, setNewReading] = useState({ name: '', description: '', courseId: id });

  const handleNewQuiz = async (e) => {
    e.preventDefault();
    const result = await axios.post('/api/courses/createquiz', newQuiz);
    if (result.status === 200) {
      navigate(`/course/${id}/quiz/${result.data.quizId}`);
    }
  };

  const handleNewReading = async (e) => {
    e.preventDefault();
    const result = await axios.post('/api/courses/createreading', newReading);
    if (result.status === 200) {
      navigate(`/course/${id}/reading/${result.data.readingId}`);
    }
  };

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

  return (
    <CourseWrapper>
      <Title>{courseData.name}</Title>
      <Description>{courseData.description}</Description>

      <BoxContainer>
        <h2>Create a New Quiz</h2>
        <Form onSubmit={handleNewQuiz}>
          <Input
            type="text"
            value={newQuiz.name}
            onChange={(e) => setNewQuiz({ ...newQuiz, name: e.target.value })}
          />
          <Input
            type="text"
            value={newQuiz.description}
            onChange={(e) => setNewQuiz({ ...newQuiz, description: e.target.value })}
          />
          <Button type="submit">Create Quiz</Button>
        </Form>

        <h2>Quizzes</h2>
        {courseData.quizzes.$values.map((quiz, index) => (
          <Box key={index} onClick={() => navigate(`quiz/${quiz.quizId}`)}>
            <h3>{quiz.name}</h3>
            <p>{quiz.description}</p>
          </Box>
        ))}
      </BoxContainer>

      <BoxContainer>
        <h2>Create a New Reading</h2>
        <Form onSubmit={handleNewReading}>
          <Input
            type="text"
            value={newReading.name}
            onChange={(e) => setNewReading({ ...newReading, name: e.target.value })}
          />
          <Input
            type="text"
            value={newReading.description}
            onChange={(e) => setNewReading({ ...newReading, description: e.target.value })}
          />
          <Button type="submit">Create Reading</Button>
        </Form>

        <h2>Readings</h2>
        {courseData.readings.$values.map((reading, index) => (
          <Box key={index} onClick={() => navigate(`reading/${reading.readingId}`)}>
            <h3>{reading.name}</h3>
            <p>{reading.description}</p>
          </Box>
        ))}
      </BoxContainer>
    </CourseWrapper>
  );
};

export default Course;