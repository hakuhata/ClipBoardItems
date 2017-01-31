namespace ClipBoardItems.TabControls
{
    using System.Windows.Forms;

    class MainTabDrawing
    {
        private Control.ControlCollection Controls;
        private TabControl MainTabControl;

        public MainTabDrawing(Control.ControlCollection Controls, TabControl MainTabControl)
        {
            this.Controls = Controls;
            this.MainTabControl = MainTabControl;
        }

        public void MainTabDrow()
        {
            this.Controls.Add(this.MainTabControl); //MainTab表示
        }
    }
}
