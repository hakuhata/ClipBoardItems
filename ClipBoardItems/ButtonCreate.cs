namespace ClipBoardItems
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    class ButtonCreate
    {
        private Button[,] button;
        private EventHandler ButtonClick;
        private string[] iniKey;
        private int pointX;
        
        public ButtonCreate(Button[,] button, EventHandler ButtonClick, string[] iniKey, int pointX)
        {
            this.ButtonClick = ButtonClick;
            this.iniKey = iniKey;
            this.pointX = pointX;
            this.button = button;
        }

        public void CreateButton()
        {
            GetExecutingAssembly getAssembly = new GetExecutingAssembly();
            string dirPath = getAssembly.GetApplicationDirectory();
            FilePathUtils filePath = new FilePathUtils(dirPath);
            InifileUtils[] ini = filePath.IniFileNameArray(); // ファイルパス取得

            for (int tabNum = 0; tabNum < 5; tabNum++)
            {
                addButton(tabNum, ini);
            }
        }
        private void addButton(int tabNum, InifileUtils[] ini)
        {
            for (int i = 0; i < 20; i++)
            {
                button[tabNum, i] = new Button();
                button[tabNum, i].Location = new Point(this.pointX, 10 + 27 * i);
                button[tabNum, i].Name = this.iniKey[0] + i.ToString();
                button[tabNum, i].Size = new Size(150, 25);
                button[tabNum, i].TabIndex = tabNum;
                button[tabNum, i].Text = getValueString(ini, tabNum, i, iniKey); // ボタンのタイトルを取得
                button[tabNum, i].TextAlign = ContentAlignment.MiddleLeft; // ボタン表示テキストを中段左寄せ
                button[tabNum, i].Click += new EventHandler(this.ButtonClick); // イベントハンドラの登録
            }
        }
        private string getValueString(InifileUtils[] ini, int tabNum, int i, string[] iniKey)
        {
            return ini[tabNum].getValueString(i.ToString(), iniKey[1]); // ボタンのタイトルを取得
        }
    }
}