namespace WindowsFormsApp1
{
    partial class MyForm
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
            this.btn_getPosInfo = new System.Windows.Forms.Button();
            this.rtb_to = new System.Windows.Forms.RichTextBox();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_getShipInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_getPosInfo
            // 
            this.btn_getPosInfo.CausesValidation = false;
            this.btn_getPosInfo.Location = new System.Drawing.Point(106, 247);
            this.btn_getPosInfo.Name = "btn_getPosInfo";
            this.btn_getPosInfo.Size = new System.Drawing.Size(96, 23);
            this.btn_getPosInfo.TabIndex = 0;
            this.btn_getPosInfo.Text = "获取位置信息";
            this.btn_getPosInfo.UseVisualStyleBackColor = true;
            this.btn_getPosInfo.Click += new System.EventHandler(this.GetPosInfo);
            // 
            // rtb_to
            // 
            this.rtb_to.Location = new System.Drawing.Point(78, 66);
            this.rtb_to.Name = "rtb_to";
            this.rtb_to.Size = new System.Drawing.Size(300, 175);
            this.rtb_to.TabIndex = 2;
            this.rtb_to.Text = "";
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(79, 21);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(299, 21);
            this.tb_url.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "mmsi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Json:";
            // 
            // btn_getShipInfo
            // 
            this.btn_getShipInfo.Location = new System.Drawing.Point(246, 247);
            this.btn_getShipInfo.Name = "btn_getShipInfo";
            this.btn_getShipInfo.Size = new System.Drawing.Size(92, 23);
            this.btn_getShipInfo.TabIndex = 6;
            this.btn_getShipInfo.Text = "获取船舶信息";
            this.btn_getShipInfo.UseVisualStyleBackColor = true;
            this.btn_getShipInfo.Click += new System.EventHandler(this.GetShipInfo);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 282);
            this.Controls.Add(this.btn_getShipInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.rtb_to);
            this.Controls.Add(this.btn_getPosInfo);
            this.KeyPreview = true;
            this.Name = "MyForm";
            this.Text = "我的翻译";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_getPosInfo;
        private System.Windows.Forms.RichTextBox rtb_to;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_getShipInfo;
    }
}

