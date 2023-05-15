import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";
import Pagination from "react-js-pagination";



const AdminPatient = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalPatients, setTotalPatients] = useState(0);
    //  const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/patient/all?pageNumber=1&pageSize=6").then((rsp) => {
            debugger
            setResult(rsp.data);
            setTotalPatients(rsp.data.length);
            // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);

    // const deleteDoctor = (id) => {
    //     axiosConfig.post(`/doctor/delete/${id}`).then((rsp) => {
    //       debugger
    //       axiosConfig.get("/doctor/all").then((rsp) => {
    //         //debugger
    //         setResult(rsp.data);
    //         setTotalDoctors(rsp.data.length);
    //         setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
    //         debugger
    //     }, (err) => {
    //         debugger
    //     })
    //     setDelete("Doctor deleted!");
    //     setIsReady(true);
    //     }, (err) => {
    //         debugger
    //      // setErrs(err.response.data);

    //     })
    //   }
    const handlePageChange = (pageNumber) => {

        console.log(`active page is ${pageNumber}`);
        // const searchPage = { search: keyword, page: pageNumber };
        //axiosConfig.post("/search", keyword);
        // this.setState({ activePage: pageNumber });
        // axiosConfig.post("/search",searchPage).then((rsp) => {
        axiosConfig.get(`/patient/all?pageNumber=${pageNumber}&pageSize=6`).then((rsp) => {

            debugger
            setResult(rsp.data);
            setTotalPatients(rsp.data.length);
            setIsReady(true);
            // console.log(rsp.data);
        }, (err) => {
            debugger
        })
    }

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div align='center'>
            <br /><br />
            <p align="center"><b>Patient list</b></p>
            <span><b>Registered:  {totalPatients}</b></span><br /><span></span><br />
            {/* <span><b>Available:{availableDoctors}</b></span><br/> */}
            <span><b><i>{msgDelete ? msgDelete : ''}</i></b><br /></span>
            <table border="2" align="center" cellPadding="10" width="30%">

                <th>Patient ID</th>
                <th>Name</th>
                <th>Age</th>
                <th>Gender</th>
                <th>Mobile</th>
                <th>OPD Count</th>
                <th>IPD Count</th>
                <th>Total Paid</th>
                {
                    result.Data?.map((patient, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{patient.Id}</td>
                            <td>{patient.Name}</td>
                            <td>{patient.Age}</td>
                            <td>{patient.Gender}</td>
                            {/* <td>{patient.BloodGroup}</td>
                            <td>{patient.Department.Name}</td>
                            <td>{patient.Salary}</td> */}
                            <td>{patient.Mobile}</td>
                            <td>{patient.OPDCount}</td>
                            <td>{patient.IPDCount}</td>
                            <td>{patient.TotalPaid}</td>
                            {/* <td>
                            <button class='btn btn-warning'><Link class='text text-dark' to={`/doctor/edit/${doctor.Id}`}> Edit</Link></button>
                            <button class='btn btn-danger ' onClick={() => deleteDoctor(doctor.Id)}>Delete</button>
                            </td> */}
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
            <br/>
            <div class="pagination justify-content-center">

                <Pagination
                    activePage={result.Page.CurrentPage}
                    itemsCountPerPage={result.Page.PageSize}
                    totalItemsCount={result.Page.TotalCount}
                    pageRangeDisplayed={5}
                    onChange={handlePageChange.bind(this)}
                    itemClass="page-item"
                    linkClass="page-link" /></div>
        </div >)
}

export default AdminPatient;