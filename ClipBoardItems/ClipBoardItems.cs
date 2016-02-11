namespace ClipBoardItems
{
    using System;
    using System.Windows.Forms;

    public partial class ClipBoardItems : Form
    {
        ValueButton valBtn = new ValueButton();

        public ClipBoardItems()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // サイズ変更不可の直線ウィンドウに変更する
            this.MaximizeBox = !this.MaximizeBox;               //フォームの最大化ボタンの表示、非表示を切り替える
            this.Height = 645;                                  // ウィンドウ本体の縦幅
            this.Width = 375;                                   // ウィンドウ本体の横幅
        }
        private void ClipBoardItems_Load(object sender, EventArgs e)
        {
            this.SuspendLayout(); //コントロールの描画を一旦止める

            TabPages tabPage = new TabPages();
            TabPage[] TabPages = tabPage.MainTabAndTabPageDrawing(Controls); // TabPageの描画

            valBtn.BtnType(10, "CopyID", "NameID");     // ボタンの初期値設定
            valBtn.ButtonCreate(ButtonClick, TabPages); // ボタンをタブページに描画
            valBtn.BtnType(170, "CopyPW", "NamePW");    // ボタンの初期値設定
            valBtn.ButtonCreate(ButtonClick, TabPages); // ボタンをタブページに描画

            this.ResumeLayout(false); //コントロールの描画を再開
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            string senderName = ((Button)sender).Name;
            // Nameから数字を取り除いて、CopyID or CopyPW のみにする
            string strCopy = senderName.Remove(6);
            // 不要な文字列を削除して数値のみにする
            string nameNumber = valBtn.strProcessing(senderName, strCopy);
            // 
            int number = int.Parse(nameNumber);
            // TabPageに使用する番号を取得
            int tabNumber = ((Button)sender).TabIndex;

            // Ini File から文字列を取得
            string keyButton = valBtn.GetIniValue(tabNumber, number, strCopy);
            // Clipboardに文字列をコピーする
            valBtn.ClipBoardCopy(keyButton);
        }
    }
}