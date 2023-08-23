import { Typography, TypographyPropsVariantOverrides } from '@mui/material';
import { Variant } from '@mui/material/styles/createTypography';
import { OverridableStringUnion } from '@mui/types';

type Params = {
    variant: OverridableStringUnion<Variant | 'inherit', TypographyPropsVariantOverrides> | undefined
    children: string
}

export default function TypographyAtom({ variant, children }: Params) {
  return <Typography variant={variant}>{children}</Typography>;
}