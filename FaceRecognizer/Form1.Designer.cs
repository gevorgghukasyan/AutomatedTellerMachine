namespace FaceRecognizer
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
			this.picCapture = new System.Windows.Forms.PictureBox();
			this.btnCapture = new System.Windows.Forms.Button();
			this.btnDetectFaces = new System.Windows.Forms.Button();
			this.txtPersonName = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnTrain = new System.Windows.Forms.Button();
			this.btnRecogize = new System.Windows.Forms.Button();
			this.picDetected = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
			this.SuspendLayout();
			// 
			// picCapture
			// 
			this.picCapture.Location = new System.Drawing.Point(13, 13);
			this.picCapture.Name = "picCapture";
			this.picCapture.Size = new System.Drawing.Size(627, 425);
			this.picCapture.TabIndex = 0;
			this.picCapture.TabStop = false;
			// 
			// btnCapture
			// 
			this.btnCapture.Location = new System.Drawing.Point(669, 25);
			this.btnCapture.Name = "btnCapture";
			this.btnCapture.Size = new System.Drawing.Size(119, 23);
			this.btnCapture.TabIndex = 1;
			this.btnCapture.Text = "1. Capture";
			this.btnCapture.UseVisualStyleBackColor = true;
			this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click_1);
			// 
			// btnDetectFaces
			// 
			this.btnDetectFaces.Location = new System.Drawing.Point(669, 67);
			this.btnDetectFaces.Name = "btnDetectFaces";
			this.btnDetectFaces.Size = new System.Drawing.Size(119, 23);
			this.btnDetectFaces.TabIndex = 2;
			this.btnDetectFaces.Text = "2. Detect Faces";
			this.btnDetectFaces.UseVisualStyleBackColor = true;
			this.btnDetectFaces.Click += new System.EventHandler(this.btnDetectFaces_Click_1);
			// 
			// txtPersonName
			// 
			this.txtPersonName.Location = new System.Drawing.Point(669, 259);
			this.txtPersonName.Name = "txtPersonName";
			this.txtPersonName.Size = new System.Drawing.Size(119, 20);
			this.txtPersonName.TabIndex = 3;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(669, 285);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(119, 23);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Add Person";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnTrain
			// 
			this.btnTrain.Location = new System.Drawing.Point(669, 314);
			this.btnTrain.Name = "btnTrain";
			this.btnTrain.Size = new System.Drawing.Size(119, 23);
			this.btnTrain.TabIndex = 5;
			this.btnTrain.Text = "Train Images";
			this.btnTrain.UseVisualStyleBackColor = true;
			this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click_1);
			// 
			// btnRecogize
			// 
			this.btnRecogize.Location = new System.Drawing.Point(669, 343);
			this.btnRecogize.Name = "btnRecogize";
			this.btnRecogize.Size = new System.Drawing.Size(119, 23);
			this.btnRecogize.TabIndex = 6;
			this.btnRecogize.Text = "Recognize Persons";
			this.btnRecogize.UseVisualStyleBackColor = true;
			// 
			// picDetected
			// 
			this.picDetected.Location = new System.Drawing.Point(671, 112);
			this.picDetected.Name = "picDetected";
			this.picDetected.Size = new System.Drawing.Size(116, 130);
			this.picDetected.TabIndex = 7;
			this.picDetected.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.picDetected);
			this.Controls.Add(this.btnRecogize);
			this.Controls.Add(this.btnTrain);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtPersonName);
			this.Controls.Add(this.btnDetectFaces);
			this.Controls.Add(this.btnCapture);
			this.Controls.Add(this.picCapture);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picCapture;
		private System.Windows.Forms.Button btnCapture;
		private System.Windows.Forms.Button btnDetectFaces;
		private System.Windows.Forms.TextBox txtPersonName;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnTrain;
		private System.Windows.Forms.Button btnRecogize;
		private System.Windows.Forms.PictureBox picDetected;
	}
}

