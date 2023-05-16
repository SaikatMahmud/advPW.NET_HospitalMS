import { Link } from 'react-router-dom';
const AdminLogin = () => {
    return (
        // <nav class="navbar navbar-default">
        <nav class="navbar navbar-expand-sm bg-light justify-content-center">
        <div align="center">
            <text><b>======== Admin ========</b></text><br/>
            <span> <Link to="/admin/dashboard">Dashboard</Link> </span>|
            <span> <Link to="/admin/doctor/list"> Doctors</Link> </span>|
            <span> <Link to="/admin/staff/list"> Staffs </Link></span>|
            <span> <Link to="/admin/dept/list"> Departments </Link></span>|
            <span> <Link to="/admin/patient/list"> Patients </Link></span>|
            <span> <Link to="/admin/statistics"> Stats </Link></span>|
            <span> <Link to="/admin/leaveapplications/all"> Leave Applications </Link></span>|
            {/* <span> <Link to="/admin/finance"> Finance</Link></span> */}
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
export default AdminLogin;
