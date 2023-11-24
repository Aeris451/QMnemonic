import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import './navi.css';



function Navi() {

  return (
    <>
      <Navbar className="navbar-shadow" bg="dark" data-bs-theme="dark" sticky="top" >
        <Container>
          <Navbar.Brand href="/">Quick<br />Mnemonic</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link href="/about">About</Nav.Link>
            <Nav.Link href="/createcourse">Course create</Nav.Link>
            <Nav.Link href="/courses">Courses</Nav.Link>
            <Nav.Link href="/schools">Schools</Nav.Link>
            <Nav.Link href="/profile">Profile</Nav.Link>
            <Nav.Link href="/pricing">Pricing</Nav.Link>
            <Nav.Link href="/quiz">Quiz</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    </>
  );
}

export default Navi;