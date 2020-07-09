using System;
using System.Windows.Forms;
using WebStoresParser.WinForms.Core;
using WebStoresParser.WinForms.Core.Habra;
using WebStoresParser.WinForms.Core.Ksanf;

namespace WebStoresParser.WinForms
{
    public partial class MainForm : Form
    {
        ParserWorker<string[]> _parser;
        public MainForm()
        {
            InitializeComponent();
            _parser = new ParserWorker<string[]>(
                new KsanfParser()
                );
            _parser.OnCompleted += Parser_OnCompleted;
            _parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            TitlesList.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Done!");
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            _parser.Settings = new KsanfSettings();
            _parser.Start(SearchProductTxt.Text);
        }

        private void AbortBtn_Click(object sender, EventArgs e)
        {
            _parser.Abort();
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
