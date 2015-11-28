namespace ClipBoardItems
{
    public partial class Setting
    {
        private InifileUtils sInifileUtils = new InifileUtils("Setting.ini");

        private int[] buttonIdColorRGB = new int[3];
        private int[] buttonPwColorRGB = new int[3];

        public Setting()
        {
            buttonIdColorRGB[0] = 0xFF;
            buttonIdColorRGB[1] = 0xFF;
            buttonIdColorRGB[2] = 0xFF;
            buttonPwColorRGB[0] = 0xFF;
            buttonPwColorRGB[1] = 0xFF;
            buttonPwColorRGB[2] = 0xFF;
        }

        public int DoButtonQuantity()
        {
            return int.Parse(sInifileUtils.getValueString("Button", "ButtonQuantity"));
        }
        // ボタンの色
        public int ButtonIdColor(int numberColorArrary, string ButtonColorKey)
        {
            return buttonIdColorRGB[numberColorArrary] = int.Parse(sInifileUtils.getValueString("ButtonIdColor", ButtonColorKey));
        }
        public int ButtonPwColor(int numberColorArrary, string ButtonColorKey)
        {
            return buttonPwColorRGB[numberColorArrary] = int.Parse(sInifileUtils.getValueString("ButtonPwColor", ButtonColorKey));
        }
    }
}
