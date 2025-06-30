import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Layout from "./shared/Layout";
import ContactDashboard from "./pages/ContactDashboard";
import EditContact from "./pages/EditContact";
// import AddContact from "./pages/AddContact";
import Login from "./pages/Login";
import "./App.css";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/" element={<Layout />}>
          <Route path="contact-dashboard" element={<ContactDashboard />} />
          <Route path="edit-contact/:id" element={<EditContact />} />
          {/* <Route path="add-contact" element={<AddContact />} /> */}
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
