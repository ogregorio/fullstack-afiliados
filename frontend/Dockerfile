# Pull image from dockerhub
FROM node:16-alpine3.14

# Define working directory as /usr/fulstack-afilliados
WORKDIR /usr/share/fulstack-afilliados

# Copy all files except .dockerignore
COPY . .

# Install dependencies
RUN yarn

# Build application
RUN NODE_ENV=production yarn build

# Run in production
CMD yarn preview 