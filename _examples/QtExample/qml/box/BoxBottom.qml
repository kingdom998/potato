import QtQuick 2.0
import QtQuick.Window 2.0


Rectangle
{
    id: boxBottom

    property alias image: icon.source
    property alias title: txt.text

    property string textColor: "white"
    property real fontSize: 18
    property string bgImage: "qrc:///resources/bg.png"

    clip: true
    width: parent.width / 5.0 - 10
    height: parent.height
    border { width: 2; color: "white" }

    Image { source: bgImage; width: parent.width - 4; height: parent.height - 4; anchors.centerIn: parent}


    Column {
        clip: true
        height: parent.height
        width:  parent.width
        anchors.centerIn: parent

        //图标和文字
        Item {
            id: itemIcon
            y: 6
            clip: true
            width: parent.width; height: parent.height * 2 / 3.0

            Image {id: icon; anchors.centerIn: parent  }
        }


        // 文本
        Item {
            width: parent.width; height: parent.height / 3.0
            Text { id: txt; font.pointSize: fontSize; color: textColor; anchors.centerIn: parent }
        }
    }


    MouseArea {
        hoverEnabled: true
        anchors.fill: parent
        onExited: boxBottom.border.color = "white"
        onEntered: boxBottom.border.color = "red"
    }
}


