import axios from 'axios';

const apiInstance = axios.create({
  baseURL: 'http://localhost:5001/',
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiInstance;