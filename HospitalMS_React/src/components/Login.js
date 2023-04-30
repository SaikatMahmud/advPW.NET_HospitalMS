import { useState } from "react";
import axiosConfig from './axiosConfig';
import axios from "axios";
import { useNavigate } from "react-router-dom";


const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [errs, setErrs] = useState({});
    const [msg, setMsg] = useState("");
    const navigate = useNavigate();

    const handleSubmit = (event) => {
        event.preventDefault();
        const data = { Username: username, Password: password };
        axiosConfig.post("/login", data).
            then((succ) => {
                debugger;
                localStorage.setItem('_authToken', succ.data.Data.TKey);
                localStorage.setItem('_HMSuserType', succ.data.userType);
                if (succ.data.userType =="Admin") {
                     navigate({ pathname: '/admin/dashboard' });
                    // navigate({ pathname: '/admin/doctor/list' });
                }
                if (succ.data.userType =="Receptionist") {
                    navigate({ pathname: '/receptionist/dashboard' });
                }
                //navigate({ pathname: '/' });
                window.location.reload();
            }, (err) => {
                debugger;
                setErrs(err.response.data);
            })
    }
    return (
        <div align="center">
        <form onSubmit={handleSubmit}>
            <h2>{errs.msg}</h2>
            Username: <input value={username} onChange={(e) => { setUsername(e.target.value) }} type="text" /><span>{errs.username ? errs.username[0] : ''}</span><br />
            Password: <input value={password} onChange={(e) => { setPassword(e.target.value) }} type="password" /><span>{errs.password ? errs.password[0] : ''}</span><br />
            <input type="submit" value="Login" /><br/>
                <p>{errs.Msg ? errs.Msg : ''}</p>
        </form></div>
    )
}
export default Login;