namespace ClipBoardItems
{
    using System.Windows.Forms;

    class ButtonPush
    {
        private string btnName;
        private string btnNumber;

        public ButtonPush(object sender)
        {
            this.btnName = ((Button)sender).Name;
            this.btnNumber = PushBtnNumber();
        }

        // Typeを取得
        public string PushBtnType()
        {
            return this.btnName.Remove(6); // 不要な6番目の数字を削除
        }
        // ボタンの番号をキャスト
        public int PushBtnNum()
        {
            return int.Parse(this.btnNumber);
        }
        // Numberを取得
        private string PushBtnNumber()
        {
            string btnType = PushBtnType();
            return this.btnName.Replace(btnType, ""); // btnType に指定した文字列を削除
        }
    }
}
