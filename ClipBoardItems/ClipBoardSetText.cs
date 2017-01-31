namespace ClipBoardItems
{
    using System.Windows.Forms;

    class ClipBoardSetText
    {
        private string keyButton;

        public ClipBoardSetText(string keyButton)
        {
            this.keyButton = keyButton;
        }

        public void ClipBoardSendText()
        {
            Clipboard.SetText(this.keyButton); // クリップボードに文字列をコピーする
        }
    }
}
