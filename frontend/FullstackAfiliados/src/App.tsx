import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import {ThemeProvider} from './theme';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';
import './langs/i18n';
import Login from '@pages/login';
import Header from '@cp/molecules/header';
import Footer from '@cp/molecules/footer';
import Dashboard from '@pages/dashboard';

export default function App() {
  return (
    <LocalizationProvider dateAdapter={AdapterMoment}>
      <ThemeProvider>
        <header>
          <Header />
        </header>
        <Router>
          <Routes>
            <Route path='/login' element={<Login />} />
            <Route path='/dashboard' element={<Dashboard />} />
          </Routes>
        </Router>
        <footer>
          <Footer />
        </footer>
      </ThemeProvider>
    </LocalizationProvider>
  );
}
