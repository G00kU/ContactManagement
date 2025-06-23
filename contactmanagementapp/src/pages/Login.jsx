import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { loginMethod } from '../config/apiconfig';
const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate();
    const handleSubmit = async (e) => {
        e.preventDefault();
        const payload = {
            "username": username,
            "password": password
        }
        const response = await fetch(loginMethod, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        });
        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('TOKEN', data.token);
            console.log('Login successful:', data);
            navigate('/contact-dashboard');
        } else if (response.status === 401) {
            setError('Unauthorized: Incorrect username or password');
        } else {
            console.error('Error:', response.status, response.statusText);
        }

    };

    return (
        <div className="d-flex justify-content-center align-items-center blue-bg" style={{ height: '100vh' }}>
            <div className="login-card p-4 rounded shadow-sm w-25" >
                <div className="text-center mb-4">
                    <img
                        src="/images/logo.jpg"
                        alt="Logo"
                        className="login-logo "
                    />
                </div>

                {error && <div className="alert alert-danger">{error}</div>}
                <form onSubmit={handleSubmit}>
                    <div className="mb-3 d-flex align-items-center">
                        <input
                            type="text"
                            className="form-control"
                            id="username"
                            placeholder="Enter your username"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <div className="mb-3 d-flex align-items-center">
                        <input
                            type="password"
                            className="form-control"
                            id="password"
                            placeholder="Enter your password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>

                    <button type="submit" className="btn btn-primary w-100">Login</button>
                </form>
            </div>
        </div>
    );
};

export default Login;
