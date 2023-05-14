import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";


const RcpPatient = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [msgDelete, setDelete] = useState("");
    const [totalPatients, setTotalPatients] = useState(0);
  //  const [availableDoctors, setAvailableDoctors] = useState(0);

    useEffect(() => {
        axiosConfig.get("/receptionist/patient/all").then((rsp) => {
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

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div align='center'>
            <br /><br />
            <p align="center"><b>Patient list</b></p>
            <span><b>Registered:  {totalPatients}</b></span><br/><span></span><br/>
            {/* <span><b>Available:{availableDoctors}</b></span><br/> */}
            <span><b><i>{msgDelete ? msgDelete : ''}</i></b><br /></span>
            <table border="2" align="center" class="table">

                <th>Patient ID</th>
                <th>Name</th>
                <th>DOB</th>
                <th>Gender</th>
                <th>Mobile</th>
                {
                    result?.map((patient, index) =>
                        <tbody align="center">
                            {/* <td>{index + 1}</td> */}
                            {/* <td><Link to={`/details/order/${order.order_id}`}>#{order.order_id}</Link></td> */}
                            <td>{patient.Id}</td>
                            <td>{patient.Name}</td>
                            <td>{patient.DOB}</td>
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
          
        </div >
    )
}

export default RcpPatient;