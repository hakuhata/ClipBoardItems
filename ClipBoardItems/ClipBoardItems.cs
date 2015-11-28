using System;
using System.Windows.Forms;
using System.Drawing;

namespace ClipBoardItems
{
    public partial class ClipBoardItems : Form
    {
        private static Setting setting = new Setting();
        private string[] arrayText = new string[256];
        private ValueButton[] ButtonId = new ValueButton[setting.DoButtonQuantity()];
        private ValueButton[] ButtonPw = new ValueButton[setting.DoButtonQuantity()];
        private InifileUtils sInifileUtils = new InifileUtils("Item.ini");

        public ClipBoardItems()
        {
            InitializeComponent();
            Text = "ClipBoardItem";
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更不可の直線ウィンドウに変更する
            this.MaximizeBox = !this.MaximizeBox;               //フォームの最大化ボタンの表示、非表示を切り替える
            //this.MinimizeBox = !this.MinimizeBox;             //フォームの最小化ボタンの表示、非表示を切り替える
            //this.BackColor = Color.FromKnownColor(KnownColor.Window); // このフォームの背景色をウィンドウの背景にする (システム色の名前による指定)
            this.Height += setting.DoButtonQuantity() * 25;
            this.Width = 330;
            //TextFileOpen();
            setting.DoButtonQuantity();
        }
        private void ClipBoardItems_Load(object sender, EventArgs e)
        {
            for (int i = 0, j = 0, k = 0, h = 0; i < setting.DoButtonQuantity(); i++, j += 3, k += 3, h += 3)
            {
                ButtonId[i] = new ValueButton();                                          // インスタンスを作成
                ButtonId[i].Location = new System.Drawing.Point(0,25 * i);                // 配置位置を設定
                ButtonId[i].Name = "ID:" + i.ToString();                                  // Nameプロパティを設定
                ButtonId[i].Size = new System.Drawing.Size(150, 25);                      // サイズを設定
                ButtonId[i].TabIndex = i + 1;                                             // TabIndexを設定
                ButtonId[i].Text = GetButtonName(i, "ButtonNameID");                          // ボタンテキストを設定
                ButtonId[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                ButtonId[i].Click += new System.EventHandler(ButtonClickId);              // イベントハンドラの登録
                this.Controls.Add(ButtonId[i]);                                           // フォームに配置
                ButtonId[i].value = arrayText[j + 1];                                     // txtのID行を読む
                ButtonId[i].BackColor = SystemColors.Control;

                ButtonPw[i] = new ValueButton();                                          // インスタンスを作成
                ButtonPw[i].Location = new System.Drawing.Point(160,25 * i);              // 配置位置を設定
                ButtonPw[i].Name = "PW:" + i.ToString();                                  // Nameプロパティを設定
                ButtonPw[i].Size = new System.Drawing.Size(150, 25);                      // サイズを設定
                ButtonPw[i].TabIndex = i + 1;                                             // TabIndexを設定
                ButtonPw[i].Text = GetButtonName(i, "ButtonNamePW");                          // ボタンテキストを設定
                ButtonPw[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                ButtonPw[i].Click += new System.EventHandler(ButtonClickPw);              // イベントハンドラの登録
                this.Controls.Add(ButtonPw[i]);                                           // フォームに配置
                ButtonPw[i].value = arrayText[j + 2];                                     // txtのPW行を読む
                ButtonPw[i].BackColor = SystemColors.Control;
            }
        }

        private void ButtonClickId(object sender, EventArgs e)
        {
            int number = int.Parse(DoStringDelete(((System.Windows.Forms.Button)sender).Name)); // Nameから不要な文字列を置換して、押下したボタンの数値を取得
            DoClipBoardSet(GetkeyName(number,"ID")); // Clipboard に文字列をコピーする

            // Button ColorをDefaultにする
            DoButtonColorLiset();
            // 押下したButton Color変更
            ButtonId[number].BackColor = Color.FromArgb(
                setting.ButtonIdColor(0, "R"),
                setting.ButtonIdColor(1, "G"),
                setting.ButtonIdColor(2, "B")
            );

            DebugOutput(number, GetkeyName(number,"PW")); // Console Debug Output
        }
        private void ButtonClickPw(object sender, EventArgs e)
        {
            int number = int.Parse(DoStringDelete(((System.Windows.Forms.Button)sender).Name)); // Nameから不要な文字列を置換して、押下したボタンの数値を取得
            DoClipBoardSet(GetkeyName(number, "PW")); // Clipboard に文字列をコピーする

            // Button ColorをDefaultにする
            DoButtonColorLiset();
            // 押下したButton Color変更
            ButtonPw[number].BackColor = Color.FromArgb(
                setting.ButtonPwColor(0, "R"),
                setting.ButtonPwColor(1, "G"),
                setting.ButtonPwColor(2, "B")
            );

            DebugOutput(number, GetkeyName(number, "PW")); // Console Debug Output
        }
        /* ========== File Open ========== */
        //private void TextFileOpen()
        //{
        //    try { this.arrayText = System.IO.File.ReadAllLines(@"Item.txt", System.Text.Encoding.GetEncoding("shift-jis")); }
        //    catch (Exception)
        //    { MessageBox.Show("読み込めるテキストファイルがありません"); }
        //}
        /* ========== String Copy ========== */
        private void DoClipBoardSet(string SetItem)
        {
            if (SetItem != "") { Clipboard.SetText(SetItem); } // クリップボードに文字列をコピーする
            if (SetItem == "") { SetItem = "No Item"; Clipboard.SetText(SetItem); }
        }
        private string DoStringDelete(string text)
        {
            text = text.Replace("ID:", ""); // 文字列を置換
            text = text.Replace("PW:", ""); // 文字列を置換
            text = text.Replace("Service:", ""); // 文字列を置換
            return text;
        }

        private string GetButtonName(int sNum, string sName)
        {
            return sInifileUtils.getValueString(sNum.ToString(), sName);
        }
        private string GetkeyName(int sNum, string sName)
        {
            return sInifileUtils.getValueString(sNum.ToString(), sName);
        }
        private void DoButtonColorLiset()
        {
            for (int i = 0; i < setting.DoButtonQuantity(); i++)
            {
                ButtonId[i].BackColor = SystemColors.Control; //ButtonId[i].BackColor = Color.Empty;
                ButtonPw[i].BackColor = SystemColors.Control; //ButtonId[i].BackColor = Color.Empty;
            }
        }
        /* ========== Debug ========== */
        private void DebugOutput(int senderId, string SetItem)
        {
            if (SetItem != "") { Console.WriteLine(senderId + " " + SetItem); }
            if (SetItem == "") { SetItem = "No Item"; Console.WriteLine(senderId + " " + SetItem); }
        }
    }
}