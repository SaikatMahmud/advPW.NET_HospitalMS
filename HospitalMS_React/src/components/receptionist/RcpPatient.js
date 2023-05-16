import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";
import Pagination from "react-js-pagination";



const RcpPatient = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalPatients, setTotalPatients] = useState(0);
  //  const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/receptionist/patient/all?pageNumber=1&pageSize=6").then((rsp) => {
            debugger
            setResult(rsp.data);
            setTotalPatients(rsp.data.Page.TotalCount);
           // setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);
    const handlePageChange = (pageNumber) => {

        console.log(`active page is ${pageNumber}`);
        // const searchPage = { search: keyword, page: pageNumber };
        //axiosConfig.post("/search", keyword);
        // this.setState({ activePage: pageNumber });
        // axiosConfig.post("/search",searchPage).then((rsp) => {
        axiosConfig.get(`/receptionist/patient/all?pageNumber=${pageNumber}&pageSize=6`).then((rsp) => {

            debugger
            setResult(rsp.data);
            setResult(rsp.data);
            setTotalPatients(rsp.data.Page.TotalCount);
            setIsReady(true);
            // console.log(rsp.data);
        }, (err) => {
            debugger
        })
    }

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

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div align='center'>
            <br /><br />
            <p align="center"><b>Patient list</b></p>
            <span><b>Registered:  {totalPatients}</b></span><br/><span></span>
            {/* <span><b>Available:{availableDoctors}</b></span><br/> */}
            <span><b><i>{msgDelete ? msgDelete : ''}</i></b><br /></span>
            <button class='btn btn-success'><Link class='text text-light' to={`/patient/register`}>Register New</Link></button>
            <table border="2" align="center" class="table">

                <th>Patient ID</th>
                <th>Name</th>
                <th>DOB</th>
                <th>Gender</th>
                <th>Mobile</th>
                {
                    result.Data?.map((patient, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{patient.Id}</td>
                            <td>{patient.Name}</td>
                            <td>{new Date(patient.DOB).toLocaleDateString('en-CA')}</td>
                            <td>{patient.Gender}</td>
                            {/* <td>{patient.BloodGroup}</td>
                            <td>{patient.Department.Name}</td>
                            <td>{patient.Salary}</td> */}
                            <td>{patient.Mobile}</td>
                            <td>
                            <button class='btn btn-warning'><Link class='text text-dark' to={`/patient/edit/${patient.Id}`}> Edit</Link></button>
                            {/* <button class='btn btn-danger ' onClick={() => deleteDoctor(doctor.Id)}>Delete</button> */}
                            </td>


                        </tbody>
                    )
                }

            </table> 
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
    
        </div >
    )
}

export default RcpPatient;