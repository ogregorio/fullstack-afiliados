import { Button, TextField, Typography } from '@mui/material';
import style from './styles.module.sass';
import { useAuth } from '@core/hooks/useAuth';

export default function Login() {
  const { handleLogin } = useAuth();

  const [formData, setFormData] = React.useState({
    identifier: '',
    password: '',
  });

  const [error, setError] = React.useState<string | null>(null);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    try {
      await handleLogin(formData.identifier, formData.password, setError);
    } catch (error) {
      setError(t('login.error.login-failed'));
    }
  };

  React.useEffect(() => {
    localStorage.clear();
  }, []);
  
  return (
    <form className={style.Form} onSubmit={handleSubmit}>
      <Typography variant="h3">
        {t('login.title')}
      </Typography>
      <TextField
        label={t('login.username')}
        name="identifier"
        value={formData.identifier}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      <TextField
        label={t('login.password')}
        type="password"
        name="password"
        value={formData.password}
        onChange={handleChange}
        fullWidth
        margin="normal"
      />
      {error && (
        <Typography sx={{ color: 'red' }} variant="caption">
          {error}
        </Typography>
      )}
      <Button type="submit" variant="contained" color="primary">
        {t('login.button')}
      </Button>
    </form>
  );
}
