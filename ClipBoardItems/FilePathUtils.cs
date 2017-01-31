namespace ClipBoardItems
{
    using System.Collections.ObjectModel;

    class FilePathUtils
    {
        private FindFiles findFile;
        private string directoryPath;
        private int iniFileQuantity = 0; // iniファイルの数

        public FilePathUtils(string directoryPath)
        {
            findFile = new FindFiles(directoryPath); // 全てのIniファイルが入る
            this.directoryPath = directoryPath;
        }

        // 全てのiniファイル名を取得
        public InifileUtils[] IniFileNameArray()
        {
            string iniFileName = "";
            string dirPath = this.directoryPath;
            InifileUtils[] sIni = new InifileUtils[5];
            ReadOnlyCollection<string> iniFile = findFile.GetIniFileName();
            int fileQuantity = this.iniFileQuantity;

            for (fileQuantity = 0; fileQuantity < 5; fileQuantity++)
            {
                iniFileName = iniFile[fileQuantity].Replace(dirPath, ""); // Iniファイルパスからファイル名のみに置換する
                sIni[fileQuantity] = new InifileUtils(iniFileName); // ファイル名のみのIniファイルを配列に格納
            }
            return (InifileUtils[])sIni.Clone(); // すべてのIniファイル名を返す
        }
    }
}