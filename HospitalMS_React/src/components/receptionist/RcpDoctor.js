import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link } from "react-router-dom";


const RcpDoctor = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {
        axiosConfig.get("/doctor/deptwise").then((rsp) => {
            debugger
            setResult(rsp.data);
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }


    return (
        <div align='center'><br />
            <p align="center"><b>Department Wise Doctor</b></p>

            <table border="2" align="center" cellPadding="10" width="30%">
                {
                    result?.map((data, index) =>
                        <tbody align="center">

                           
                                <td><Link class='text text-dark' to={`/receptionist/doctor/dept/${data.DeptId}`}><b>Department-  </b>{data.DeptName}<br />Total: {data.TotalDoctor}    Available: {data.AvailableDoctor}</Link></td>
                                {/* <td><Link class='text text-dark' to={`/receptionist/doctor/dept/${data.DeptId}`}><b>Department-  </b>{data.DeptName}<br />Total: {data.TotalDoctor}    Available: {data.AvailableDoctor}</Link></td> */}
                            
                        </tbody>
                    )
                }
            </table>
            
        </div >
    )


}

export default RcpDoctor;