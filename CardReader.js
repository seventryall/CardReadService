var CardReader = {
    createNew:function () {
        var reader = {};
        var ws = null;
        var socketOpen = false;

        var wsOnOpen = function () {
            socketOpen = true;
        };
        var wsOnMessage = function (evt) {
            var data = evt.data;
            //alert(data);
            document.getElementById("textCardNo").value = data;
        };
        var wsOnClose = function () {
            socketOpen = false;
        };
        var wsOnError = function () {
            alert("Error");
        };

        reader.tryConnect = function () {

            try {
                if ("WebSocket" in window) {
                    ws = new WebSocket("ws://127.0.0.1:8088/CardReader");
                } else if ("MozWebSocket" in window) {
                    ws = new MozWebSocket("ws://127.0.0.1:8088/CardReader");
                } else {
                    return false;
                }
                ws.onopen = wsOnOpen;
                ws.onmessage = wsOnMessage;
                ws.onclose = wsOnClose;
                ws.onerror = wsOnError;
                return true;
            } catch (ex) {
                return false;
            }
        }

        reader.disconnect = function () {
            if (ws != null) ws.close();
        };

        reader.connected = function () {
            return socketOpen;
        };

        reader.requestIDCardNo = function () {
            sendCmd({ FuncName: "RequestIDCardNo" });
        };

        var sendCmd = function (data, callback) {
            ws.send(JSON.stringify(data));
            if (callback)
                callback();

        }
        return reader;
    }



}