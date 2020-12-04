# -*- coding: utf-8 -*-
"""
***************************************************************************
@version: python2.7.5 
@author: 'kingdom'
@license: Apache Licence 
@contact: 995350347@qq.com
@site: 
@software: PyCharm
@file: MyQgis.py
@time: 2017/7/24 16:43
***************************************************************************
"""

import os
from qgis.core import *
from qgis.gui import *
from qgis.utils import *
from qgis.PyQt.QtGui import *
from qgis.PyQt.QtCore import *


class MyWnd(QMainWindow):
    def __init__(self, layer):
        super(MyWnd, self).__init__()
        self.canvas = QgsMapCanvas()
        self.canvas.setCanvasColor(Qt.white)

        QgsMapLayerRegistry.instance().addMapLayer(layer)
        self.canvas.setExtent(layer.extent())
        self.canvas.setLayerSet([QgsMapCanvasLayer(layer)])
        self.setCentralWidget(self.canvas)

        actionZoomIn = QAction("Zoom in", self)
        actionZoomIn.setCheckable(True)
        self.connect(actionZoomIn, SIGNAL("triggered()"), self.zoomIn)

        actionZoomOut = QAction("Zoom out", self)
        self.connect(actionZoomOut, SIGNAL("triggered()"), self.zoomOut)
        actionZoomOut.setCheckable(True)

        actionPan = QAction("Pan", self)
        actionPan.setCheckable(True)
        self.connect(actionPan, SIGNAL("triggered()"), self.pan)

        actionFullExtent = QAction("Full Extent", self)
        actionFullExtent.setCheckable(True)
        self.connect(actionFullExtent, SIGNAL("triggered()"), self.fullExtent)

        self.toolbar = self.addToolBar("Canvas actions")
        self.toolbar.addAction(actionZoomIn)
        self.toolbar.addAction(actionZoomOut)
        self.toolbar.addAction(actionPan)
        self.toolbar.addAction(actionFullExtent)

        # create the map tools
        self.toolPan = QgsMapToolPan(self.canvas)
        self.toolPan.setAction(actionPan)
        self.toolZoomIn = QgsMapToolZoom(self.canvas, False)  # false = in
        self.toolZoomIn.setAction(actionZoomIn)
        self.toolZoomOut = QgsMapToolZoom(self.canvas, True)  # true = out
        self.toolZoomOut.setAction(actionZoomOut)
        self.toolFullExtent = QgsMapToolTouch(self.canvas)  # true = out
        self.toolFullExtent.setAction(actionFullExtent)

        self.pan()

    def zoomIn(self):
        self.canvas.setMapTool(self.toolZoomIn)

    def zoomOut(self):
        self.canvas.setMapTool(self.toolZoomOut)

    def pan(self):
        self.canvas.setMapTool(self.toolPan)

    def fullExtent(self):
        self.canvas.zoomToFullExtent()


class MyApp(object):
    def __init__(self, prefixPath=None):
        """

        :type prefixPath: str
        """
        self.prefixPath = prefixPath

    def init(self):
        app = QgsApplication([], True)
        app.setPrefixPath(self.prefixPath, True)
        app.initQgis()

        canvas = QgsMapCanvas()
        canvas.setWindowTitle("PyQGIS Standalone Application Example")
        canvas.setCanvasColor(Qt.white)

        layer = self.memoryLayer() if 0 else self.ogrLayer()
        if not layer.isValid():
            print "Layer %s did not load" % layer.name()
            return

        layer.updateExtents()
        QgsMapLayerRegistry.instance().addMapLayer(layer)
        canvas.setExtent(layer.extent())
        canvas.setLayerSet([QgsMapCanvasLayer(layer)])
        canvas.zoomToFullExtent()
        canvas.freeze(True)
        canvas.show()
        canvas.refresh()
        canvas.freeze(False)
        canvas.repaint()

        exitcode = app.exec_()
        sys.exit(exitcode)

    def uninit(self):
        QgsApplication.exitQgis()

    def memoryLayer(self):
        layer = QgsVectorLayer('LineString?crs=epsg:4326', 'MyLine', "memory")
        pr = layer.dataProvider()
        linstr = QgsFeature()
        geom = QgsGeometry.fromWkt("LINESTRING (1 1, 10 20, 35 35)")
        linstr.setGeometry(geom)
        pr.addFeatures([linstr])

        return layer

    def ogrLayer(self):
        layer = QgsVectorLayer(r"D:\01_XN\QGIS\trunk\xndata\qgis_sample_data\shapefiles\lakes.shp",
                               "New York City Museums", "ogr")

        return layer

    def spatialLayer(self):
        uri = QgsDataSourceURI()
        uri.setConnection("192.168.1.5", "5432", "map_test",
                          "wjd", "wjd")
        uri.setDataSource("public", "islands", "wkb_geometry", "")
        layer = QgsVectorLayer(uri.uri(), "Islands", "postgres")

        return layer


def test1():
    prefixPath = r"E:/Program Files/QGIS 2.18/apps/qgis"
    app = MyApp(prefixPath=prefixPath)
    app.init()
    app.uninit()


def test():
    prefixPath = ""
    if os.environ.has_key("qgis_prefix"):
        prefixPath = os.environ("qgis_prefix")
    qgs = QgsApplication([], True)
    QgsApplication.setPrefixPath(prefixPath, True)  # 设置安装路径
    qgs.initQgis()

    layerPath = r"D:\01_XN\QGIS\trunk\xndata\training_manual_data\world\oceans.shp"
    layer = QgsVectorLayer(layerPath, "test", "ogr")
    if not layer.isValid():
        print "Layer %s did not load" % layer.name()
        return
    w = MyWnd(layer)
    w.show()

    ret = qgs.exec_()
    sys.exit(ret)
    QgsApplication.exitQgis()


if __name__ == '__main__':
    test()
