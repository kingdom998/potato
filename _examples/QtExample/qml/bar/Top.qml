import QtQuick 2.0
import QtQuick.Window 2.0
import QtQuick.Layouts 1.1
import "../box"

Item {
    id: top

    property alias wdt: top.width
    property alias hgt: top.height

    anchors.top: parent.top
    anchors.horizontalCenter: parent.horizontalCenter

    RowLayout {
        id: layout
        spacing: 0
        width: parent.width
        height: parent.height

        Component.onCompleted: {
            console.log("boxPos", layout.width, layout.parent.width)
        }

        BoxTop{
            id : boxPos
            txt_top: pos_lon
            txt_bottom: pos_lat
            Component.onCompleted: {
                console.log("boxPos", boxPos.width, boxPos.parent.width)
            }
        }

        BoxTop{
            id : boxCursor
            txt_top: cur_lon
            txt_bottom: cur_lat
        }

        BoxTop{
            id : boxCog
            txt_top: cog_lbl
            txt_bottom: cog_val
        }

        BoxTop{
            id : boxSog
            txt_top: sog_lbl
            txt_bottom: sog_val
        }      
    }


    Component.onCompleted: {
        console.log("top", top.width,
                    "layout", layout.width)
    }
}



