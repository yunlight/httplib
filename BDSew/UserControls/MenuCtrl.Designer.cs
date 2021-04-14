
namespace BDSew
{
    partial class MenuCtrl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileMangement = new System.Windows.Forms.Button();
            this.btnFileEdit = new System.Windows.Forms.Button();
            this.btnSystemParam = new System.Windows.Forms.Button();
            this.btnMachineParam = new System.Windows.Forms.Button();
            this.btnAssistSetting = new System.Windows.Forms.Button();
            this.btnMachineStatus = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFileMangement
            // 
            this.btnFileMangement.Location = new System.Drawing.Point(39, 32);
            this.btnFileMangement.Name = "btnFileMangement";
            this.btnFileMangement.Size = new System.Drawing.Size(150, 75);
            this.btnFileMangement.TabIndex = 34;
            this.btnFileMangement.Text = "文件管理";
            this.btnFileMangement.UseVisualStyleBackColor = true;
            this.btnFileMangement.Click += new System.EventHandler(this.btnFileMangement_Click);
            // 
            // btnFileEdit
            // 
            this.btnFileEdit.Location = new System.Drawing.Point(225, 32);
            this.btnFileEdit.Name = "btnFileEdit";
            this.btnFileEdit.Size = new System.Drawing.Size(150, 75);
            this.btnFileEdit.TabIndex = 35;
            this.btnFileEdit.Text = "文件编辑";
            this.btnFileEdit.UseVisualStyleBackColor = true;
            this.btnFileEdit.Click += new System.EventHandler(this.btnFileEdit_Click);
            // 
            // btnSystemParam
            // 
            this.btnSystemParam.Location = new System.Drawing.Point(411, 32);
            this.btnSystemParam.Name = "btnSystemParam";
            this.btnSystemParam.Size = new System.Drawing.Size(150, 75);
            this.btnSystemParam.TabIndex = 36;
            this.btnSystemParam.Text = "系统参数";
            this.btnSystemParam.UseVisualStyleBackColor = true;
            this.btnSystemParam.Click += new System.EventHandler(this.btnSystemParam_Click);
            // 
            // btnMachineParam
            // 
            this.btnMachineParam.Location = new System.Drawing.Point(597, 32);
            this.btnMachineParam.Name = "btnMachineParam";
            this.btnMachineParam.Size = new System.Drawing.Size(150, 75);
            this.btnMachineParam.TabIndex = 37;
            this.btnMachineParam.Text = "机械参数";
            this.btnMachineParam.UseVisualStyleBackColor = true;
            this.btnMachineParam.Click += new System.EventHandler(this.btnMachineParam_Click);
            // 
            // btnAssistSetting
            // 
            this.btnAssistSetting.Location = new System.Drawing.Point(39, 176);
            this.btnAssistSetting.Name = "btnAssistSetting";
            this.btnAssistSetting.Size = new System.Drawing.Size(150, 75);
            this.btnAssistSetting.TabIndex = 38;
            this.btnAssistSetting.Text = "辅助设置";
            this.btnAssistSetting.UseVisualStyleBackColor = true;
            this.btnAssistSetting.Click += new System.EventHandler(this.btnAssistSetting_Click);
            // 
            // btnMachineStatus
            // 
            this.btnMachineStatus.Location = new System.Drawing.Point(225, 176);
            this.btnMachineStatus.Name = "btnMachineStatus";
            this.btnMachineStatus.Size = new System.Drawing.Size(150, 75);
            this.btnMachineStatus.TabIndex = 39;
            this.btnMachineStatus.Text = "机械状态";
            this.btnMachineStatus.UseVisualStyleBackColor = true;
            this.btnMachineStatus.Click += new System.EventHandler(this.btnMachineStatus_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(626, 458);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(121, 60);
            this.btnReturn.TabIndex = 52;
            this.btnReturn.Text = "返回";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // MenuCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnMachineStatus);
            this.Controls.Add(this.btnAssistSetting);
            this.Controls.Add(this.btnMachineParam);
            this.Controls.Add(this.btnSystemParam);
            this.Controls.Add(this.btnFileEdit);
            this.Controls.Add(this.btnFileMangement);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuCtrl";
            this.Size = new System.Drawing.Size(784, 562);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFileMangement;
        private System.Windows.Forms.Button btnFileEdit;
        private System.Windows.Forms.Button btnSystemParam;
        private System.Windows.Forms.Button btnMachineParam;
        private System.Windows.Forms.Button btnAssistSetting;
        private System.Windows.Forms.Button btnMachineStatus;
        private System.Windows.Forms.Button btnReturn;
    }
}
