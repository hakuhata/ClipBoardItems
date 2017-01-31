namespace ClipBoardItems
{
    using System.Reflection;

    class GetExecutingAssembly
    {
        public string GetApplicationDirectory()
        {
            return Assembly.GetExecutingAssembly().Location.Replace("ClipBoardItems.exe", ""); ;
        }
    }
}
