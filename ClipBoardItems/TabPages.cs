namespace ClipBoardItems
{
    using System.Windows.Forms;

    class TabPages
    {
        public TabPage[] MainTabAndTabPageDrawing(Control.ControlCollection Controls)
        {
            TabPage[] TabPages = new TabPage[5];

            // MainTab描画
            TabControl MainTabControl = MainTabControlDrawing(Controls);
            // TabPageの描画
            TabPageControlDrawing(MainTabControl, TabPages);

            return TabPages;
        }
        private TabControl MainTabControlDrawing(Control.ControlCollection Controls)
        {
            TabControl MainTabControl = new TabControl();

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
            //MainTab表示
            Controls.Add(MainTabControl);

            return MainTabControl;
        }
        private void TabPageControlDrawing(TabControl MainTabControl, TabPage[] TabPages)
        {
            for (int i = 0; i < 5; i++)
            {
                // Tab インスタンス
                TabPages[i] = new TabPage();
                // Nameプロパティを設定
                TabPages[i].Name = "TabPage";
                // タブテキストを設定
                TabPages[i].Text = GetTabName(i);
                //TabPage表示
                MainTabControl.Controls.Add(TabPages[i]);
            }
        }
        private string GetTabName(int i)
        {
            FilePathUtils filePathUtils = new FilePathUtils();

            // IniFile 読み込み
            InifileUtils[] sIniFile = filePathUtils.GetIniFileUtils();
            // TabPages.Textに表示するタブ名取得
            return sIniFile[i].getValueString("TabPage", "Tab");
        }
    }
}