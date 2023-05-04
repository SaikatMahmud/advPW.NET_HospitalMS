import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { Link, useNavigate } from "react-router-dom";
import { Chart } from "react-google-charts";

const AdminDashboard = () => {
  const [result, setResult] = useState([]);
  const [total, setTotal] = useState();
  const [isReady, setIsReady] = useState(false);
  const [cusAdd, setAddress] = useState("");
  const [method, setMethod] = useState("");
  const [errs, setErrs] = useState({});
  const [msgRemove, setRemove] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    axiosConfig.get("/admin/dashboard").then((rsp) => {
      debugger
      setResult(rsp.data);
      setIsReady(true);
    }, (err) => {
      //setErrs(err.response.data);

    })

  }, []);


  if (!isReady) {
    return <h2 align="center">Page loading....</h2>
  }

  return (
    <div align='center'><br/>
      <table border="2" align="center" cellPadding="10" width="30%">
        <tbody>

          <tr><td><b>Doctor</b><br />Total: {result.TotalDoctor}<br />Available:{result.AvailableDoctor}</td>
            <td><b>Patient</b><br />Registered: {result.RegisteredPatient}</td>
            <td><b>Department</b><br />Total: {result.TotalDept}</td>
          </tr>
          <tr><td><b>Staff</b><br />Total: {result.TotalStaff}</td>
            <td><b>Cabin</b><br />Total: {result.TotalCabin}<br />Available:{result.AvailableCabin}</td>
          </tr>
        </tbody>
      </table>

    </div >
  )
}

export default AdminDashboard