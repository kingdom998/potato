"""
Main command-line interface to PyInstaller.
"""

from PyInstaller.__main__ import run


def test():
    opts = ['MyQgis.py']
    run(opts)


if __name__ == '__main__':
    test()
