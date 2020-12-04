# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: MyGoogle.py
@time: 2017/5/12 14:48
***************************************************************************
"""


import os
import sys
import locale
import execjs
import urllib
import urllib2
import requests


class XnToken(object):
    def __init__(self):
        fPath = os.path.dirname(__file__)
        fJs = open(fPath + "/token.js")
        js = fJs.read()
        self.ctx = execjs.compile(js)
        fJs.close()

    def getTk(self, text):
        return self.ctx.call("TL", text)


class Translator(object):
    def __init__(self):
        self.url = "http://translate.google.cn/translate_a/single?"
        self.headers = {
            'User-Agent': 'Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0'
        }

        self.js = XnToken()

    def translate(self, text, src="en", dest="zh-CN"):
        if len(text) > 4891:
            print("翻译的长度超过限制！！！")
            return

        tk = self.js.getTk(text)
        params = {
            "client": "t",
            "hl": "zh-CN",
            "ie": "UTF-8",
            "oe": "UTF-8",
            'dt': ['at', 'bd', 'ex', 'ld', 'md', 'qca', 'rw', 'rm', 'ss', 't'],
            "pc": 1,
            "kc": 2,
            "otf": 1,
            "ssel": 0,
            "tsel": 0,
            "srcrom": 0,
            "clearbtn": 1,
            "sl": src,
            "tl": dest,
            "tk": tk,
            "q": text,
        }

        if 0:
            self.url += urllib.urlencode(params)
            req = urllib2.Request(self.url, headers=self.headers)
            response = urllib2.urlopen(req)
            result = response.read().decode('utf-8')

        # 返回值是一个多层嵌套列表的字符串形式，解析起来还相当费劲，写了几个正则，发现也很不理想，
        # 后来感觉，使用正则简直就是把简单的事情复杂化，这里直接切片就Ok了
        response = requests.request("GET", self.url, headers=self.headers, params=params)
        if 200 == response.status_code:
            result = response.content
        else:
            print response.status_code
            return
        end = result.find("\",")
        if end > 4:
            print(result[4:end])


def google(text):
    translator = Translator()
    translator.translate(text, "zh-CN", "en")


def test():
    reload(sys)
    sys.setdefaultencoding("utf-8")
    while 1:
        text = raw_input(u"请输入要翻译的文本：\n").decode(sys.stdin.encoding or locale.getpreferredencoding(True))
        if text in ('', 'q'):
            exit(0)

        print u"翻译结果为："
        google(text)


def replaceInto(**kwargs):
    for k in kwargs.items()[2]:
        print k



if __name__ == '__main__':
    replaceInto(x=2, y=3, z=4)