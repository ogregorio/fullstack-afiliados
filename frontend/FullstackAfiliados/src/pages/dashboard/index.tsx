import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import DashboardIcon from '@mui/icons-material/Dashboard';
import ListAltIcon from '@mui/icons-material/ListAlt';
import ExitToAppIcon from '@mui/icons-material/ExitToApp';
import styles from './styles.module.sass';
import { Route, Routes, useNavigate } from 'react-router-dom';
import Upload from './upload';
import { logout } from '@core/services/auth';
import Salesmans from './salesman';
import TransactionsPage from './salesman/:id';

const TOP_BUTTONS = [
  {
    link: '/dashboard/upload',
    text: t('menu.upload'),
    icon: <DashboardIcon />,
  },
  {
    link: '/dashboard/salesmans',
    text: t('menu.transactions'),
    icon: <ListAltIcon />,
  },
];

export default function Dashboard() {
  const navigate = useNavigate();
    
  return (
    <div className={styles.Dashboard}>
      <nav className={styles.Sidebar}>
        <List>
          {TOP_BUTTONS.map((button) => (
            <React.Fragment key={button.link}>
              <ListItemButton
                onClick={
                  () => navigate(button.link)
                }
                className={styles.ListItem}
              >
                <ListItemIcon className={styles.ListItemIcon}>
                  {button.icon}
                </ListItemIcon>
                <ListItemText primary={button.text} />
              </ListItemButton>
            </React.Fragment>
          ))}
        </List>
        <List className={styles.BottomList}>
          <ListItemButton 
            onClick={() => logout()} 
            className={styles.ExitButton}
          >
            <ListItemIcon>
              <ExitToAppIcon />
            </ListItemIcon>
            <ListItemText primary={t('menu.exit')} />
          </ListItemButton>
        </List>
      </nav>
      <main className={styles.Content}>
        <Routes>
          <Route path="upload/*" element={<Upload />} />
          <Route path="salesmans/*" element={<Salesmans />} />
          <Route path="salesmans/:id" element={<TransactionsPage />} />
        </Routes>
      </main>
    </div>
  );
}