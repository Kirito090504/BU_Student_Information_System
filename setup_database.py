#!/usr/bin/env python3

"""
This script sets up the database for the application.
"""

import sys
import argparse
from typing import Final, Any

DEFAULTS: Final[dict[str, Any]] = {
    "host": "127.0.0.1",
    "port": 3306,
    "user": "root",
    "pass": "",
}


def setup_database(host: str, port: int, username: str, password: str) -> int:
    """
    Create the database, tables, and default data for the application.

    :param str host: The serving host address.
    :param int port: The serving port number.
    :param str username: The database server user.
    :param str password: The database server password.
    :return int: Returns 0 on success, 1 on failure.
    """

    # TODO
    print(f"Creating database on {host}:{port}...")
    print(f"Using default user:     {username}")
    print(f"Using default password: {'*' * len(password)}")
    return 0


def main() -> int:
    """
    The main function for the script.
    """

    parser = argparse.ArgumentParser(
        description="Setup the database for the client application."
    )
    parser.add_argument(
        "--host", type=str, default=DEFAULTS["host"], help="The database serving host."
    )
    parser.add_argument(
        "--port", type=int, default=DEFAULTS["port"], help="The database serving port."
    )
    parser.add_argument(
        "--user", type=str, default=DEFAULTS["user"], help="The database user."
    )
    parser.add_argument(
        "--passwd",
        type=str,
        default=DEFAULTS["pass"],
        help="The database password.",
    )
    args = parser.parse_args()

    return setup_database(args.host, args.port, args.user, args.passwd)


if __name__ == "__main__":
    sys.exit(main())
