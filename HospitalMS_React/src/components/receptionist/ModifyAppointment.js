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



const ModifyAppointment = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [errs, setErrs] = useState([]);
    const navigate = useNavigate();

    const [doctorId, setDoctorId] = useState("");
    const [patientId, setPatientId] = useState("");
    const [scheduleDate, setScheduleDate] = useState(new Date());
    const [scheduleTime, setScheduleTime] = useState("");
    const [availableTime, setAvailableTime] = useState([]);
    const [isPaidChecked, setIsPaidChecked] = useState(false);
    const [fee, setFee] = useState("");


    // const [showTime1, setShowTime1] = useState(false);
    // const [showTime2, setShowTime2] = useState(false);

    useEffect(() => {
        axiosConfig.get("/appointment/" + id).then((rsp) => {
            debugger
            //setResult(rsp.data);
            setDoctorId(rsp.data.Doctor.Id);
            setPatientId(rsp.data.Patient.Id);
            setScheduleDate(new Date(rsp.data.ScheduleDate));
            setScheduleTime(rsp.data.ScheduleTime);
            setFee(rsp.data.Fee);
            (rsp.data.Status === "Paid") ? setIsPaidChecked(true) : setIsPaidChecked(false)

            setIsReady(true);
        }, (err) => {
            debugger
            //  setErrs(err.response.data);
        })

    }, []);


    const ModifyAppointment = (event) => {
        event.preventDefault();
        var data = { Id: id, DoctorId: doctorId, PatientId: patientId, ScheduleDate: scheduleDate.toLocaleDateString('en-CA'), ScheduleTime: scheduleTime, Status: (isPaidChecked) ? "Paid" : "Open" };
        debugger;
        axiosConfig.post("/appointment/update", data).
            then((rsp) => {
                debugger;
                navigate({ pathname: '/receptionist/appointment/all' });
            }, (err) => {
                debugger;
                setErrs(err.response.data);
            })
    }

    const handleDateChange = (date) => {
        setAvailableTime([]);
        setScheduleDate("");
        setScheduleDate(date);
        //  setScheduleTime("");
        // const newDate = new Date(date.setDate(scheduleDate.getDate() + 1));
        // const dateOnly = date.toISOString().substring(0, 10);
        const dateOnly = date.toLocaleDateString('en-CA');
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
    const handleCheckboxChange = () => {
        setIsPaidChecked(!isPaidChecked);
    }

    if (!isReady) {
        return <h2 align="center">Page loading....</h2>
    }

    return (
        <div>
            <br /><br />
            <p align="center"><b>Book an appointment</b></p>
            <span>{errs.Msg ? errs.Msg : ''}</span>
            <form onSubmit={ModifyAppointment}>
                Doctor ID: <input defaultValue={doctorId ? doctorId : ""} onChange={(e) => { setDoctorId(e.target.value) }} type="text" readOnly /><br />
                Patient ID: <input defaultValue={patientId} onChange={(e) => { setPatientId(e.target.value) }} type="text" readOnly /><br />
                Schedule date: <DatePicker dateFormat="yyyy-MM-dd" selected={scheduleDate} onChange={(e) => { handleDateChange(e) }} type="text" /><br />
                Schedule Time:
                <select value={scheduleTime} onChange={(e) => { setScheduleTime(e.target.value) }}>
                    <option value={scheduleTime}>{scheduleTime}</option>
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

                <br /><input type="submit" value="Update" />
            </form>
        </div>
    )
}

export default ModifyAppointment;