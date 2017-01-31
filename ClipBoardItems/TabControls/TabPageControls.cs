namespace ClipBoardItems.TabControls
{
    using System.Windows.Forms;

    class TabPageControls
    {
        private TabPage[] tabPage;

        public TabPageControls(TabPage[] tabPage)
        {
            this.tabPage = tabPage;
        }

        public void TabPageControlSetting()
        {
            GetExecutingAssembly getAssembly = new GetExecutingAssembly();
            string dirPath = getAssembly.GetApplicationDirectory();

            for (int i = 0; i < 5; i++)
            {
                this.tabPage[i] = new TabPage();
                this.tabPage[i].Name = "TabPage";
                this.tabPage[i].Text = getValueString(dirPath, i);
            }
        }
        private string getValueString(string dirPath, int i)
        {
            FilePathUtils FilePath = new FilePathUtils(dirPath);
            InifileUtils[] fileName = FilePath.IniFileNameArray();

            return fileName[i].getValueString("TabPage", "Tab");
        }
    }
}