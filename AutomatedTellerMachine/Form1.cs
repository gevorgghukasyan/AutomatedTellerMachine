using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Entities;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV;
//using Capture = Emgu.CV.Capture;



namespace AutomatedTellerMachine
{
	public enum ATMOperations
	{
		CardID,
		Password,
		CashIn,
		CashOut,
		Balance,
		Tax,
		Transaction,
		ChangePin
	}

	public partial class ATM : Form, IView
	{
		public ATM()
		{
			InitializeComponent();
		}

		private string _connectionString = @"Data Source = DESKTOP-44N2VNP; Initial Catalog=ATMDB; Integrated Security = True";

		private ATMOperations currentOperation = ATMOperations.CardID;

		private string AccountNumber;
		private string Password;
		Card card = new Card();
		private async void BtnEnter_Click(object sender, EventArgs e)
		{
			switch (currentOperation)
			{
				case ATMOperations.CardID:
					AccountNumber = TxtInputData.Text;
					card.AccountNumber = AccountNumber;
					lblText.Text = "Password";
					TxtInputData.Text = "";
					TxtInputData.UseSystemPasswordChar = true;
					ActiveControl = TxtInputData;
					currentOperation = ATMOperations.Password;
					break;
				case ATMOperations.Password:
					Password = TxtInputData.Text;
					card.Password = Password;
					OnSubmitIdPass?.Invoke(this, card);
					break;
				case ATMOperations.CashIn:
					CashEventArgs cashIn = new CashEventArgs(card, decimal.Parse(TxtInputData.Text));
					OnCashIn?.Invoke(this, cashIn);
					lblText.Location = new Point(25, 50);
					lblText.Text = "Your transfer is complete";
					await Task.Delay(5000);
					SuccessLogin();
					break;
				case ATMOperations.CashOut:
					CashEventArgs cash = new CashEventArgs(card, decimal.Parse(TxtInputData.Text));
					OnCashOut?.Invoke(this, cash);
					lblText.Location = new Point(25, 50);
					lblText.Text = "Your transaction is complete";
					await Task.Delay(5000);
					SuccessLogin();
					break;
				case ATMOperations.Balance:

					break;
				case ATMOperations.Tax:
					break;
				case ATMOperations.Transaction:
					int moneySize = int.Parse(TxtInputData.Text);
					transmitter.Balance -= moneySize;
					recipient.Balance += moneySize;

					UpdateCard(transmitter);
					UpdateCard(recipient);

					Thread.Sleep(5000);

					lblCardBlock.Visible = true;
					lblBalance.Visible = true;
					lblCashIn.Visible = true;
					lblCashOut.Visible = true;
					lblChangePin.Visible = true;
					lblTax.Visible = true;
					lblTransaction.Visible = true;
					lblTransfer.Visible = true;

					lblText.Location = new Point(133, 64);
					lblText.Visible = false;

					break;
				case ATMOperations.ChangePin:
					if (TxtInputData.Text.Length == 4)
					{
						var card = GetById(AccountNumber);
						string salt = GenerateGuid();
						card.Password = SHA1(TxtInputData.Text, salt);
						card.Guid = salt;

						UpdateCard1(card);


						TxtInputData.Visible = false;
						lblText.Text = "Your Pin Changed Successfully";


						Thread.Sleep(5000);

						lblCardBlock.Visible = true;
						lblBalance.Visible = true;
						lblCashIn.Visible = true;
						lblCashOut.Visible = true;
						lblChangePin.Visible = true;
						lblTax.Visible = true;
						lblTransaction.Visible = true;
						lblTransfer.Visible = true;

						lblText.Location = new Point(133, 64);
						lblText.Visible = false;
					}
					break;
				default:
					break;
			}

		}
		Card transmitter = new Card();
		Card recipient = new Card();
		public void UpdateCard1(Card card)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "UPDATE Cards SET Balance=@Balance,Blocked=@Blocked,Password=@Password,Guid = @Guid WHERE AccountNumber=@AccountNumber";
					command.Parameters.Add(new SqlParameter("@Password", card.Password));
					command.Parameters.Add(new SqlParameter("@Guid", card.Guid));
					command.Parameters.Add(new SqlParameter("@Balance", card.Balance));
					command.Parameters.Add(new SqlParameter("@AccountNumber", card.AccountNumber));
					command.Parameters.Add(new SqlParameter("@Blocked", card.Blocked));
					command.ExecuteNonQuery();
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ActiveControl = TxtInputData;
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblTax.Visible = false;
			lblBalance.Visible = false;

			BtnCashOut.Enabled = false;
			BtnTax.Enabled = false;
			BtnCashIn.Enabled = false;
			BtnBalance.Enabled = false;
			lblOr.Visible = true;
			lblAuth.Visible = true;
		}

		private string txtinputDatalastText = "";

		public event EventHandler<Card> OnSubmitIdPass;
		public event EventHandler<CheckEventArgs> OnBalanceRequest;
		public event EventHandler<CashEventArgs> OnCashOut;
		public event EventHandler OnTaxRequest;
		public event EventHandler<CashEventArgs> OnCashIn;



		private void TxtInputData_TextChanged(object sender, EventArgs e)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(TxtInputData.Text, @"^\d*$"))
			{
				txtinputDatalastText = TxtInputData.Text;
			}

			else
			{
				if (txtinputDatalastText.Length > 1)
				{
					TxtInputData.Text = txtinputDatalastText;
				}
				else
				{
					TxtInputData.Text = "";
				}
				TxtInputData.SelectionStart = TxtInputData.Text.Length;
				TxtInputData.SelectionLength = 0;
			}
		}


		public void SuccessLogin()
		{
			lblErrorText.Text = "";

			TxtInputData.Visible = false;
			lblText.Visible = false;

			lblCashIn.Visible = true;
			lblCashOut.Visible = true;
			lblTax.Visible = true;
			lblBalance.Visible = true;
			lblTransaction.Visible = true;
			lblChangePin.Visible = true;

			BtnCashOut.Enabled = true;
			BtnTax.Enabled = true;
			BtnCashIn.Enabled = true;
			BtnBalance.Enabled = true;
			BtnTransaction.Enabled = true;
			BtnChangePin.Enabled = true;
			lblTransfer.Visible = true;
			lblCardBlock.Visible = true;

		}

		public async void FailLogin(LoginResultType message)
		{
			switch (message)
			{
				case LoginResultType.NotFound:
					lblErrorText.Text = "CardID is wrong. Try again";
					lblText.Text = "CardID";
					TxtInputData.Text = "";
					TxtInputData.UseSystemPasswordChar = false;
					ActiveControl = TxtInputData;
					break;

				case LoginResultType.WrongPaswword:
					lblErrorText.Text = "Password is wrong. Try again";
					lblText.Text = "Password";
					TxtInputData.Text = "";
					ActiveControl = TxtInputData;
					break;

				case LoginResultType.Expired:
					lblErrorText.Text = "Your card is disabled";
					await Task.Delay(10000);
					lblErrorText.Text = "";
					lblText.Text = "CardID";
					TxtInputData.Text = "";
					TxtInputData.UseSystemPasswordChar = false;
					ActiveControl = TxtInputData;
					break;

				case LoginResultType.Blocked:
					lblErrorText.Text = "Your card is blocked";
					await Task.Delay(10000);
					lblErrorText.Text = "";
					lblText.Text = "CardID";
					TxtInputData.Text = "";
					TxtInputData.UseSystemPasswordChar = false;
					ActiveControl = TxtInputData;
					break;
			}
		}

		private void BtnCashIn_Click(object sender, EventArgs e)
		{
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblBalance.Visible = false;
			lblTax.Visible = false;
			lblTransaction.Visible = false;
			lblTransfer.Visible = false;
			lblCardBlock.Visible = false;
			lblChangePin.Visible = false;

			BtnCashOut.Enabled = false;
			BtnTax.Enabled = false;
			BtnCashIn.Enabled = false;
			BtnBalance.Enabled = false;

			TxtInputData.Visible = true;
			TxtInputData.Text = "";
			ActiveControl = TxtInputData;
			TxtInputData.UseSystemPasswordChar = false;

			lblText.Location = new Point(80, 64);
			lblText.Visible = true;
			lblText.Text = "Input money size";
			currentOperation = ATMOperations.CashIn;

		}

		private void BtnNum1_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "1";
		}

		private void BtnNum2_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "2";
		}

		private void BtnNum3_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "3";
		}

		private void BtnNum4_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "4";
		}

		private void BtnNum5_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "5";
		}

		private void BtnNum6_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "6";
		}

		private void BtnNum7_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "7";
		}

		private void BtnNum8_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "8";
		}

		private void BtnNum9_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "9";
		}

		private void BtnNum0_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "0";
		}

		private void BtnPoint_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += ".";
		}

		private void BtnNum00_Click(object sender, EventArgs e)
		{
			TxtInputData.Text += "00";
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			if (TxtInputData.Text.Length > 0)
			{
				TxtInputData.Text = TxtInputData.Text.Remove(TxtInputData.Text.Length - 1);
			}
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			TxtInputData.UseSystemPasswordChar = false;
			currentOperation = ATMOperations.CardID;
			lblText.Visible = true;
			lblText.Location = new Point(133, 64);
			lblText.Text = "CardID";
			TxtInputData.Visible = true;
			TxtInputData.Text = "";
			txtinputDatalastText = TxtInputData.Text;

			lblErrorText.Text = "";

			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblBalance.Visible = false;
			lblTax.Visible = false;

			BtnCashOut.Enabled = false;
			BtnTax.Enabled = false;
			BtnCashIn.Enabled = false;
			BtnBalance.Enabled = false;

			ActiveControl = TxtInputData;
		}

		private async void BtnBalance_Click(object sender, EventArgs e)
		{
			currentOperation = ATMOperations.Balance;

			CheckEventArgs checkEvent = new CheckEventArgs(card);
			OnBalanceRequest?.Invoke(this, checkEvent);


			lblText.Visible = true;
			lblBalance.Visible = false;
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblTax.Visible = false;


			BtnCashOut.Enabled = false;
			BtnTax.Enabled = false;
			BtnCashIn.Enabled = false;
			BtnBalance.Enabled = false;

			await Task.Delay(10000);
			SuccessLogin();
		}

		private void BtnCashOut_Click(object sender, EventArgs e)
		{
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblBalance.Visible = false;
			lblTax.Visible = false;

			BtnCashOut.Enabled = false;
			BtnTax.Enabled = false;
			BtnCashIn.Enabled = false;
			BtnBalance.Enabled = false;

			TxtInputData.Visible = true;
			TxtInputData.Text = "";
			ActiveControl = TxtInputData;
			TxtInputData.UseSystemPasswordChar = false;

			lblText.Location = new Point(80, 64);
			lblText.Visible = true;
			lblText.Text = "Input money size";
			currentOperation = ATMOperations.CashOut;

		}

		private void BtnTax_Click(object sender, EventArgs e)
		{
			currentOperation = ATMOperations.Tax;
		}

		public void WarningMessage(string message)
		{
			lblErrorText.Visible = true;
			lblErrorText.Text = message;
			Thread.Sleep(5000);
			SuccessLogin();
		}

		public void InfoMessage(string message)
		{
			lblText.Location = new Point(50, 50);
			lblText.Text = message;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			groupBoxDesktop.Visible = false;
			groupBoxTransaction.Visible = true;
		}

		public List<Transaction> GetTransaction(int day)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				List<Transaction> transactions = new List<Transaction>();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = $"Select * from Transactions where TransactionDate = {DateTime.Now.Day - 1}";
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Transaction transaction = new Transaction();

							transaction.CardId = int.Parse(reader["CardId"].ToString());
							transaction.TransactionId = int.Parse(reader["TransactionId"].ToString());
							transaction.Amount = decimal.Parse(reader["Amount"].ToString());
							transaction.TransactionDate = DateTime.Parse(reader["TransactionDate"].ToString());
							transaction.Withdraw = bool.Parse(reader["Withdraw"].ToString());
							transactions.Add(transaction);
						}
					}
					return transactions;
				}

			}
		}

		private void cb1day_CheckedChanged(object sender, EventArgs e)
		{
			cb1week.Checked = false;
			cb1month.Checked = false;

			List<Transaction> transactions = new List<Transaction>();
			transactions.Add(new Transaction() { CardId = 1, TransactionId = 1, TransactionDate = DateTime.Parse("2020-5-21"), Withdraw = false, Amount = 5000 });
			transactions.Add(new Transaction() { CardId = 1, TransactionId = 2, TransactionDate = DateTime.Parse("2020-5-21"), Withdraw = true, Amount = 3000 });
			transactions.Add(new Transaction() { CardId = 1, TransactionId = 3, TransactionDate = DateTime.Parse("2020-5-21"), Withdraw = true, Amount = 2000 });
			transactions.Add(new Transaction() { CardId = 1, TransactionId = 4, TransactionDate = DateTime.Parse("2020-5-21"), Withdraw = false, Amount = 21000 });
			transactions.Add(new Transaction() { CardId = 1, TransactionId = 5, TransactionDate = DateTime.Parse("2020-5-21"), Withdraw = true, Amount = 5000 });

			dataGridView1.DataSource = transactions;
			//GetTransaction(1);
		}

		private void cb1week_CheckedChanged(object sender, EventArgs e)
		{
			cb1day.Checked = false;
			cb1month.Checked = false;

			dataGridView1.DataSource = GetTransaction(7);
		}

		private void cb1month_CheckedChanged(object sender, EventArgs e)
		{
			cb1day.Checked = false;
			cb1week.Checked = false;

			dataGridView1.DataSource = GetTransaction(30);
		}
		public void UpdateCard(Card card)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "UPDATE Cards SET Balance=@Balance,Blocked=@Blocked WHERE AccountNumber=@AccountNumber";
					command.Parameters.Add(new SqlParameter("@Balance", card.Balance));
					command.Parameters.Add(new SqlParameter("@AccountNumber", card.AccountNumber));
					command.Parameters.Add(new SqlParameter("@Blocked", card.Blocked));
					command.ExecuteNonQuery();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			lblCardBlock.Visible = false;
			lblBalance.Visible = false;
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblChangePin.Visible = false;
			lblErrorText.Visible = false;
			lblTax.Visible = false;
			lblText.Visible = false;
			lblTransaction.Visible = false;
			lblTransfer.Visible = false;
			// DialogResult dialogResult = MessageBox.Show("Are you sure you want to transfer to\n          Karen Abrahamyan?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to block the card?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				lblText.Visible = true;


				var card = GetById(AccountNumber);
				card.Blocked = true;

				UpdateCard(card);
				//lblText.Text = "Your Card Is Blocked, Please Connect \n            With Our Support Service.";

				lblText.Location = new Point(50, 64);
				lblText.Text = "Your Card Blocked Successfully";
				lblText.Visible = true;

				Thread.Sleep(5000);

				lblCardBlock.Visible = true;
				lblBalance.Visible = true;
				lblCashIn.Visible = true;
				lblCashOut.Visible = true;
				lblChangePin.Visible = true;
				lblTax.Visible = true;
				lblTransaction.Visible = true;
				lblTransfer.Visible = true;

				lblText.Location = new Point(133, 64);
				lblText.Visible = false;


				//Thread.Sleep(5000);
				//lblText.Visible = false;

				//lblCardBlock.Visible = true;
				//lblBalance.Visible = true;
				//lblCashIn.Visible = true;
				//lblCashOut.Visible = true;
				//lblChangePin.Visible = true;
				//lblTax.Visible = true;
				//lblTransaction.Visible = true;
				//lblTransfer.Visible = true;
			}
			else
			{
				lblCardBlock.Visible = true;
				lblBalance.Visible = true;
				lblCashIn.Visible = true;
				lblCashOut.Visible = true;
				lblChangePin.Visible = true;
				lblTax.Visible = true;
				lblTransaction.Visible = true;
				lblTransfer.Visible = true;
			}
		}


		public Card GetById(string accountNumber)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				Card card = new Card();
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "Select * from Cards where AccountNumber = @AccountNumber";
					command.Parameters.Add(new SqlParameter("@AccountNumber", accountNumber));
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							card.AccountNumber = reader["AccountNumber"].ToString();
							card.UserId = int.Parse(reader["UserId"].ToString());
							card.CardId = int.Parse(reader["CardId"].ToString());
							card.Password = reader["Password"].ToString();
							card.Validation = DateTime.Parse(reader["Validation"].ToString());
							card.Balance = int.Parse(reader["Balance"].ToString());
							card.Blocked = bool.Parse(reader["Blocked"].ToString());
							card.Guid = reader["Guid"].ToString();
						}
					}

				}
				return card;
			}
		}


		private void button2_Click(object sender, EventArgs e)
		{
			lblCardBlock.Visible = false;
			lblBalance.Visible = false;
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblChangePin.Visible = false;
			lblErrorText.Visible = false;
			lblTax.Visible = false;
			lblTransaction.Visible = false;
			lblTransfer.Visible = false;

			lblText.Text = "Write the recipient's account number";
			TxtInputData.Visible = true;

			string accountNumber = TxtInputData.Text;

			transmitter = GetById(AccountNumber);
			recipient = GetById(accountNumber);

			var user = GetByUserId(recipient.UserId);

			DialogResult dialogResult = MessageBox.Show($"Are you sure you want to transfer to\n{user.FirstName} {user.LastName}?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dialogResult == DialogResult.Yes)
			{
				TxtInputData.Text = "";
				lblText.Text = "Input money size";
			}

			Thread.Sleep(5000);
			lblText.Visible = false;

			lblCardBlock.Visible = true;
			lblBalance.Visible = true;
			lblCashIn.Visible = true;
			lblCashOut.Visible = true;
			lblChangePin.Visible = true;
			lblTax.Visible = true;
			lblTransaction.Visible = true;
			lblTransfer.Visible = true;
		}

		public User GetByUserId(int userId)
		{
			User user = new User();
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "Select * from Users where UserId=@Userid";
					command.Parameters.Add(new SqlParameter("@UserId", userId));
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{

							user.Id = int.Parse(reader["UserId"].ToString());
							user.PassportSerial = reader["PassportSerial"].ToString();
							user.FirstName = reader["FirstName"].ToString();
							user.LastName = reader["LastName"].ToString();
							user.BirthDay = DateTime.Parse(reader["BirthDay"].ToString());
							user.Email = reader["Email"].ToString();
							user.Tax = decimal.Parse(reader["Tax"].ToString());
						}
					}
				}
			}
			return user;
		}
		public string GenerateGuid()
		{
			return System.Guid.NewGuid().ToString();
		}
		private string SHA1(string password, string salt)
		{
			var passSalt = password + salt;

			using (var algorithm = System.Security.Cryptography.SHA1.Create())
			{
				var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passSalt));
				var HashedPassword = Convert.ToBase64String(hash);

				return HashedPassword;
			}
		}
		private void BtnChangePin_Click(object sender, EventArgs e)
		{
			currentOperation = ATMOperations.ChangePin;
			TxtInputData.Text = "";

			lblCardBlock.Visible = false;
			lblBalance.Visible = false;
			lblCashIn.Visible = false;
			lblCashOut.Visible = false;
			lblChangePin.Visible = false;
			lblErrorText.Visible = false;
			lblTax.Visible = false;
			lblTransaction.Visible = false;
			lblTransfer.Visible = false;

			TxtInputData.Visible = true;

			lblText.Location = new Point(80, 64);
			lblText.Text = "Please Write New Pin";
			lblText.Visible = true;

		}

		private void lblAuthFace_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void lblOr_Click(object sender, EventArgs e)
		{

		}

		private void btnAuthFaceId_Click(object sender, EventArgs e)
		{
			btnAuthFaceId.Enabled = false;
			btnAuthFaceId.Visible = false;

			facesDetectionEnabled = true;

			//Dispose of Capture if it was created before
			if (videoCapture != null) videoCapture.Dispose();
			videoCapture = new Capture();
			//videoCapture.ImageGrabbed += ProcessFrame;
			Application.Idle += ProcessFrame;
			// videoCapture.Start();
		}

		#region Face recognation


		#region Variables
		int testid = 0;
		private Capture videoCapture = null;
		private Image<Bgr, Byte> currentFrame = null;
		Mat frame = new Mat();
		private bool facesDetectionEnabled = false;
		CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"C:\Users\C1\Downloads\New folder (2)\haarcascade_frontalface_alt.xml");
		Image<Bgr, Byte> faceResult = null;
		List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
		List<int> PersonsLabes = new List<int>();

		bool EnableSaveImage = false;
		private bool isTrained = false;
		EigenFaceRecognizer recognizer;
		List<string> PersonsNames = new List<string>();

		#endregion

		private bool TrainImagesFromDir()
		{
			int ImagesCount = 0;
			double Threshold = 2000;
			TrainedFaces.Clear();
			PersonsLabes.Clear();
			PersonsNames.Clear();
			try
			{
				string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
				string[] files = Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);

				foreach (var file in files)
				{
					Image<Gray, byte> trainedImage = new Image<Gray, byte>(file).Resize(200, 200, Inter.Cubic);
					CvInvoke.EqualizeHist(trainedImage, trainedImage);
					TrainedFaces.Add(trainedImage);
					PersonsLabes.Add(ImagesCount);
					string name = file.Split('\\').Last().Split('_')[0];
					PersonsNames.Add(name);
					ImagesCount++;
					Debug.WriteLine(ImagesCount + ". " + name);

				}

				if (TrainedFaces.Count() > 0)
				{
					// recognizer = new EigenFaceRecognizer(ImagesCount,Threshold);
					recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
					recognizer.Train(TrainedFaces.ToArray(), PersonsLabes.ToArray());

					isTrained = true;
					//Debug.WriteLine(ImagesCount);
					//Debug.WriteLine(isTrained);
					return true;
				}
				else
				{
					isTrained = false;
					return false;
				}
			}
			catch (Exception ex)
			{
				isTrained = false;
				MessageBox.Show("Error in Train Images: " + ex.Message);
				return false;
			}
		}

		private void ProcessFrame(object sender, EventArgs e)
		{
			//Step 1: Video Capture
			if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
			{
				videoCapture.Retrieve(frame, 0);
				currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height, Inter.Cubic);

				//Step 2: Face Detection
				if (facesDetectionEnabled)
				{
					//Convert from Bgr to Gray Image
					Mat grayImage = new Mat();
					CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
					//Enhance the image to get better result
					CvInvoke.EqualizeHist(grayImage, grayImage);

					Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 3, Size.Empty, Size.Empty);
					//If faces detected
					if (faces.Length > 0)
					{
						foreach (var face in faces)
						{
							//Draw square around each face 
							// CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

							//Step 3: Add Person 
							//Assign the face to the picture Box face picDetected
							Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
							resultImage.ROI = face;
							picCapture.SizeMode = PictureBoxSizeMode.StretchImage;
							picCapture.Image = resultImage.Bitmap;

							if (EnableSaveImage)
							{
								//We will create a directory if does not exists!
								string path = Directory.GetCurrentDirectory() + @"\TrainedImages";
								if (!Directory.Exists(path))
									Directory.CreateDirectory(path);
								//we will save 10 images with delay a second for each image 
								//to avoid hang GUI we will create a new task
								Task.Factory.StartNew(() =>
								{
									for (int i = 0; i < 10; i++)
									{
										//resize the image then saving it
										resultImage.Resize(200, 200, Inter.Cubic).Save(path + @"\" + "Gevorg_Ghukasyan" + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
										Thread.Sleep(1000);
									}
								});

							}
							EnableSaveImage = false;

							//if (btnSave.InvokeRequired)
							//{
							//	btnSave.Invoke(new ThreadStart(delegate
							//	{
							//		btnSave.Enabled = true;
							//	}));
							//}

							// Step 5: Recognize the face 
							if (isTrained)
							{
								Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
								CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
								var result = recognizer.Predict(grayFaceResult);
								picCapture.Image = grayFaceResult.Bitmap;
								picDetected.Image = TrainedFaces[result.Label].Bitmap;
								Debug.WriteLine(result.Label + ". " + result.Distance);
								//Here results found known faces
								if (result.Label != -1 && result.Distance < 2000)
								{
									CvInvoke.PutText(currentFrame, PersonsNames[result.Label], new Point(face.X - 2, face.Y - 2),
										FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
									CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Green).MCvScalar, 2);
								}
								//here results did not found any know faces
								else
								{
									CvInvoke.PutText(currentFrame, "Unknown", new Point(face.X - 2, face.Y - 2),
										FontFace.HersheyComplex, 1.0, new Bgr(Color.Orange).MCvScalar);
									CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

								}
							}
						}
					}
				}

				//Render the video capture into the Picture Box picCapture
				picCapture.Image = currentFrame.Bitmap;
			}

			//Dispose the Current Frame after processing it to reduce the memory consumption.
			if (currentFrame != null)
				currentFrame.Dispose();
		}
		#endregion

		private void picDetected_Click(object sender, EventArgs e)
		{

		}
	}
}