import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
//import TimeField from 'react-simple-timefield';
//import TimePicker from 'react-time-picker';
//import TimeRangePicker from '@wojtekmaj/react-timerange-picker'
import Timekeeper from 'react-timekeeper';
import "../NoBootstrap.css";


const EditDoctor = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);

    const [dcotorId, setId] = useState("");
    const [name, setName] = useState("");
    const [aboutDoctor, setAboutDoctor] = useState("");
    const [designation, setDesignation] = useState("");
    const [gender, setGender] = useState("");
    const [mobile, setMobile] = useState("");
    const [email, setEmail] = useState("");
    const [username, setUsername] = useState("");
    const [room, setRoom] = useState("");
    const [stayFrom, setStayFrom] = useState("");
    const [stayTill, setStayTill] = useState("");
    const [joinDate, setJoinDate] = useState("");
    const [deptId, setDeptId] = useState("");
    const [salary, setSalary] = useState("");
    const [fee, setFee] = useState("");
    //const [time, setTime] = useState('12:34PM');
    const [showTime1, setShowTime1] = useState(false);
    const [showTime2, setShowTime2] = useState(false);

    useEffect(() => {
        axiosConfig.get("/doctor/" + id).then((rsp) => {
            debugger
            // setResult(rsp.data);
            // setId(rsp.data.Id);
            setName(rsp.data.Name);
            setAboutDoctor(rsp.data.AboutDoctor);
            setDesignation(rsp.data.Designation);
            setGender(rsp.data.Gender);
            setMobile(rsp.data.Mobile);
            setEmail(rsp.data.Email);
            setUsername(rsp.data.Username);
            setRoom(rsp.data.Room);
            setStayFrom(rsp.data.StayFrom);
            setStayTill(rsp.data.StayTill);
            setJoinDate(rsp.data.JoinDate);
            setDeptId(rsp.data.DeptId);
            setSalary(rsp.data.Salary);
            setFee(rsp.data.Fee);
            setIsReady(true);
        }, (err) => {
            debugger
        })

    }, []);

    const saveDoctorEdit = (event) => {
        // event.preventDefault();
        // // var image= new FormData();
        // // image.append('cus_pic',mfile);
        // var data = { name: name, email: email, mobile: mobile, address: address };
        // axiosConfig.post("/doctor/update", data).
        //     then((rsp) => {
        //         setResult(rsp.data);
        //         //setMsg(succ.data.msg);
        //         //window.location.href="/list";
        //         debugger;
        //         setMsg("Profile updated");
        //     }, (err) => {
        //         //  debugger;
        //         setErrs(err.response.data);
        //     })
    }

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div className="noBootstrap">
            <br /><br />
            <p align="center"><b>Edit doctor details</b></p>
            <form onSubmit={saveDoctorEdit}>
                {/* Name: <input defaultValue={name} onChange={(e) => { setName(e.target.value) }} type="text" /><span>{errs.name ? errs.name[0] : ''}</span><br /> */}
                Name: <input defaultValue={name} onChange={(e) => { setName(e.target.value) }} type="text" /><br />
                About doctor: <input defaultValue={aboutDoctor} onChange={(e) => { setAboutDoctor(e.target.value) }} type="text" /><br />
                Designation: <input defaultValue={designation} onChange={(e) => { setDesignation(e.target.value) }} type="text" /><br />
                Gender: <input defaultValue={gender} onChange={(e) => { setGender(e.target.value) }} type="text" /><br />
                Mobile: <input defaultValue={mobile} onChange={(e) => { setMobile(e.target.value) }} type="text" /><br />
                Email: <input defaultValue={email} onChange={(e) => { setEmail(e.target.value) }} type="text" /><br />
                Username: <input defaultValue={username} onChange={(e) => { setUsername(e.target.value) }} type="text" /><br />
                Room: <input defaultValue={room} onChange={(e) => { setRoom(e.target.value) }} type="text" /><br />
                {/* Stay from: <input defaultValue={stayFrom} onChange={(e) => { setStayFrom(e.target.value) }} type="text" /><br /> */}
                Join date: <input defaultValue={joinDate} onChange={(e) => { setJoinDate(e.target.value) }} type="text" /><br />
                Department id: <input defaultValue={deptId} onChange={(e) => { setDeptId(e.target.value) }} type="text" /><br />
                Salary: <input defaultValue={salary} onChange={(e) => { setSalary(e.target.value) }} type="text" /><br />
                Fee: <input defaultValue={fee} onChange={(e) => { setFee(e.target.value) }} type="text" /><br />

                Stay From: <input value={stayFrom} onClick={() => { setShowTime1(true) }} type="text" readOnly /><br />
                {showTime1 &&
                    <Timekeeper time={stayFrom} onChange={(e) => { setStayFrom(e.formatted12) }}
                        onDoneClick={() => setShowTime1(false)}
                        switchToMinuteOnHourSelect />
                }
                Stay till:<input value={stayTill} onClick={() => { setShowTime2(true) }} type="text" readOnly /><br />
                {showTime2 &&
                    <Timekeeper time={stayTill} onChange={(e) => { setStayTill(e.formatted12) }}
                        onDoneClick={() => setShowTime2(false)}
                        switchToMinuteOnHourSelect />
                }


                <br /><input type="submit" value="Save info" />
            </form>
        </div>
    )
}

export default EditDoctor;