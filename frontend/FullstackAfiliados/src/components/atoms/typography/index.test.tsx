import { render } from '@testing-library/react';
import TypographyAtom from './';

test('renders TypographyAtom with text', () => {
  const { getByText } = render(<TypographyAtom variant="h4">Hello</TypographyAtom>);
  const typographyElement = getByText('Hello');

  expect(typographyElement).toBeInTheDocument();
});
