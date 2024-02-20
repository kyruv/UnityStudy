# Fetching the latest nginx image
FROM nginx:1.23-alpine

# Removing default nginx.conf
RUN rm /etc/nginx/conf.d/default.conf

# Copying our nginx.conf
COPY default.conf /etc/nginx/conf.d

# link nginx logs to container stdout
RUN ln -sf /dev/stdout /var/log/nginx/access.log && ln -sf /dev/stderr /var/log/nginx/error.log