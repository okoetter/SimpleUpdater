using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExampleApp
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        public string Info
        {
            get
            {
                return labelInfo.Text;
            }
            set
            {
                labelInfo.Text = value;
            }
        }

        public string Changelog {
            get
            {
                return textBoxChangelog.Text;
            }

            set
            {
                string result = "";
                foreach (string line in value.Split(new string[] { "\r\n", "\r", "\n"}, StringSplitOptions.None))
                {
                    result += line + Environment.NewLine;
                }
                result = Regex.Replace(result, $"^\\s*{Environment.NewLine}", ""); //remove first empty line
                result = Regex.Replace(result, $"{Environment.NewLine}\\s*$", ""); //remove last empty lines

                textBoxChangelog.Text = result;
            }
        }
    }
}
