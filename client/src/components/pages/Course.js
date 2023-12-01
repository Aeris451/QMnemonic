import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import axios from 'axios';
import { useNavigate, useParams } from 'react-router-dom';
import { Card } from 'react-bootstrap';


const CourseContainer = styled.div`
  width: 80%;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
`;

const CourseDescription = styled.div`

font-size: 22px;
margin-bottom: 100px;


`;

const CourseTitle = styled.h1`
  font-size: 44px;
  font-weight: bold;
  margin-bottom: 20px;
`;

const QuizList = styled.ul`
  list-style: none;
  margin: 20px;
  display: flex;
  justify-content: center;
  padding: 0;
  flex-wrap: wrap;

`;

const QuizItem = styled(Card)`
  width: 100px;
  height: 110px;
  margin-bottom: 10px;
  padding: 10px;
  border-radius: 5px;
  margin: 10px;
  cursor: pointer;
  background-color: #fff;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: all 0.2s ease-in-out;
  background-color: #f0f0f0;

  &:hover {
    background: rgb(220, 166, 17);
    
  }
`;

const QuizTitle = styled.h3`
  font-size: 18px;
  margin-bottom: 5px;
`;

const ReadingList = styled(QuizList)``;

const ReadingItem = styled(QuizItem)``;

const AddButton = styled.button`
  background-color: #007bff;
  color: #fff;
  padding: 10px 20px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  margin: 30px;
`;

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

    <CourseContainer>
      <CourseTitle>{courseData.name}</CourseTitle>
      <CourseDescription>{courseData.description}</CourseDescription>

      <h2>Quizzes</h2>
      <AddButton onClick={() => navigate(`/courses/${id}/quizzes/add`)}>
        Add quiz
      </AddButton>
      <QuizList>
        {quizzes.map((quiz) => (
          <QuizItem key={quiz.id} onClick={() => navigate(`/courses/${id}/quizzes/${quiz.id}`)}>
            <QuizTitle>{quiz.name}</QuizTitle>
            <a>{quiz.description}</a>
          </QuizItem>
        ))}
      </QuizList>
      <h2>Readings</h2>
      <AddButton onClick={() => navigate(`/courses/${id}/readings/add`)}>
        Add reading
      </AddButton>
      <ReadingList>
        {readings.map((reading) => (
          <ReadingItem key={reading.id} onClick={() => navigate(`/courses/${id}/readings/${reading.id}`)}>
            <QuizTitle>{reading.name}</QuizTitle>
          </ReadingItem>
        ))}
      </ReadingList>
      <div>
      </div>
    </CourseContainer>
  );
};

export default Course;