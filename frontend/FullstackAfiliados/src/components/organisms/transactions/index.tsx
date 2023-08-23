import React, { useState } from 'react';
import {
  CircularProgress,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  Alert,
  TablePagination,
} from '@mui/material';
import useTransactions from '@core/hooks/useTransactions';
import { Transaction, Type } from 'src/types/transaction.type';

const TransactionsListComponent: React.FC = () => {
  const { transactions, loading, error } = useTransactions();
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  if (loading) {
    return <CircularProgress />;
  }

  const handleChangePage = (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  return (
    <Paper elevation={3} style={{ padding: '16px' }}>
      <Typography variant="h4" gutterBottom>
        Transactions List
      </Typography>
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
            rowsPerPageOptions={[5, 10, 25]}
            component="div"
            count={transactions.length}
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={handleChangePage}
            onRowsPerPageChange={handleChangeRowsPerPage}
          />
        </TableContainer>
      ) : (
        <Typography variant="body2">No transactions available.</Typography>
      )}
    </Paper>
  );
};

export default TransactionsListComponent;
