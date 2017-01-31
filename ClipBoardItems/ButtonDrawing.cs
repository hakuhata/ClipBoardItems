namespace ClipBoardItems
{
    using System;
    using System.Windows.Forms;
    
    class ButtonDrawing
    {
        private TabPage[] tabPage;
        private Button[,] button;

        public ButtonDrawing(TabPage[] tabPage, Button[,] button)
        {
            this.tabPage = tabPage;
            this.button = button;
        }
        public void ButtonDraw()
        {
            for (int tabNum = 0; tabNum < 5; tabNum++)
            {
                addButtonDrawing(tabNum);
            }
        }
        private void addButtonDrawing(int tabNum)
        {
            for (int i = 0; i < 20; i++)
            {
                this.tabPage[tabNum].Controls.Add(this.button[tabNum, i]);
            }
        }
    }
}