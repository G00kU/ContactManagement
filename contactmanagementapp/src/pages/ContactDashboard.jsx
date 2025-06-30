import React, { useState, useEffect } from "react";
import { Table, Button, Container, Row, Col } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import DeleteModal from "../components/ContactDeleteModal";
import { contactActionAPI } from "../config/apiconfig";
import LoadingSpinner from "../shared/Loader";

const ContactDashboard = () => {
    const navigate = useNavigate();
    const [contacts, setContacts] = useState([]);
    const [loading, setLoading] = useState(true);

    const [showDeleteModal, setShowDeleteModal] = useState(false);
    const [selectedContactId, setSelectedContactId] = useState(null);

    const [currentPage, setCurrentPage] = useState(1);
    const itemsPerPage = 10;
    const totalPages = Math.ceil(contacts.length / itemsPerPage);

    const indexOfLastContact = currentPage * itemsPerPage;
    const indexOfFirstContact = indexOfLastContact - itemsPerPage;
    const currentContacts = contacts.slice(indexOfFirstContact, indexOfLastContact);

    const fetchContacts = async () => {
        try {
            const token = localStorage.getItem("TOKEN");
            const response = await fetch(contactActionAPI, {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${token}`,
                },
            });
            const data = await response.json();
            setContacts(data);
            setTimeout(() => setLoading(false), 1000);
        } catch (err) {
            setLoading(false);
        }
    };

    const deleteContact = async (id) => {
        try {
            const token = localStorage.getItem("TOKEN");
            await fetch(`${contactActionAPI}/${id}`, {
                method: 'DELETE',
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${token}`,
                },
            });
            setTimeout(() => setLoading(false), 1000);
        } catch (err) {
            setLoading(false);
        }
    };

    const handleDeleteContact = (contactId) => {
        setLoading(true);
        deleteContact(contactId);
        setContacts(contacts.filter((contact) => contact.contactId !== contactId));
        setSelectedContactId(null);
    };

    const handleDeleteClick = (contactId) => {
        setSelectedContactId(contactId);
        setShowDeleteModal(true);
    };

    const handleCloseDeleteModal = () => {
        setShowDeleteModal(false);
        setSelectedContactId(null);
    };

    const handlePageChange = (pageNumber) => {
        setCurrentPage(pageNumber);
    };

    const handleEditClick = (contact) => {
        navigate(`/edit-contact/${contact.contactId}`);
    };

    useEffect(() => {
        fetchContacts();
    }, []);

    if (loading) return <LoadingSpinner />;

    return (
        <>
            <Container className="mt-4" variant="light">
                <Row>
                    <Col>
                        <div className="d-flex flex-column flex-sm-row align-items-start align-items-sm-center justify-content-between gap-2 my-4">
                            <h2 className="mb-0">Contact Dashboard</h2>
                            <Button variant="primary" as={Link} to="/edit-contact/0">
                                <img src="./images/add.svg" alt="Add" width="20" height="20" />
                                <span className="ms-2 d-none d-sm-inline">Add Contact</span>
                            </Button>
                        </div>

                        <div className="table-responsive">
                            <Table striped bordered hover responsive="md">
                                <thead>
                                    <tr>
                                        <th>First Name</th>
                                        <th>Last Name</th>
                                        <th>Email</th>
                                        <th>Phone</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {currentContacts.length === 0 ? (
                                        <tr>
                                            <td colSpan="5" className="text-center">
                                                No records found
                                            </td>
                                        </tr>
                                    ) : (
                                        currentContacts.map((contact) => (
                                            <tr key={contact.contactId}>
                                                <td>{contact.firstName}</td>
                                                <td>{contact.lastName}</td>
                                                <td>{contact.email}</td>
                                                <td>{contact.phoneNumber || "N/A"}</td>
                                                <td>
                                                    <img
                                                        className="mx-2 pointer-cursor"
                                                        src="./images/edit.svg"
                                                        alt="Edit"
                                                        width="20"
                                                        height="20"
                                                        role="button"
                                                        onClick={() => handleEditClick(contact)}
                                                    />
                                                    <img
                                                        className="mx-2 pointer-cursor"
                                                        src="./images/delete.svg"
                                                        alt="Delete"
                                                        width="20"
                                                        height="20"
                                                        role="button"
                                                        onClick={() => handleDeleteClick(contact.contactId)}
                                                    />
                                                </td>
                                            </tr>
                                        ))
                                    )}
                                </tbody>
                            </Table>
                        </div>

                        <div className="d-flex justify-content-center flex-wrap gap-2 m-2">
                            <Button
                                disabled={currentPage === 1}
                                onClick={() => handlePageChange(currentPage - 1)}
                                variant="outline-dark"
                            >
                                <img src="./images/lesserThan.svg" alt="Previous" width="16" />
                            </Button>
                            {[...Array(totalPages)].map((_, index) => (
                                <Button
                                    key={index}
                                    variant={currentPage === index + 1 ? "dark" : "outline-dark"}
                                    onClick={() => handlePageChange(index + 1)}
                                    className="px-3"
                                >
                                    {index + 1}
                                </Button>
                            ))}
                            <Button
                                disabled={currentPage === totalPages}
                                onClick={() => handlePageChange(currentPage + 1)}
                                variant="outline-dark"
                            >
                                <img src="./images/geaterThan.svg" alt="Next" width="16" />
                            </Button>
                        </div>
                    </Col>
                </Row>
            </Container>

            <DeleteModal
                show={showDeleteModal}
                onHide={handleCloseDeleteModal}
                contactId={selectedContactId}
                handleDelete={handleDeleteContact}
            />
        </>
    );
};

export default ContactDashboard;
