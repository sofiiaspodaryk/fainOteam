import React from "react";
import { Formik, Form, Field, ErrorMessage } from "formik";
import { Button, TextField, Container, Typography } from "@mui/material";
import * as Yup from "yup";
import axios from "axios";  

const SignUp = () => {

    const validationSchema = Yup.object({
        username: Yup.string().required("Required field"),
        email: Yup.string().email("Invalid format").required("Required field"),
        password: Yup.string().min(6, "Minimum 6 characters").required("Required field"),
    });

    const handleSubmit = async (values, { setSubmitting, setErrors }) => {
        try {
            const response = await axios.post("http://localhost:5238/fainoteam/register", {
                username: values.username,
                email: values.email,
                password: values.password,
            });
            console.log("Registration successful:", response.data);
        } catch (error) {
            console.error("There was an error registering the user:", error);
            setErrors({ server: "Error during registration, please try again." });
        } finally {
            setSubmitting(false); 
        }
    };

    return (
        <Container maxWidth="xs" style={{ backgroundColor: "#FEF0CE", padding: "20px", borderRadius: "8px", marginTop: "50px" }}>
            <Typography variant="h4" align="center" color="#332118" gutterBottom>
                Sign up
            </Typography>
            <Formik
                initialValues={{ username: "", email: "", password: "" }}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}
            >
                {({ isSubmitting, errors }) => (
                    <Form>
                        <Field
                            as={TextField}
                            name="username"
                            label="Name of user"
                            fullWidth
                            margin="normal"
                            style={{ backgroundColor: "#E4D6B4", borderRadius: "4px" }}
                        />
                        <ErrorMessage name="username" component="div" style={{ color: "#892F14" }} />
                        
                        <Field
                            as={TextField}
                            name="email"
                            label="Email"
                            fullWidth
                            margin="normal"
                            style={{ backgroundColor: "#E4D6B4", borderRadius: "4px" }}
                        />
                        <ErrorMessage name="email" component="div" style={{ color: "#892F14" }} />
                        
                        <Field
                            as={TextField}
                            type="password"
                            name="password"
                            label="Password"
                            fullWidth
                            margin="normal"
                            style={{ backgroundColor: "#E4D6B4", borderRadius: "4px" }}
                        />
                        <ErrorMessage name="password" component="div" style={{ color: "#892F14" }} />
                        
                        {errors.server && <div style={{ color: "#892F14" }}>{errors.server}</div>}  {/* Вивести помилки сервера */}
                        
                        <Button type="submit" fullWidth variant="contained" style={{ backgroundColor: "#C56524", color: "#E4D6B4", marginTop: "10px" }} disabled={isSubmitting}>
                            Sign up
                        </Button>
                    </Form>
                )}
            </Formik>
        </Container>
    );
};

export default SignUp;
