# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: mytranslate.py
@time: 2017/7/14 17:05
***************************************************************************
"""
import locale
import sys

from .lib.MyMemory import mymemory
from .lib.MyYoudao import youdao
from .lib.MyGoogle import google
from .lib.tts import tts


def test():
    translations = {
        0: mymemory,
        1: youdao,
        2: google,
        3: tts,
    }

    reload(sys)
    sys.setdefaultencoding("utf-8")
    while 1:
        text = raw_input(u"请输入要翻译的文本：\n").decode(sys.stdin.encoding or locale.getpreferredencoding(True))
        if text in ('', 'q'):
            exit(0)

        print u"翻译结果为："
        translations[2](text)


if __name__ == '__main__':
    test()
