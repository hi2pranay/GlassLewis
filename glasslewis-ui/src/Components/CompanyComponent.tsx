import React from 'react'
import axios from "axios";
import { useState, useEffect } from "react";
import Table from 'react-bootstrap/Table'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import {Button, Form, Modal} from 'react-bootstrap';
import {Company} from '../Models/Company'
import { toast } from 'react-toastify';
import { useNavigate } from "react-router-dom";

type CompanyResponse = 
{
    data: Company[];
};

const CompanyComponent = () => 
{
  const navigate = useNavigate();
  
    const [show, setShow] = useState(false);

    const [jwtToken, setJwtToken] = useState('');
    const [id, setId] = useState('');
    const [Name, setName] = useState('');
    const [Exchange, setExchange] = useState('');
    const [Ticker, setTicker] = useState('');
    const [ISIN, setISIN] = useState('');
    const [Website, setWebsite] = useState('');

    const [editItem, setEditItem] = useState(false);
     
    const [items, setItems] = useState<Company[]>([]);

    const [CompanyById, setCompanyById] = useState('');
    const [CompanyName, setCompanyName] = useState('');

    const [CompanyByISIN, setCompanyByISIN] = useState('');
    const [CompanyByISINCompanyName, setCompanyByISINCompanyName] = useState('');

    const apiEndPoint:string = process.env.REACT_APP_API_URL || 'https://localhost:7008';
    
    useEffect(() => 
    {
      const token:any = localStorage.getItem("auth");      

      if(token != null)
      {
        setJwtToken(token);
        
        getItems(token);
      }
    }, []);
    
    const getItems = async (token:string) => 
    {
      debugger;
        try
        {
          let allCompaniesApiEndpoint = apiEndPoint + '/api/v1/glasslewis/Company/GetAllCompanies';
          const todoResult:any = await axios.get<CompanyResponse>(allCompaniesApiEndpoint,
                                      {
                                          headers: {
                                              Accept: 'application/json',
                                              "Authorization" : `Bearer ${token}`
                                          },
                                      });
          setItems(todoResult.data);
        }  
        catch(err:any)
        {
            console.log("Err: ", err);

            if(err.message === "Request failed with status code 401")
            {
              navigate("/");
            }
        }        
    };
    
    const SubmitOnClick = async (e: { preventDefault: () => void; }) => 
    {
      // eslint-disable-next-line no-debugger
      debugger;
      e.preventDefault();
  
      if(editItem === true)
      {
        const company = {
                            "id": id,
                            "name": Name,
                            "exchange": Exchange,
                            "ticker": Ticker,
                            "isin": ISIN,
                            "website": Website
                        };
        
        try
        {
          let updateApiEndPoint = apiEndPoint + '/api/v1/glasslewis/Company/UpdateCompany';
          await axios.put(updateApiEndPoint, company ,{
                                                      headers: {
                                                          Accept: 'application/json',
                                                          "Authorization" : `Bearer ${jwtToken}`
                                                      },
                                                  });     
                                                  
          toast.success('item added successfully', 
          {
            position: "top-right",
            autoClose: 3000,
            hideProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: false,
            progress: 0,
            toastId: "my_toast",
          });
        }
        catch(err:any)
        {        
          console.log("Err: ", err);

          toast.error(err.message, {
            position: "top-right",
            autoClose: 3000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
          });

          if(err.message === "Request failed with status code 401")
          {
            navigate("/");
          }
        }
  
      }
      else
      {
        const company = {
            "name": Name,
            "exchange": Exchange,
            "ticker": Ticker,
            "isin": ISIN,
            "website": Website
        };
        
        try
        {
          let addApiEndPoint = apiEndPoint + '/api/v1/glasslewis/Company/CreateCompany';
          await axios.post(addApiEndPoint, company,{
                                                headers: {
                                                    Accept: 'application/json',
                                                    "Authorization" : `Bearer ${jwtToken}`
                                                },
                                            });

          toast.success('item added successfully', 
          {
            position: "top-right",
            autoClose: 3000,
            hideProgressBar: true,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: false,
            progress: 0,
            toastId: "my_toast",
          });
        }
        catch(err:any)
        {       
          debugger;
          console.log("Err: ", err);

          toast.error(err.message, {
            position: "top-right",
            autoClose: 3000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            });

            if(err.message === "Request failed with status code 401")
            {
              navigate("/");
            }
        }
      }
  
      handleClose();
      getItems(jwtToken);          
    };
  
    const showModal = async () => 
    {
      setShow(true);
    };
  
    const showEditModal = async (item: Company) => 
    {    
      // eslint-disable-next-line no-debugger
      debugger;
      setShow(true);
      setEditItem(true);
  
      setId(item.id);
      setName(item.name);
      setExchange(item.exchange);    
      setTicker(item.ticker);
      setISIN(item.isin);
      setWebsite(item.website);
    }
  
    const NameOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {   
      setName(event.target.value);
    };
  
    const ExchangeOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {
      setExchange(event.target.value);
    }; 
  
    const TickerOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {
      setTicker(event.target.value);
    }; 

    const ISINOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {
      setISIN(event.target.value);
    }; 

    const WebsiteOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {
      setWebsite(event.target.value);
    }; 
    
    const CompanyByIdOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {
      debugger;
      setCompanyById(event.target.value);
    }; 

    
    const CompanyByISINOnChange = (event: { target: { value: React.SetStateAction<string>; }; }) => 
    {
      debugger;
      setCompanyByISIN(event.target.value);
    }; 

    const CompanyByIdOnClick = async (e: { preventDefault: () => void; }) =>
    {
      debugger;
      e.preventDefault();
      try
      {
        if(CompanyById !== "")
        {
          let CompanyByIdApiEndpoint = apiEndPoint + '/api/v1/glasslewis/Company/GetCompanyById/'+CompanyById;
          const results:any = await axios.get(CompanyByIdApiEndpoint,
                                              {
                                                  headers: {
                                                      Accept: 'application/json',
                                                      "Authorization" : `Bearer ${jwtToken}`
                                                  },
                                              });
          setCompanyName(results.data);
        }
      }  
      catch(err:any)
      {
          console.log("Err: ", err);

          if(err.message === "Request failed with status code 401")
          {
            navigate("/");
          }
      }    
    }

    const CompanyByISINOnClick = async (e: { preventDefault: () => void; }) =>
    {
      debugger;
      e.preventDefault();
      try
      {
        if(CompanyByISIN !== "")
        {
          let CompanyByIdApiEndpoint = apiEndPoint + '/api/v1/glasslewis/Company/GetCompanyByISIN/'+CompanyByISIN;
          const results:any = await axios.get(CompanyByIdApiEndpoint,
                                              {
                                                  headers: {
                                                      Accept: 'application/json',
                                                      "Authorization" : `Bearer ${jwtToken}`
                                                  },
                                              });
          setCompanyByISINCompanyName(results.data);
        }
      }  
      catch(err:any)
      {
          console.log("Err: ", err);

          if(err.message === "Request failed with status code 401")
          {
            navigate("/");
          }
      }    
    }
  
    const handleClose = () => setShow(false);
  
      return (
        <div className="container">
            <h3> Companies </h3>

            <div className="container">
              <div className="row">
                <div className="col-md-12 bg-light text-left">
                  <button onClick={() => showModal()}  className="btn btn-primary">Add New Item</button>
                </div>
                <div className="col-md-12 bg-light text-left">
                  <div className="col-md-6 bg-light text-left">

                    <form className="d-flex">
                      <label>Company By Id</label>
                      <div className="form-group">      
                        <select value={CompanyById} onChange={CompanyByIdOnChange}>
                          <option value="">Select</option>
                          {
                            items.map((items,index) => 
                            (
                              <option key={index} value={items.id}>{items.id}</option>
                            ))}
                        </select>                        
                      </div>
                      <button type="submit" className="btn btn-primary" onClick={CompanyByIdOnClick}>Submit</button>
                      <span>{CompanyName}</span>
                    </form>

                  </div>
                  <div className="col-md-6 bg-light text-left">

                    <form className="d-flex">
                      <label>Company By ISIN</label>
                      <div className="form-group">      
                        <select value={CompanyByISIN} onChange={CompanyByISINOnChange}>
                          <option value="">Select</option>
                          {                            
                            items.map((items,index) => 
                            (
                              items.isin != ""
                              ?
                              <option key={index} value={items.isin}>{items.isin}</option>
                              :
                              null
                            ))}
                        </select>                        
                      </div>
                      <button type="submit" className="btn btn-primary" onClick={CompanyByISINOnClick}>Submit</button>
                      <span>{CompanyByISINCompanyName}</span>
                    </form>

                  </div>

                </div>
              </div>
        </div>
  
        <Modal show={show} onHide={() => handleClose()}>
  
              <Modal.Header closeButton>
                  <Modal.Title>Add Company</Modal.Title>
              </Modal.Header>
  
              <Modal.Body>
                <div className="form-group">
                  <label>Name</label>
                  <input value={Name} onChange={NameOnChange} type="text" className="form-control" placeholder="Enter Name"/>
                </div>
                <div className="form-group">
                  <label>Exchange</label>
                  <input value={Exchange} onChange={ ExchangeOnChange}  type="text" className="form-control" placeholder="Enter Exchange"/>
                </div>
                <div className="form-group">
                  <label>Ticker</label>
                  <input value={Ticker} onChange={ TickerOnChange}  type="text" className="form-control" placeholder="Enter Ticker"/>
                </div>
                <div className="form-group">
                  <label>ISIN</label>
                  <input value={ISIN} onChange={ ISINOnChange}  type="text" className="form-control" placeholder="Enter ISIN"/>
                </div>
                <div className="form-group">
                  <label>Website</label>
                  <input value={Website} onChange={ WebsiteOnChange}  type="text" className="form-control" placeholder="Enter Website"/>
                </div>
                  
              </Modal.Body>
  
              <Modal.Footer>
                  <button onClick={() => handleClose()}>
                      Close
                  </button>
                  <button onClick={SubmitOnClick}>
                      Submit
                  </button>
              </Modal.Footer>
  
        </Modal>
  
          <Table striped bordered hover>
              <thead>
                  <th>Company Id</th>
                  <th>Name</th>
                  <th>Exchange</th>
                  <th>Ticker</th>        
                  <th>ISIN</th>       
                  <th>Website</th>    
                  <th>Action</th>    
              </thead>
              <tbody>
            {
            items.map((items,index) => 
            (
              <tr key={index}>
                <td> {items.id} </td>
                <td> {items.name} </td> 
                <td> {items.exchange} </td>
                <td> {items.ticker} </td>     
                <td> {items.isin} </td> 
                <td> {items.website} </td>                
                <td>
                  <button onClick={() => showEditModal(items)} className="btn btn-primary">
                    Edit
                  </button>
                </td>               
              </tr>
            ))}
          </tbody>
          </Table>
        </div>
      );
}

export default CompanyComponent;
