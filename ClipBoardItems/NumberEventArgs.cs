using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipBoardItems
{
    /* 使い方
     * public delegate void ButtonClickEventHandler(object sender, NumberEventArgs e);
     * public event ButtonClickEventHandler ButtonClick;
     * 
     * public static NumberEventArgs numberEventArgs = new NumberEventArgs();
     * public static Listener listener = new Listener();
     * 
     * public ClipBoardItems()
     * {
     *   InitializeComponent();
     *   ButtonClick += listener.OnHoge;
     * }
     */


    //public class NumberEventArgs : EventArgs
    //{
    //    private static int[] buttonId = new int[40];

    //    public void Number(int dataId)
    //    {
    //        buttonId[ClipBoardItems.i] = dataId;
    //    }
    //    public int IdNumber
    //    {
    //        get { return buttonId[0]; }
    //    }
    //}

    //public class Listener
    //{
    //    public void OnHoge(object sender, NumberEventArgs e)
    //    {
    //        Show(e.IdNumber);
    //    }

    //    private void Show(int dataId)
    //    {
    //        Console.WriteLine(dataId);
    //    }
    //}
}
