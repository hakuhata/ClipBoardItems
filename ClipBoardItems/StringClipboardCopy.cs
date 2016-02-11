namespace ClipBoardItems
{
    using System.Windows.Forms;

    class StringClipboardCopy
    {
        public void DoClipBoardSet(string iSetItem)
        {
            // クリップボードに文字列をコピーする
            if (iSetItem != "") { Clipboard.SetText(iSetItem); }
            if (iSetItem == "") { Clipboard.SetText("Text Not Found"); }
        }

    }
}
