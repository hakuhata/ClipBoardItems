namespace ClipBoardItems.TabControls
{
    using System.Windows.Forms;

    class MainTabControls
    {
        private TabControl MainTabControl;

        public MainTabControls(TabControl MainTabControl)
        {
            this.MainTabControl = MainTabControl;
        }

        public void MainTabControlSetting()
        {
            this.MainTabControl.Location = new System.Drawing.Point(10, 10);
            this.MainTabControl.Name = "tabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(340, 585);
            this.MainTabControl.TabIndex = 0;
        }
    }
}
