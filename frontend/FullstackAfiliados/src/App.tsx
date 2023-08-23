import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import {ThemeProvider} from './theme';
import './langs/i18n';
import Login from '@pages/login';
import Header from '@cp/molecules/header';
import Footer from '@cp/molecules/footer';
import Dashboard from '@pages/dashboard';
import { UserProvider } from '@core/contexts/userContext';

export default function App() {
  return (
    <UserProvider>
      <ThemeProvider>
        <header>
          <Header />
        </header>
        <Router>
          <Routes>
            <Route path='/login' element={<Login />} />
            <Route path='/dashboard/*' element={<Dashboard />} />
          </Routes>
        </Router>
        <footer>
          <Footer />
        </footer>
      </ThemeProvider>
    </UserProvider>
  );
}
