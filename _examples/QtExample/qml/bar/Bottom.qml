import QtQuick 2.2
import QtQuick.Window 2.0
import QtQuick.Layouts 1.1
import "../box"

Item {
    id: bottom

    property alias wdt: bottom.width
    property alias hgt: bottom.height

    property string weekText: "星期二"
    property string dayText: "16"
    property string canvasIcon: "qrc:///resources/canvas.png"
    property string calendarIcon: "qrc:///resources/calendar.png"
    property string weatherIcon: "qrc:///resources/weather.png"
    property string typhoonIcon: "qrc:///resources/typhoon.png"
    property string logwarnIcon: "qrc:///resources/logw.png"
    property string settingIcon: "qrc:///resources/setting.png"
    property string tempText: "30°"
    property string speedofTypthoonText: "S 4m/s"

    anchors.bottom: parent.bottom
    anchors.horizontalCenter: parent.horizontalCenter

    RowLayout {
        id: layout

        spacing: 5
        width: parent.width
        height: parent.height

        BoxBottom{ id : boxCanvas; image: canvasIcon; title: "图面" }     //图面

        // 日期
        BoxBottom
        {
            id: date
            title: "日历"
            Text { id: txtWeek; text: weekText; font.pointSize: 18; color: "white";
                anchors.top: parent.top; anchors.horizontalCenter: parent.horizontalCenter}
            Text { id: txtDay; text: dayText; font.pointSize: 20; color: "white";
                anchors.centerIn: parent}

        }   // 日期

        // 天气
        BoxBottom{
            id : boxWeather
            clip: true
            title: "天气"

            Grid {
                height: parent.height * 2/ 3.0
                width:  parent.width
                clip: true
                columns: 2
                anchors.top: parent.top
                horizontalItemAlignment: Grid.AlignHCenter
                verticalItemAlignment : Grid.AlignVCenter


                Text { id: txtTemp; text:tempText; font.pointSize: 16; color: "white" }
                Text { id: txtSpeed;  text:speedofTypthoonText; font.pointSize: 16; color: "white"}
                Image {id: icTemp; source: weatherIcon }
                Image {id: icTyphoon; source: typhoonIcon }
            }
        }   // 天气

        BoxBottom{ id : boxLogw; image: logwarnIcon; title: "报警日志" }     //报警日志

        BoxBottom{ id : boxSetting; image: settingIcon; title: "设置" }       //设置
    }

    Component.onCompleted: {
           console.log("MainView onCompleted!")
           var list = bottom.children;

           console.log("count: " + list.length);
           for ( var i in list) {
               console.log("list[ " +i + " ] objectName = " + list[i].objectName)
               console.log("list[ " +i + " ] width = " + list[i].width)
               console.log("list[ " +i + " ] height = " + list[i].height)
           }
       }

}



