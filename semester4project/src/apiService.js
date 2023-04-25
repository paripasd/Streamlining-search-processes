import axios from 'axios';

const apiService = axios.create({
  baseURL: 'https://localhost:7018/api/',
});

apiService.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('jwtToken');
    if (token) {
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default apiService;
