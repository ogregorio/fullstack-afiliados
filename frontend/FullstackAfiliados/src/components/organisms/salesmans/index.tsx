import { CircularProgress, Alert, AlertTitle, List, ListItem, ListItemText, Typography, Paper } from '@mui/material';
import useSalesman from '@core/hooks/useSalesman';
import { Salesman } from 'src/types/salesman.type';

export default function SalesmanList() {
  const { loading, data, error } = useSalesman();

  if (loading) {
    return <CircularProgress />;
  }

  if (error) {
    return (
      <Alert severity="error">
        {t('salesman.error')}
      </Alert>
    );
  }

  return (
    <Paper elevation={3} style={{ padding: '16px' }}>
      <Typography variant="h4" gutterBottom>
        {t('salesman.title')}
      </Typography>
      {(data?.length || 0) > 0 ? (
        <List>
          {data?.map((salesman: Salesman, index: number) => (
            <ListItem key={index}>
              <ListItemText primary={salesman.name} secondary={`Total Amount: $${salesman.totalAmount}`} />
            </ListItem>
          ))}
        </List>
      ) : (
        <Typography variant="body2">{t('salesman.not-found')}</Typography>
      )}
    </Paper>
  );
}
