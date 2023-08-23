import { render } from '@testing-library/react';
import SalesmanTemplate from './';
import { MemoryRouter } from 'react-router-dom';

const simpleData = [
  { name: 'John Doe', totalAmount: 1000 },
  { name: 'Jane Smith', totalAmount: 1500 },
];

test('renders SalesmanListTemplate with loading state', () => {
  const { getByRole } = render(
    <MemoryRouter>
      <SalesmanTemplate data={[]} t={(k) => k} loading={true} />
    </MemoryRouter>
  );

  const circularProgress = getByRole('progressbar');

  expect(circularProgress).toBeInTheDocument();
});

test('renders SalesmanListTemplate with error state', () => {
  const { getByText } = render(
    <MemoryRouter>
      <SalesmanTemplate error={true} data={[]} t={(key) => key} />
    </MemoryRouter>
  );

  const errorText = getByText('error');

  expect(errorText).toBeInTheDocument();
});

test('renders SalesmanListTemplate with data', () => {
  const { getByText } = render(
    <MemoryRouter>
      <SalesmanTemplate data={simpleData} t={(key) => key} />
    </MemoryRouter>
  );

  const johnDoe = getByText('John Doe');
  const janeSmith = getByText('Jane Smith');

  expect(johnDoe).toBeInTheDocument();
  expect(janeSmith).toBeInTheDocument();
});
