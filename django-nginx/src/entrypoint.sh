#!/bin/bash
RUN_PORT="8000"

/opt/venv/bin/python manage.py migrate --no-input

echo "Starting gunicorn"
/opt/venv/bin/gunicorn cairo_project.wsgi:application --bind "0.0.0.0:${RUN_PORT}" --access-logfile /dev/stdout --capture-output --log-level info

# echo "Starting nginx"
# nginx -g 'daemon off;'