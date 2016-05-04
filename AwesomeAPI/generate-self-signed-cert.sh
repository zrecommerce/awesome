#!/bin/bash

# ./generate-self-signed-cert.sh YOU_HOST_NAME
makecert -r -eku 1.3.6.1.5.5.7.3.1 -n "CN=$1" -sv "$1.pvk" "$1.cer"