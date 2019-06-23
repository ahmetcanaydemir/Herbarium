using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Herbarium
{
    public class CueTextBox: TextBox
    {
        /// <summary>
        /// The cue banner text.
        /// </summary>
        private string _cueText;

        /// <summary>
        /// Gets or sets the cue banner text.
        /// </summary>
        public string CueText
        {
            get
            {
                return _cueText;
            }

            set
            {
                _cueText = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">A Windows Message object.</param>
        [DebuggerStepThrough]
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_PAINT = 0xF;
            System.Drawing.Font newFont = new System.Drawing.Font(Font.FontFamily, 9);
            if (m.Msg == WM_PAINT)
            {
                if (!Focused && String.IsNullOrEmpty(Text) && !String.IsNullOrEmpty(CueText))
                {
                    using (var graphics = CreateGraphics())
                    {
                        TextRenderer.DrawText(
                            dc: graphics,
                            text: CueText,
                            font: newFont,
                            bounds: ClientRectangle,
                            foreColor: System.Drawing.SystemColors.GrayText,
                            backColor: Enabled ? BackColor : System.Drawing.SystemColors.Control,
                            flags: TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                    }
                }
            }
        }
    }
}
