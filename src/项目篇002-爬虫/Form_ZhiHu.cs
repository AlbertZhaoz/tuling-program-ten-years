using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NET_FiveMinutes_002_CrawlZhihu.Common;
using NET_FiveMinutes_002_CrawlZhihu.Const;
using NET_FiveMinutes_002_CrawlZhihu.Interfaces;
using NET_FiveMinutes_002_CrawlZhihu.Models;
using Newtonsoft.Json;

namespace NET_FiveMinutes_002_CrawlZhihu
{
    public partial class Form_ZhiHu : Form
    {
        private readonly IZhiHuService _zhihuService;
        private readonly IJDService _JDService;
        private static Logger logger = new Logger(typeof(Form_ZhiHu));
        // 后台任务取消选项
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public Form_ZhiHu(IZhiHuService zhihuService, IJDService JDService)
        {
            InitializeComponent();
            this._zhihuService = zhihuService;
            this._JDService = JDService;
            ComboxBinding.BindEnumToComboBox<CrawlEnum>(this.uiComboBox_Crawl);
            this.label_ID.Visible = false;
            this.uiTextBox_ID.Visible = false;
            
        }

        private void Form_Zhihu_Load(object sender, EventArgs e)
        {
            
        }

        private void uiComboBox_Crawl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void uiButton_StartCrawl_Click(object sender, EventArgs e)
        {
            if (ComboxBinding.GetEnumFromComboBox<CrawlEnum>(this.uiComboBox_Crawl) == CrawlEnum.爬取知乎热点)
            {
                Task.Run(() =>
                {
                    var hotList = _zhihuService.CrawlHot();

                    this.uiDataGridView1.Invoke(new Action(() =>
                    {
                        this.uiDataGridView1.DataSource = hotList;
                    }));
                }, _cts.Token);
            }

            if(ComboxBinding.GetEnumFromComboBox<CrawlEnum>(this.uiComboBox_Crawl) == CrawlEnum.爬取京东商品)
            {
                Task.Run(() =>
                {
                    string testCategory = "{\"Id\":73,\"Code\":\"02f01s01T\",\"ParentCode\":\"02f01s\",\"Name\":\"烟机/灶具\",\"Url\":\"http://list.jd.com/list.html?cat=737,13297,1300\",\"Level\":3}";
                    JDCategory category = JsonConvert.DeserializeObject<JDCategory>(testCategory);
                    var categoryList = _JDService.GetJDCategory(category);

                    this.uiDataGridView1.Invoke(new Action(() =>
                    {
                        this.uiDataGridView1.DataSource = categoryList;
                    }));
                }, _cts.Token);
            }
               
        }

        private void uiButton_EndCrawl_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
        }
    }
}
