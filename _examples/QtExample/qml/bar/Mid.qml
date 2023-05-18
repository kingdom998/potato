import QtQuick 2.0
import QtQuick.Window 2.0
import QtQuick.Layouts 1.1
import "../box"

Item {
    id: mid

    property alias wdt: mid.width
    property alias hgt: mid.height

    property string mapIcon: "qrc:///resources/map.png"
    property string posIcon: "qrc:///resources/gnss.png"
    property string tideIcon: "qrc:///resources/tide.png"
    property real space: 30

    anchors.verticalCenter: parent.verticalCenter
    anchors.horizontalCenter: parent.horizontalCenter

    RowLayout {
        id: layout
        spacing: space
        width: parent.width * 3 / 4.0 + 2*space
        height: parent.height
        anchors.horizontalCenter: parent.horizontalCenter

        BoxMid { id : boxMapView; image: mapIcon; title: "海图"; objectName: "objMap" }

        BoxMid { id : boxPos; image: posIcon; title: "GNSS"; objectName: "objPos" }

        BoxMid { id : boxTide; image: tideIcon; title: "潮汐"; objectName: "objTide" }
    }

    Component.onCompleted: {
        console.log("mid", mid.width,
                    "layout", layout.width)
    }
}



