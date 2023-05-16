import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { useNavigate } from "react-router-dom";
//import TimeField from 'react-simple-timefield';
//import TimePicker from 'react-time-picker';
//import TimeRangePicker from '@wojtekmaj/react-timerange-picker'
import Timekeeper from 'react-timekeeper';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
//import "../NoBootstrap.css";


const EditPatientAdmin = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [errs, setErrs] = useState([]);
    const navigate = useNavigate();

    const [name, setName] = useState("");
    const [dob, setDob] = useState(new Date());
    const [gender, setGender] = useState("");
    const [bloodGroup, setBloodGroup] = useState("");
    const [mobile, setMobile] = useState("");
    const [email, setEmail] = useState("");
    const [address, setAddress] = useState("");
    const [username, setUsername] = useState("");
    const [totalPaid, setTotalPaid] = useState("");

    useEffect(() => {
        axiosConfig.get("/patient/" + id).then((rsp) => {
            debugger
            setResult(rsp.data);
            setName(rsp.data.Name);
            setDob(new Date(rsp.data.DOB));
            setGender(rsp.data.Gender);
            setBloodGroup(rsp.data.BloodGroup);
            setMobile(rsp.data.Mobile);
            setEmail(rsp.data.Email);
            setAddress(rsp.data.Address);
            setUsername(rsp.data.Username);
            // setTotalPaid(rsp.data.TotalPaid);

            setIsReady(true);
        }, (err) => {
            debugger
            setErrs(err.response.data);
        })

    }, []);

    const savePatientEdit = (event) => {
        event.preventDefault();
        var data = { Id: result.Id, Name: name, DOB: dob.toLocaleDateString('en-CA'), Gender: gender, BloodGroup: bloodGroup, Mobile: mobile, Email: email, Address: address, Username: username };

        debugger;
        axiosConfig.post("/patient/update", data).
            then((rsp) => {
                debugger;
                navigate({ pathname: '/receptionist/patient/all' });
            }, (err) => {
                debugger;
                setErrs(err.response.data);
            })
    }

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div>
            <br /><br />
            <p align="center"><b>Edit patient details</b></p>
            <span>{errs.Msg ? errs.Msg : ''}</span>
            <form onSubmit={savePatientEdit}>
                Name: <input defaultValue={name} onChange={(e) => { setName(e.target.value) }} type="text" /><br />
                DOB: <DatePicker dateFormat="yyyy-MM-dd" selected={dob} onChange={(e) => { setDob(e) }} type="text" /><br />
                Gender: <input defaultValue={gender} onChange={(e) => { setGender(e.target.value) }} type="text" /><br />
                Blood Group: <input defaultValue={bloodGroup} onChange={(e) => { setBloodGroup(e.target.value) }} type="text" /><br />
                Mobile: <input defaultValue={mobile} onChange={(e) => { setMobile(e.target.value) }} type="text" /><br />
                Email: <input defaultValue={email} onChange={(e) => { setEmail(e.target.value) }} type="text" /><br />
                Address: <input defaultValue={address} onChange={(e) => { setAddress(e.target.value) }} type="text" /><br />
                Username: <input defaultValue={username} onChange={(e) => { setUsername(e.target.value) }} type="text" readOnly /><br />
                <br /><input type="submit" value="Save info" />
            </form>
        </div>
    )
}

export default EditPatientAdmin;