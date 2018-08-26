FROM alpine:3.7
WORKDIR /app
COPY root /var/spool/cron/crontabs/root
COPY run.sh .
CMD crond -l 2 -f
