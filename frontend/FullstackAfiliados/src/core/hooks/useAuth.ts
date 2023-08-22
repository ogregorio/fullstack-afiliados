import { useNavigate } from 'react-router-dom';
import { useContext } from 'react';
import { UserContext } from '@core/contexts/userContext';
import { login } from '@core/services/auth';

export function useAuth() {
  const navigate = useNavigate();
  const { setUser } = useContext(UserContext);

  async function authenticate(username: string, password: string) {
    try {
      const user = await login({ username, password });
      if (user) {
        setUser(user);
        localStorage.setItem('user', JSON.stringify(user));
        return true;
      }
    } catch (error: any) {
      return false;
    }
  }

  async function handleLogin(
    username: string,
    password: string,
    setError: React.Dispatch<React.SetStateAction<string | null>>
  ) {
    const isAuthenticated = await authenticate(username, password);
    if (isAuthenticated) {
      navigate('/dashboard');
    } else {
      setError(t('login.error.login-failed'));
    }
  }

  return { handleLogin };
}
