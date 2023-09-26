import React, { useState } from "react"
import Constants from "../utilities/Constants"

import AuthForm from "./auth/AuthForm"
import RegistrationForm from "./auth/RegistrationForm"

export default function AuthPage(props) {
    const [showingRegistrationForm, setShowingRegistrationForm] = useState(false);

    return (
        <div className="auth-page">
            {!showingRegistrationForm && <AuthForm setShowingRegistrationForm={setShowingRegistrationForm} changePage={props.changePage} setCurrentUser={props.setCurrentUser} />}
            {showingRegistrationForm && <RegistrationForm setShowingRegistrationForm={setShowingRegistrationForm} changePage={props.changePage} />}
        </div>
    );
}
