import React, { useState } from "react"

import Constants from "./utilities/Constants"

import AuthPage from "./components/AuthPage"
import HomePage from "./components/HomePage"

function App() {
  const [currentPage, setCurrentPage] = useState(Constants.CURRENT_PAGE.Auth);

  function renderSwitch() {
    switch (currentPage) {
      case Constants.CURRENT_PAGE.Auth:
        return <AuthPage onPostCreated={onPostCreated} changePage={changePage} />
      case Constants.CURRENT_PAGE.Home:
        return <HomePage onPostCreated={onPostCreated} changePage={changePage} />
      default:
        return "";
    }
  }

  return (renderSwitch());


  function onPostCreated(createdPost) {

    if (createdPost === null) {
      return;
    }

    alert(`Post successfully created. After clicking OK, your new post titled '${createdPost.title}' will show up in the table below.`);
  }

  function changePage(page) {
    setCurrentPage(page);
  }
}

export default App;