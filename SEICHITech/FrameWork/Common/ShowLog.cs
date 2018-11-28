using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class ShowLog
    {
        private RichTextBox rhbox;
        private object LOCK = new object();
        public ShowLog(RichTextBox box)
        {
            this.rhbox = box;
        }

        public void OutputLog(string msg, WriteLogType LogType, Exception ex = null)
        {
            lock (LOCK)
            {
                if (msg == null || msg.Length <= 0) { return; }
                switch (LogType)
                {
                    case WriteLogType.Normal:
                        ShowLogTextEvent(this.rhbox, msg, Color.Green, new Font("Consolas", 12));
                        break;

                    case WriteLogType.Error:
                        ShowLogTextEvent(this.rhbox, msg, Color.Red, new Font("Consolas", 12));
                        break;

                    case WriteLogType.Warning:
                        ShowLogTextEvent(this.rhbox, msg, Color.Yellow, new Font("Consolas", 12));
                        break;
                    case WriteLogType.Action:
                        ShowLogTextEvent(this.rhbox, msg, Color.Blue, new Font("Consolas", 12));
                        break;
                    default:
                        break;
                }
            }
        }

        public void ShowLogTextEvent(RichTextBox richbox, string message, Color color, Font font)
        {
            if (richbox.InvokeRequired)
            {
                richbox.BeginInvoke(new Action(delegate { ShowLogTextEvent(richbox, message, color, font); }));
                return;
            }
            richbox.SelectionLength = message.Length;
            richbox.SelectionColor = color;
            richbox.SelectionFont = font;
            if (richbox.Lines.Length == 0)
            {
                richbox.AppendText($"[{DateTime.Now.ToString("MM-dd-HH-mm-ss")}]:"+message);
                richbox.ScrollToCaret();
                richbox.AppendText(System.Environment.NewLine);
            }
            else
            {
                richbox.AppendText($"[{DateTime.Now.ToString("MM-dd-HH-mm-ss")}]:" + message);
                richbox.ScrollToCaret();
                richbox.AppendText(System.Environment.NewLine);
            }
        }
    }
}