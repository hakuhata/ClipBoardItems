namespace ClipBoardItems
{
    using Microsoft.VisualBasic.FileIO;
    using System.Collections.ObjectModel;
    using System.Windows.Forms;

    class FindFiles
    {
        private string DirectoryPath;

        public FindFiles(string DirectoryPath)
        {
            this.DirectoryPath = DirectoryPath;
        }

        public ReadOnlyCollection<string> GetIniFileName()
        {
            //"DOBON.NET"を含むHTMLファイルを、大文字小文字を区別して探す ※参照にMicrosoft.VisualBasic.dllを追加する必要がある
            return FileSystem.FindInFiles(this.DirectoryPath, "", false, SearchOption.SearchAllSubDirectories, new string[] { "*.ini" });
        }
    }
}
