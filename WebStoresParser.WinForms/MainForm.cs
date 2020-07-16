using System;
using System.Windows.Forms;
using WebStoresParser.WinForms.Core;
using WebStoresParser.WinForms.Core.Habra;
using WebStoresParser.WinForms.Core.Ksanf;
using WebStoresParser.WinForms.Core.Promelec;
using WebStoresParser.WinForms.Core.Chipdip;
using WebStoresParser.WinForms.Core.Platan;
using WebStoresParser.WinForms.Core.Electronshik;
using WebStoresParser.WinForms.Core.Zip;
using System.Threading.Tasks;

namespace WebStoresParser.WinForms
{
    public partial class MainForm : Form
    {
        ParserWorker<string[]> _parserWorker;
        public MainForm()
        {
            InitializeComponent();
            _parserWorker = new ParserWorker<string[]>(
                new ZipParser()
                );
            _parserWorker.OnCompleted += Parser_OnCompleted;
            _parserWorker.OnNewData += Parser_OnNewData;
            StartBtn.Click += async (sender, e) => { await StartBtn_Click(sender, e); };
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            TitlesList.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Done!");
            StartBtn.Enabled = true;
        }

        private async Task StartBtn_Click(object sender, EventArgs e)
        {
            _parserWorker.Settings = new ZipSettings();
            await _parserWorker.Start(SearchProductTxt.Text);
            (sender as Button).Enabled = false;
        }

        private void AbortBtn_Click(object sender, EventArgs e)
        {
            _parserWorker.Abort();
        }

    
        private void SearchProductTxt_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((sender as TextBox).Text))
            {
                StartBtn.Enabled = AbortBtn.Enabled = true;
                this.AcceptButton = StartBtn;
            }
        }
    }
}
