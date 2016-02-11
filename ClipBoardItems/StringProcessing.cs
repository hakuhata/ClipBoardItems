namespace ClipBoardItems
{
    class StringProcessing
    {
        public string TextDelete(string text, string textDelete)
        {
            // 文字列を空文字に置換する
            return text.Replace(textDelete, "");
        }
    }
}
