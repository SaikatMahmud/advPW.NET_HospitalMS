// import Reg from "./customer/Reg";
import BeforeLogin from "./layouts/BeforeLogin";
import AdminLogin from "./layouts/AdminLogin";
import RcpLogin from "./layouts/RcpLogin";
import AfterLogin from "./layouts/AfterLogin";
// import AboutUs from "./AboutUs";
// import Home from "./customer/Home";
import Login from "./Login";
import AdminDashboard from "./admin/AdminDashboard";
import AdminDoctor from "./admin/AdminDoctor";
import AdminDept from "./admin/AdminDept";
import AdminFinance from "./admin/AdminFinance";
import AdminPatient from "./admin/AdminPatient";
import AdminStaff from "./admin/AdminStaff";
import AdminStat from "./admin/AdminStat";
import AddDoctor from "./admin/AddDoctor";
import AddStaff from "./admin/AddStaff";
import EditDoctor from "./admin/EditDoctor";
import EditStaff from "./admin/EditStaff";
import EditDept from "./admin/EditDept";
import EditPatient from "./receptionist/EditPatient";
import EditPatientAdmin from "./admin/EditPatientAdmin";
import LeaveApplicationAll from "./admin/LeaveApplicationsAll";

import RcpDashboard from "./receptionist/RcpDashboard";
import RcpAppointment from "./receptionist/RcpAppointment";
import RcpDoctor from "./receptionist/RcpDoctor";
import RcpIPDAdmit from "./receptionist/RcpIPDAdmit";
import RcpPathology from "./receptionist/RcpPathology";
import RcpPatient from "./receptionist/RcpPatient";
import RcpDeptWiseDoctor from "./receptionist/RcpDeptWiseDoctor";
import RcpBookAppointment from "./receptionist/RcpBookAppointment";
import ModifyAppointment from "./receptionist/ModifyAppointment";
import AddPatient from "./receptionist/AddPatient";
// import ContactUs from "./ContactUs";
// import SearchResult from "./customer/SearchResult";
// import Cart from "./customer/Cart";
// import Orders from "./customer/Orders";
// import EditProfile from "./customer/EditProfile";
// import Logout from "./customer/Logout";
import Logout from "./Logout";
// import OrderDetails from "./customer/OrderDetails";
// import OrderConfirmPage from "./customer/OrderConfirmPage";
// import MedicineDetails from "./customer/MedicineDetails";
// import AddReview from "./customer/AddReview";
// import ExpenseHistory from "./customer/ExpenseHistory";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { useState, useEffect } from "react";
//====================================================================================================================================

const Main = () => {
    const [logIn, setLogIn] = useState(false);
    // const check=()=>{
    //     if (localStorage.getItem('_authToken')) {
    //         setLogIn(true);
    //     }
    // }
    // useEffect(() => {
    //     if (localStorage.getItem('_authToken')) {
    //         setLogIn(true);
    //     }
    // }, []);
    return (
        <div>
            <BrowserRouter>
                {(localStorage.getItem('_authToken')) ? 
                ((localStorage.getItem('_HMSuserType') == 'Admin')? <AdminLogin/> : <RcpLogin/>) 
                : <BeforeLogin />}
                <Routes>
                    <Route path="/" element={<Login />} />
                    <Route path="/login" element={<Login />} />
                    <Route path="/logout" element={<Logout />} />
                    {/* <Route path="/registration" element={<Reg />} />
                    <Route path="/aboutUs" element={<AboutUs />} />
                    <Route path="/contactUs" element={<ContactUs />} />
                    <Route path="/search" element={<SearchResult />} />
                    <Route path="/editProfile" element={<EditProfile />} />
                    <Route path="/cart" element={<Cart />} />
                    <Route path="/orders" element={<Orders />} />
                    <Route path="/orderConfirm" element={<OrderConfirmPage />} />
                    <Route path="/details/order/:id" element={<OrderDetails />} />
                    <Route path="/medicine/details/:id" element={<MedicineDetails />} /> */}

                    <Route path="/admin/dashboard" element={<AdminDashboard />} />
                    <Route path="/admin/doctor/list" element={<AdminDoctor />} />
                    <Route path="/admin/dept/list" element={<AdminDept />} />
                    <Route path="/admin/finance" element={<AdminFinance />} />
                    <Route path="/admin/patient/list" element={<AdminPatient />} />
                    <Route path="/admin/staff/list" element={<AdminStaff />} />
                    <Route path="/admin/statistics" element={<AdminStat />} />
                    <Route path="/admin/doctor/add" element={<AddDoctor />} />
                    <Route path="/admin/staff/add" element={<AddStaff />} />
                    <Route path="/doctor/edit/:id" element={<EditDoctor />} />
                    <Route path="/staff/edit/:id" element={<EditStaff />} />
                    <Route path="/dept/edit/:id" element={<EditDept />} />
                    <Route path="/admin/patient/edit/:id" element={<EditPatientAdmin />} /> 
                    <Route path="/admin/leaveapplications/all" element={<LeaveApplicationAll/>} /> 

                    <Route path="/receptionist/dashboard" element={<RcpDashboard />} />
                    <Route path="/receptionist/appointment/all" element={<RcpAppointment />} />
                    <Route path="/appointment/doctor/:id/:fee" element={<RcpBookAppointment />} />
                    <Route path="/receptionist/doctors" element={<RcpDoctor />} />
                    <Route path="/receptionist/ipd/admit" element={<RcpIPDAdmit />} />
                    <Route path="/receptionist/pathology" element={<RcpPathology />} />
                    <Route path="/receptionist/patient/all" element={<RcpPatient />} />
                    <Route path="/receptionist/doctor/dept/:id" element={<RcpDeptWiseDoctor />} />
                    <Route path="/appointment/modify/:id" element={<ModifyAppointment />} />
                    <Route path="/patient/edit/:id" element={<EditPatient />} />
                    <Route path="/patient/register" element={<AddPatient />} />


                    

                    {/* <Route path="/order_review" element={<AddReview/>} />
                    <Route path="/expense/history" element={<ExpenseHistory/>} /> */}

                </Routes>
            </BrowserRouter>

        </div>
    )
}
export default Main;