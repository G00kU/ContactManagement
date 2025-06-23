import React, { useState, useEffect } from "react";
import { Table, Button, Container, Row, Col } from "react-bootstrap";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import DeleteModal from "../components/ContactDeleteModal";
import { deleteContactById, getAllContacts } from "../config/apiconfig";
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
    console.log(contacts, 'contact')

    const currentContacts = contacts.slice(indexOfFirstContact, indexOfLastContact);
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
    const deleteContact = async (id) => {
        try {
            const token = localStorage.getItem("TOKEN");
            const response = await fetch(deleteContactById + '/' + id, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            });
            const data = await response.json();
            setTimeout(() => {
                setLoading(false);
            }, 2000);
        } catch (err) {
            setLoading(false);
        }
    };

    const fetchContacts = async () => {
        try {
            const token = localStorage.getItem("TOKEN");
            const response = await fetch(getAllContacts, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            });
            const data = await response.json();
            setContacts(data);
            setTimeout(() => {
                setLoading(false);
            }, 2000);
        } catch (err) {
            setLoading(false);
        }
    };


    useEffect(() => {
        fetchContacts();
    }, []);

    const handleEditClick = (contact) => {
        navigate(`/edit-contact/${contact.contactId}`);
    };
    if (loading)
        return <>
            <LoadingSpinner />
        </>
    return (<>

        <Container className="mt-4" variant="light">
            <Row>
                <Col>
                    <div className="d-flex my-4">
                        <h2>Contact Dashboard</h2>
                        <Button variant="light" className="mb-3 ms-auto" as={Link} to="/edit-contact/0">
                            <img src="./images/add.svg" />
                        </Button>
                    </div>
                    <Table striped bordered hover responsive>
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
                                    <td colSpan="5" className="text-center">No records found</td>
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
                                                onClick={() => handleEditClick(contact)}
                                            />
                                            <img
                                                className="mx-2 pointer-cursor"
                                                src="./images/delete.svg"
                                                onClick={() => { handleDeleteClick(contact.contactId) }}
                                            />
                                        </td>
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </Table>
                    <div className="d-flex justify-content-center m-2">
                        <Button
                            disabled={currentPage === 1}
                            onClick={() => handlePageChange(currentPage - 1)}
                            variant={"outline-dark"}
                        >
                            <img src="./images/lesserThan.svg" />
                        </Button>
                        {[...Array(totalPages)].map((_, index) => (
                            <Button
                                key={index}
                                variant={currentPage === index + 1 ? "dark" : "outline-dark"}
                                onClick={() => handlePageChange(index + 1)}
                                className="mx-1"
                            >
                                {index + 1}
                            </Button>
                        ))}
                        <Button
                            disabled={currentPage === totalPages}
                            onClick={() => handlePageChange(currentPage + 1)}
                            variant={"outline-dark"}
                        >
                            <img src="./images/geaterThan.svg" />
                        </Button>
                    </div>
                </Col>
            </Row>
        </Container >
        <DeleteModal
            show={showDeleteModal}
            onHide={handleCloseDeleteModal}
            contactId={selectedContactId}
            handleDelete={handleDeleteContact}
        ></DeleteModal>
    </>
    );
};

export default ContactDashboard;

const contactsList = [
    {
        "ContactId": 1,
        "FirstName": "John",
        "LastName": "Doe",
        "Email": "john.doe@example.com",
        "PhoneNumber": "123-456-7890",
        "Address": "123 Main St",
        "City": "Somewhere",
        "State": "NY",
        "Country": "USA",
        "PostalCode": "10001"
    },
    {
        "ContactId": 2,
        "FirstName": "Jane",
        "LastName": "Smith",
        "Email": "jane.smith@example.com",
        "PhoneNumber": "987-654-3210",
        "Address": "456 Oak St",
        "City": "Anywhere",
        "State": "CA",
        "Country": "USA",
        "PostalCode": "90001"
    },
    {
        "ContactId": 3,
        "FirstName": "Alice",
        "LastName": "Johnson",
        "Email": "alice.johnson@example.com",
        "PhoneNumber": "555-123-4567",
        "Address": "789 Pine St",
        "City": "Elsewhere",
        "State": "TX",
        "Country": "USA",
        "PostalCode": "75001"
    },
    {
        "ContactId": 4,
        "FirstName": "Bob",
        "LastName": "Williams",
        "Email": "bob.williams@example.com",
        "PhoneNumber": "111-222-3333",
        "Address": "321 Maple St",
        "City": "Anywhere",
        "State": "FL",
        "Country": "USA",
        "PostalCode": "33001"
    }
];
