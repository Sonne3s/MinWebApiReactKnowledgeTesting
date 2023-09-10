import React, { useState } from "react"
import Constants from "../../utilities/Constants"

export default function AuthForm(props) {
    const initialFormData = Object.freeze({
        login: "",
        password: "",
    });

    const [formData, setFormData] = useState(initialFormData);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name.replaceAll("-", "_")]: e.target.value,
        });
    };

    const handleBack = (e) => {
        e.preventDefault();
        props.setShowingRegistrationForm(true);
    };

    const handleAuthentication = (e) => {
        e.preventDefault();

        const authenticationData = {
            login: formData.login,
            password: formData.password,
        };

        const url = Constants.URLS.API_URL_AUTHENTICATION;

        fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(authenticationData)
        })
            .then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                props.changePage(Constants.CURRENT_PAGE.Home);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    };

    return (
        <div className="auth">
            <form className="auth-form form">
                <div className="header-block">
                    <h1 className="header">Авторизация в системе</h1>
                </div>
                <div className="body-block">
                    <div className="inputs-block">
                        <div className="input-block">
                            <label>Логин:</label>
                            <input name="login" type="text" onChange={handleChange} />
                        </div>
                        <div className="input-block">
                            <label>Пароль:</label>
                            <input name="password" type="password" onChange={handleChange} />
                        </div>
                    </div>
                    <div className="buttons-block">
                        <a href="#" onClick={handleBack}>Зарегистрироваться</a>
                        <button onClick={handleAuthentication}>Войти</button>
                    </div>
                </div>
            </form>
        </div>
    );
}