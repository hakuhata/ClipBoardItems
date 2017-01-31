namespace ClipBoardItems
{
    using System.Windows.Forms;

    class StringIniFile
    {
        private int tabIndex; // ButtonのTabIndex
        private int btnNumber; // BubbonのNumber
        private string btnType; // Buttonの種類(ID,PW)

        public StringIniFile(object sender, int btnNumber, string btnType)
        {
            this.tabIndex = ((Button)sender).TabIndex;
            this.btnNumber = btnNumber;
            this.btnType = btnType;
        }

        public string SendText()
        {
            GetExecutingAssembly getAssembly = new GetExecutingAssembly();
            string dirPath = getAssembly.GetApplicationDirectory();

            return getValueString(dirPath);
        }
        private string getValueString(string dirPath)
        {
            FilePathUtils filePath = new FilePathUtils(dirPath);
            InifileUtils[] ini = filePath.IniFileNameArray(); // ファイルパス取得
            // iniFileからクリップボードに送る文字列取得
            return ini[this.tabIndex].getValueString(this.btnNumber.ToString(), this.btnType);
        }
    }
}