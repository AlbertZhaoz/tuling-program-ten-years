using Aspose.Cells;
using MiniExcelLibs;
using NET_FiveMinutes_005_SqlSugarHelper.Interfaces;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Common;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Const;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CliWrap;
using CliWrap.Buffered;
using Microsoft.Extensions.Options;
using NET_FiveMinutes_006_AlbertToolHelperDesktop.DTOs;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop
{
    public partial class MainFrm : Form
    {
        private readonly ISqlServerService _iServerService; 
        private readonly IOptionsSnapshot<PushDto> _option; 
            
        private DataTable dtSource = null;
        public MainFrm(ISqlServerService iServerService,IOptionsSnapshot<PushDto> _option)
        {
            this._iServerService = iServerService;
            this._option = _option;
            _iServerService.CreateTableByModels(Assembly.GetExecutingAssembly());
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            ComboxBinding.BindEnumToComboBox<AlbertToolHelperEnum>(this.uiComboBox1);
            BindingDtSource(AlbertToolHelperEnum.ToolHelper.ToString());
        }

        private void uiAvatar_OK_Click(object sender, EventArgs e)
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory+"TempExcel\\";
            var totalPath =  dirPath + "README.md";

            StreamWriter swTotal = new StreamWriter(totalPath, true);
            swTotal.Write(ConstToolHelper.Header);
            swTotal.Flush();
           

            // 先将Datatable中数据生成每一个excel
            // 将excel导出为markdown文件
            // 将多个markdown拼接为一个大的markdown
            string mdContent = "";
            foreach (var item in this.uiComboBox1.Items)
            {
                var dtSource = _iServerService
                    .GetSqlClient()
                    .Queryable<AlbertToolHelperModel>()
                    .Where(a=>a.Sort==item.ToString())
                    .IgnoreColumns(a=>a.Id)
                    .IgnoreColumns(a=>a.Sort)
                    .IgnoreColumns(a=>a.Link)
                    .IgnoreColumns(a=>a.SupportVersion)
                    .ToDataTable();
                if(dtSource.Rows.Count>0)
                {
                    var excelPath = dirPath+$"{item.ToString()}.xlsx";
                    var mdPath =  dirPath+$"{item.ToString()}.md";
                   

                    MiniExcel.SaveAs(excelPath, dtSource);
                    var workbook = new Workbook(excelPath);
                    workbook.Save(mdPath);

                    StreamReader sr = null;
                    try
                    {
                        sr = new StreamReader(mdPath);
                        mdContent = sr.ReadToEnd(); // 读取文件
                        mdContent = mdContent.Replace(@"# Evaluation Only. Created with Aspose.Cells for .NET.Copyright 2003 - 2022 Aspose Pty Ltd.","");

                        // 追加标题内容
                        swTotal.Write($"\r\n# {item.ToString()}\r\n");
                        swTotal.Flush();

                        // 追加markdown文本内容
                        swTotal.Write(mdContent);
                        swTotal.Flush();

                        sr.Close();
                        sr.Dispose();
                    }
                    catch { }
                }
            }

            // 追加结尾
            swTotal.Write("\r\n"+ConstToolHelper.End);
            swTotal.Flush();
            swTotal.Close();
            swTotal.Dispose();
            MessageBox.Show("Transfer OK");
        }

        private void uiAvatar_Add_Click(object sender, EventArgs e)
        { 
            var addForm = new AddForm(_iServerService,this.uiComboBox1.SelectedIndex);
            addForm.StartPosition = FormStartPosition.CenterScreen;
            addForm.ShowDialog();
            if(addForm.DialogResult == DialogResult.OK)
            {
                addForm.Close();
                addForm.Dispose();
                BindingDtSource(this.uiComboBox1.SelectedText);
            }
        }

        private void uiAvatar_Delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.uiDV.SelectedRows)
            {
                try
                {
                    _iServerService
                        .GetSqlClient().Deleteable<AlbertToolHelperModel>().In(row.Cells["Id"].Value).ExecuteCommand();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
               
            }
            BindingDtSource(this.uiComboBox1.SelectedText);
            MessageBox.Show("Delete OK");
        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingDtSource(this.uiComboBox1.SelectedText);
        }

        private void BindingDtSource(string selectedText)
        {
            dtSource = _iServerService
                .GetSqlClient()
                .Queryable<AlbertToolHelperModel>()
                .Where(a=>a.Sort == selectedText)
                .ToDataTable();
            uiDV.DataSource = dtSource;
        }

        public void DeleteFolder()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory+"TempExcel\\";

            if(Directory.Exists(dirPath))
            {
                new DirectoryInfo(dirPath).Delete(true);
            }

            Directory.CreateDirectory(dirPath);
        }

        private void uiAvatar_Clear_Click(object sender, EventArgs e)
        {
            DeleteFolder();
            Task.Delay(2000);
            MessageBox.Show("Clear OK");
        }

        private async void uiAvatar_Push_Click(object sender, EventArgs e)
        {
            var args = $"copy \"{AppDomain.CurrentDomain.BaseDirectory}TempExcel\\README.md\" \"{_option.Value.DestinationDirectory}\"";
            await CliWrapHelper.CallPowerShell(args, _option.Value.DestinationDirectory);
            await CliWrapHelper.CallGit("Update README.md",_option.Value.DestinationDirectory);

            MessageBox.Show("Github Update OK");
        }

        private void uiDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}