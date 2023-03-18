using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NET_FiveMinutes_005_SqlSugarHelper.Interfaces;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Common;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Const;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Models;
using Sunny.UI;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop
{
    public partial class AddForm : UIForm
    {
        private readonly ISqlServerService _iServerService;
        private int _index = -1;
        public AddForm(ISqlServerService iServerService,int index)
        {
            this._iServerService = iServerService;
            _index = index;
            InitializeComponent();
        }

        private void uiButton_OK_Click(object sender, EventArgs e)
        {
            var toolHelperModel = new AlbertToolHelperModel()
            {
                Name = "["+this.textBox_Name.Text+"]("+this.textBox_Link.Text+")",
                Link = this.textBox_Link.Text,
                Description = this.textBox_Description.Text,
                SupportVersion = this.textBox_Version.Text == string.Empty?@"```"+this.textBox_Version.Text + "```":">.NET Framework 4.5",
                Doc = this.textBox_Doc.Text == string.Empty?this.textBox_Link.Text:this.textBox_Doc.Text,
                Sort = this.uiComboBox1.SelectedText
            };
            _iServerService.GetSqlClient().Insertable(toolHelperModel).ExecuteCommand();
            this.DialogResult = DialogResult.OK;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            ComboxBinding.BindEnumToComboBox<AlbertToolHelperEnum>(this.uiComboBox1);
            this.uiComboBox1.SelectedIndex = _index;
        }
    }
}
