import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";
import fileDownload from "js-file-download";
import Pagination from "react-js-pagination";


const LeaveApplicationAll = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {
        axiosConfig.get("/leaveapplication/all?pageNumber=1&pageSize=6").then((rsp) => {
            debugger
            setResult(rsp.data);
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);


    const rejectApplication = (id) => {
        axiosConfig.get(`/leaveapplication/reject/${id}`).then((rsp) => {
            debugger
            // setResult(rsp.data);
            axiosConfig.get("/leaveapplication/all?pageNumber=1&pageSize=6").then((rsp) => {
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

    const approveApplication = (id) => {
        axiosConfig.get(`/leaveapplication/approve/${id}`).then((rsp) => {
            debugger
            // setResult(rsp.data);
            axiosConfig.get("/leaveapplication/all?pageNumber=1&pageSize=6").then((rsp) => {
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

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }


    return (
        <div align='center'><br />
            <p align="center"><b>Leave application list</b></p>

            <table border="2" align="center" class="table">

                <th>Staff Id</th>
                <th>Staff Name</th>
                <th>Details</th>
                <th>Leave From</th>
                <th>Leave Till</th>
                <th>Status</th>
                <th>Action</th>

                {
                    result.Data?.map((la, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{la.StaffId}</td>
                            <td>{la.StaffName}</td>
                            <td>{la.Details}</td>
                            <td>{new Date(la.LeaveFrom).toLocaleDateString('en-CA')}</td>
                            <td>{new Date(la.LeaveTill).toLocaleDateString('en-CA')}</td>
                            <td>{la.Status}</td>
                            <td>
                                {
                                    la.Status == 'Pending' &&
                                    <button class='btn btn-success'onClick={() => approveApplication(la.Id)}>Approve</button>
                                }
                                {
                                    la.Status == 'Pending' &&
                                    <button class='btn btn-danger' onClick={() => rejectApplication(la.Id)}>Reject</button>
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

export default LeaveApplicationAll;