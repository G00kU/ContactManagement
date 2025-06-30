import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Form, Button, Container, Row, Col } from "react-bootstrap";
import { contactActionAPI } from "../config/apiconfig";

const EditContact = () => {
    const { id } = useParams();
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        email: "",
        phoneNumber: "",
        address: "",
        city: "",
        state: "",
        country: "",
        postalCode: "",
    });

    useEffect(() => {
        const fetchContact = async () => {
            const token = localStorage.getItem("TOKEN");
            const response = await fetch(contactActionAPI + '/' + id, {
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            });
            const contact = await response.json();
            if (contact) {
                setFormData({
                    contactId: contact.contactId || 0,
                    firstName: contact.firstName,
                    lastName: contact.lastName,
                    email: contact.email,
                    phoneNumber: contact.phoneNumber || "",
                    address: contact.address || "",
                    city: contact.city || "",
                    state: contact.state || "",
                    country: contact.country || "",
                    postalCode: contact.postalCode || "",
                });

            }
        };
        if (parseInt(id) > 0)
            fetchContact();
    }, [id]);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };
    const handleSave = async () => {
        try {
            debugger;
            const payload = {
                contactId: formData.contactId || 0,
                firstName: formData.firstName,
                lastName: formData.lastName,
                email: formData.email || "",
                phoneNumber: formData?.phoneNumber || "",
                address: formData?.address || "",
                city: formData?.city || "",
                state: formData?.state || "",
                country: formData?.country || "",
                postalCode: formData?.postalCode || "",
                createdAt: new Date().toISOString(),
                modifiedAt: new Date().toISOString(),
                gender: "UnKnown"
            };
            const token = localStorage.getItem("TOKEN");
            const response = await fetch(contactActionAPI, {
                method: payload.contactId == 0 ? 'POST' : 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                },
                body: JSON.stringify(payload)
            });
            if (response.ok) {
                const result = await response.json();
                console.log('Contact saved successfully:', result);
                navigate('/contact-dashboard');
            } else {
                const error = await response.json();
                console.error('Error saving contact:', error);
                alert('Failed to save contact!');
            }
        } catch (error) {
            console.error('Network error:', error);
            alert('An error occurred while saving the contact!');
        }
    };

    const handleCancel = () => {
        navigate('/contact-dashboard');
    };

    return (
        <div>
            <Container fluid className="px-3 px-md-5">
                <Row className="justify-content-center">
                    <Col xs={12} md={10} lg={8} className="my-4">
                        <Form>
                            <Row>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formFirstName">
                                        <Form.Label>First Name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="firstName"
                                            value={formData.firstName}
                                            onChange={handleInputChange}
                                            placeholder="Enter First Name"
                                        />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formLastName">
                                        <Form.Label>Last Name</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="lastName"
                                            value={formData.lastName}
                                            onChange={handleInputChange}
                                            placeholder="Enter Last Name"
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <Row>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formEmail">
                                        <Form.Label>Email</Form.Label>
                                        <Form.Control
                                            type="email"
                                            name="email"
                                            value={formData.email}
                                            onChange={handleInputChange}
                                            placeholder="Enter Email"
                                        />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formPhoneNumber">
                                        <Form.Label>Phone Number</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="phoneNumber"
                                            value={formData.phoneNumber}
                                            onChange={handleInputChange}
                                            placeholder="Enter Phone Number"
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <Row>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formAddress">
                                        <Form.Label>Address</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="address"
                                            value={formData.address}
                                            onChange={handleInputChange}
                                            placeholder="Enter Address"
                                        />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formCity">
                                        <Form.Label>City</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="city"
                                            value={formData.city}
                                            onChange={handleInputChange}
                                            placeholder="Enter City"
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <Row>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formState">
                                        <Form.Label>State</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="state"
                                            value={formData.state}
                                            onChange={handleInputChange}
                                            placeholder="Enter State"
                                        />
                                    </Form.Group>
                                </Col>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formCountry">
                                        <Form.Label>Country</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="country"
                                            value={formData.country}
                                            onChange={handleInputChange}
                                            placeholder="Enter Country"
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <Row>
                                <Col xs={12} md={6} className="mb-3">
                                    <Form.Group controlId="formPostalCode">
                                        <Form.Label>Postal Code</Form.Label>
                                        <Form.Control
                                            type="text"
                                            name="postalCode"
                                            value={formData.postalCode}
                                            onChange={handleInputChange}
                                            placeholder="Enter Postal Code"
                                        />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <div className="d-grid gap-2  justify-content-end mt-3">
                                <Button variant="primary" onClick={handleSave} className="mb-2 mb-sm-0">
                                    Save
                                </Button>
                                <Button variant="outline-dark" onClick={handleCancel}>
                                    Cancel
                                </Button>
                            </div>
                        </Form>
                    </Col>
                </Row>
            </Container>

        </div>
    );
};

export default EditContact;



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
