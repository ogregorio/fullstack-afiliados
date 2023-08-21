import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Button from '@mui/material/Button';
import LogoImage from '@assets/Logo.svg';
import styles from './styles.module.sass';

export default function Header() {
  return (
    <div className={styles.Header}>
      <Box sx={{flexGrow: 1}}>
        <AppBar position='static' sx={{backgroundColor: 'var(--primary-color)', boxShadow: 'none'}}>
          <Toolbar sx={{justifyContent: 'space-between'}}>
            <Box sx={{display: 'flex', alignItems: 'center'}}>
              <img style={{filter: 'invert(1)', width: '100px'}} src={LogoImage} alt='Logo'/>
              <h1 style={{display: 'none'}}>{(t('title'))}</h1>
            </Box>
            <Box sx={{display: 'flex'}}>
              <Button href='/' color='inherit'>{(t('home.title'))}</Button>
            </Box>
          </Toolbar>
        </AppBar>
      </Box>
    </div>
  );
}
