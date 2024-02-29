# gunicorn_config.py

bind = "0.0.0.0:8000"
module = "cairo_project.wsgi:application"

workers = 4 
worker_connections = 1000
threads = 4

certfile = "/etc/letsencrypt/live/cairo-studies.com/fullchain.pem"
keyfile = "/etc/letsencrypt/live/cairo-studies.com/privkey.pem"