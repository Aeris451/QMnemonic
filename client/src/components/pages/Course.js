import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';


const CourseWrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  width: 80%;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
`;

const Title = styled.h1`
  text-align: center;
  font-size: 2rem;
  font-weight: bold;
  margin-bottom: 20px;
`;

const Description = styled.p`
  text-align: center;
  font-size: 1.2rem;
  line-height: 1.5;
  margin-bottom: 20px;
`;

const BoxContainer = styled.div`
  display: flex;
  flex-direction: column;
  width: 45%;
  margin-bottom: 20px;
`;

const Box = styled.div`
  background-color: #212121;
  color: #fff;
  border: 1px solid #444;
  margin-bottom: 10px;
  padding: 10px;
  cursor: pointer;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.5);
  transition: background-color 0.3s;

  &:hover {
    background-color: #333;
  }
`;

const BoxContent = styled.div`
  display: flex;
  flex-direction: column;
  align-items: flex-start;
`;

const BoxTitle = styled.h3`
  font-size: 1.5rem;
  font-weight: bold;
  margin-bottom: 5px;
`;

const BoxDescription = styled.p`
  font-size: 1rem;
  line-height: 1.5;
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
        <form onSubmit={handleNewQuiz}>
          <label>
            Name:
            <input type="text" value={newQuiz.name} onChange={e => setNewQuiz({ ...newQuiz, name: e.target.value })} />
          </label>
          <label>
            Description:
            <input type="text" value={newQuiz.description} onChange={e => setNewQuiz({ ...newQuiz, description: e.target.value })} />
          </label>
          <input type="submit" value="Create Quiz" />
        </form>
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
        <form onSubmit={handleNewReading}>
          <label>
            Name:
            <input type="text" value={newReading.name} onChange={e => setNewReading({ ...newReading, name: e.target.value })} />
          </label>
          <label>
            Description:
            <input type="text" value={newReading.description} onChange={e => setNewReading({ ...newReading, description: e.target.value })} />
          </label>
          <input type="submit" value="Create Reading" />
        </form>
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