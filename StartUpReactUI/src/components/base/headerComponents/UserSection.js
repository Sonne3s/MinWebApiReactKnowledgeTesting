import React, { useState } from "react"
import Constants from "../../../utilities/Constants"

export default function UserSection(props) {
    const url = Constants.URLS.API_URL_UNAUTHENTICATION;

    const handleUnauthentication = (e) => {
        fetch(url, {
            method: 'GET',
            credentials: 'include'
        })
            .then(() => {
                props.setCurrentUser(undefined);
            })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
    };

    let fullName = (props.currentUser === undefined) ? "" : `${props.currentUser.lastName} ${props.currentUser.firstName} ${props.currentUser.middleName}`;

    return (
        <div id="user-section" className={(props.currentUser === undefined) ? "" : ("authenticated")}>
            {(props.currentUser === undefined) && (
                <div id="unauthenticated-user">
                    <span id="unauthenticated-user-name">Гость</span>
                    <div id="auth-menu">Войти</div>
                </div>
            )}
            {(props.currentUser !== undefined) && (
                <div id="authenticated-user">
                    <span id="authenticated-user-name">{fullName}</span>
                    <div id="user-menu">
                        <span className="user-menu-name">{fullName}</span>
                        <span>Личный кабинет</span>
                        <span>Статистика</span>
                        <span onClick={handleUnauthentication}>Выйти</span>
                    </div>
                </div>
            )}
        </div>
    );
}