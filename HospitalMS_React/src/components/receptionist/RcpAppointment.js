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


const RcpAppointment = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [errs, setErrs] = useState([]);
    const navigate = useNavigate();

    const [doctorId, setDoctorId] = useState(id);
    const [patientId, setPatientId] = useState("");
    const [scheduleDate, setScheduleDate] = useState(new Date());
    const [scheduleTime, setScheduleTime] = useState("5:00 pm");

    const [showTime1, setShowTime1] = useState(false);
    const [showTime2, setShowTime2] = useState(false);

    const BookAppointment = (event) => {
         event.preventDefault();
         var data = {DoctorId:doctorId, PatientId:patientId,ScheduleDate:scheduleDate,ScheduleTime:scheduleTime};
        axiosConfig.post("/appointment/add", data).
             then((rsp) => {
                 debugger;
               // navigate({ pathname: '/admin/doctor/list' });
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
            <p align="center"><b>Book an appointment</b></p>
            <span>{errs.Msg ? errs.Msg : ''}</span>
            <form onSubmit={BookAppointment}>
                Doctor ID: <input defaultValue={doctorId ? doctorId : ""} onChange={(e) => { setDoctorId(e.target.value) }} type="text" /><br />
                Patient ID: <input value={patientId} onChange={(e) => { setPatientId(e.target.value) }} type="text" /><br />
                Schedule date: <DatePicker selected={scheduleDate} onChange={(e) => { setScheduleDate(e) }} type="text" /><br />
                Schedule Time: <input value={scheduleTime} onClick={() => { setShowTime1(true) }} type="text" readOnly /><br />
                {showTime1 &&
                    <Timekeeper time={scheduleTime} onChange={(e) => { setScheduleTime(e.formatted12) }}
                        onDoneClick={() => setShowTime1(false)}
                        switchToMinuteOnHourSelect />
                }

                <br /><input type="submit" value="Proceed" />
            </form>
        </div>
    )
}

export default RcpAppointment;