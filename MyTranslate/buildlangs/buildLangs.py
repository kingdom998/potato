# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: buildLangs.py
@time: 2017/5/12 15:28
***************************************************************************
"""

from html.parser import HTMLParser


class MyHTMLParser(HTMLParser):
    def __init__(self):
        HTMLParser.__init__(self)
        self.keys = []
        self.data = []

    def handle_starttag(self, tag, attrs):
        for (name, value) in attrs:
            self.keys.append(value)

    def handle_data(self, data):
        self.data.append(data)


def chCurDir():
    import os

    curdir = os.path.dirname(__file__)  # 获取当前目录
    os.chdir(curdir)  # 进入当前目录


def test():
    chCurDir()  # 进入当前目录

    fin = open("language.txt")
    fout = open("../lib/language.py", "w")

    fout.write('buildlangs = {\n')
    for line in fin.readlines():
        if line != '\n':
            hp = MyHTMLParser()
            hp.feed(line)
            for (key, data) in zip(hp.keys, hp.data):
                val = " u'" + data + "': '" + key + "',\n"
                fout.write(val)
            hp.close()
    fout.write('}\n')
    fout.close()
    fin.close()


if __name__ == '__main__':
    test()
