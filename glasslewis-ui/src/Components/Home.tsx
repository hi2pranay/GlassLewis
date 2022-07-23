import React, { useEffect, useState } from "react";
import "./home.css";
import jwt_decode from "jwt-decode";
import { Navbar, Form, Button, ButtonGroup, Row, Col, Nav } from 'react-bootstrap'
import { Link } from "react-router-dom";
import CompanyComponent from '../Components/CompanyComponent';
import { useNavigate } from "react-router-dom";

const Home = () => 
{
    const navigate = useNavigate();

    const [Email, setEmail] = useState('');

  const logout = () => {
    localStorage.clear();
    navigate("/");
  };

  useEffect(() => 
  {
    debugger;
    var isExpired = false;
    const token = localStorage.getItem("auth");
    if(token != null)
    {
        var decodedToken:any = jwt_decode(token);
        var dateNow = new Date();

        if(decodedToken.exp * 1000 < dateNow.getTime())
        {
            isExpired = true;

            localStorage.clear();
            navigate("/");
        }
        else
        {
            setEmail(decodedToken.Email);
            //navigate("/home");
        }
    }
    else
    {
        navigate("/");
    }
  }, []);

  const authButton = () => 
  {
        if (Email === '') {
            return (
                <ButtonGroup>
                    <Button variant="secondary">Login</Button>
                </ButtonGroup>
            )
                
        } 
        else 
        {
            return (
            <>
                <Row>
                    <Col><p className="muted">Hello {Email}👋</p></Col>
                    <Col md="auto"><button type="submit" className="buttons" onClick={logout}> Logout </button></Col>
                </Row>
                
                
            </>)
        }
    }

  return (
    <>
        <Navbar collapseOnSelect expand="sm" bg="light" variant="light" className="mb-3">
            <Navbar.Brand as={Link} to="/" className="mx-3">Glass Lewis</Navbar.Brand>
            <Navbar.Toggle aria-controls="responsive-navbar-nav" />
            <Navbar.Collapse id="responsive-navbar-nav">
                <Nav className="mr-auto">
                    <Nav.Link as={Link} to="/home">Company</Nav.Link>
                </Nav>
            </Navbar.Collapse>
            <Form className="mx-3">
                
                {authButton()}
            </Form>
        </Navbar>
      <div style={{ display: "flex", justifyContent: "space-between", paddingLeft: 50, paddingRight: 50 }}>
      </div>
      <div className="container">
        <div className="row d-flex justify-content-center align-items-center text-center">
          <CompanyComponent></CompanyComponent>
        </div>
      </div>
    </>
  );
};

export default Home;