import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";


const RcpDeptWiseDoctor = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalDoctors, setTotalDoctors] = useState(0);
    const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/doctor/dept/" + id).then((rsp) => {
            debugger
            setResult(rsp.data);
            setTotalDoctors(rsp.data.length);
            setAvailableDoctors(rsp.data.filter(d => d.IsAvailable == true).length)
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);


    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div align='center'>
            <br /><br />
            <p align="center"><b>Department Wise Doctors List</b></p>
            <span><b>Department- {result[0].Department.Name}</b><br /><b>Total: {totalDoctors}</b></span><br /><span></span><span><b>Available:{availableDoctors}</b></span><br />
            {/* <table border="2" align="center" cellPadding="10" width="30%"  class="table table-layout: auto;" > */}
            <table border="2" align="center" class="table" >

                <th>Doctor ID</th>
                <th>Name</th>
                <th>Designation</th>
                <th>Gender</th>
                <th>Room</th>
                <th>Availability</th>
                <th>Stay From</th>
                <th>Stay Till</th>
                <th>Fee</th>

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
                            {(doctor.IsAvailable) ?
                                (<span style={{ backgroundColor: 'green', width: '15px', height: '15px', borderRadius: '50%', display: 'inline-block', marginLeft: '5px' }}></span>
                                ) :
                                (<span style={{ backgroundColor: 'red', width: '15px', height: '15px', borderRadius: '50%', display: 'inline-block', marginLeft: '5px' }}></span>
                                )}
                            {/* <td>{doctor.IsAvailable}</td> */}
                            <td>{doctor.StayFrom}</td>
                            <td>{doctor.StayTill}</td>
                            <td>{doctor.Fee}</td>

                            <td>
                                <button class='btn btn-warning'><Link class='text text-dark' to={`/appointment/doctor/${doctor.Id}/${doctor.Fee}`}> Book</Link></button>

                            </td>
                        </tbody>
                    )
                }

            </table>

        </div >
    )
}

export default RcpDeptWiseDoctor;