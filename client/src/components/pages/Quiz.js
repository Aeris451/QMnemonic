import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { Container, Row, Col, Button, Form } from 'react-bootstrap';
import DataGrid, { textEditor } from 'react-data-grid';
import 'react-data-grid/lib/styles.css';

const Quiz = () => {
  const { courseid, order } = useParams();
  const [quizData, setQuizData] = useState(null);
  const [rows, setRows] = useState([]);

  const fetchData = async () => {
    try {
      const result = await axios(`/api/quiz/${courseid}/${order}`);
      if (result.status === 200) {
        setQuizData(result.data);
      }
    } catch (error) {
      console.error('Error fetching quiz data:', error);
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const question = { quizId: quizData.id };
    try {
      const response = await axios.post('/api/quiz', question);
      console.log(response.data);
      fetchData();
    } catch (error) {
      console.error(error);
    }
  };

  const handleRowsChange = (newRows) => {
    setRows(newRows);
  };

  useEffect(() => {
    fetchData();
  }, [courseid]);

  useEffect(() => {
    if (quizData) {
      const questions = quizData.questions.$values;
      const initialRows = questions.map((question) => ({
        id: question.id,
        questionContent: question.content,
        answerContent: question.answer.content,
        selectableContent: question.sContent,
      }));
      setRows(initialRows);
    }
  }, [quizData]);

  if (!quizData) {
    return <div>Loading...</div>;
  }

  const columns = [
    { key: 'id', name: 'ID', header: 'ID' },
    { key: 'questionContent', name: 'Question Content', header: 'Question Content', renderEditCell: textEditor },
    { key: 'answerContent', name: 'Answer Content', header: 'Answer Content', renderEditCell: textEditor },
    {
      key: 'selectableContent',
      name: 'Selectable Content',
      header: 'Selectable Content',
      editor: (props) => (
        <select
          value={props.row.selectableContent}
          onChange={(event) => {
            props.onRowChange({ ...props.row, selectableContent: event.target.value });
          }}
        >
          {quizData.selectableContent.map((string) => (
            <option key={string} value={string}>
              {string}
            </option>
          ))}
        </select>
      ),
    },
  ];

  return (
    <Container fluid>
      <Row className="course-info">
        <Col>
          <h1 className="course-title">{quizData.name}</h1>
          <p className="course-description">{quizData.description}</p>
        </Col>
      </Row>
      <Container>
        <Row className="grid-row">
          <DataGrid columns={columns} rows={rows} onRowsChange={handleRowsChange} />
          <Form onSubmit={handleSubmit}>
            <Button className="add-button" type="submit" variant="primary">
              Add new question
            </Button>
          </Form>
        </Row>
      </Container>
    </Container>
  );
};

export default Quiz;
