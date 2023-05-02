import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";


const AdminStaff = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalStaff, setTotalStaffs] = useState(0);
    // const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/staff/all").then((rsp) => {
            debugger
            setResult(rsp.data);
            setTotalStaffs(rsp.data.length);
            // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);

    const deleteDept = (id) => {
        axiosConfig.post(`/staff/delete/${id}`).then((rsp) => {
          debugger
          axiosConfig.get("/staff/all").then((rsp) => {
            //debugger
            setResult(rsp.data);
            setTotalStaffs(rsp.data.length);
            // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
        }, (err) => {
            debugger
        })
        setDelete("Staff deleted!");
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
            <p align="center"><b>Staff list</b></p>
            <span><b>Total: {totalStaff}</b></span><br/><span></span>
            {/* <span><b>Available:{availableDoctors}</b></span> */}
            <br/>
            <button class='btn btn-success'><Link class='text text-light' to={`/admin/staff/add`}> Add New</Link></button>
            <span><b><i>{msgDelete ? msgDelete : ''}</i></b><br /></span>
            <table border="2" align="center" cellPadding="10" width="30%">

                <th>Doctor ID</th>
                <th>Name</th>
                <th>Designation</th>
                <th>Gender</th>
                <th>Dept</th>
                <th>Salary</th>
                <th>Mobile</th>
                <th>Email</th>
              

                {
                    result?.map((staff, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{staff.Id}</td>
                            <td>{staff.Name}</td>
                            <td>{staff.Designation}</td>
                            <td>{staff.Gender}</td>
                            {/* <td>{staff.Room}</td> */}
                            <td>{staff.DeptId}</td>
                            <td>{staff.Salary}</td>
                            <td>{staff.Mobile}</td>
                            <td>{staff.Email}</td>
                            <td>
                            <button class='btn btn-warning'><Link class='text text-dark' to={`/staff/edit/${staff.Id}`}> Edit</Link></button>
                            <button class='btn btn-danger ' onClick={() => deleteDept(staff.Id)}>Delete</button>
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

export default AdminStaff;