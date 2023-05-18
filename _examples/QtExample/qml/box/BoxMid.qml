import QtQuick 2.0
import QtQuick.Window 2.0


Rectangle
{
    id: boxMid

    property alias title: txtBottom.text;
    property alias image: img.source;

    property string textColor: "white"
    property real fontSize: 18

    clip: true
    width: parent.width / 3.5
    height: parent.height
    border { color: "white"; width: 1}

    Image { width: parent.width - 4; height: parent.height - 4
        anchors.centerIn: parent; source: "qrc:///resources/bg.png"; }

    Column {
        height: parent.height
        width: parent.width - 6
        anchors.centerIn: parent

        //图标
        Item {
            id: itemIcon
            clip: true
            y: 6
            width: parent.width; height: parent.height * 3 / 4.0
            Image {id: img }
        }

        Image {id: imgLine; anchors.top: itemIcon.bottom }  // 分割线

        // 文本
        Item {
            width: parent.width; height: parent.height / 5.0
            Text { id: txtBottom; font.pointSize: fontSize; color: textColor; anchors.centerIn: parent }
        }

    }   // column

    MouseArea {
        hoverEnabled: true
        anchors.fill: parent
        onExited: boxMid.border.color = "white"
        onEntered: boxMid.border.color = "red"
        onClicked: {
            var objName = this.parent.objectName
            switch(objName) {
            case "objMap":
                console.log(objName)
                break
            default:
                break
            }
        }
    }
}


