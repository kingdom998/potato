# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: Tide.py
@time: 2017/7/28 17:39
***************************************************************************
"""
import xlwt
import requests
from HTMLParser import HTMLParser
from urllib import unquote


class PlaceParser(HTMLParser):
    def __init__(self):
        HTMLParser.__init__(self)
        self.find = False
        self.data = []


    def handle_starttag(self, tag, attrs):
        if "script" == tag and not len(attrs):
                self.find = True


    def handle_data(self, data):
        if self.find:
            self.find = False
            js = data.encode("utf-8").strip()
            # 取出estaciones_mapa变量数据
            if js.startswith("estaciones_mapa"):
                expr = js.split(";")[0]       # 表达式
                var = expr.split("=")[1]      # 变量值
                # 追加表名和链接
                for item in eval(var):
                    self.data.append((item[0], item[4]))


class TideParser(HTMLParser):
    def __init__(self):
        HTMLParser.__init__(self)
        self.find = False
        self.data = ""


    # 只取出脚本内容
    def handle_starttag(self, tag, attrs):
        if "script" == tag and "text/javascript" == attrs[0][1]:
                self.find = True


    def handle_data(self, data):
        if self.find:
            js = data.encode("utf-8")   # 转成utf-8编码
            self.find = False
            # 取出函数列表
            if js.startswith("function"):
                fun = js.split('function')[2]   # 取出init_t函数
                url = fun.split('"')[1]         # 取出返回字符数据
                self.data = unquote(url)        # url解码


class Tide(object):
    def __init__(self):
        self.root = "http://www.haichaobiao.com"
        self.wb = ""
        self.ws = ""
        self.row = 0
        self.places = []
        self.month = "2017-01-01"
        self.content = ""
        self.data = ""


    def addBook(self):
        self.wb = xlwt.Workbook()  # 工作簿


    # 保存工作簿
    def saveBook(self, book="vietnam"):
        name = book + ".xls"
        self.wb.save(name)


    # 表名不能包含括号
    def addTable(self, table="new"):
        self.ws = self.wb.add_sheet(table)
        # 写入表头
        header = [u"日期", u"时间", u"高度"]
        for col, item in enumerate(header):
            self.ws.write(0, col, item)


    # 获取钓鱼站点
    def getPlaces(self, tail="/as/vietnam"):
        url = self.root + tail
        response = requests.get(url)
        if 200 == response.status_code:
            parser = PlaceParser()
            parser.feed(response.content.decode("utf-8"))
            self.places = parser.data
            parser.close()

    def getData(self, tail="/as/vietnam/hon-me", month="2017-01-01", code="utf-8"):
        self.month = month
        data = {"fecha": month}
        url = self.root + tail
        response = requests.post(url, data=data)
        if 200 == response.status_code:
            content = response.content
            parser = TideParser()       # 解析并返回数据
            parser.feed(content.decode(code))
            self.data = parser.data

            parser.close()


    def parserData(self):
        if not self.data:
            return

        table = self.data.split("&")[2:]  # 取出有效记录
        dt = self.month.split("-")
        for day, tr in enumerate(table):
            dt[2] = "{:02d}".format(day + 1)
            date = "".join(dt)
            tide = tr.split("~")[6]     # 取出潮汐信息
            for td in tide.split("#"):  # 分离高潮低潮
                self.row += 1
                row = self.row
                # 写入潮汐数据
                tide = td.split("/")
                self.ws.write(row, 0, date)
                self.ws.write(row, 1, tide[0].replace(":", ""))
                self.ws.write(row, 2, tide[2])


    def parserByYear(self, year="2017"):
        fstDay = "2017-01-01"
        date = fstDay.split("-")
        date[0] = year
        for ws, tail in self.places:
            self.addTable(ws.decode("utf-8"))
            self.row = 0    # 记录个数重设为0
            for idx in range(1, 13):
                date[1] = "{:02d}".format(idx)  # 格式化为0x
                month = "-".join(date)
                self.getData(tail, month, "latin-1")
                self.parserData()


def test():
    import time

    beg = time.time()

    tide = Tide()
    tide.addBook()
    tide.getPlaces()
    tide.parserByYear("2017")
    tide.saveBook()

    end = time.time()
    print "elapsed {}s".format(end - beg)


if __name__ == '__main__':
    test()
