namespace AutomatedTellerMachine
{
    partial class ATM
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATM));
			this.groupBoxDesktop = new System.Windows.Forms.GroupBox();
			this.lblTransfer = new System.Windows.Forms.Label();
			this.lblErrorText = new System.Windows.Forms.Label();
			this.lblTransaction = new System.Windows.Forms.Label();
			this.lblCashIn = new System.Windows.Forms.Label();
			this.lblBalance = new System.Windows.Forms.Label();
			this.lblCardBlock = new System.Windows.Forms.Label();
			this.lblChangePin = new System.Windows.Forms.Label();
			this.lblTax = new System.Windows.Forms.Label();
			this.lblCashOut = new System.Windows.Forms.Label();
			this.lblText = new System.Windows.Forms.Label();
			this.TxtInputData = new System.Windows.Forms.TextBox();
			this.groupBoxTransaction = new System.Windows.Forms.GroupBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.cb1month = new System.Windows.Forms.CheckBox();
			this.cb1week = new System.Windows.Forms.CheckBox();
			this.cb1day = new System.Windows.Forms.CheckBox();
			this.BtnEnter = new System.Windows.Forms.Button();
			this.BtnNum00 = new System.Windows.Forms.Button();
			this.BtnPoint = new System.Windows.Forms.Button();
			this.BtnNum9 = new System.Windows.Forms.Button();
			this.BtnNum8 = new System.Windows.Forms.Button();
			this.BtnNum7 = new System.Windows.Forms.Button();
			this.BtnNum6 = new System.Windows.Forms.Button();
			this.BtnNum5 = new System.Windows.Forms.Button();
			this.BtnNum4 = new System.Windows.Forms.Button();
			this.BtnNum3 = new System.Windows.Forms.Button();
			this.BtnNum1 = new System.Windows.Forms.Button();
			this.BtnNum2 = new System.Windows.Forms.Button();
			this.BtnNum0 = new System.Windows.Forms.Button();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnDelete = new System.Windows.Forms.Button();
			this.BtnCashOut = new System.Windows.Forms.Button();
			this.BtnTax = new System.Windows.Forms.Button();
			this.BtnChangePin = new System.Windows.Forms.Button();
			this.BtnTransaction = new System.Windows.Forms.Button();
			this.BtnCashIn = new System.Windows.Forms.Button();
			this.BtnBalance = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.lblOr = new System.Windows.Forms.Label();
			this.lblAuth = new System.Windows.Forms.Label();
			this.btnAuthFaceId = new System.Windows.Forms.Button();
			this.picCapture = new System.Windows.Forms.PictureBox();
			this.picDetected = new System.Windows.Forms.PictureBox();
			this.groupBoxDesktop.SuspendLayout();
			this.groupBoxTransaction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxDesktop
			// 
			this.groupBoxDesktop.BackColor = System.Drawing.Color.Navy;
			this.groupBoxDesktop.Controls.Add(this.btnAuthFaceId);
			this.groupBoxDesktop.Controls.Add(this.lblAuth);
			this.groupBoxDesktop.Controls.Add(this.lblTransfer);
			this.groupBoxDesktop.Controls.Add(this.lblErrorText);
			this.groupBoxDesktop.Controls.Add(this.lblOr);
			this.groupBoxDesktop.Controls.Add(this.lblTransaction);
			this.groupBoxDesktop.Controls.Add(this.lblCashIn);
			this.groupBoxDesktop.Controls.Add(this.groupBoxTransaction);
			this.groupBoxDesktop.Controls.Add(this.lblBalance);
			this.groupBoxDesktop.Controls.Add(this.lblCardBlock);
			this.groupBoxDesktop.Controls.Add(this.lblChangePin);
			this.groupBoxDesktop.Controls.Add(this.lblTax);
			this.groupBoxDesktop.Controls.Add(this.lblCashOut);
			this.groupBoxDesktop.Controls.Add(this.lblText);
			this.groupBoxDesktop.Controls.Add(this.TxtInputData);
			this.groupBoxDesktop.Location = new System.Drawing.Point(78, 29);
			this.groupBoxDesktop.Name = "groupBoxDesktop";
			this.groupBoxDesktop.Size = new System.Drawing.Size(361, 295);
			this.groupBoxDesktop.TabIndex = 1;
			this.groupBoxDesktop.TabStop = false;
			// 
			// lblTransfer
			// 
			this.lblTransfer.AutoSize = true;
			this.lblTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTransfer.Location = new System.Drawing.Point(247, 65);
			this.lblTransfer.Name = "lblTransfer";
			this.lblTransfer.Size = new System.Drawing.Size(79, 24);
			this.lblTransfer.TabIndex = 27;
			this.lblTransfer.Text = "Transfer";
			this.lblTransfer.Visible = false;
			// 
			// lblErrorText
			// 
			this.lblErrorText.AutoSize = true;
			this.lblErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblErrorText.Location = new System.Drawing.Point(78, 26);
			this.lblErrorText.Name = "lblErrorText";
			this.lblErrorText.Size = new System.Drawing.Size(0, 20);
			this.lblErrorText.TabIndex = 23;
			// 
			// lblTransaction
			// 
			this.lblTransaction.AutoSize = true;
			this.lblTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTransaction.Location = new System.Drawing.Point(247, 117);
			this.lblTransaction.Name = "lblTransaction";
			this.lblTransaction.Size = new System.Drawing.Size(108, 24);
			this.lblTransaction.TabIndex = 27;
			this.lblTransaction.Text = "Transaction";
			this.lblTransaction.Visible = false;
			// 
			// lblCashIn
			// 
			this.lblCashIn.AutoSize = true;
			this.lblCashIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCashIn.Location = new System.Drawing.Point(247, 174);
			this.lblCashIn.Name = "lblCashIn";
			this.lblCashIn.Size = new System.Drawing.Size(68, 24);
			this.lblCashIn.TabIndex = 27;
			this.lblCashIn.Text = "CashIn";
			// 
			// lblBalance
			// 
			this.lblBalance.AutoSize = true;
			this.lblBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBalance.Location = new System.Drawing.Point(247, 222);
			this.lblBalance.Name = "lblBalance";
			this.lblBalance.Size = new System.Drawing.Size(78, 24);
			this.lblBalance.TabIndex = 26;
			this.lblBalance.Text = "Balance";
			// 
			// lblCardBlock
			// 
			this.lblCardBlock.AutoSize = true;
			this.lblCardBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCardBlock.Location = new System.Drawing.Point(22, 64);
			this.lblCardBlock.Name = "lblCardBlock";
			this.lblCardBlock.Size = new System.Drawing.Size(101, 24);
			this.lblCardBlock.TabIndex = 25;
			this.lblCardBlock.Text = "Card Block";
			this.lblCardBlock.Visible = false;
			// 
			// lblChangePin
			// 
			this.lblChangePin.AutoSize = true;
			this.lblChangePin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblChangePin.Location = new System.Drawing.Point(22, 117);
			this.lblChangePin.Name = "lblChangePin";
			this.lblChangePin.Size = new System.Drawing.Size(104, 24);
			this.lblChangePin.TabIndex = 25;
			this.lblChangePin.Text = "ChangePin";
			this.lblChangePin.Visible = false;
			// 
			// lblTax
			// 
			this.lblTax.AutoSize = true;
			this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTax.Location = new System.Drawing.Point(22, 174);
			this.lblTax.Name = "lblTax";
			this.lblTax.Size = new System.Drawing.Size(42, 24);
			this.lblTax.TabIndex = 25;
			this.lblTax.Text = "Tax";
			// 
			// lblCashOut
			// 
			this.lblCashOut.AutoSize = true;
			this.lblCashOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCashOut.Location = new System.Drawing.Point(22, 222);
			this.lblCashOut.Name = "lblCashOut";
			this.lblCashOut.Size = new System.Drawing.Size(83, 24);
			this.lblCashOut.TabIndex = 24;
			this.lblCashOut.Text = "CashOut";
			// 
			// lblText
			// 
			this.lblText.AutoSize = true;
			this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblText.Location = new System.Drawing.Point(134, 54);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(73, 24);
			this.lblText.TabIndex = 23;
			this.lblText.Text = "CardID";
			// 
			// TxtInputData
			// 
			this.TxtInputData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtInputData.Location = new System.Drawing.Point(66, 91);
			this.TxtInputData.Name = "TxtInputData";
			this.TxtInputData.Size = new System.Drawing.Size(229, 35);
			this.TxtInputData.TabIndex = 23;
			this.TxtInputData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TxtInputData.TextChanged += new System.EventHandler(this.TxtInputData_TextChanged);
			// 
			// groupBoxTransaction
			// 
			this.groupBoxTransaction.BackColor = System.Drawing.Color.Navy;
			this.groupBoxTransaction.Controls.Add(this.dataGridView1);
			this.groupBoxTransaction.Controls.Add(this.cb1month);
			this.groupBoxTransaction.Controls.Add(this.cb1week);
			this.groupBoxTransaction.Controls.Add(this.picCapture);
			this.groupBoxTransaction.Controls.Add(this.cb1day);
			this.groupBoxTransaction.Location = new System.Drawing.Point(6, 0);
			this.groupBoxTransaction.Name = "groupBoxTransaction";
			this.groupBoxTransaction.Size = new System.Drawing.Size(361, 295);
			this.groupBoxTransaction.TabIndex = 1;
			this.groupBoxTransaction.TabStop = false;
			this.groupBoxTransaction.Visible = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(0, 49);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(371, 246);
			this.dataGridView1.TabIndex = 24;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// cb1month
			// 
			this.cb1month.AutoSize = true;
			this.cb1month.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cb1month.Location = new System.Drawing.Point(229, 19);
			this.cb1month.Name = "cb1month";
			this.cb1month.Size = new System.Drawing.Size(99, 17);
			this.cb1month.TabIndex = 23;
			this.cb1month.Text = "Last one month";
			this.cb1month.UseVisualStyleBackColor = true;
			this.cb1month.CheckedChanged += new System.EventHandler(this.cb1month_CheckedChanged);
			// 
			// cb1week
			// 
			this.cb1week.AutoSize = true;
			this.cb1week.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cb1week.Location = new System.Drawing.Point(111, 19);
			this.cb1week.Name = "cb1week";
			this.cb1week.Size = new System.Drawing.Size(96, 17);
			this.cb1week.TabIndex = 23;
			this.cb1week.Text = "Last one week";
			this.cb1week.UseVisualStyleBackColor = true;
			this.cb1week.CheckedChanged += new System.EventHandler(this.cb1week_CheckedChanged);
			// 
			// cb1day
			// 
			this.cb1day.AutoSize = true;
			this.cb1day.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cb1day.Location = new System.Drawing.Point(6, 19);
			this.cb1day.Name = "cb1day";
			this.cb1day.Size = new System.Drawing.Size(87, 17);
			this.cb1day.TabIndex = 23;
			this.cb1day.Text = "Last one day";
			this.cb1day.UseVisualStyleBackColor = true;
			this.cb1day.CheckedChanged += new System.EventHandler(this.cb1day_CheckedChanged);
			// 
			// BtnEnter
			// 
			this.BtnEnter.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_15;
			this.BtnEnter.Location = new System.Drawing.Point(345, 501);
			this.BtnEnter.Name = "BtnEnter";
			this.BtnEnter.Size = new System.Drawing.Size(61, 36);
			this.BtnEnter.TabIndex = 12;
			this.BtnEnter.UseVisualStyleBackColor = true;
			this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
			// 
			// BtnNum00
			// 
			this.BtnNum00.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_21;
			this.BtnNum00.Location = new System.Drawing.Point(259, 555);
			this.BtnNum00.Name = "BtnNum00";
			this.BtnNum00.Size = new System.Drawing.Size(54, 37);
			this.BtnNum00.TabIndex = 11;
			this.BtnNum00.UseVisualStyleBackColor = true;
			this.BtnNum00.Click += new System.EventHandler(this.BtnNum00_Click);
			// 
			// BtnPoint
			// 
			this.BtnPoint.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_20;
			this.BtnPoint.Location = new System.Drawing.Point(189, 555);
			this.BtnPoint.Name = "BtnPoint";
			this.BtnPoint.Size = new System.Drawing.Size(55, 37);
			this.BtnPoint.TabIndex = 10;
			this.BtnPoint.UseVisualStyleBackColor = true;
			this.BtnPoint.Click += new System.EventHandler(this.BtnPoint_Click);
			// 
			// BtnNum9
			// 
			this.BtnNum9.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_18;
			this.BtnNum9.Location = new System.Drawing.Point(259, 501);
			this.BtnNum9.Name = "BtnNum9";
			this.BtnNum9.Size = new System.Drawing.Size(54, 36);
			this.BtnNum9.TabIndex = 8;
			this.BtnNum9.UseVisualStyleBackColor = true;
			this.BtnNum9.Click += new System.EventHandler(this.BtnNum9_Click);
			// 
			// BtnNum8
			// 
			this.BtnNum8.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_17;
			this.BtnNum8.Location = new System.Drawing.Point(189, 501);
			this.BtnNum8.Name = "BtnNum8";
			this.BtnNum8.Size = new System.Drawing.Size(55, 36);
			this.BtnNum8.TabIndex = 7;
			this.BtnNum8.UseVisualStyleBackColor = true;
			this.BtnNum8.Click += new System.EventHandler(this.BtnNum8_Click);
			// 
			// BtnNum7
			// 
			this.BtnNum7.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_16;
			this.BtnNum7.Location = new System.Drawing.Point(115, 501);
			this.BtnNum7.Name = "BtnNum7";
			this.BtnNum7.Size = new System.Drawing.Size(55, 36);
			this.BtnNum7.TabIndex = 6;
			this.BtnNum7.UseVisualStyleBackColor = true;
			this.BtnNum7.Click += new System.EventHandler(this.BtnNum7_Click);
			// 
			// BtnNum6
			// 
			this.BtnNum6.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_13;
			this.BtnNum6.Location = new System.Drawing.Point(259, 449);
			this.BtnNum6.Name = "BtnNum6";
			this.BtnNum6.Size = new System.Drawing.Size(54, 34);
			this.BtnNum6.TabIndex = 5;
			this.BtnNum6.UseVisualStyleBackColor = true;
			this.BtnNum6.Click += new System.EventHandler(this.BtnNum6_Click);
			// 
			// BtnNum5
			// 
			this.BtnNum5.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_11;
			this.BtnNum5.Location = new System.Drawing.Point(189, 449);
			this.BtnNum5.Name = "BtnNum5";
			this.BtnNum5.Size = new System.Drawing.Size(55, 34);
			this.BtnNum5.TabIndex = 4;
			this.BtnNum5.UseVisualStyleBackColor = true;
			this.BtnNum5.Click += new System.EventHandler(this.BtnNum5_Click);
			// 
			// BtnNum4
			// 
			this.BtnNum4.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_10;
			this.BtnNum4.Location = new System.Drawing.Point(115, 449);
			this.BtnNum4.Name = "BtnNum4";
			this.BtnNum4.Size = new System.Drawing.Size(55, 34);
			this.BtnNum4.TabIndex = 3;
			this.BtnNum4.UseVisualStyleBackColor = true;
			this.BtnNum4.Click += new System.EventHandler(this.BtnNum4_Click);
			// 
			// BtnNum3
			// 
			this.BtnNum3.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_7;
			this.BtnNum3.Location = new System.Drawing.Point(259, 395);
			this.BtnNum3.Name = "BtnNum3";
			this.BtnNum3.Size = new System.Drawing.Size(53, 36);
			this.BtnNum3.TabIndex = 2;
			this.BtnNum3.UseVisualStyleBackColor = true;
			this.BtnNum3.Click += new System.EventHandler(this.BtnNum3_Click);
			// 
			// BtnNum1
			// 
			this.BtnNum1.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_1button;
			this.BtnNum1.Location = new System.Drawing.Point(117, 395);
			this.BtnNum1.Name = "BtnNum1";
			this.BtnNum1.Size = new System.Drawing.Size(53, 36);
			this.BtnNum1.TabIndex = 0;
			this.BtnNum1.UseVisualStyleBackColor = true;
			this.BtnNum1.Click += new System.EventHandler(this.BtnNum1_Click);
			// 
			// BtnNum2
			// 
			this.BtnNum2.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_6;
			this.BtnNum2.Location = new System.Drawing.Point(189, 395);
			this.BtnNum2.Name = "BtnNum2";
			this.BtnNum2.Size = new System.Drawing.Size(53, 36);
			this.BtnNum2.TabIndex = 1;
			this.BtnNum2.UseVisualStyleBackColor = true;
			this.BtnNum2.Click += new System.EventHandler(this.BtnNum2_Click);
			// 
			// BtnNum0
			// 
			this.BtnNum0.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Capture;
			this.BtnNum0.Location = new System.Drawing.Point(115, 555);
			this.BtnNum0.Name = "BtnNum0";
			this.BtnNum0.Size = new System.Drawing.Size(55, 37);
			this.BtnNum0.TabIndex = 9;
			this.BtnNum0.UseVisualStyleBackColor = true;
			this.BtnNum0.Click += new System.EventHandler(this.BtnNum0_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_9;
			this.BtnCancel.Location = new System.Drawing.Point(345, 395);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(61, 36);
			this.BtnCancel.TabIndex = 13;
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnDelete
			// 
			this.BtnDelete.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_14;
			this.BtnDelete.Location = new System.Drawing.Point(345, 449);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(61, 34);
			this.BtnDelete.TabIndex = 14;
			this.BtnDelete.UseVisualStyleBackColor = true;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// BtnCashOut
			// 
			this.BtnCashOut.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_23;
			this.BtnCashOut.Location = new System.Drawing.Point(21, 245);
			this.BtnCashOut.Name = "BtnCashOut";
			this.BtnCashOut.Size = new System.Drawing.Size(41, 27);
			this.BtnCashOut.TabIndex = 15;
			this.BtnCashOut.UseVisualStyleBackColor = true;
			this.BtnCashOut.Click += new System.EventHandler(this.BtnCashOut_Click);
			// 
			// BtnTax
			// 
			this.BtnTax.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_23;
			this.BtnTax.Location = new System.Drawing.Point(21, 191);
			this.BtnTax.Name = "BtnTax";
			this.BtnTax.Size = new System.Drawing.Size(41, 26);
			this.BtnTax.TabIndex = 16;
			this.BtnTax.UseVisualStyleBackColor = true;
			this.BtnTax.Click += new System.EventHandler(this.BtnTax_Click);
			// 
			// BtnChangePin
			// 
			this.BtnChangePin.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_23;
			this.BtnChangePin.Enabled = false;
			this.BtnChangePin.Location = new System.Drawing.Point(21, 136);
			this.BtnChangePin.Name = "BtnChangePin";
			this.BtnChangePin.Size = new System.Drawing.Size(41, 28);
			this.BtnChangePin.TabIndex = 17;
			this.BtnChangePin.UseVisualStyleBackColor = true;
			this.BtnChangePin.Click += new System.EventHandler(this.BtnChangePin_Click);
			// 
			// BtnTransaction
			// 
			this.BtnTransaction.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_22;
			this.BtnTransaction.Enabled = false;
			this.BtnTransaction.Location = new System.Drawing.Point(455, 136);
			this.BtnTransaction.Name = "BtnTransaction";
			this.BtnTransaction.Size = new System.Drawing.Size(42, 28);
			this.BtnTransaction.TabIndex = 18;
			this.BtnTransaction.UseVisualStyleBackColor = true;
			this.BtnTransaction.Click += new System.EventHandler(this.button4_Click);
			// 
			// BtnCashIn
			// 
			this.BtnCashIn.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_22;
			this.BtnCashIn.Location = new System.Drawing.Point(455, 191);
			this.BtnCashIn.Name = "BtnCashIn";
			this.BtnCashIn.Size = new System.Drawing.Size(42, 26);
			this.BtnCashIn.TabIndex = 19;
			this.BtnCashIn.UseVisualStyleBackColor = true;
			this.BtnCashIn.Click += new System.EventHandler(this.BtnCashIn_Click);
			// 
			// BtnBalance
			// 
			this.BtnBalance.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_22;
			this.BtnBalance.Location = new System.Drawing.Point(455, 245);
			this.BtnBalance.Name = "BtnBalance";
			this.BtnBalance.Size = new System.Drawing.Size(42, 27);
			this.BtnBalance.TabIndex = 20;
			this.BtnBalance.UseVisualStyleBackColor = true;
			this.BtnBalance.Click += new System.EventHandler(this.BtnBalance_Click);
			// 
			// button1
			// 
			this.button1.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_23;
			this.button1.Location = new System.Drawing.Point(21, 83);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(41, 27);
			this.button1.TabIndex = 21;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources.Screenshot_22;
			this.button2.Location = new System.Drawing.Point(455, 83);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(42, 27);
			this.button2.TabIndex = 22;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// lblOr
			// 
			this.lblOr.AutoSize = true;
			this.lblOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOr.Location = new System.Drawing.Point(153, 129);
			this.lblOr.Name = "lblOr";
			this.lblOr.Size = new System.Drawing.Size(38, 26);
			this.lblOr.TabIndex = 25;
			this.lblOr.Text = "Or";
			this.lblOr.Click += new System.EventHandler(this.lblOr_Click);
			// 
			// lblAuth
			// 
			this.lblAuth.AutoSize = true;
			this.lblAuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAuth.Location = new System.Drawing.Point(100, 16);
			this.lblAuth.Name = "lblAuth";
			this.lblAuth.Size = new System.Drawing.Size(183, 26);
			this.lblAuth.TabIndex = 26;
			this.lblAuth.Text = "Authenticate via";
			this.lblAuth.Click += new System.EventHandler(this.lblAuthFace_Click);
			// 
			// btnAuthFaceId
			// 
			this.btnAuthFaceId.BackColor = System.Drawing.Color.SlateGray;
			this.btnAuthFaceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAuthFaceId.Image = ((System.Drawing.Image)(resources.GetObject("btnAuthFaceId.Image")));
			this.btnAuthFaceId.Location = new System.Drawing.Point(105, 158);
			this.btnAuthFaceId.Name = "btnAuthFaceId";
			this.btnAuthFaceId.Size = new System.Drawing.Size(143, 135);
			this.btnAuthFaceId.TabIndex = 28;
			this.btnAuthFaceId.UseVisualStyleBackColor = false;
			this.btnAuthFaceId.Click += new System.EventHandler(this.btnAuthFaceId_Click);
			// 
			// picCapture
			// 
			this.picCapture.Enabled = false;
			this.picCapture.Location = new System.Drawing.Point(187, 31);
			this.picCapture.Name = "picCapture";
			this.picCapture.Size = new System.Drawing.Size(191, 295);
			this.picCapture.TabIndex = 29;
			this.picCapture.TabStop = false;
			this.picCapture.Visible = false;
			// 
			// picDetected
			// 
			this.picDetected.Enabled = false;
			this.picDetected.Location = new System.Drawing.Point(41, 395);
			this.picDetected.Name = "picDetected";
			this.picDetected.Size = new System.Drawing.Size(627, 425);
			this.picDetected.TabIndex = 30;
			this.picDetected.TabStop = false;
			this.picDetected.Visible = false;
			this.picDetected.Click += new System.EventHandler(this.picDetected_Click);
			// 
			// ATM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::AutomatedTellerMachine.Properties.Resources._512x620;
			this.ClientSize = new System.Drawing.Size(928, 850);
			this.Controls.Add(this.picDetected);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.BtnBalance);
			this.Controls.Add(this.BtnCashIn);
			this.Controls.Add(this.BtnTransaction);
			this.Controls.Add(this.BtnChangePin);
			this.Controls.Add(this.BtnTax);
			this.Controls.Add(this.BtnCashOut);
			this.Controls.Add(this.BtnDelete);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.BtnEnter);
			this.Controls.Add(this.groupBoxDesktop);
			this.Controls.Add(this.BtnNum00);
			this.Controls.Add(this.BtnNum1);
			this.Controls.Add(this.BtnPoint);
			this.Controls.Add(this.BtnNum2);
			this.Controls.Add(this.BtnNum0);
			this.Controls.Add(this.BtnNum3);
			this.Controls.Add(this.BtnNum9);
			this.Controls.Add(this.BtnNum4);
			this.Controls.Add(this.BtnNum8);
			this.Controls.Add(this.BtnNum5);
			this.Controls.Add(this.BtnNum7);
			this.Controls.Add(this.BtnNum6);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ATM";
			this.Text = "ATM";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBoxDesktop.ResumeLayout(false);
			this.groupBoxDesktop.PerformLayout();
			this.groupBoxTransaction.ResumeLayout(false);
			this.groupBoxTransaction.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxDesktop;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.Button BtnNum00;
        private System.Windows.Forms.Button BtnPoint;
        private System.Windows.Forms.Button BtnNum9;
        private System.Windows.Forms.Button BtnNum8;
        private System.Windows.Forms.Button BtnNum7;
        private System.Windows.Forms.Button BtnNum6;
        private System.Windows.Forms.Button BtnNum5;
        private System.Windows.Forms.Button BtnNum4;
        private System.Windows.Forms.Button BtnNum3;
        private System.Windows.Forms.Button BtnNum2;
        private System.Windows.Forms.Button BtnNum1;
        private System.Windows.Forms.Button BtnNum0;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnCashOut;
        private System.Windows.Forms.Button BtnTax;
        private System.Windows.Forms.Button BtnChangePin;
        private System.Windows.Forms.Button BtnTransaction;
        private System.Windows.Forms.Button BtnCashIn;
        private System.Windows.Forms.Button BtnBalance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtInputData;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblCashIn;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblCashOut;
        private System.Windows.Forms.Label lblErrorText;
        private System.Windows.Forms.Label lblTransaction;
        private System.Windows.Forms.Label lblChangePin;
        private System.Windows.Forms.GroupBox groupBoxTransaction;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cb1month;
        private System.Windows.Forms.CheckBox cb1week;
        private System.Windows.Forms.CheckBox cb1day;
        private System.Windows.Forms.Label lblTransfer;
        private System.Windows.Forms.Label lblCardBlock;
		private System.Windows.Forms.Label lblOr;
		private System.Windows.Forms.Label lblAuth;
		private System.Windows.Forms.Button btnAuthFaceId;
		private System.Windows.Forms.PictureBox picDetected;
		private System.Windows.Forms.PictureBox picCapture;
	}
}

