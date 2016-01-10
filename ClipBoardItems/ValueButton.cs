using System;
using System.Windows.Forms;
using System.Drawing;

namespace ClipBoardItems
{
    public partial class ValueButton : Button
    {
        public ValueButton()
        {
        }

        // IDボタンの初期化
        public ValueButton ButtonCreate(ValueButton button, System.EventHandler ButtonClick, int sNum, int buttonType, InifileUtils sInifileUtils)
        {
            string name = "";
            string text = "";
            int drawPoint = 0;

            if (buttonType == 1) { name = "CopyID"; text = "NameID"; drawPoint = 10; }
            if (buttonType == 2) { name = "CopyPW"; text = "NamePW"; drawPoint = 170; }

            // インスタンスを作成
            button = new ValueButton();
            // 配置位置を設定
            button.Location = new System.Drawing.Point(drawPoint, 10 + 27 * sNum);
            // Nameプロパティを設定
            button.Name = name + sNum.ToString();
            // サイズを設定
            button.Size = new System.Drawing.Size(150, 25);
            // TabIndexを設定
            button.TabIndex = sNum + 1;
            // ボタンテキストを設定
            button.Text = GetButtonName(sInifileUtils, sNum, text);
            // ボタン表示テキストを中段左寄せ
            button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // イベントハンドラの登録
            button.Click += new System.EventHandler(ButtonClick);

            return button;
        }
        public void MainTabControl(TabControl MainTabControl)
        {
            // 配置位置を設定
            MainTabControl.Location = new System.Drawing.Point(10, 10);
            // Nameプロパティを設定
            MainTabControl.Name = "tabControl";
            // 選択されているタブページのインデックス取得
            MainTabControl.SelectedIndex = 0;
            // サイズを設定
            MainTabControl.Size = new System.Drawing.Size(340, 585);
            // TabIndexを設定
            MainTabControl.TabIndex = 0;
        }
        public void TabPages(TabPage TabPages, int i)
        {
            // Nameプロパティを設定
            TabPages.Name = "TabPage";
            // タブテキストを設定
            //TabPages.Text = "TabText";
            TabPages.Text = GetTabName(i);
            //TabPages.Text = GetTabName();
        }
        public string GetkeyName(InifileUtils sInifileUtils, int sNum, string sName)
        {
            // iniFileから文字列を取得
            return sInifileUtils.getValueString(sNum.ToString(), sName);
        }
        public void DoClipBoardSet(string iSetItem)
        {
            // クリップボードに文字列をコピーする
            if (iSetItem != "") { Clipboard.SetText(iSetItem); }
            if (iSetItem == "") { iSetItem = "Text Not Found"; Clipboard.SetText(iSetItem); }
        }
        public string TextDelete(string text, string textDelete)
        {
            // 文字列を空文字に置換する
            return text.Replace(textDelete, "");
        }
        public void DebugOutput(int senderId, string SetItem)
        {
            // Consoleにデバッグ出力する
            if (SetItem != "") { Console.WriteLine(senderId + " " + SetItem); }
            if (SetItem == "") { SetItem = "No Item"; Console.WriteLine(senderId + " " + SetItem); }
        }
        private string GetButtonName(InifileUtils sInifileUtils, int sNum, string sName)
        {
            // iniFileからボタンの名前を取得
            return sInifileUtils.getValueString(sNum.ToString(), sName);
        }
        //private string GetTabName(int i)
        private string GetTabName(int i)
        {
            // IniFile 読み込み
            //InifileUtils[] sIniFile = GetIniFileUtils(i);
            InifileUtils[] sIniFile = GetIniFileUtils();
            // TabPages.Textに表示するタブ名取得
            return sIniFile[i].getValueString("TabPage", "Tab");
        }
        public InifileUtils[] GetIniFileUtils()
        {
            InifileUtils[] sIni = new InifileUtils[5];

            // アプリケーションの格納ディレクトリを取得
            string filePath = GetApplicationPath();
            // 与えたパスからIniFile名を取得
            System.Collections.ObjectModel.ReadOnlyCollection<string> files = GetIniFileName(filePath);
            for (int i = 0; i < 5; i++)
            {
                string iniFileName = files[i].Replace(filePath, "");
                sIni[i] = new InifileUtils(iniFileName);
            }
            // IniFileのCloneを作成し、結果を返す
            return (InifileUtils[])sIni.Clone();
        }
        private System.Collections.ObjectModel.ReadOnlyCollection<string> GetIniFileName(string filePath)
        {
            //参照にMicrosoft.VisualBasic.dllを追加する必要がある
            //"DOBON.NET"を含むHTMLファイルを、大文字小文字を区別して探す
            System.Collections.ObjectModel.ReadOnlyCollection<string> files =
                Microsoft.VisualBasic.FileIO.FileSystem.FindInFiles(filePath,
                "",
                false,
                Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
                new string[] { "*.ini" }
                );

            return files;
        }
        private string GetApplicationPath()
        {
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string filePath = appPath.Replace("ClipBoardItems.exe", "");

            return filePath;
        }
    }
}
