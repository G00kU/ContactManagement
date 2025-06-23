import { Navbar, Container, Button } from "react-bootstrap";
import { Link, useNavigate, Outlet } from "react-router-dom";

const Layout = () => {
    const navigate = useNavigate();
    const token = localStorage.getItem('TOKEN');
    const handleLogoutClick = () => {
        localStorage.clear();
        navigate(`/login`);
    };
    if (!token)
        navigate('/login');
    return (
        <div className="d-flex flex-column min-vh-100">
            <Navbar style={{ backgroundColor: "#352949" }}>
                <Container>
                    <Navbar.Brand as={Link} to="/contact-dashboard" className="text-white">
                        CONTACT MANAGEMENT
                    </Navbar.Brand>
                    <Navbar.Collapse className="justify-content-end">
                        <Button variant="light" onClick={() => {
                            handleLogoutClick()
                        }}>
                            <img className="mx-2 pointer-cursor" src="./images/logout.svg" />
                        </Button>
                    </Navbar.Collapse>
                </Container>
            </Navbar>

            <div className="flex-grow-1">
                <Outlet />
            </div>

            <footer className="bg-dark text-white text-center py-3 mt-auto">
                <Container>
                    <p>@2025 Knila IT Solutions. All Rights Reserved.</p>
                </Container>
            </footer>
        </div>
    );
};

export default Layout;
