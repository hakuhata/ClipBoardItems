namespace ClipBoardItems
{
    public partial class Setting
    {
        private InifileUtils sInifileUtils = new InifileUtils("Setting.ini");

        public Setting()
        {
        }

        public int DoButtonQuantity()
        {
            return int.Parse(sInifileUtils.getValueString("Button", "ButtonQuantity"));
        }
    }
}
