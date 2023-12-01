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
            <Nav.Link href="/courses/en">Courses</Nav.Link>
            <Nav.Link href="/createcourse">Create course</Nav.Link>
            <Nav.Link href="/createcourse">Profile</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    </>
  );
}

export default Navi;