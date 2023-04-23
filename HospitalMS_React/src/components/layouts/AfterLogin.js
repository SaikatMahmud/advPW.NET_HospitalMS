import { Link } from 'react-router-dom';
const AfterLogin = () => {
    return (
        // <nav class="navbar navbar-default">
        <nav class="navbar navbar-expand-sm bg-light justify-content-center">
        <div align="center">
            <span> <Link to="/">Home</Link> </span>|
            <span> <Link to="/aboutUs"> About us</Link> </span>|
            <span> <Link to="/contactUs"> Contact Us</Link></span>
            &emsp; &emsp; &emsp; &emsp; 
            
            <span> <Link to="/editProfile"> Edit profile</Link> </span>|
            <span> <Link to="/cart"> Cart</Link> </span>|
            <span> <Link to="/orders"> Orders</Link> </span>|
            <span> <Link to="/expense/history"> Expense History</Link> </span>| 
            <span> <Link to="/logout"> Logout</Link></span>

        </div>
        </nav>
    )
}
export default AfterLogin;
