namespace NET_FiveMinutes_002_CrawlZhihu
{
    partial class Form_ZhiHu
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiComboBox_Crawl = new Sunny.UI.UIComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiButton_StartCrawl = new Sunny.UI.UIButton();
            this.uiButton_EndCrawl = new Sunny.UI.UIButton();
            this.label_ID = new System.Windows.Forms.Label();
            this.uiTextBox_ID = new Sunny.UI.UITextBox();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiTextBox_ID);
            this.panel1.Controls.Add(this.label_ID);
            this.panel1.Controls.Add(this.uiButton_EndCrawl);
            this.panel1.Controls.Add(this.uiButton_StartCrawl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.uiComboBox_Crawl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 641);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uiDataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(328, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 641);
            this.panel2.TabIndex = 1;
            // 
            // uiComboBox_Crawl
            // 
            this.uiComboBox_Crawl.DataSource = null;
            this.uiComboBox_Crawl.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Crawl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox_Crawl.Location = new System.Drawing.Point(141, 30);
            this.uiComboBox_Crawl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Crawl.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Crawl.Name = "uiComboBox_Crawl";
            this.uiComboBox_Crawl.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Crawl.Size = new System.Drawing.Size(175, 29);
            this.uiComboBox_Crawl.TabIndex = 0;
            this.uiComboBox_Crawl.Text = "uiComboBox1";
            this.uiComboBox_Crawl.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Crawl.Watermark = "";
            this.uiComboBox_Crawl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiComboBox_Crawl.SelectedIndexChanged += new System.EventHandler(this.uiComboBox_Crawl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择爬虫操作：";
            // 
            // uiButton_StartCrawl
            // 
            this.uiButton_StartCrawl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_StartCrawl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_StartCrawl.Location = new System.Drawing.Point(25, 174);
            this.uiButton_StartCrawl.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_StartCrawl.Name = "uiButton_StartCrawl";
            this.uiButton_StartCrawl.Size = new System.Drawing.Size(100, 35);
            this.uiButton_StartCrawl.TabIndex = 2;
            this.uiButton_StartCrawl.Text = "开始爬取";
            this.uiButton_StartCrawl.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_StartCrawl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton_StartCrawl.Click += new System.EventHandler(this.uiButton_StartCrawl_Click);
            // 
            // uiButton_EndCrawl
            // 
            this.uiButton_EndCrawl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_EndCrawl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_EndCrawl.Location = new System.Drawing.Point(160, 174);
            this.uiButton_EndCrawl.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_EndCrawl.Name = "uiButton_EndCrawl";
            this.uiButton_EndCrawl.Size = new System.Drawing.Size(100, 35);
            this.uiButton_EndCrawl.TabIndex = 3;
            this.uiButton_EndCrawl.Text = "终止爬取";
            this.uiButton_EndCrawl.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_EndCrawl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton_EndCrawl.Click += new System.EventHandler(this.uiButton_EndCrawl_Click);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ID.Location = new System.Drawing.Point(3, 86);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(140, 22);
            this.label_ID.TabIndex = 5;
            this.label_ID.Text = "输入知乎问题ID：";
            // 
            // uiTextBox_ID
            // 
            this.uiTextBox_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_ID.Location = new System.Drawing.Point(142, 82);
            this.uiTextBox_ID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_ID.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_ID.Name = "uiTextBox_ID";
            this.uiTextBox_ID.ShowText = false;
            this.uiTextBox_ID.Size = new System.Drawing.Size(175, 29);
            this.uiTextBox_ID.TabIndex = 6;
            this.uiTextBox_ID.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_ID.Watermark = "";
            this.uiTextBox_ID.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView1.RowTemplate.Height = 23;
            this.uiDataGridView1.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.Size = new System.Drawing.Size(843, 641);
            this.uiDataGridView1.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.TabIndex = 0;
            this.uiDataGridView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Form_ZhiHu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 641);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_ZhiHu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Zhihu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIComboBox uiComboBox_Crawl;
        private System.Windows.Forms.Label label_ID;
        private Sunny.UI.UIButton uiButton_EndCrawl;
        private Sunny.UI.UIButton uiButton_StartCrawl;
        private Sunny.UI.UITextBox uiTextBox_ID;
        private Sunny.UI.UIDataGridView uiDataGridView1;
    }
}

