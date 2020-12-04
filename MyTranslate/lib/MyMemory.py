# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: MyMemory.py
@time: 2017/4/11 14:56
***************************************************************************
"""
from translate import Translator


# http://mymemory.translated.net/最多支持1000个单词
# 暂时只支持英文翻译成中文
def mymemory(text="This is a pen.", src="en", dest="zh"):
    translator = Translator(from_lang=src, to_lang=dest)
    translation = translator.translate(text)
    return translation
