const ENDPOINTS: Record<string,string> = {
  AUTH: '/auth',
  UPLOAD: '/transactions/file'
};

const getApiUrl = (route: string): string =>
  import.meta.env.API_BASE + ENDPOINTS[route];

export {
  ENDPOINTS,
  getApiUrl
};
