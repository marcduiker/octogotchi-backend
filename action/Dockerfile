FROM ubuntu:18.04

LABEL "com.github.actions.name"="Interact with your Octogotchi"
LABEL "com.github.actions.description"="Interact with your Octogotchi"
LABEL "com.github.actions.icon"="code"
LABEL "com.github.actions.color"="blue"
LABEL "repository"=" https://github.com/marcduiker/octogotchi-backend"

# install powershell core
RUN apt-get update \
    && apt-get install wget -y \
    && wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y powershell

# actions starting point
ADD entrypoint.ps1 /entrypoint.ps1
ADD github-calls.ps1 /github-calls.ps1
ENTRYPOINT ["pwsh", "/entrypoint.ps1"]

