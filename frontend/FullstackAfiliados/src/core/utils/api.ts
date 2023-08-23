import axios from 'axios';

const apiInstance = axios.create({
  baseURL: 'http://localhost:5001/',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

const getToken = (): string | null => {
  const local = localStorage.getItem('user');
  return local ? JSON.parse(local).token : null;
};

const setAuthorizationHeader = (token: string | null) => {
  if (token) {
    apiInstance.defaults.headers.common['Authorization'] = 'Bearer ' + token;
  } else {
    delete apiInstance.defaults.headers.common['Authorization'];
  }
};

const configureInterceptor = () => {
  const token = getToken();
  setAuthorizationHeader(token);

  apiInstance.interceptors.request.use((config) => {
    const updatedToken = getToken();
    if (updatedToken) {
      config.headers['Authorization'] = 'Bearer ' + updatedToken;
    }
    return config;
  });
};

configureInterceptor();

export default apiInstance;
