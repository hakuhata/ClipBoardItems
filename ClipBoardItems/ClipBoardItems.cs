namespace ClipBoardItems
{
    using System;
    using System.Windows.Forms;
    using TabControls;

    public partial class ClipBoardItems : Form
    {
        private TabControl mainTabControl = new TabControl();
        private TabPage[] tabPage = new TabPage[5];

        private Button[,] buttonId = new Button[5, 20];
        private static readonly string[] iniKeyId = { "CopyID", "NameID" };

        private Button[,] buttonPw = new Button[5, 20];
        private static readonly string[] iniKeyPw = { "CopyPW", "NamePW" };

        public ClipBoardItems()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // サイズ変更不可の直線ウィンドウに変更する
            this.MaximizeBox = !this.MaximizeBox; //フォームの最大化ボタンの表示、非表示を切り替える
            //this.Height = 645;                  // ウィンドウ本体の縦幅
            this.Height = 670;                    // ウィンドウ本体の縦幅
            this.Width = 375;                     // ウィンドウ本体の横幅
        }

        // LoadEvent
        private void ClipBoardItems_Load(object sender, EventArgs e)
        {
            //コントロールの描画を一旦止める
            this.SuspendLayout();

            // MainTabの設定と描画の処理を行う
            var mainControls = new MainTabControls(mainTabControl);
            var mainDraw = new MainTabDrawing(Controls, mainTabControl);
            mainControls.MainTabControlSetting();
            mainDraw.MainTabDrow();

            // TabPageの設定と描画の処理を行う
            var tabControls = new TabPageControls(tabPage);
            var tabPages = new TabPageDrawing(tabPage, mainTabControl);
            tabControls.TabPageControlSetting();
            tabPages.TabPageDrow();

            // ButtonIdの設定と描画の処理を行う
            var btnCreateId = new ButtonCreate(buttonId, ButtonClick, iniKeyId, 10);
            var btnDrawId = new ButtonDrawing(tabPage, buttonId);
            btnCreateId.CreateButton();
            btnDrawId.ButtonDraw();

            // ButtonPwの設定と描画の処理を行う
            var ButtonCreatePw = new ButtonCreate(buttonPw, ButtonClick, iniKeyPw, 170);
            var btnDrawPw = new ButtonDrawing(tabPage, buttonPw);
            ButtonCreatePw.CreateButton();
            btnDrawPw.ButtonDraw();

            //コントロールの描画を再開
            this.ResumeLayout(false);
        }
        // ClickEvent
        private void ButtonClick(object sender, EventArgs e)
        {
            // 押下したボタンから番号と種類を取得する
            ButtonPush btnPush = new ButtonPush(sender);
            int btnNumber = btnPush.PushBtnNum();
            string btnType = btnPush.PushBtnType();

            // iniファイルからクリップボードに読み込む文字列を取得する
            StringIniFile stringIni = new StringIniFile(sender, btnNumber, btnType);
            string BtnText = stringIni.SendText();

            // 空文字の場合はエラーメッセージを取得する
            StringCheck stringCheck = new StringCheck(BtnText);
            BtnText = stringCheck.ConfirmString();

            // ClipBoardに文字列コピー
            ClipBoardSetText clipSet = new ClipBoardSetText(BtnText);
            clipSet.ClipBoardSendText();
        }
    }
}