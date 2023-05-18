import QtQuick 2.0
import QtQuick.Window 2.0


Rectangle
{
    id: boxTop

    property alias txt_top: txtTop.text
    property alias txt_bottom: txtBottom.text
    property alias img_url: imgIcon.source

    property string bgImage: "qrc:///resources/bg.png"
    property string txt_color: "white"
    property real fontSize: 18

    width: parent.width / 4.0
    height: parent.height
    border { width: 1; color: "white" }

    // 背景图片
    Image { width: parent.width - 4; height: parent.height - 4
        anchors.centerIn: parent; source: "qrc:///resources/bg.png" }


    Column {
        clip: true
        anchors.fill: parent

        // 文本
        Item {
            width: parent.width; height: parent.height / 2.0
            Text { id: txtTop; font.pointSize: fontSize; color: txt_color ; anchors.horizontalCenter: parent.horizontalCenter}
        }
        // 文本
        Item {
            width: parent.width; height: parent.height / 2.0
            Text { id: txtBottom; font.pointSize: fontSize; color: txt_color ; anchors.horizontalCenter: parent.horizontalCenter}
        }

        Image {id: imgIcon}     //图标
    }

}


