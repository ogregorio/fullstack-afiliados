import React from 'react';
import { render, fireEvent } from '@testing-library/react';
import TablePaginationMolecule from './';

test('renders TablePaginationMolecule', () => {
  const onPageChange = jest.fn();
  const onRowsPerPageChange = jest.fn();

  const { getByLabelText, getByText } = render(
    <TablePaginationMolecule
      count={15}
      rowsPerPage={5}
      page={1}
      onPageChange={onPageChange}
      onRowsPerPageChange={onRowsPerPageChange}
    />
  );

  // Open rows per page dropdown
  const rowsPerPageButton = getByLabelText('Rows per page:');
  fireEvent.mouseDown(rowsPerPageButton);

  // Select a different rows per page option
  const rowsPerPageOption = getByText('10');
  fireEvent.click(rowsPerPageOption);

  // Find the next page button and click it
  const nextPageButton = getByLabelText('Go to next page');
  fireEvent.click(nextPageButton);

  // Assert that functions were called and page changed
  expect(rowsPerPageButton).toBeInTheDocument();
  expect(onRowsPerPageChange).toHaveBeenCalled();
  expect(nextPageButton).toBeInTheDocument();
  expect(onPageChange).toHaveBeenCalledWith(expect.any(Object), 2);
  
});
