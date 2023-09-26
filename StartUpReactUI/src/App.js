import React, { useState } from "react"

import Constants from "./utilities/Constants"

import Header from "./components/base/header"

import AuthPage from "./components/AuthPage"
import HomePage from "./components/HomePage"

var timerId;

function App() {
  console.log("App");
  const [currentPage, setCurrentPage] = useState(Constants.CURRENT_PAGE.Auth);
  const [currentUser, setCurrentUser] = useState(undefined);
  clearTimeout(timerId);
  timerId = setTimeout(() => getUserData(), 1);

  function renderPage() {
    if (currentUser === undefined) {
      return <AuthPage changePage={changePage} setCurrentUser={onSetCurrentUser} />
    }
    switch (currentPage) {
      //case Constants.CURRENT_PAGE.Auth:
      //case Constants.CURRENT_PAGE.Home:        
      default:
        return <HomePage changePage={changePage} />
    }
  }

  return (
    <div id="main">
      <Header currentUser={currentUser} setCurrentUser={onSetCurrentUser} />
      {renderPage()}
    </div>
  );

  function onSetCurrentUser(user) {
    setCurrentUser(user);
  }

  function changePage(page) {
    setCurrentPage(page);
  }

  function getUserData() {
    const url = Constants.URLS.API_URL_GET_USER_DATA;

    fetch(url, {
      method: 'GET',
      credentials: 'include'
    })
      .then(response => response.status === 401 ? response : response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        if (responseFromServer.id !== undefined) {
          if (currentUser === undefined || currentUser.id != responseFromServer.id) {
            setCurrentUser(responseFromServer);
          }
        }
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  };
}

export default App;