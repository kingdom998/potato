TEMPLATE = app

QT += qml quick
CONFIG += c++11

SOURCES += main.cpp \
    chart.cpp

RESOURCES += qml.qrc

# Additional import path used to resolve QML modules in Qt Creator's code model
QML_IMPORT_PATH =

# Default rules for deployment.
include(deployment.pri)

DISTFILES += \
    resources/bg.png \
    resources/calendar.png \
    resources/canvas.png \
    resources/gnss.png \
    resources/line_h.png \
    resources/logw.png \
    resources/map.png \
    resources/proj.png \
    resources/setting.png \
    resources/tide.png \
    resources/typhoon.png \
    resources/weather.png \
    map.qml \
    qml/bar/BoxMidqml \
    qml/Bar.qml \
    qml/main - 副本.qml

HEADERS += \
    chart.h

