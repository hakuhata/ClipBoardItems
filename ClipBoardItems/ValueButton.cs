using System;
using System.Windows.Forms;
using System.Drawing;

namespace ClipBoardItems
{
    public partial class ValueButton : Button
    {
        private InifileUtils[] sIni = new InifileUtils[5];

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
        private string GetTabName(int i)
        {
            // IniFile 読み込み
            InifileUtils[] sIniFile = GetIniFileUtils(i);
            // TabPages.Textに表示するタブ名取得
            return sIniFile[i].getValueString("TabPage", "Tab");
        }
        private InifileUtils[] GetIniFileUtils(int i)
        {
            // IniFile読み込み
            sIni[i] = new InifileUtils("Item0" + (i + 1).ToString() + ".ini");
            // IniFileのCloneを作成し、結果を返す
            return (InifileUtils[])sIni.Clone();
        }
    }
}
