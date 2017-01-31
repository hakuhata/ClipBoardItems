namespace ClipBoardItems
{
    class StringCheck
    {
        private string keyButton;

        public StringCheck(string keyButton)
        {
            this.keyButton = keyButton;
        }

        public string ConfirmString()
        {
            return ConfirmStringCheck() == true ? "Text Not Found" : this.keyButton;
        }
        private bool ConfirmStringCheck()
        {
            return this.keyButton == "" ? true : false;
        }
    }
}
