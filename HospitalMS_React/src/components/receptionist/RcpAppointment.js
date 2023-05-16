import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";
import fileDownload from "js-file-download";
import Pagination from "react-js-pagination";


const RcpAppointment = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {
        axiosConfig.get("/appointment/all?pageNumber=1&pageSize=6").then((rsp) => {
            debugger
            setResult(rsp.data);
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);


    const cancelAppointment = (id) => {
        axiosConfig.get(`/appointment/cancel/${id}`).then((rsp) => {
            debugger
            // setResult(rsp.data);
            axiosConfig.get("/appointment/all?pageNumber=1&pageSize=6").then((rsp) => {
                debugger
                setResult(rsp.data);
                setIsReady(true);
            }, (err) => {
                debugger
            })

            //  setRemove("Order cancelled");
        }, (err) => {
            // setErrs(err.response.data);

        })
    }

    const closeAppointment = (id) => {
        axiosConfig.get(`/appointment/close/${id}`).then((rsp) => {
            debugger
            // setResult(rsp.data);
            axiosConfig.get("/appointment/all?pageNumber=1&pageSize=6").then((rsp) => {
                debugger
                setResult(rsp.data);
                setIsReady(true);
            }, (err) => {
                debugger
            })

            //  setRemove("Order cancelled");
        }, (err) => {
            // setErrs(err.response.data);

        })
    }
    const handlePageChange = (pageNumber) => {

        console.log(`active page is ${pageNumber}`);
        // const searchPage = { search: keyword, page: pageNumber };
        //axiosConfig.post("/search", keyword);
        // this.setState({ activePage: pageNumber });
        // axiosConfig.post("/search",searchPage).then((rsp) => {
        axiosConfig.get(`/appointment/all?pageNumber=${pageNumber}&pageSize=6`).then((rsp) => {

            debugger
            setResult(rsp.data);
            setIsReady(true);
            // console.log(rsp.data);
        }, (err) => {
            debugger
        })
    }
    const printAppointment = (id) => {
        axiosConfig.get(`/appointment/print/${id}`, { responseType: 'blob' }).then((rsp) => {
            debugger
            // saveAs(rsp.blob,'order_recipt.pdf');
            fileDownload(rsp.data, "appointment_" + id + ".pdf");

        }, (err) => {
            //setErrs(err.response.data);

        })

    }


    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }


    return (
        <div align='center'><br />
            <p align="center"><b>Appointments list</b></p>

            <table border="2" align="center" class="table">

                <th>Patient Id</th>
                <th>Patient Name</th>
                <th>Doctor Name</th>
                <th>Scheduled</th>
                <th>Status</th>

                {
                    result.Data.map((appointment, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{appointment.PatientId}</td>
                            <td>{appointment.Patient.Name}</td>
                            <td>{appointment.Doctor.Name}</td>
                            <td>{new Date(appointment.ScheduleDate).toLocaleDateString('en-CA')}, {appointment.ScheduleTime}</td>
                            <td>{appointment.Status}</td>
                            <td>
                                {
                                    appointment.Status == 'Open' &&
                                    <button class='btn btn-warning'><Link class='text text-dark' to={`/appointment/modify/${appointment.Id}`}>Modify</Link></button>
                                }
                                {
                                    appointment.Status == 'Open' &&
                                    <button class='btn btn-danger' onClick={() => cancelAppointment(appointment.Id)}>Cancel</button>
                                }
                                {
                                    (appointment.Status == 'Paid' && appointment.Status != 'Closed') &&
                                    <button class='btn btn-success' onClick={() => closeAppointment(appointment.Id)}>Close</button>
                                }
                                {
                                    (appointment.Status == 'Paid' || appointment.Status == 'Closed') &&
                                    <button class='btn btn-info' onClick={() => printAppointment(appointment.Id)}>Print</button>
                                }
                            </td>
                        </tbody>
                    )
                }

            </table>
            <br />
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

export default RcpAppointment;