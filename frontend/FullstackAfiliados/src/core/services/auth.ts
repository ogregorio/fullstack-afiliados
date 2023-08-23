
import { ENDPOINTS } from '@core/constants/endpoints';
import apiInstance from '@core/utils/api';
import { User, Login } from 'src/types/user.type';

const login = async(login: Login): Promise<User|undefined> => {
  try {
    const reponse = await apiInstance.post(ENDPOINTS.AUTH, login);
    return reponse.data;
  } catch (err) {
    return undefined;
  }
};

const logout = (): void => {
  window.location.href = '/login';
};

export {
  login,
  logout
};