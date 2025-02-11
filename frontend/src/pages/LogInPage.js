import React from "react";
import { Formik, Form, Field, ErrorMessage } from "formik";
import { Button, TextField, Container, Typography } from "@mui/material";
import * as Yup from "yup";
import axios from "axios";  
const LogIn = () => {
    const validationSchema = Yup.object({
        email: Yup.string().email("Invalid format").required("Required field"),
        password: Yup.string().min(6, "Minimum 6 characters").required("Required field"),
    });

    const handleSubmit = async (values, { setSubmitting, setErrors }) => {
        try {
            const response = await axios.post("http://api/login", {
                email: values.email,
                password: values.password,
            });

            console.log("Login successful:", response.data);
//
        } catch (error) {
            console.error("There was an error logging in:", error);
            setErrors({ server: "Invalid email or password, please try again." });
        } finally {
            setSubmitting(false);  
        }
    };

    return (
        <Container maxWidth="xs" style={{ backgroundColor: "#FEF0CE", padding: "20px", borderRadius: "8px", marginTop: "50px" }}>
            <Typography variant="h4" align="center" color="#332118" gutterBottom>
                Log In
            </Typography>
            <Formik
                initialValues={{ email: "", password: "" }}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}
            >
                {({ isSubmitting, errors }) => (
                    <Form>
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
                            Log In
                        </Button>
                    </Form>
                )}
            </Formik>
        </Container>
    );
};

export default LogIn;
