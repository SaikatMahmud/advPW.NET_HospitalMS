import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";


const AdminDept = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalDepts, setTotalDepts] = useState(0);
    const [newDeptName, setNewDept] = useState("");
    const navigate = useNavigate();

    // const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/dept/all").then((rsp) => {
            debugger
            setResult(rsp.data);
            setTotalDepts(rsp.data.length);
            // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);

    const AddDept = (event) => {
        event.preventDefault();
        var data = {Name:newDeptName};
       axiosConfig.post("/dept/add", data).
            then((rsp) => {
                debugger;
                axiosConfig.get("/dept/all").then((rsp) => {
                    debugger
                    setResult(rsp.data);
                    setTotalDepts(rsp.data.length);
                    setNewDept("");
                    // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
                    setIsReady(true);
                }, (err) => {
                    debugger
                })
           }, (err) => {
               debugger;
              // setErrs(err.response.data);
           })
   }

    // const deleteDept = (id) => {
    //     axiosConfig.post(`/dept/delete/${id}`).then((rsp) => {
    //       debugger
    //       axiosConfig.get("/dept/all").then((rsp) => {
    //         //debugger
    //         setResult(rsp.data);
    //         setTotalDepts(rsp.data.length);
    //         // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
    //         debugger
    //     }, (err) => {
    //         debugger
    //     })
    //     setDelete("Department deleted!");
    //     setIsReady(true);
    //     }, (err) => {
    //         debugger
    //      // setErrs(err.response.data);
    
    //     })
    //   }

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div align='center'>
            <br /><br />
            <p align="center"><b>Department list</b></p>
            <span><b>Total: {totalDepts}</b></span><br/><span></span><br/>
            {/* <span><b>Available:{availableDoctors}</b></span><br/> */}
            <form onSubmit={AddDept}>
                Name: <input value={newDeptName} onChange={(e) => { setNewDept(e.target.value) }} type="text" />
                <input type="submit" value="Add" class="btn btn-success" />
            </form>
            <span><b><i>{msgDelete ? msgDelete : ''}</i></b><br /></span>
            <table border="2" align="center" cellPadding="10" width="30%">

                <th>Department ID</th>
                <th>Name</th>
               <th>Doctors Count</th>
               <th>Staffs Count</th>

                {
                    result?.map((dept, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{dept.Id}</td>
                            <td>{dept.Name}</td>
                            <td>{dept.Doctors.length}</td>
                            <td>{dept.Staffs.length}</td>
                        
                            <td>
                            <button class='btn btn-warning'><Link class='text text-dark' to={`/dept/edit/${dept.Id}`}> Edit</Link></button>
                            {/* <button class='btn btn-danger ' onClick={() => deleteDept(dept.Id)}>Delete</button> */}
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

export default AdminDept;