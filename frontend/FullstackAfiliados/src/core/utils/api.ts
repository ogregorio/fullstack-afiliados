import axios from 'axios';

const getToken = (): string | null => {
  const local = localStorage.getItem('user');
  return local ? JSON.parse(local).token : null;
};

const token = getToken();

const apiInstance = axios.create({
  baseURL: 'http://localhost:5001/',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
    ...(token && { 'Authorization': 'Bearer ' + token }),
  },
});

export default apiInstance;