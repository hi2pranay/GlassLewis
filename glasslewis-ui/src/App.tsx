import React from 'react';
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import Login from "./Components/Login";
import Home from "./Components/Home";
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import CompanyComponent from './Components/CompanyComponent';

const App = () => 
{
  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Login/>}/>
          <Route path="/home" element={<Home/>}/>
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
