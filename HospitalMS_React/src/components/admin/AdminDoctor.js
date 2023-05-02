import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";


const AdminDoctor = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalDoctors, setTotalDoctors] = useState(0);
    const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/doctor/all").then((rsp) => {
            debugger
            setResult(rsp.data);
            setTotalDoctors(rsp.data.length);
            setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);

    const deleteDoctor = (id) => {
        axiosConfig.post(`/doctor/delete/${id}`).then((rsp) => {
          debugger
          axiosConfig.get("/doctor/all").then((rsp) => {
            //debugger
            setResult(rsp.data);
            setTotalDoctors(rsp.data.length);
            setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            debugger
        }, (err) => {
            debugger
        })
        setDelete("Doctor deleted!");
        setIsReady(true);
        }, (err) => {
            debugger
         // setErrs(err.response.data);
    
        })
      }

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div align='center'>
            <br /><br />
            <p align="center"><b>Doctors list</b></p>
            <span><b>Total: {totalDoctors}</b></span><br/><span></span><span><b>Available:{availableDoctors}</b></span><br/>
            <br/><button class='btn btn-success'><Link class='text text-light' to={`/admin/doctor/add`}> Add New</Link></button>
            <span><b><i>{msgDelete ? msgDelete : ''}</i></b><br /></span>
            <table border="2" align="center" cellPadding="10" width="30%">

                <th>Doctor ID</th>
                <th>Name</th>
                <th>Designation</th>
                <th>Gender</th>
                <th>Room</th>
                <th>Dept</th>
                <th>Salary</th>
                <th>Mobile</th>
                <th>Email</th>

                {
                    result?.map((doctor, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{doctor.Id}</td>
                            <td>{doctor.Name}</td>
                            <td>{doctor.Designation}</td>
                            <td>{doctor.Gender}</td>
                            <td>{doctor.Room}</td>
                            <td>{doctor.Department.Name}</td>
                            <td>{doctor.Salary}</td>
                            <td>{doctor.Mobile}</td>
                            <td>{doctor.Email}</td>
                            <td>
                            <button class='btn btn-warning'><Link class='text text-dark' to={`/doctor/edit/${doctor.Id}`}> Edit</Link></button>
                            <button class='btn btn-danger ' onClick={() => deleteDoctor(doctor.Id)}>Delete</button>
                            </td>
                            {/* <td>
                {
                  order.status == 'Pending' && <span><button onClick={() => cancelOrder(order.order_id)}>Cancel</button> | </span>
                }
                <button onClick={() => downloadOrder(order.order_id)}>Download</button>
                {
                  order.status == 'Delivered' && <span> | <button onClick={() => returnOrder(order.order_id)}>Return</button></span>
                }
                {
                  (order.status != 'Pending') && (order.status != 'Canceled') && (order.review_status!='true') && <span> | <button onClick={() => addReview(order.order_id, order.amount)}>Review</button></span>
                }
                {
                  (order.status != 'Pending') && (order.status != 'Canceled') && (order.review_status=='true') && <span> | Reviewed</span>
                }
                        </td> */}

                        </tbody>
                    )
                }

            </table> 
            {/* & emsp;& emsp;& emsp;& emsp; */}
            {/* <table border="2" align="center" cellPadding="10" width="30%">
                <td>
                    <b>Details:</b>   {result.med.details} <br /><br />
                    <b>Side effects:</b>   none
                </td>

            </table> */}
        </div >
    )
}

export default AdminDoctor;