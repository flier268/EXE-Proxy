![workflow](https://github.com/flier268/EXE-Proxy/actions/workflows/dotnet.yml/badge.svg)

# [EXE Proxy](https://github.com/flier268/EXE-Proxy)
EXE Proxy 是一個使用C＃編寫的應用，它能讓你輕鬆地代理其他應用程式的啟動以及將其標準輸出和錯誤輸出重新定向。
此應用程式讀取一個含有設定參數的json文件，並根據這些參數啟動另一個應用程式。這完全透明，可用於日誌收集，錯誤監視等各種情況。

## 如何使用
此應用程式需要一個.json格式的設定檔。如果設定檔不存在，那麼應用程式將創建一個具有預設值的設定檔。
設定檔的路徑預設為應用程式啟動的.exe文件名（不包括副檔名）加上.json。
例如，如果應用程式的路徑為C:\path\to\EXE Proxy.exe，那麼預設的設定檔路徑則為C:\path\to\EXE Proxy.json。

## 設定檔結構
設定檔必須是一個json對象，含有以下屬性：

* FileName： 啟動的程式的路徑。
* Arguments： 啟動程式需要使用的命令行參數。

其他參數請看[MSDN](https://learn.microsoft.com/zh-tw/dotnet/api/system.diagnostics.processstartinfo?view=net-8.0)

執行應用程式時，將讀取這些值並設置到新啟動的程式中。


## 已知問題和限制
暫無

## 開源許可證
此項目使用 MIT 開源許可證。

# [EXE Proxy](https://github.com/flier268/EXE-Proxy)
EXE Proxy is an application written in C# that allows you to easily proxy the start of other applications and redirect their standard output and error output.
This application reads a json file containing configuration parameters and starts another application based on these parameters. This is completely transparent and can be used for various situations such as log collection, error monitoring, etc.

## How to Use
This application requires a configuration file in .json format. If the configuration file does not exist, then the application will create one with default values.
The default path for the configuration file is the .exe filename (without the extension) of the application startup plus .json.
For example, if the application path is C:\path\to\EXE Proxy.exe, then the default configuration file path is C:\path\to\EXE Proxy.json.
Configuration File Structure
The configuration file must be a json object, containing the following attributes:
* FileName: The path of the startup application.
* Arguments: The command-line parameters needed to start the application. ...

Other property find this [MSDN](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.processstartinfo?view=net-8.0)

When the application is run, these values are read and set to the new startup application.


## Known Issues and Limitations
(Possible reasons for abnormal program behavior under certain conditions can be listed here.)

## Open Source License
This project uses the MIT open source license.