# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: MyYoudao.py
@time: 2017/5/12 14:51
***************************************************************************
"""

import json
import requests


def youdao(word, dest="AUTO"):
    data = {
        'type': dest,
        'i': word,
        'doctype': 'json',
        'xmlVersion': '1.8',
        'keyfrom': 'fanyi.web',
        'ue': 'UTF-8',
        'action': 'FY_BY_CLICKBUTTON',
        'typoResult': 'true'
    }
    url = 'http://fanyi.youdao.com/translate'
    try:
        response = requests.request("post", url, data=data)
        if 200 == response.status_code:
            content = json.loads(response.text)  # 将字符串转换为json数据
            print json.dumps(content, encoding='utf-8', ensure_ascii=False)  # json，有方法.dumps 实现转码

            return content['translateResult'][0][0]['tgt'] + "\n"
        response.close()

    except requests.exceptions.ConnectionError as request_err:
        print data, request_err
