namespace ClipBoardItems
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;

    class ButtonSetting
    {
        // ボタンを20個作成
        public Button[] ValueButtonCreate(EventHandler ButtonClick, string btnName, string btnText, TabPage[] TabPages, int DrawPointX)
        {
            FilePathUtils filePath = new FilePathUtils();
            Button[] button = new Button[20];

            for (int i = 0; i < 20; i++)
            {
                for (int tabNum = 0; tabNum < 5; tabNum++)
                {
                    button[i] = new Button();
                    button[i].Location = new Point(DrawPointX, 10 + 27 * i);
                    button[i].Name = btnName + i.ToString();
                    button[i].Size = new Size(150, 25);
                    button[i].TabIndex = tabNum;
                    button[i].Text = filePath.GetIniValue(tabNum, i, btnText); // ボタンのタイトルを取得
                    button[i].TextAlign = ContentAlignment.MiddleLeft; // ボタン表示テキストを中段左寄せ
                    button[i].Click += new EventHandler(ButtonClick); // イベントハンドラの登録

                    TabPages[tabNum].Controls.Add(button[i]);
                }
            }
            return (Button[])button.Clone();
        }
    }
}