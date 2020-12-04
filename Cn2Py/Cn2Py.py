# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: Cn2Py.py
@time: 2017/6/27 9:14
@goal: '''本文主要是做一个汉字转拼音的例子'''
***************************************************************************
"""

import re
import time
import xlrd
from xlutils.copy import copy
from xpinyin import Pinyin


# 中文转拼音
def cn2py(chars=u'中国70周年庆'):
    p = Pinyin()
    return p.get_pinyin(chars=chars, splitter=' ')


# 解析表格
def parseXls(filename):
    wb = xlrd.open_workbook(filename)
    for sheet in wb.sheets():
        print u"从 {} 读取 {} 条数据。\n".format(sheet.name, sheet.nrows)
        for row in range(1, sheet.nrows):
            row_data = sheet.row_values(row)
            for data in row_data:
                print data


# 修改表格（中文字段转拼音）
def modifyXls(filename):
    print time.ctime()  # 打印当前时间
    start = time.time()
    # 打开只读工作簿
    rb = xlrd.open_workbook(filename)

    wb = copy(rb)   # xlrd打开的是只读文件, 因此用copy备份工作簿
    ptn = u"[\w+\.\!\/_,$%^*(+\"\']+|[+——！，。？、~@#￥%……&*（）]+"
    for idx, rs in enumerate(rb.sheets()):
        # 通过get_sheet()获取的sheet有write()方法
        ws = wb.get_sheet(idx)
        print u"从工作表----{} 读取 {} 条数据。\n".format(rs.name, rs.nrows - 1)
        for row in range(1, rs.nrows):
            data = rs.row_values(row)
            cn = re.sub(ptn, u"", data[0])      # 去掉数字和字母和标点符号
            en = cn2py(cn)                      # 汉字转成拼音
            # 拼音为空的跳过
            if not en:
                continue
            # 写入数据
            ws.write(row, 1, cn)        # 中文
            ws.write(row, 2, en)        # 英文

    wb.save(filename)   # 保存已修改的工作簿

    # 计算耗时
    end = time.time()
    print "总耗时： {}.\n".format(end - start)


def test():
    myfile = r'名称.xls'
    modifyXls(myfile)


if __name__ == '__main__':
    test()
