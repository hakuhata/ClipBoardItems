namespace ClipBoardItems.TabControls
{
    using System.Windows.Forms;

    class TabPageDrawing
    {
        private TabPage[] tabPage;
        private TabControl MainTabControl;

        public TabPageDrawing(TabPage[] tabPage, TabControl MainTabControl)
        {
            this.tabPage = tabPage;
            this.MainTabControl = MainTabControl;
        }

        public void TabPageDrow()
        {
            for (int i = 0; i < 5; i++)
            {
                this.MainTabControl.Controls.Add(this.tabPage[i]); //TabPage表示
            }
        }
    }
}