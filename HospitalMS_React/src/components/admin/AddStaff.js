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


const EditStaff = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [errs, setErrs] = useState([]);
    const navigate = useNavigate();

    const [staffId, setId] = useState("");
    const [name, setName] = useState("");
    // const [aboutDoctor, setAboutDoctor] = useState("");
    const [designation, setDesignation] = useState("");
    const [gender, setGender] = useState("");
    const [mobile, setMobile] = useState("");
    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    // const [room, setRoom] = useState("");
    // const [stayFrom, setStayFrom] = useState("");
    // const [stayTill, setStayTill] = useState("");
    const [joinDate, setJoinDate] = useState(new Date());
    const [deptId, setDeptId] = useState("");
    const [salary, setSalary] = useState("");
    // const [fee, setFee] = useState("");
    //const [time, setTime] = useState('12:34PM');
    // const [showTime1, setShowTime1] = useState(false);
    // const [showTime2, setShowTime2] = useState(false);

    // useEffect(() => {
    //     axiosConfig.get("/staff/" + id).then((rsp) => {
    //         debugger
    //         // setResult(rsp.data);
    //         setId(rsp.data.Id);
    //         setName(rsp.data.Name);
    //         // setAboutDoctor(rsp.data.AboutDoctor);
    //         setDesignation(rsp.data.Designation);
    //         setGender(rsp.data.Gender);
    //         setMobile(rsp.data.Mobile);
    //         setEmail(rsp.data.Email);
    //         setUsername(rsp.data.Username);
    //         // setRoom(rsp.data.Room);
    //         // setStayFrom(rsp.data.StayFrom);
    //         // setStayTill(rsp.data.StayTill);
    //         setJoinDate(rsp.data.JoinDate);
    //         setDeptId(rsp.data.DeptId);
    //         setSalary(rsp.data.Salary);
    //         // setFee(rsp.data.Fee);
    //         setIsReady(true);
    //     }, (err) => {
    //         debugger
    //         setErrs(err.response.data);
    //     })

    // }, []);

    const AddStaff = (event) => {
         event.preventDefault();
         var data = {Name:name, Designation:designation, Gender:gender, Mobile:mobile, Email:email,Username:username,
            JoinDate:joinDate, DeptId:deptId, Salary:salary};
            debugger
        axiosConfig.post("/staff/add", data).
             then((rsp) => {
                 debugger;
                navigate({ pathname: '/admin/staff/list' });
            }, (err) => {
                debugger;
                setErrs(err.response.data);
            })
    }

    // if (!isReady) {
    //     return <h2 align="center">Page loading....</h2>
    // }

    return (
        <div>
            <br /><br />
            <p align="center"><b>Add new staff</b></p>
            <span>{errs.Msg ? errs.Msg : ''}</span>
            <form onSubmit={AddStaff}>
                {/* Name: <input defaultValue={name} onChange={(e) => { setName(e.target.value) }} type="text" /><span>{errs.name ? errs.name[0] : ''}</span><br /> */}
                Name: <input value={name} onChange={(e) => { setName(e.target.value) }} type="text" /><br />
                {/* About doctor: <input defaultValue={aboutDoctor} onChange={(e) => { setAboutDoctor(e.target.value) }} type="text" /><br /> */}
                Designation: <input value={designation} onChange={(e) => { setDesignation(e.target.value) }} type="text" /><br />
                Gender: <input value={gender} onChange={(e) => { setGender(e.target.value) }} type="text" /><br />
                Mobile: <input value={mobile} onChange={(e) => { setMobile(e.target.value) }} type="text" /><br />
                Email: <input value={email} onChange={(e) => { setEmail(e.target.value) }} type="text" /><br />
                Username: <input value={username} onChange={(e) => { setUsername(e.target.value) }} type="text"/><br />
                {/* Room: <input defaultValue={room} onChange={(e) => { setRoom(e.target.value) }} type="text" /><br /> */}
                {/* Stay from: <input defaultValue={stayFrom} onChange={(e) => { setStayFrom(e.target.value) }} type="text" /><br /> */}
                Join date: <DatePicker selected={joinDate} onChange={(e) => { setJoinDate(e) }} type="text" /><br />
                Department id: <input value={deptId} onChange={(e) => { setDeptId(e.target.value) }} type="text" /><br />
                Salary: <input value={salary} onChange={(e) => { setSalary(e.target.value) }} type="text" /><br />
                {/* Fee: <input defaultValue={fee} onChange={(e) => { setFee(e.target.value) }} type="text" /><br /> */}
                <br /><input type="submit" value="Add" />
            </form>
        </div>
    )
}

export default EditStaff;