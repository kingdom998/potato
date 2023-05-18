//![0]
import QtQuick 2.0
import QtQuick.Window 2.0
import Charts 1.0


Chart {
    id: mainWindow


    property var component: null

    visible: true
    width: 800; height: 600
    name: "A simple pie chart"
    color: "red"


    Item {
        id: itemMain
        focus: true
        anchors.fill: parent
        Keys.enabled: true;
        Keys.onPressed: {
            switch (event.key) {
            case Qt.Key_0:
                console.log(0)
                break
            case Qt.Key_Escape:
                Qt.quit()
                console.log("quit")
                break
            default:
                break
            }

        }
    }

    MouseArea {
        anchors.fill: parent
        onClicked: {
            if (null !== component) return

            component = Qt.createComponent("../qml/main.qml")
            if (component.status === Component.Ready) {
                   var object = component.createObject(this);
                   if (object === null) {
                       console.log("Error creating object");
                   }
               } else if (component.status == Component.Error) {
                   console.log("Error loading component:", component.errorString());
               }
        }
    }


}
//![0]
