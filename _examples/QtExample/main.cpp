#include "chart.h"
#include <QGuiApplication>
#include <QQmlApplicationEngine>
#include <QtQuick/QQuickView>

int main(int argc, char *argv[])
{
    QGuiApplication app(argc, argv);

    qmlRegisterType<Chart>("Charts", 1, 0, "Chart");

    QQuickView view;
    view.setResizeMode(QQuickView::SizeRootObjectToView);
    view.setSource(QUrl("qrc:///map.qml"));
    QObject::connect(view.engine(), SIGNAL(quit()), &app, SLOT(quit()));
    view.show();



    return app.exec();
}

