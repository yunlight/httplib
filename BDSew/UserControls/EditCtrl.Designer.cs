
namespace BDSew
{
    partial class EditCtrl
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
            this.btnMoveLineSegment = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCancelCollection = new System.Windows.Forms.Button();
            this.btnMoveLineStep = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGenGraphics = new System.Windows.Forms.Button();
            this.btnCenter = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnYuan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPreStep = new System.Windows.Forms.Button();
            this.btnDottedLine = new System.Windows.Forms.Button();
            this.btnYuanHu = new System.Windows.Forms.Button();
            this.txtStepDistance = new System.Windows.Forms.TextBox();
            this.pnlMiddleBotton = new System.Windows.Forms.Panel();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnCollection = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnMoveRightDown = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMoveLeftDown = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveSpeed = new System.Windows.Forms.Button();
            this.btnMoveRightUp = new System.Windows.Forms.Button();
            this.btnMoveLeftUp = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnInsertLineStep = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteLineStep = new System.Windows.Forms.Button();
            this.pnlbotton = new System.Windows.Forms.Panel();
            this.tbxAngle = new System.Windows.Forms.TextBox();
            this.btnModifyAngle = new System.Windows.Forms.Button();
            this.pnlMiddleBotton.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlbotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMoveLineSegment
            // 
            this.btnMoveLineSegment.Location = new System.Drawing.Point(135, 5);
            this.btnMoveLineSegment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLineSegment.Name = "btnMoveLineSegment";
            this.btnMoveLineSegment.Size = new System.Drawing.Size(60, 60);
            this.btnMoveLineSegment.TabIndex = 2;
            this.btnMoveLineSegment.Text = "移动针段";
            this.btnMoveLineSegment.UseVisualStyleBackColor = true;
            this.btnMoveLineSegment.Click += new System.EventHandler(this.btnMoveLineSegment_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnReset.Location = new System.Drawing.Point(5, 5);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 60);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "复位";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.BackColor = System.Drawing.Color.Black;
            this.pnlMiddle.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(29, 0);
            this.pnlMiddle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(420, 420);
            this.pnlMiddle.TabIndex = 14;
            this.pnlMiddle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMiddle_Paint);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(29, 420);
            this.pnlLeft.TabIndex = 12;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 45);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(60, 31);
            this.btnOpen.TabIndex = 32;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancelCollection
            // 
            this.btnCancelCollection.Location = new System.Drawing.Point(133, 358);
            this.btnCancelCollection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelCollection.Name = "btnCancelCollection";
            this.btnCancelCollection.Size = new System.Drawing.Size(60, 60);
            this.btnCancelCollection.TabIndex = 31;
            this.btnCancelCollection.Text = "取消采集";
            this.btnCancelCollection.UseVisualStyleBackColor = true;
            // 
            // btnMoveLineStep
            // 
            this.btnMoveLineStep.Location = new System.Drawing.Point(70, 5);
            this.btnMoveLineStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLineStep.Name = "btnMoveLineStep";
            this.btnMoveLineStep.Size = new System.Drawing.Size(60, 60);
            this.btnMoveLineStep.TabIndex = 1;
            this.btnMoveLineStep.Text = "移动针步";
            this.btnMoveLineStep.UseVisualStyleBackColor = true;
            this.btnMoveLineStep.Click += new System.EventHandler(this.btnMoveLineStep_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(133, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "针距";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGenGraphics
            // 
            this.btnGenGraphics.Location = new System.Drawing.Point(198, 358);
            this.btnGenGraphics.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenGraphics.Name = "btnGenGraphics";
            this.btnGenGraphics.Size = new System.Drawing.Size(60, 60);
            this.btnGenGraphics.TabIndex = 28;
            this.btnGenGraphics.Text = "生成图形";
            this.btnGenGraphics.UseVisualStyleBackColor = true;
            // 
            // btnCenter
            // 
            this.btnCenter.Location = new System.Drawing.Point(6, 385);
            this.btnCenter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCenter.Name = "btnCenter";
            this.btnCenter.Size = new System.Drawing.Size(45, 45);
            this.btnCenter.TabIndex = 26;
            this.btnCenter.Text = "中心显示";
            this.btnCenter.UseVisualStyleBackColor = true;
            this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
            // 
            // btnLine
            // 
            this.btnLine.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnLine.Location = new System.Drawing.Point(70, 5);
            this.btnLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(60, 60);
            this.btnLine.TabIndex = 10;
            this.btnLine.Text = "直线";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnYuan
            // 
            this.btnYuan.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnYuan.Location = new System.Drawing.Point(200, 5);
            this.btnYuan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnYuan.Name = "btnYuan";
            this.btnYuan.Size = new System.Drawing.Size(60, 60);
            this.btnYuan.TabIndex = 11;
            this.btnYuan.Text = "圆";
            this.btnYuan.UseVisualStyleBackColor = true;
            this.btnYuan.Click += new System.EventHandler(this.btnYuan_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "修改";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreStep
            // 
            this.btnPreStep.Location = new System.Drawing.Point(6, 135);
            this.btnPreStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreStep.Name = "btnPreStep";
            this.btnPreStep.Size = new System.Drawing.Size(60, 60);
            this.btnPreStep.TabIndex = 2;
            this.btnPreStep.Text = "上一针步";
            this.btnPreStep.UseVisualStyleBackColor = true;
            this.btnPreStep.Click += new System.EventHandler(this.btnPreStep_Click);
            // 
            // btnDottedLine
            // 
            this.btnDottedLine.BackColor = System.Drawing.Color.Transparent;
            this.btnDottedLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnDottedLine.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnDottedLine.Location = new System.Drawing.Point(5, 5);
            this.btnDottedLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDottedLine.Name = "btnDottedLine";
            this.btnDottedLine.Size = new System.Drawing.Size(60, 60);
            this.btnDottedLine.TabIndex = 8;
            this.btnDottedLine.Text = "虚线";
            this.btnDottedLine.UseVisualStyleBackColor = false;
            this.btnDottedLine.Click += new System.EventHandler(this.btnDottedLine_Click);
            // 
            // btnYuanHu
            // 
            this.btnYuanHu.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnYuanHu.Location = new System.Drawing.Point(135, 5);
            this.btnYuanHu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnYuanHu.Name = "btnYuanHu";
            this.btnYuanHu.Size = new System.Drawing.Size(60, 60);
            this.btnYuanHu.TabIndex = 9;
            this.btnYuanHu.Text = "圆弧";
            this.btnYuanHu.UseVisualStyleBackColor = true;
            this.btnYuanHu.Click += new System.EventHandler(this.btnYuanHu_Click);
            // 
            // txtStepDistance
            // 
            this.txtStepDistance.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtStepDistance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStepDistance.ForeColor = System.Drawing.Color.Transparent;
            this.txtStepDistance.Location = new System.Drawing.Point(198, 101);
            this.txtStepDistance.Name = "txtStepDistance";
            this.txtStepDistance.ReadOnly = true;
            this.txtStepDistance.Size = new System.Drawing.Size(60, 29);
            this.txtStepDistance.TabIndex = 29;
            this.txtStepDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStepDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtStepDistance_MouseDown);
            // 
            // pnlMiddleBotton
            // 
            this.pnlMiddleBotton.Controls.Add(this.btnModifyAngle);
            this.pnlMiddleBotton.Controls.Add(this.tbxAngle);
            this.pnlMiddleBotton.Controls.Add(this.btnDottedLine);
            this.pnlMiddleBotton.Controls.Add(this.btnLine);
            this.pnlMiddleBotton.Controls.Add(this.btnYuanHu);
            this.pnlMiddleBotton.Controls.Add(this.btnYuan);
            this.pnlMiddleBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMiddleBotton.Location = new System.Drawing.Point(0, 420);
            this.pnlMiddleBotton.Name = "pnlMiddleBotton";
            this.pnlMiddleBotton.Size = new System.Drawing.Size(449, 72);
            this.pnlMiddleBotton.TabIndex = 15;
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(6, 203);
            this.btnNextStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(60, 60);
            this.btnNextStep.TabIndex = 1;
            this.btnNextStep.Text = "下一针步";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnOpen);
            this.pnlRight.Controls.Add(this.btnCancelCollection);
            this.pnlRight.Controls.Add(this.label7);
            this.pnlRight.Controls.Add(this.txtStepDistance);
            this.pnlRight.Controls.Add(this.btnGenGraphics);
            this.pnlRight.Controls.Add(this.label2);
            this.pnlRight.Controls.Add(this.btnCenter);
            this.pnlRight.Controls.Add(this.btnPreStep);
            this.pnlRight.Controls.Add(this.btnNextStep);
            this.pnlRight.Controls.Add(this.btnZoomOut);
            this.pnlRight.Controls.Add(this.btnZoomIn);
            this.pnlRight.Controls.Add(this.btnCollection);
            this.pnlRight.Controls.Add(this.btnSaveAs);
            this.pnlRight.Controls.Add(this.btnMoveRightDown);
            this.pnlRight.Controls.Add(this.btnSave);
            this.pnlRight.Controls.Add(this.btnMoveLeftDown);
            this.pnlRight.Controls.Add(this.btnMoveDown);
            this.pnlRight.Controls.Add(this.btnNew);
            this.pnlRight.Controls.Add(this.btnMoveRight);
            this.pnlRight.Controls.Add(this.btnMoveLeft);
            this.pnlRight.Controls.Add(this.btnMoveSpeed);
            this.pnlRight.Controls.Add(this.btnMoveRightUp);
            this.pnlRight.Controls.Add(this.btnMoveLeftUp);
            this.pnlRight.Controls.Add(this.btnMoveUp);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(449, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(335, 492);
            this.pnlRight.TabIndex = 13;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(6, 434);
            this.btnZoomOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(45, 45);
            this.btnZoomOut.TabIndex = 25;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(6, 336);
            this.btnZoomIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(45, 45);
            this.btnZoomIn.TabIndex = 24;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.Location = new System.Drawing.Point(263, 358);
            this.btnCollection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(60, 60);
            this.btnCollection.TabIndex = 8;
            this.btnCollection.Text = "采集";
            this.btnCollection.UseVisualStyleBackColor = true;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(263, 8);
            this.btnSaveAs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(60, 60);
            this.btnSaveAs.TabIndex = 23;
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnMoveRightDown
            // 
            this.btnMoveRightDown.Location = new System.Drawing.Point(263, 265);
            this.btnMoveRightDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveRightDown.Name = "btnMoveRightDown";
            this.btnMoveRightDown.Size = new System.Drawing.Size(60, 60);
            this.btnMoveRightDown.TabIndex = 20;
            this.btnMoveRightDown.Text = "右下";
            this.btnMoveRightDown.UseVisualStyleBackColor = true;
            this.btnMoveRightDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveRightDown_MouseDown);
            this.btnMoveRightDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveRightDown_MouseUp);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(198, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 60);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMoveLeftDown
            // 
            this.btnMoveLeftDown.Location = new System.Drawing.Point(133, 265);
            this.btnMoveLeftDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLeftDown.Name = "btnMoveLeftDown";
            this.btnMoveLeftDown.Size = new System.Drawing.Size(60, 60);
            this.btnMoveLeftDown.TabIndex = 19;
            this.btnMoveLeftDown.Text = "左下";
            this.btnMoveLeftDown.UseVisualStyleBackColor = true;
            this.btnMoveLeftDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveLeftDown_MouseDown);
            this.btnMoveLeftDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveLeftDown_MouseUp);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(198, 265);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(60, 60);
            this.btnMoveDown.TabIndex = 18;
            this.btnMoveDown.Text = "下";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveDown_MouseDown);
            this.btnMoveDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveDown_MouseUp);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(133, 8);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 60);
            this.btnNew.TabIndex = 21;
            this.btnNew.Text = "新建";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Location = new System.Drawing.Point(263, 200);
            this.btnMoveRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(60, 60);
            this.btnMoveRight.TabIndex = 17;
            this.btnMoveRight.Text = "右";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveRight_MouseDown);
            this.btnMoveRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveRight_MouseUp);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Location = new System.Drawing.Point(133, 200);
            this.btnMoveLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(60, 60);
            this.btnMoveLeft.TabIndex = 16;
            this.btnMoveLeft.Text = "左";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveLeft_MouseDown);
            this.btnMoveLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveLeft_MouseUp);
            // 
            // btnMoveSpeed
            // 
            this.btnMoveSpeed.Location = new System.Drawing.Point(198, 200);
            this.btnMoveSpeed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveSpeed.Name = "btnMoveSpeed";
            this.btnMoveSpeed.Size = new System.Drawing.Size(60, 60);
            this.btnMoveSpeed.TabIndex = 15;
            this.btnMoveSpeed.Text = "移速";
            this.btnMoveSpeed.UseVisualStyleBackColor = true;
            this.btnMoveSpeed.Click += new System.EventHandler(this.btnMoveSpeed_Click);
            // 
            // btnMoveRightUp
            // 
            this.btnMoveRightUp.Location = new System.Drawing.Point(263, 135);
            this.btnMoveRightUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveRightUp.Name = "btnMoveRightUp";
            this.btnMoveRightUp.Size = new System.Drawing.Size(60, 60);
            this.btnMoveRightUp.TabIndex = 14;
            this.btnMoveRightUp.Text = "右上";
            this.btnMoveRightUp.UseVisualStyleBackColor = true;
            this.btnMoveRightUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveRightUp_MouseDown);
            this.btnMoveRightUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveRightUp_MouseUp);
            // 
            // btnMoveLeftUp
            // 
            this.btnMoveLeftUp.Location = new System.Drawing.Point(133, 135);
            this.btnMoveLeftUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveLeftUp.Name = "btnMoveLeftUp";
            this.btnMoveLeftUp.Size = new System.Drawing.Size(60, 60);
            this.btnMoveLeftUp.TabIndex = 13;
            this.btnMoveLeftUp.Text = "左上";
            this.btnMoveLeftUp.UseVisualStyleBackColor = true;
            this.btnMoveLeftUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveLeftUp_MouseDown);
            this.btnMoveLeftUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveLeftUp_MouseUp);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(198, 135);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(60, 60);
            this.btnMoveUp.TabIndex = 12;
            this.btnMoveUp.Text = "上";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveUp_MouseDown);
            this.btnMoveUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveUp_MouseUp);
            // 
            // btnInsertLineStep
            // 
            this.btnInsertLineStep.Location = new System.Drawing.Point(200, 5);
            this.btnInsertLineStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInsertLineStep.Name = "btnInsertLineStep";
            this.btnInsertLineStep.Size = new System.Drawing.Size(60, 60);
            this.btnInsertLineStep.TabIndex = 3;
            this.btnInsertLineStep.Text = "插入针步";
            this.btnInsertLineStep.UseVisualStyleBackColor = true;
            this.btnInsertLineStep.Click += new System.EventHandler(this.btnInsertLineStep_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(711, 7);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 60);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "返回";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(459, 5);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(60, 60);
            this.btnPaste.TabIndex = 7;
            this.btnPaste.Text = "粘贴";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(394, 5);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(60, 60);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "复制";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(329, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 60);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "撤销";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteLineStep
            // 
            this.btnDeleteLineStep.Location = new System.Drawing.Point(265, 5);
            this.btnDeleteLineStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteLineStep.Name = "btnDeleteLineStep";
            this.btnDeleteLineStep.Size = new System.Drawing.Size(60, 60);
            this.btnDeleteLineStep.TabIndex = 4;
            this.btnDeleteLineStep.Text = "删除针步";
            this.btnDeleteLineStep.UseVisualStyleBackColor = true;
            this.btnDeleteLineStep.Click += new System.EventHandler(this.btnDeleteLineStep_Click);
            // 
            // pnlbotton
            // 
            this.pnlbotton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlbotton.Controls.Add(this.btnExit);
            this.pnlbotton.Controls.Add(this.btnPaste);
            this.pnlbotton.Controls.Add(this.btnCopy);
            this.pnlbotton.Controls.Add(this.btnCancel);
            this.pnlbotton.Controls.Add(this.btnDeleteLineStep);
            this.pnlbotton.Controls.Add(this.btnInsertLineStep);
            this.pnlbotton.Controls.Add(this.btnMoveLineSegment);
            this.pnlbotton.Controls.Add(this.btnMoveLineStep);
            this.pnlbotton.Controls.Add(this.btnReset);
            this.pnlbotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbotton.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.pnlbotton.Location = new System.Drawing.Point(0, 492);
            this.pnlbotton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlbotton.Name = "pnlbotton";
            this.pnlbotton.Size = new System.Drawing.Size(784, 70);
            this.pnlbotton.TabIndex = 11;
            // 
            // tbxAngle
            // 
            this.tbxAngle.BackColor = System.Drawing.SystemColors.Highlight;
            this.tbxAngle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxAngle.ForeColor = System.Drawing.Color.Transparent;
            this.tbxAngle.Location = new System.Drawing.Point(311, 23);
            this.tbxAngle.Name = "tbxAngle";
            this.tbxAngle.Size = new System.Drawing.Size(60, 29);
            this.tbxAngle.TabIndex = 33;
            this.tbxAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnModifyAngle
            // 
            this.btnModifyAngle.Location = new System.Drawing.Point(372, 11);
            this.btnModifyAngle.Name = "btnModifyAngle";
            this.btnModifyAngle.Size = new System.Drawing.Size(50, 50);
            this.btnModifyAngle.TabIndex = 34;
            this.btnModifyAngle.Text = "修改角度";
            this.btnModifyAngle.UseVisualStyleBackColor = true;
            // 
            // EditCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlMiddleBotton);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlbotton);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditCtrl";
            this.Size = new System.Drawing.Size(784, 562);
            this.Load += new System.EventHandler(this.EditCtrl_Load);
            this.pnlMiddleBotton.ResumeLayout(false);
            this.pnlMiddleBotton.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlbotton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoveLineSegment;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCancelCollection;
        private System.Windows.Forms.Button btnMoveLineStep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGenGraphics;
        private System.Windows.Forms.Button btnCenter;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnYuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPreStep;
        private System.Windows.Forms.Button btnDottedLine;
        private System.Windows.Forms.Button btnYuanHu;
        private System.Windows.Forms.TextBox txtStepDistance;
        private System.Windows.Forms.Panel pnlMiddleBotton;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnMoveRightDown;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMoveLeftDown;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveSpeed;
        private System.Windows.Forms.Button btnMoveRightUp;
        private System.Windows.Forms.Button btnMoveLeftUp;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnInsertLineStep;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDeleteLineStep;
        private System.Windows.Forms.Panel pnlbotton;
        private System.Windows.Forms.TextBox tbxAngle;
        private System.Windows.Forms.Button btnModifyAngle;
    }
}
