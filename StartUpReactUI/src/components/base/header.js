import React, { useState } from "react"
import UserSection from "./headerComponents/UserSection"

export default function Header(props) {
    return (
        <div id="header">
            <p>Конструктор тестов онлайн</p>
            <UserSection currentUser={props.currentUser} setCurrentUser={props.setCurrentUser} />
        </div>
    );
}