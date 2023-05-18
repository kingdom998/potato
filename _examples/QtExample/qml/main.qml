import QtQuick 2.0
import QtQuick.Window 2.0
import QtQuick.Layouts 1.1
import "bar"

Item {
    id: mainMenu

    property real win_width: 800
    property real win_height: 600
    property string img_bg: "qrc:///resources/bg.png"
    property string pos_lon: "118°52.5321E"
    property string pos_lat: "21°58.9302N"
    property string cur_lon: "118°14.5321E"
    property string cur_lat: "24°58.9302N"
    property string cog_lbl: "COG"
    property string cog_val: "301.1°"
    property string sog_lbl: "SOG"
    property string sog_val: "10.2KN"


    visible: true
    width: parent.width
    height: parent.height


    Image { id: imgBg; source: img_bg; anchors.fill: parent }

    Top { id: barTop; wdt: 800; hgt: 60  }
    Mid { id: barMid; wdt: 800; hgt: 270 }
    Bottom { id: barBottom; wdt: 800; hgt: 100 }
}
