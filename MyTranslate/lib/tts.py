# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: tts.py
@time: 2017/5/12 14:52
***************************************************************************
"""

import requests
import subprocess


def tts(text):
    url = "http://translate.google.cn/translate_tts?ie=UTF-8&q=%s&tl=en&total=1&idx=0&textlen=4&prev=input"
    ret = requests.get(url % text)
    if ret.status_code == 200:
        ext = ret.headers["content-type"].split("/")[1]
        filename = "tts.%s" % ext
        with open(filename, "wb") as f:
            f.write(ret.content)
        # 不显示mplayer的输出
        log_file = "./mplayer.log"
        with open(log_file, "w") as f:
            subprocess.call(["mplayer", filename], stdout=f, stderr=f)
    else:
        raise Exception("Google TTS服务状态码异常。")