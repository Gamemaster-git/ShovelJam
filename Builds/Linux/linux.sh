#!/bin/sh
echo -ne '\033c\033]0;ShovelJam\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/linux.x86_64" "$@"
