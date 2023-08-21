import { createTheme, ThemeProvider as MUIThemeProvider } from '@mui/material/styles';

const theme = createTheme({
  palette: {
    primary: {
      main: '#337cc4',
      dark: '#104b85',
    },
    secondary: {
      main: '#F7DDA0',
      dark: '#915E16',
    },
    common: {
      white: '#fff',
      black: '#2b2b2b',
    },
  },
  typography: {
    fontFamily: [
      'Raleway',
      'sans-serif',
    ].join(','),
    h1: {
      fontFamily: [
        'Tilt Neon',
        'sans-serif',
      ].join(','),
    },
    h2: {
      fontFamily: [
        'Tilt Neon',
        'sans-serif',
      ].join(','),
    },
    h3: {
      fontFamily: [
        'Tilt Neon',
        'sans-serif',
      ].join(','),
    },
    h4: {
      fontFamily: [
        'Tilt Neon',
        'sans-serif',
      ].join(','),
    },
    h5: {
      fontFamily: [
        'Tilt Neon',
        'sans-serif',
      ].join(','),
    },
    h6: {
      fontFamily: [
        'Tilt Neon',
        'sans-serif',
      ].join(','),
    },
  },
});

export function ThemeProvider({children}: any) {
  return (
    <MUIThemeProvider theme={theme}>
      {children}
    </MUIThemeProvider>
  );
}