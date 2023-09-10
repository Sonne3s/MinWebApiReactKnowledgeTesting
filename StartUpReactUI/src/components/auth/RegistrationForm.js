import React, { useState } from "react"
import Constants from "../../utilities/Constants"

export default function RegistrationForm(props) {
    const initialFormData = Object.freeze({
        login: "",
        password: "",
        password_confirm: "",
        first_name: "",
        last_name: "",
        middle_name: ""
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
        props.setShowingRegistrationForm(false);
    };

    const handleRegistration = (e) => {
        e.preventDefault();

        const registrationData = {
            login: formData.login,
            password: formData.password,
            firstName: formData.first_name,
            lastName: formData.last_name,
            middleName: formData.middle_name
        };

        const url = Constants.URLS.API_URL_REGISTRATION;

        fetch(url, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(registrationData)
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
        <div className="registration">
            <form className="registration-form form">
                <div className="header-block">
                    <h1 className="header">Регистрация в системе</h1>
                </div>
                <div className="body-block">
                    <div className="inputs-block">
                        <div className="input-block">
                            <label>Логин:</label>
                            <input value={formData.login} name="login" type="text" onChange={handleChange} />
                        </div>
                        <div className="input-block">
                            <label>Пароль:</label>
                            <input value={formData.password} name="password" type="password" onChange={handleChange} />
                        </div>
                        <div className="input-block">
                            <label>Повторите пароль:</label>
                            <input value={formData.password_confirm} name="password-confirm" type="password" onChange={handleChange} />
                        </div>
                        <div className="input-block">
                            <label>Имя:</label>
                            <input value={formData.first_name} name="first-name" type="text" onChange={handleChange} />
                        </div>
                        <div className="input-block">
                            <label>Фамилия:</label>
                            <input value={formData.last_name} name="last-name" type="text" onChange={handleChange} />
                        </div>
                        <div className="input-block">
                            <label>Отчество:</label>
                            <input value={formData.middle_name} name="middle-name" type="text" onChange={handleChange} />
                        </div>
                    </div>
                    <div className="buttons-block">
                        <a href="#" onClick={handleBack}>Назад</a>
                        <button type="button" onClick={handleRegistration}>Зарегистрироваться</button>
                    </div>
                </div>
            </form>
        </div>
    );
}