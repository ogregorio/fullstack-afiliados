import React from 'react';
import { 
  Paper, 
  Typography, 
  Alert, 
  TableContainer,
  TableHead,
  TableRow,
  TableCell,
  Table,
  TableBody 
} from '@mui/material';
import CircularProgress from '@cp/atoms/circular-progress';
import TablePagination from '@cp/molecules/table-pagination';
import { Transaction } from 'src/types/transaction.type'; // Import the correct type

interface TransactionsListOrganismProps {
  transactions: Transaction[];
  loading: boolean;
  error: string | null;
  t: (key: string) => string;
  page: number;
  rowsPerPage: number;
  onPageChange: (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => void;
  onRowsPerPageChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

const TransactionsListOrganism: React.FC<TransactionsListOrganismProps> = ({
  transactions,
  loading,
  error,
  t,
  page,
  rowsPerPage,
  onPageChange,
  onRowsPerPageChange,
}) => {
  return (
    <Paper elevation={3} style={{ padding: '16px' }}>
      <Typography variant="h4" gutterBottom>
        {t('transactions.title')}
      </Typography>
      {loading && <CircularProgress />}
      {error && <Alert severity="error">{error}</Alert>}
      {transactions.length > 0 ? (
        <TableContainer>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>{t('transactions.date')}</TableCell>
                <TableCell>{t('transactions.product')}</TableCell>
                <TableCell>{t('transactions.amount')}</TableCell>
                <TableCell>{t('transactions.origin')}</TableCell>
                <TableCell>{t('transactions.description')}</TableCell>
                <TableCell>{t('transactions.signal')}</TableCell>
                <TableCell>{t('transactions.type')}</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {transactions
                .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                .map((transaction: Transaction, index: number) => (
                  <TableRow key={index}>
                    <TableCell>{new Date(transaction.date).toLocaleDateString()}</TableCell>
                    <TableCell>{transaction.product}</TableCell>
                    <TableCell>{t('global.currency')} {transaction.amount}</TableCell>
                    <TableCell>{transaction.type.origin}</TableCell>
                    <TableCell>{transaction.type.description}</TableCell>
                    <TableCell>{transaction.type.signal ? '+' : '-'}</TableCell>
                    <TableCell>{transaction.type.type}</TableCell>
                  </TableRow>
                ))}
            </TableBody>
          </Table>
          <TablePagination
            count={transactions.length}
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={onPageChange}
            onRowsPerPageChange={onRowsPerPageChange}
          />
        </TableContainer>
      ) : (
        <Typography variant="body2">{t('transactions.not-found')}</Typography>
      )}
    </Paper>
  );
};

export default TransactionsListOrganism;