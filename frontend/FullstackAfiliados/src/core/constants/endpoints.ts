const ENDPOINTS: Record<string,string> = {
  AUTH: '/auth'
};

const getApiUrl = (route: string): string =>
  import.meta.env.API_BASE + ENDPOINTS[route];

export {
  ENDPOINTS,
  getApiUrl
};
