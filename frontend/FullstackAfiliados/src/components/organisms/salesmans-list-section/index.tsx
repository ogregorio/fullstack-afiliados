import { Paper, List } from '@mui/material';
import Typography from '@cp/atoms/typography';
import SalesmanListItem from '@cp/molecules/salesmans-simple-list';
import { Salesman } from 'src/types/salesman.type';

export type Params = {
  data: Salesman[],
  t: (str: string) => string
}

export default function SalesmanListSection({ data, t }: Params) {
  return (
    <Paper elevation={3} style={{ padding: '16px' }}>
      <Typography variant="h4">
        {t('salesman.title')}
      </Typography>
      {data?.length > 0 ? (
        <List>
          {data.map((salesman, index) => (
            <SalesmanListItem
              key={index}
              salesman={salesman}
              t={t}
            />
          ))}
        </List>
      ) : (
        <Typography variant="body2">
          {t('salesman.not-found')}
        </Typography>
      )}
    </Paper>
  );
}
