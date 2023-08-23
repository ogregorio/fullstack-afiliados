import { styled } from '@mui/material/styles';
import { Container, Grid, Link, Typography } from '@mui/material';
import LogoImage from '@assets/Logo.svg';

const FooterWrapper = styled('footer')(({ theme }) => ({
  backgroundColor: 'var(--primary-color)',
  color: 'var(--white)',
  padding: theme.spacing(6, 0),
}));

const FooterLink = styled(Link)(({ theme }) => ({
  display: 'block',
  color: 'var(--white)',
  marginBottom: theme.spacing(1),
}));

const Footer = () => {
  return (
    <FooterWrapper>
      <Container maxWidth="lg">
        <Grid container alignItems="center">
          <Grid item xs={12} sm={6}>
            <img style={{filter: 'invert(1)', width: '200px'}} src={LogoImage} alt='Logo'/>
            <h1 style={{display: 'none'}}>{(t('title'))}</h1>
            <Typography sx={{maxWidth: '500px'}} variant="body1">
              
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Grid container spacing={2}>
              <Grid item xs={6}>
                <Typography variant="h6" gutterBottom>
                  {(t('contact.title'))}
                </Typography>
                <FooterLink href="mailto:arthurgregorioleal@gmail.com">{(t('contact.email'))}</FooterLink>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
      </Container>
    </FooterWrapper>
  );
};

export default Footer;
