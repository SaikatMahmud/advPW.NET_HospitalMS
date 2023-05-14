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


const RcpBookAppointment = () => {
    const { id, fee } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [errs, setErrs] = useState([]);
    const navigate = useNavigate();

    const [doctorId, setDoctorId] = useState(id);
    const [patientId, setPatientId] = useState("");
    const [scheduleDate, setScheduleDate] = useState(new Date());
    const [scheduleTime, setScheduleTime] = useState("");
    const [availableTime, setAvailableTime] = useState([]);
    const [isPaidChecked, setIsPaidChecked] = useState(false);

    // const [showTime1, setShowTime1] = useState(false);
    // const [showTime2, setShowTime2] = useState(false);

    const BookAppointment = (event) => {
        event.preventDefault();

        var data = { DoctorId: doctorId, PatientId: patientId, ScheduleDate: scheduleDate.toLocaleDateString('en-CA'), ScheduleTime: scheduleTime, Fee: fee, Status: (isPaidChecked) ? "Paid" : "Open" };
        debugger;
        axiosConfig.post("/appointment/add", data).
            then((rsp) => {
                debugger;
                navigate({ pathname: '/receptionist/appointment/all' });
            }, (err) => {
                debugger;
                setErrs(err.response.data);
            })
    }
    const handleCheckboxChange = () => {
        setIsPaidChecked(!isPaidChecked);
    }

    const handleDateChange = (date) => {
        setAvailableTime([]);
        setScheduleDate("");
        setScheduleDate(date);
        setScheduleTime("");
        // const newDate = new Date(date.setDate(scheduleDate.getDate() + 1));
        // const dateOnly = date.toISOString().substring(0, 10);
        const dateOnly = date.toLocaleDateString('en-CA');
        debugger;
        // setSelectedDate(selectedDateOnly);
        //   debugger;
        //  event.preventDefault();
        // var data = {DoctorId:doctorId, PatientId:patientId,ScheduleDate:scheduleDate,ScheduleTime:scheduleTime};
        axiosConfig.get(`appointment/available/${doctorId}/${dateOnly}`).
            then((rsp) => {
                debugger;
                setAvailableTime(rsp.data.AvailableTimes);
                // navigate({ pathname: '/admin/doctor/list' });
            }, (err) => {
                debugger;
                // setErrs(err.response.data);
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
                Doctor ID: <input defaultValue={doctorId ? doctorId : ""} onChange={(e) => { setDoctorId(e.target.value) }} type="text" readOnly/><br />
                Patient ID: <input value={patientId} onChange={(e) => { setPatientId(e.target.value) }} type="text" /><br />
                Schedule date: <DatePicker dateFormat="yyyy-MM-dd" selected={scheduleDate} onChange={(e) => { handleDateChange(e) }} type="text" /><br />
                Schedule Time:
                <select value={scheduleTime} onChange={(e) => { setScheduleTime(e.target.value) }}>
                    <option value="">Select time</option>
                    {availableTime?.length == 0 && <option value="">No time available</option>}
                    {availableTime?.map((option, index) => (
                        <option key={index} value={option}>{option}</option>
                    ))}
                </select><br />
                Fee: {fee} &nbsp;
                <label>
                    &nbsp;&nbsp;
                    <input
                        type="checkbox"
                        checked={isPaidChecked}
                        onChange={handleCheckboxChange}
                    />
                    Paid
                </label>
                {/* Schedule Time: <input value={scheduleTime} onClick={() => { setShowTime1(true) }} type="text" readOnly /><br />
                {showTime1 &&
                    <Timekeeper time={scheduleTime} onChange={(e) => { setScheduleTime(e.formatted12) }}
                        onDoneClick={() => setShowTime1(false)}
                        switchToMinuteOnHourSelect />
                } */}

                <br /><input type="submit" value="Proceed" />
            </form>
        </div>
    )
}

export default RcpBookAppointment;