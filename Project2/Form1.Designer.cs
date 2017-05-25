namespace Project2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelP2 = new System.Windows.Forms.Label();
            this.labelP1 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.labelOrder = new System.Windows.Forms.Label();
            this.LabelAlg2 = new System.Windows.Forms.Label();
            this.comboBoxAlgP2 = new System.Windows.Forms.ComboBox();
            this.LabelAlg1 = new System.Windows.Forms.Label();
            this.comboBoxAlgP1 = new System.Windows.Forms.ComboBox();
            this.numericUpDownTimer = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_P2Depth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_P1Depth = new System.Windows.Forms.NumericUpDown();
            this.groupBoxPlayer2Type = new System.Windows.Forms.GroupBox();
            this.radioButtonAI2 = new System.Windows.Forms.RadioButton();
            this.radioButtonHuman2 = new System.Windows.Forms.RadioButton();
            this.groupBoxPlayer1Type = new System.Windows.Forms.GroupBox();
            this.radioButtonAI1 = new System.Windows.Forms.RadioButton();
            this.radioButtonHuman1 = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxUseTimer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_WinReq = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Row = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_Col = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadStateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_P2Depth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_P1Depth)).BeginInit();
            this.groupBoxPlayer2Type.SuspendLayout();
            this.groupBoxPlayer1Type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WinReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Row)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Col)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelP2);
            this.panel1.Controls.Add(this.labelP1);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.labelOrder);
            this.panel1.Controls.Add(this.LabelAlg2);
            this.panel1.Controls.Add(this.comboBoxAlgP2);
            this.panel1.Controls.Add(this.LabelAlg1);
            this.panel1.Controls.Add(this.comboBoxAlgP1);
            this.panel1.Controls.Add(this.numericUpDownTimer);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.numericUpDown_P2Depth);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numericUpDown_P1Depth);
            this.panel1.Controls.Add(this.groupBoxPlayer2Type);
            this.panel1.Controls.Add(this.groupBoxPlayer1Type);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBoxUseTimer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDown_WinReq);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown_Row);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown_Col);
            this.panel1.Location = new System.Drawing.Point(14, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 661);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(201, 35);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 602);
            this.panel2.TabIndex = 2;
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.Location = new System.Drawing.Point(104, 236);
            this.labelP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(43, 13);
            this.labelP2.TabIndex = 35;
            this.labelP2.Text = "black X";
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.Location = new System.Drawing.Point(20, 236);
            this.labelP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(33, 13);
            this.labelP1.TabIndex = 34;
            this.labelP1.Text = "red O";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(31, 470);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(103, 46);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrder.Location = new System.Drawing.Point(18, 206);
            this.labelOrder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(160, 15);
            this.labelOrder.TabIndex = 33;
            this.labelOrder.Text = "Note: Red (0) goes first.";
            // 
            // LabelAlg2
            // 
            this.LabelAlg2.AutoSize = true;
            this.LabelAlg2.Location = new System.Drawing.Point(99, 343);
            this.LabelAlg2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelAlg2.Name = "LabelAlg2";
            this.LabelAlg2.Size = new System.Drawing.Size(56, 13);
            this.LabelAlg2.TabIndex = 31;
            this.LabelAlg2.Text = "Algorithm2";
            // 
            // comboBoxAlgP2
            // 
            this.comboBoxAlgP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgP2.Enabled = false;
            this.comboBoxAlgP2.FormattingEnabled = true;
            this.comboBoxAlgP2.Location = new System.Drawing.Point(97, 361);
            this.comboBoxAlgP2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxAlgP2.Name = "comboBoxAlgP2";
            this.comboBoxAlgP2.Size = new System.Drawing.Size(81, 21);
            this.comboBoxAlgP2.TabIndex = 30;
            // 
            // LabelAlg1
            // 
            this.LabelAlg1.AutoSize = true;
            this.LabelAlg1.Location = new System.Drawing.Point(5, 343);
            this.LabelAlg1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelAlg1.Name = "LabelAlg1";
            this.LabelAlg1.Size = new System.Drawing.Size(56, 13);
            this.LabelAlg1.TabIndex = 29;
            this.LabelAlg1.Text = "Algorithm1";
            // 
            // comboBoxAlgP1
            // 
            this.comboBoxAlgP1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgP1.Enabled = false;
            this.comboBoxAlgP1.FormattingEnabled = true;
            this.comboBoxAlgP1.Location = new System.Drawing.Point(3, 361);
            this.comboBoxAlgP1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxAlgP1.Name = "comboBoxAlgP1";
            this.comboBoxAlgP1.Size = new System.Drawing.Size(81, 21);
            this.comboBoxAlgP1.TabIndex = 28;
            // 
            // numericUpDownTimer
            // 
            this.numericUpDownTimer.Enabled = false;
            this.numericUpDownTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTimer.Location = new System.Drawing.Point(88, 553);
            this.numericUpDownTimer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownTimer.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownTimer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimer.Name = "numericUpDownTimer";
            this.numericUpDownTimer.Size = new System.Drawing.Size(81, 26);
            this.numericUpDownTimer.TabIndex = 26;
            this.numericUpDownTimer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 400);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Depth";
            // 
            // numericUpDown_P2Depth
            // 
            this.numericUpDown_P2Depth.Enabled = false;
            this.numericUpDown_P2Depth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_P2Depth.Location = new System.Drawing.Point(95, 416);
            this.numericUpDown_P2Depth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_P2Depth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_P2Depth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_P2Depth.Name = "numericUpDown_P2Depth";
            this.numericUpDown_P2Depth.Size = new System.Drawing.Size(62, 26);
            this.numericUpDown_P2Depth.TabIndex = 22;
            this.numericUpDown_P2Depth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 400);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Depth";
            // 
            // numericUpDown_P1Depth
            // 
            this.numericUpDown_P1Depth.Enabled = false;
            this.numericUpDown_P1Depth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_P1Depth.Location = new System.Drawing.Point(16, 416);
            this.numericUpDown_P1Depth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_P1Depth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_P1Depth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_P1Depth.Name = "numericUpDown_P1Depth";
            this.numericUpDown_P1Depth.Size = new System.Drawing.Size(62, 26);
            this.numericUpDown_P1Depth.TabIndex = 19;
            this.numericUpDown_P1Depth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxPlayer2Type
            // 
            this.groupBoxPlayer2Type.Controls.Add(this.radioButtonAI2);
            this.groupBoxPlayer2Type.Controls.Add(this.radioButtonHuman2);
            this.groupBoxPlayer2Type.Location = new System.Drawing.Point(89, 247);
            this.groupBoxPlayer2Type.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPlayer2Type.Name = "groupBoxPlayer2Type";
            this.groupBoxPlayer2Type.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPlayer2Type.Size = new System.Drawing.Size(72, 77);
            this.groupBoxPlayer2Type.TabIndex = 17;
            this.groupBoxPlayer2Type.TabStop = false;
            // 
            // radioButtonAI2
            // 
            this.radioButtonAI2.AutoSize = true;
            this.radioButtonAI2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonAI2.Location = new System.Drawing.Point(33, 41);
            this.radioButtonAI2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonAI2.Name = "radioButtonAI2";
            this.radioButtonAI2.Size = new System.Drawing.Size(33, 17);
            this.radioButtonAI2.TabIndex = 16;
            this.radioButtonAI2.Text = "ai";
            this.radioButtonAI2.UseVisualStyleBackColor = true;
            // 
            // radioButtonHuman2
            // 
            this.radioButtonHuman2.AutoSize = true;
            this.radioButtonHuman2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonHuman2.Checked = true;
            this.radioButtonHuman2.Location = new System.Drawing.Point(9, 19);
            this.radioButtonHuman2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonHuman2.Name = "radioButtonHuman2";
            this.radioButtonHuman2.Size = new System.Drawing.Size(57, 17);
            this.radioButtonHuman2.TabIndex = 15;
            this.radioButtonHuman2.TabStop = true;
            this.radioButtonHuman2.Text = "human";
            this.radioButtonHuman2.UseVisualStyleBackColor = true;
            this.radioButtonHuman2.CheckedChanged += new System.EventHandler(this.radioButtonHuman2_CheckedChanged);
            // 
            // groupBoxPlayer1Type
            // 
            this.groupBoxPlayer1Type.Controls.Add(this.radioButtonAI1);
            this.groupBoxPlayer1Type.Controls.Add(this.radioButtonHuman1);
            this.groupBoxPlayer1Type.Location = new System.Drawing.Point(6, 247);
            this.groupBoxPlayer1Type.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPlayer1Type.Name = "groupBoxPlayer1Type";
            this.groupBoxPlayer1Type.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxPlayer1Type.Size = new System.Drawing.Size(72, 77);
            this.groupBoxPlayer1Type.TabIndex = 16;
            this.groupBoxPlayer1Type.TabStop = false;
            // 
            // radioButtonAI1
            // 
            this.radioButtonAI1.AutoSize = true;
            this.radioButtonAI1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonAI1.Location = new System.Drawing.Point(33, 41);
            this.radioButtonAI1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonAI1.Name = "radioButtonAI1";
            this.radioButtonAI1.Size = new System.Drawing.Size(33, 17);
            this.radioButtonAI1.TabIndex = 16;
            this.radioButtonAI1.Text = "ai";
            this.radioButtonAI1.UseVisualStyleBackColor = true;
            // 
            // radioButtonHuman1
            // 
            this.radioButtonHuman1.AutoSize = true;
            this.radioButtonHuman1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonHuman1.Checked = true;
            this.radioButtonHuman1.Location = new System.Drawing.Point(9, 19);
            this.radioButtonHuman1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonHuman1.Name = "radioButtonHuman1";
            this.radioButtonHuman1.Size = new System.Drawing.Size(57, 17);
            this.radioButtonHuman1.TabIndex = 15;
            this.radioButtonHuman1.TabStop = true;
            this.radioButtonHuman1.Text = "human";
            this.radioButtonHuman1.UseVisualStyleBackColor = true;
            this.radioButtonHuman1.CheckedChanged += new System.EventHandler(this.radioButtonHuman1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(11, 587);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBox2.Size = new System.Drawing.Size(73, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Use GUI?";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseTimer
            // 
            this.checkBoxUseTimer.AutoSize = true;
            this.checkBoxUseTimer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUseTimer.Enabled = false;
            this.checkBoxUseTimer.Location = new System.Drawing.Point(3, 557);
            this.checkBoxUseTimer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxUseTimer.Name = "checkBoxUseTimer";
            this.checkBoxUseTimer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxUseTimer.Size = new System.Drawing.Size(80, 17);
            this.checkBoxUseTimer.TabIndex = 8;
            this.checkBoxUseTimer.Text = "Use Timer?";
            this.checkBoxUseTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxUseTimer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Win-Req";
            // 
            // numericUpDown_WinReq
            // 
            this.numericUpDown_WinReq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_WinReq.Location = new System.Drawing.Point(31, 152);
            this.numericUpDown_WinReq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_WinReq.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_WinReq.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_WinReq.Name = "numericUpDown_WinReq";
            this.numericUpDown_WinReq.Size = new System.Drawing.Size(62, 26);
            this.numericUpDown_WinReq.TabIndex = 5;
            this.numericUpDown_WinReq.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rows";
            // 
            // numericUpDown_Row
            // 
            this.numericUpDown_Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_Row.Location = new System.Drawing.Point(31, 92);
            this.numericUpDown_Row.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Row.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Row.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_Row.Name = "numericUpDown_Row";
            this.numericUpDown_Row.Size = new System.Drawing.Size(62, 26);
            this.numericUpDown_Row.TabIndex = 3;
            this.numericUpDown_Row.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Columns";
            // 
            // numericUpDown_Col
            // 
            this.numericUpDown_Col.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_Col.Location = new System.Drawing.Point(31, 35);
            this.numericUpDown_Col.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Col.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Col.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_Col.Name = "numericUpDown_Col";
            this.numericUpDown_Col.Size = new System.Drawing.Size(62, 26);
            this.numericUpDown_Col.TabIndex = 1;
            this.numericUpDown_Col.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.loadStateButton);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(225, 9);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 630);
            this.panel3.TabIndex = 2;
            // 
            // loadStateButton
            // 
            this.loadStateButton.Location = new System.Drawing.Point(42, 76);
            this.loadStateButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadStateButton.Name = "loadStateButton";
            this.loadStateButton.Size = new System.Drawing.Size(132, 63);
            this.loadStateButton.TabIndex = 2;
            this.loadStateButton.Text = "Load State (debugging only)";
            this.loadStateButton.UseVisualStyleBackColor = true;
            this.loadStateButton.Click += new System.EventHandler(this.loadStateButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Debugging Panel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(493, 680);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_P2Depth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_P1Depth)).EndInit();
            this.groupBoxPlayer2Type.ResumeLayout(false);
            this.groupBoxPlayer2Type.PerformLayout();
            this.groupBoxPlayer1Type.ResumeLayout(false);
            this.groupBoxPlayer1Type.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WinReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Row)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Col)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Col;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Row;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_WinReq;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.CheckBox checkBoxUseTimer;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBoxPlayer2Type;
        private System.Windows.Forms.RadioButton radioButtonAI2;
        private System.Windows.Forms.RadioButton radioButtonHuman2;
        private System.Windows.Forms.GroupBox groupBoxPlayer1Type;
        private System.Windows.Forms.RadioButton radioButtonAI1;
        private System.Windows.Forms.RadioButton radioButtonHuman1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_P2Depth;
        private System.Windows.Forms.NumericUpDown numericUpDown_P1Depth;
        private System.Windows.Forms.NumericUpDown numericUpDownTimer;
        private System.Windows.Forms.Label LabelAlg2;
        private System.Windows.Forms.ComboBox comboBoxAlgP2;
        private System.Windows.Forms.Label LabelAlg1;
        private System.Windows.Forms.ComboBox comboBoxAlgP1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button loadStateButton;
        private System.Windows.Forms.Label label4;
    }
}

