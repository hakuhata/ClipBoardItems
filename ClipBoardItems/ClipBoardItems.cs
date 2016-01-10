using System;
using System.Windows.Forms;
using System.Drawing;

namespace ClipBoardItems
{
    public partial class ClipBoardItems : Form
    {
        private static ValueButton button = new ValueButton();
        private InifileUtils[] sIniFileUtils = button.GetIniFileUtils();

        public ClipBoardItems()
        {
            InitializeComponent();
            // サイズ変更不可の直線ウィンドウに変更する
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //フォームの最大化ボタンの表示、非表示を切り替える
            this.MaximizeBox = !this.MaximizeBox;
            // ウィンドウ本体の縦幅
            this.Height += 105 + 25 * 20;
            // ウィンドウ本体の横幅
            this.Width = 375;
        }

        // タブ描画、ボタン描画
        private void ClipBoardItems_Load(object sender, EventArgs e)
        {
            TabControl MainTabControl = new System.Windows.Forms.TabControl();
            TabPage[] TabPages = new System.Windows.Forms.TabPage[10];

            //コントロールの描画を一旦止める
            this.SuspendLayout();

            // MainTabの初期値
            button.MainTabControl(MainTabControl);
            //MainTab表示
            Controls.Add(MainTabControl);

            for (int i = 0; i < 5; i++ )
            {
                // Tab インスタンス
                TabPages[i] = new TabPage();
                // TabPagesの初期値
                button.TabPages(TabPages[i], i);
                //TabPage表示
                MainTabControl.Controls.Add(TabPages[i]); 
            }
            
            for (int i = 0; i < 20; i++)
            {
                // 指定ボタン数を表示
                Control btnIdCreate = button.ButtonCreate(button, ButtonClickId, i, 1, sIniFileUtils[0]);
                // TabPageにボタンを表示
                TabPages[0].Controls.Add(btnIdCreate);

                // 指定ボタン数を表示
                Control btnPwCreate = button.ButtonCreate(button, ButtonClickPw, i, 2, sIniFileUtils[0]);
                // TabPageにボタンを表示
                TabPages[0].Controls.Add(btnPwCreate);
            }
            //--------------------------------------------------------------------
            for (int i = 0; i < 20; i++)
            {
                Control btnIdCreate2nd = button.ButtonCreate(button, ButtonClickId2nd, i, 1, sIniFileUtils[1]);
                TabPages[1].Controls.Add(btnIdCreate2nd);
                Control btnIdCreate3rd = button.ButtonCreate(button, ButtonClickId3rd, i, 1, sIniFileUtils[2]);
                TabPages[2].Controls.Add(btnIdCreate3rd);
                Control btnIdCreate4th = button.ButtonCreate(button, ButtonClickId4th, i, 1, sIniFileUtils[3]);
                TabPages[3].Controls.Add(btnIdCreate4th);
                Control btnIdCreate5th = button.ButtonCreate(button, ButtonClickId5th, i, 1, sIniFileUtils[4]);
                TabPages[4].Controls.Add(btnIdCreate5th);

                Control btnPwCreate2nd = button.ButtonCreate(button, ButtonClickPw2nd, i, 2, sIniFileUtils[1]);
                TabPages[1].Controls.Add(btnPwCreate2nd);
                Control btnPwCreate3rd = button.ButtonCreate(button, ButtonClickPw3rd, i, 2, sIniFileUtils[2]);
                TabPages[2].Controls.Add(btnPwCreate3rd);
                Control btnPwCreate4th = button.ButtonCreate(button, ButtonClickPw4th, i, 2, sIniFileUtils[3]);
                TabPages[3].Controls.Add(btnPwCreate4th);
                Control btnPwCreate5th = button.ButtonCreate(button, ButtonClickPw5th, i, 2, sIniFileUtils[4]);
                TabPages[4].Controls.Add(btnPwCreate5th);

            }
            //コントロールの描画を再開
            this.ResumeLayout(false); 
        }
        // IDボタンをクリック時の動作
        private void ButtonClickId(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[0], "CopyID");
        }
        private void ButtonClickId2nd(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[1], "CopyID");
        }
        private void ButtonClickId3rd(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[2], "CopyID");
        }
        private void ButtonClickId4th(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[3], "CopyID");
        }
        private void ButtonClickId5th(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[4], "CopyID");
        }
        // PWボタンをクリック時の動作
        private void ButtonClickPw(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[0], "CopyPW");
        }
        private void ButtonClickPw2nd(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[1], "CopyPW");
        }
        private void ButtonClickPw3rd(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[2], "CopyPW");
        }
        private void ButtonClickPw4th(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[3], "CopyPW");
        }
        private void ButtonClickPw5th(object sender, EventArgs e)
        {
            ButtonClickEvent(sender, e, sIniFileUtils[4], "CopyPW");
        }
        //----------------------------------------------------

        private void ButtonClickEvent(object sender, EventArgs e, InifileUtils sIniFile, string IdPwString)
        {
            // senderからNameの値を取得
            string senderName = ((System.Windows.Forms.Button)sender).Name;
            // 文字列を削除して数字のみにする
            int number = int.Parse(button.TextDelete(senderName, IdPwString));
            // Ini File から文字列を取得
            string keyButton = button.GetkeyName(sIniFile, number, IdPwString);
            // Clipboard に文字列をコピーする
            button.DoClipBoardSet(keyButton);
            // Console Debug Output
            //button.DebugOutput(number, button.GetkeyName(sIniFile, number, IdPwString));
            //DebugOutput(number, GetButtonName(number, "ButtonNamePW")); // Console Debug Output
        }
    }
}