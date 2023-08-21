import {ThemeProvider} from './theme';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';
import './langs/i18n';

export default function App() {
  return (
      <LocalizationProvider dateAdapter={AdapterMoment}>
        <ThemeProvider>
        </ThemeProvider>
      </LocalizationProvider>
  );
}
