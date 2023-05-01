import { useParams } from "react-router-dom";
import { useState, useEffect } from "react";
import axiosConfig from "../axiosConfig";
import { useNavigate } from "react-router-dom";
//import TimeField from 'react-simple-timefield';
//import TimePicker from 'react-time-picker';
//import TimeRangePicker from '@wojtekmaj/react-timerange-picker'
import Timekeeper from 'react-timekeeper';
//import "../NoBootstrap.css";


const EditDept = () => {
    const { id } = useParams();
    const [result, setResult] = useState([]);
    const [isReady, setIsReady] = useState(false);
    const [errs, setErrs] = useState([]);
    const navigate = useNavigate();

    const [deptId, setId] = useState("");
    const [name, setName] = useState("");


    useEffect(() => {
        axiosConfig.get("/dept/" + id).then((rsp) => {
            debugger
            // setResult(rsp.data);
            setId(rsp.data.Id);
            setName(rsp.data.Name);
            setIsReady(true);
        }, (err) => {
            debugger
            setErrs(err.response.data);
        })

    }, []);

    const saveDeptEdit = (event) => {
         event.preventDefault();
         var data = {Id:deptId, Name:name};
        axiosConfig.post("/dept/update", data).
             then((rsp) => {
                 debugger;
                navigate({ pathname: '/admin/dept/list' });
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
            <p align="center"><b>Edit department details</b></p>
            <span>{errs.Msg ? errs.Msg : ''}</span>
            <form onSubmit={saveDeptEdit}>
                {/* Name: <input defaultValue={name} onChange={(e) => { setName(e.target.value) }} type="text" /><span>{errs.name ? errs.name[0] : ''}</span><br /> */}
                Department ID: <input defaultValue={deptId} onChange={(e) => { setName(e.target.value) }} type="text" readOnly/><br />
                Name: <input defaultValue={name} onChange={(e) => { setName(e.target.value) }} type="text" /><br />
              
                <br /><input type="submit" value="Save info" />
            </form>
        </div>
    )
}

export default EditDept;