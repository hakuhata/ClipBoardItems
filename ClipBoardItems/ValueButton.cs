namespace ClipBoardItems
{
    using System.Windows.Forms;

    public partial class ValueButton : Button
    {
        //private static ValueButton button = new ValueButton();
        private static ValueButton[] button = new ValueButton[20];

        private static int btnDrawingPointX;
        private static string btnName;
        private static string btnText;

        public void BtnType(int drawPoint, string name, string text)
        {
            btnDrawingPointX = drawPoint;
            btnName = name;
            btnText = text;
        }
        public string strProcessing(string senderName, string strCopy)
        {
            StringProcessing strProcessing = new StringProcessing();
            return strProcessing.TextDelete(senderName, strCopy);
        }
        public void ClipBoardCopy(string keyButton)
        {
            StringClipboardCopy clipCopy = new StringClipboardCopy();
            clipCopy.DoClipBoardSet(keyButton); // Clipboard に文字列をコピーする
        }
        public string GetIniValue(int tabNum, int i, string btnValue)
        {
            FilePathUtils filePathUtils = new FilePathUtils();
            InifileUtils[] InifileArray = filePathUtils.GetIniFileUtils();

            return InifileArray[tabNum].getValueString(i.ToString(), btnValue);
        }
        public void ButtonCreate(System.EventHandler ButtonClick, TabPage[] TabPages)
        {
            // ボタンの初期化

            for (int i = 0; i < 20; i++)
            {
                for (int tabNum = 0; tabNum < 5; tabNum++)
                {
                    // インスタンスを作成
                    button[i] = new ValueButton();
                    // 配置位置を設定
                    button[i].Location = new System.Drawing.Point(btnDrawingPointX, 10 + 27 * i);
                    // Nameプロパティを設定
                    button[i].Name = btnName + i.ToString();
                    // サイズを設定
                    button[i].Size = new System.Drawing.Size(150, 25);
                    // TabIndexを設定 TabPagesの値
                    button[i].TabIndex = tabNum;
                    // ボタンテキストを設定
                    button[i].Text = GetIniValue(tabNum, i, btnText); // InifileArray[tabNum].getValueString(i.ToString(), btnText);
                    // ボタン表示テキストを中段左寄せ
                    button[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    // イベントハンドラの登録
                    button[i].Click += new System.EventHandler(ButtonClick);

                    TabPages[tabNum].Controls.Add(button[i]);
                }
            }
        }
    }
}
