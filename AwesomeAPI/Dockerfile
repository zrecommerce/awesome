FROM microsoft/aspnet:1.0.0-rc1-update1

RUN printf "deb http://ftp.us.debian.org/debian jessie main\n" >> /etc/apt/sources.list
RUN apt-get -qq update && apt-get install -qqy sqlite3 libsqlite3-dev && rm -rf /var/lib/apt/lists/*

# Grab dnx-watch
RUN ["dnu", "commands", "install", "Microsoft.Dnx.Watcher"]
ENV PATH $PATH:/root/.dnx/bin

# Run directly from our synced folder.
WORKDIR /vagrant

# We need to specifically tell Docker we want this port exposed (Vagrant file forwards via d.ports array)
EXPOSE 5000

# Start! Due to a bug w/ Docker and dnx-watch, we are forced to run dnu restore and then dnx-watch like this.
CMD dnu restore && dnx-watch --dnx-args web