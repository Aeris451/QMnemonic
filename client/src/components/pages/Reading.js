import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { Card, Container, Button, Row, Col } from 'react-bootstrap';

const Reading = () => {

  const id = UseParams();
  const [quizData, setQuizData] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios(`/api/reading/${id}`);
      setCourseData(result.data);
    };

    fetchData();
  }, [id]);


  if (!quizData) {
    return <div>Loading...</div>;
  }
};




export default Reading;
