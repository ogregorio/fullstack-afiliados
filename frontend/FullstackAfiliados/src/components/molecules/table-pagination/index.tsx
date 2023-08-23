import React from 'react';
import { TablePagination } from '@mui/material';

interface TablePaginationMoleculeProps {
  count: number;
  rowsPerPage: number;
  page: number;
  onPageChange: (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => void;
  onRowsPerPageChange: (event: React.ChangeEvent<HTMLInputElement>) => void;
}

const TablePaginationMolecule: React.FC<TablePaginationMoleculeProps> = ({
  count,
  rowsPerPage,
  page,
  onPageChange,
  onRowsPerPageChange,
}) => {
  return (
    <TablePagination
      rowsPerPageOptions={[5, 10, 25]}
      component="div"
      count={count}
      rowsPerPage={rowsPerPage}
      page={page}
      onPageChange={onPageChange}
      onRowsPerPageChange={onRowsPerPageChange}
    />
  );
};

export default TablePaginationMolecule;