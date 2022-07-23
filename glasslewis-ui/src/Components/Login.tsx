import React, {useEffect } from "react";
import { useForm } from "react-hook-form";
import axios from "axios";
import { ToastContainer, toast, Flip } from "react-toastify";
import "react-toastify/dist/ReactToastify.min.css";
import jwt_decode from "jwt-decode";
import { useNavigate } from "react-router-dom";

const Login= ()=> 
{
    const navigate = useNavigate();

  const { register, handleSubmit, formState: { errors } } = useForm();
  
  useEffect(() => 
  {
    debugger;
    var isExpired = false;
    const token = localStorage.getItem("auth");
    if(token != null)
    {
        var decodedToken:any = jwt_decode(token);
        var dateNow = new Date();

        if(decodedToken.exp < dateNow.getTime())
        {
            isExpired = true;

            localStorage.clear();
            navigate("/");
        }
        else
        {
            navigate("/home");
        }
    }
  }, []);

  const login = (data: any) => 
  {
    let params = { email: data.email, password: data.password };

    axios.post("https://localhost:7008/api/token", params).then(function (response) 
    {
        debugger;
        //   IF EMAIL ALREADY EXISTS
        if (response.data === "Invalid credentials") 
        {
          toast.error('Invalid credentials!', {
            position: "top-right",
            autoClose: 3000,
            hideProgressBar: false,
            closeOnClick: true,
            pauseOnHover: true,
            draggable: true,
            progress: undefined,
            });
        } 
        else 
        {
          toast.success('logged in successfully', 
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

          localStorage.setItem("auth", response.data);
          setTimeout(() => 
          {
            navigate("/home");
          }, 1000);
        }
      })

      .catch(function (error) {
        console.log(error);
      });
  };

  return (
    <>
      <div className="container">
        <div className="row d-flex justify-content-center align-items-center" style={{ height: "100vh" }}>
          <div className="card mb-3" style={{ maxWidth: "320px" }}>
            <div className="col-md-12">
              <div className="card-body">
                <h3 className="card-title text-center text-secondary mt-3">
                  Login Form
                </h3>
                <form autoComplete="off" onSubmit={handleSubmit(login)}>
                  <div className="mb-3 mt-4">
                    <label className="form-label">Email</label>
                    <input
                      type="email"
                      className="form-control shadow-none"
                      id="exampleFormControlInput1"
                      {...register("email", { required: "Email is required!" })}
                    />
                    {errors.email && (
                      <p className="text-danger" style={{ fontSize: 14 }}>
                        {/* {errors.email.message} */}
                      </p>
                    )}
                  </div>
                  <div className="mb-3">
                    <label className="form-label">Password</label>
                    <input
                      type="password"
                      className="form-control shadow-none"
                      id="exampleFormControlInput2"
                      {...register("password", {
                        required: "Password is required!",
                      })}
                    />
                    {errors.password && (
                      <p className="text-danger" style={{ fontSize: 14 }}>
                        {/* {errors.Password.message} */}
                      </p>
                    )}
                  </div>
                  <div className="text-center mt-4 ">
                    <button className="btn btn-outline-primary text-center shadow-none mb-3" type="submit">
                      Submit
                    </button>
                    {/* <p className="card-text pb-2">
                      Have an Account?{" "}
                      <Link style={{ textDecoration: "none" }} to={"/register"}>
                        Sign Up
                      </Link>
                    </p> */}
                  </div>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar
        closeOnClick
        rtl={false}
        pauseOnFocusLoss={false}
        draggable={false}
        pauseOnHover
        limit={1}
        transition={Flip}
      />
    </>
  );
};
export default Login;