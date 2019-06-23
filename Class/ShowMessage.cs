using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium
{
    public static class ShowMessage 
    {
        private enum MessageType
        {
            Success = 0,
            Warning = 1,
            Error = 2
        }
        private static Dictionary<string, MessageBoxIcon> messageDict = new Dictionary<string, MessageBoxIcon>()
            {{ "Başarılı!",MessageBoxIcon.Information},{ "Uyarı!",MessageBoxIcon.Warning }, { "HATA!",MessageBoxIcon.Error}};

        private static void Show(string msg, MessageType type)
        {
            var choosed = messageDict.ElementAt((int)type);
            MessageBox.Show(msg, choosed.Key, MessageBoxButtons.OK, choosed.Value, MessageBoxDefaultButton.Button1);
        }
        public static void Warning(string msg)
        {
            Show(msg, MessageType.Warning);
        }
        public static void Error(string msg)
        {
            Show(msg, MessageType.Error);
        }
        public static void Success(string msg)
        {
            Show(msg, MessageType.Success);
        }
    }
}
