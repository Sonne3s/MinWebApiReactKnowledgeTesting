const API_BASE_URL_DEVELOPMENT = 'https://localhost:7242';
const API_BASE_URL_PRODUCTION = 'https://appname.azurewebsites.net';

const ENDPOINTS = {
    REGISTRATION: "Registration",
    AUTHENTICATION: "Authentication"
};

const development = {
    API_URL_REGISTRATION: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.REGISTRATION}`,
    API_URL_AUTHENTICATION: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.AUTHENTICATION}`,
}

const production = {
    API_URL_REGISTRATION: `${API_BASE_URL_PRODUCTION}/${ENDPOINTS.REGISTRATION}`,
    API_URL_AUTHENTICATION: `${API_BASE_URL_DEVELOPMENT}/${ENDPOINTS.AUTHENTICATION}`,
}

const Urls = process.env.NODE_ENV === "development" ? development : production;

export default Urls;