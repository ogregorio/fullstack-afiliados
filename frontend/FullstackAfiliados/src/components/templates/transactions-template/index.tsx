import React, { useState } from 'react';
import TransactionsListOrganism from '@cp/organisms/transactions';
import { Transaction } from 'src/types/transaction.type';

interface TransactionsListTemplateProps {
  transactions: Transaction[];
  loading: boolean;
  error: any;
  t: (str: string) => string;
}

const TransactionsListTemplate: React.FC<TransactionsListTemplateProps> = ({
  transactions,
  loading,
  error,
  t,
}) => {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);

  const handleChangePage = (event: any, newPage: React.SetStateAction<number>) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (event: { target: { value: string } }) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  return (
    <TransactionsListOrganism
      transactions={transactions}
      loading={loading}
      error={error}
      t={t}
      page={page}
      rowsPerPage={rowsPerPage}
      onPageChange={handleChangePage}
      onRowsPerPageChange={handleChangeRowsPerPage}
    />
  );
};

export default TransactionsListTemplate;