import { Link } from 'react-router-dom';
const RcpLogin = () => {
    return (
        // <nav class="navbar navbar-default">
        <nav class="navbar navbar-expand-sm bg-light justify-content-center">
            <div align="center">
                <text><b>======== Receptionist ========</b></text><br/>
                <span> <Link to="/receptionist/dashboard">Dashboard </Link> </span>|
                <span> <Link to="/receptionist/doctors"> Doctors </Link> </span>|
                <span> <Link to="/receptionist/appointment/all"> Appointments </Link></span>|
                <span> <Link to="/admin/dept/list"> Departments </Link></span>|
                <span> <Link to="/receptionist/patient/all"> Patients </Link></span>|
                <span> <Link to="/receptionist/pathology"> Pathology </Link></span>|
                <span> <Link to="/receptionist/ipd/admit"> IPD Admission </Link></span>
                &emsp; &emsp; &emsp; &emsp;

                {/* <span> <Link to="/editProfile"> Edit profile</Link> </span>|
            <span> <Link to="/cart"> Cart</Link> </span>|
            <span> <Link to="/orders"> Orders</Link> </span>|
            <span> <Link to="/expense/history"> Expense History</Link> </span>|  */}
                <span> <Link to="/logout"> Logout</Link></span>

            </div>
        </nav>
    )
}
export default RcpLogin;
