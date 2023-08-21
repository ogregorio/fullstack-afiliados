import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import {ThemeProvider} from './theme';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';
import './langs/i18n';
import Login from '@pages/login';

export default function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterMoment}>
      <ThemeProvider>
        <Router>
          <Routes>
            <Route path='/login' element={<Login />} />
          </Routes>
        </Router>
      </ThemeProvider>
    </LocalizationProvider>
  );
}
