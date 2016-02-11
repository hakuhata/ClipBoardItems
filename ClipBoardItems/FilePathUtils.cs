namespace ClipBoardItems
{
    using System.Collections.ObjectModel;
    using Microsoft.VisualBasic.FileIO;
    using System.Reflection;

    class FilePathUtils
    {
        public InifileUtils[] GetIniFileUtils()
        {
            // IniFileのファイル名を取得するメソッド

            int num = 5;
            InifileUtils[] sIni = new InifileUtils[num];

            // アプリケーションの格納ディレクトリを取得
            string filePath = GetApplicationPath();
            // アプリケーションのパスからIniFile名を取得
            ReadOnlyCollection<string> files = GetIniFileName(filePath);

            for (int i = 0; i < num; i++)
            {
                // Iniファイルパスからファイル名のみに置換する
                string iniFileName = files[i].Replace(filePath, "");
                // ファイル名のみのIniファイルを配列に格納
                sIni[i] = new InifileUtils(iniFileName);
            }
            // IniFileのCloneを作成し、結果を返す
            return (InifileUtils[])sIni.Clone();
        }
        private ReadOnlyCollection<string> GetIniFileName(string filePath)
        {
            //参照にMicrosoft.VisualBasic.dllを追加する必要がある
            //"DOBON.NET"を含むHTMLファイルを、大文字小文字を区別して探す
            ReadOnlyCollection<string> files = FileSystem.FindInFiles(filePath, "", false, SearchOption.SearchAllSubDirectories, new string[] { "*.ini" } );

            return files;
        }
        private string GetApplicationPath()
        {
            string appPath = Assembly.GetExecutingAssembly().Location;
            //string filePath = appPath.Replace("ClipBoardItems.exe", "");

            return appPath.Replace("ClipBoardItems.exe", "");
        }
    }
}
