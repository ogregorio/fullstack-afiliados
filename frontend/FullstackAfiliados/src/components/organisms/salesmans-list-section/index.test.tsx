import { render } from '@testing-library/react';
import SalesmanListOrganism from '.';
import { MemoryRouter } from 'react-router-dom';

const dataData = [
  { name: 'John Doe', totalAmount: 1000 },
  { name: 'Jane Smith', totalAmount: 1500 },
];

test('renders SalesmanListOrganism with data', () => {
  const { getByText } = render(
    <MemoryRouter>
      <SalesmanListOrganism data={dataData} t={(key) => key} />
    </MemoryRouter>
  );

  const johnDoe = getByText('John Doe');
  const janeSmith = getByText('Jane Smith');

  expect(johnDoe).toBeInTheDocument();
  expect(janeSmith).toBeInTheDocument();
});

test('renders SalesmanListOrganism without data', () => {
  const { getByText } = render(
    <SalesmanListOrganism data={[]} t={(key) => key} />
  );

  const notFoundText = getByText('salesman.not-found');

  expect(notFoundText).toBeInTheDocument();
});
