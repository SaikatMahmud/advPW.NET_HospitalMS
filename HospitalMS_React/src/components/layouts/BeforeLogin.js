import { Link } from 'react-router-dom';
const BeforeLogin = () => {
    return (
        // <nav class="navbar navbar-default">
        <nav class="navbar navbar-expand-sm bg-light justify-content-center">
        <div align="center">
            <span> <Link to="/">Home</Link> </span>|
            <span> <Link to="/login"> Login</Link> </span>|
            <span> <Link to="/registration"> Register</Link> </span>|
            <span> <Link to="/aboutUs"> About us</Link> </span>|
            <span> <Link to="/contactUs"> Contact Us</Link></span>
        </div>
        </nav>
    )
}
export default BeforeLogin;
