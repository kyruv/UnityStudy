FROM python:3.10-bullseye as web

# copy the django code
COPY . ./app

# change our working directory to the django projcet root
WORKDIR /app

# create virtual env (notice the location?)
# update pip
# install requirements
RUN python -m pip install pip --upgrade && \
    python -m pip install -r requirements.txt

# # make our entrypoint.sh executable
# RUN chmod +x entrypoint.sh

# # execute our entrypoint.sh file
# CMD ["./entrypoint.sh"]