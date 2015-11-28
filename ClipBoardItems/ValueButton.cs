using System.Windows.Forms;

namespace ClipBoardItems
{
    public partial class ValueButton : Button
    {
        public string value; // txtの文字列格納用

        public ValueButton()
        {
            value = "";
        }
    }
}
