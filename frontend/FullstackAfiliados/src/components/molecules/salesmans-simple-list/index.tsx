import { ListItem, ListItemText } from '@mui/material';
import { Link } from 'react-router-dom';
import { Salesman } from 'src/types/salesman.type';

type Params = {
    salesman: Salesman
    t: (str: string) => string
}

export default function SalesmanListItemMolecule({ salesman, t }: Params) {
  return (
    <ListItem
      component={Link}
      to={`/dashboard/salesmans/${salesman.name}`}
    >
      <ListItemText
        primary={salesman.name}
        secondary={`${t('salesman.total-amount')}: ${t('global.currency')} ${salesman.totalAmount}`}
      />
    </ListItem>
  );
}

