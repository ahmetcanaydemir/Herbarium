using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Herbarium
{
	public class MaskedTextBox : System.Windows.Forms.TextBox
	{
		public enum Mask {None, DateOnly, PhoneWithArea, IpAddress, SSN, Decimal, Digit };
		private Mask m_mask;

		public Mask Masked
		{
			get { return m_mask;}
			set { 
				m_mask = value;
				this.Text="";
			}
		}
		private int digitPos=0;
		private int DelimitNumber=0;

		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.ComponentModel.Container components = null;

		public MaskedTextBox()
		{
			InitializeComponent();
			if(Masked != Mask.None)
				m_mask = Masked;

		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		private void InitializeComponent()
		{
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			// 
			// errorProvider1
			// 
			this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			// 
			// MaskedTextBox
			// 
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);

			this.Leave += new System.EventHandler(this.OnLeave);
		}
		#endregion
		private void OnKeyPress(object sender, KeyPressEventArgs e)
		{
			MaskedTextBox sd = (MaskedTextBox) sender;
			switch(m_mask)
			{
				case Mask.DateOnly:
					sd.MaskDate(e);
					break;
				case Mask.PhoneWithArea:
					sd.MaskPhoneSSN(e, 3, 3);
					break;
				case Mask.IpAddress:
					sd.MaskIpAddr(e);
					break;
				case Mask.SSN:
					sd.MaskPhoneSSN(e, 3, 2);
					break;
				case Mask.Decimal:
					sd.MaskDecimal(e);
					break;
				case Mask.Digit:
					sd.MaskDigit(e);
					break;
			}
		}
		private void OnLeave(object sender, EventArgs e)
		{
			MaskedTextBox sd = (MaskedTextBox) sender;
			Regex regStr;
			switch(m_mask)
			{
				case Mask.DateOnly:
					regStr = new Regex(@"\d{2}/\d{2}/\d{4}");
					if(!regStr.IsMatch(sd.Text))
						errorProvider1.SetError(this, "Date is not valid; mm/dd/yyyy");
					break;
				case Mask.PhoneWithArea:
					regStr = new Regex(@"\d{3}-\d{3}-\d{4}");
					if(!regStr.IsMatch(sd.Text))
						errorProvider1.SetError(this, "Phone number is not valid; xxx-xxx-xxxx");
					break;
				case Mask.IpAddress:
					short cnt=0;
					int len = sd.Text.Length;
					for(short i=0; i<len;i++)
						if(sd.Text[i] == '.')
						{
							cnt++;
							if(i+1 < len)
								if(sd.Text[i+1] == '.')
								{
									errorProvider1.SetError(this, "IP Address is not valid; x??.x??.x??.x??");
									break;
								}
						}
					if(cnt < 3 || sd.Text[len-1] == '.')
						errorProvider1.SetError(this, "IP Address is not valid; x??.x??.x??.x??");
					break;
				case Mask.SSN:
					regStr = new Regex(@"\d{3}-\d{2}-\d{4}");
					if(!regStr.IsMatch(sd.Text))
						errorProvider1.SetError(this, "SSN is not valid; xxx-xx-xxxx");
					break;
				case Mask.Decimal:
					break;
				case Mask.Digit:
					break;
			}
		}
		private void MaskDigit(KeyPressEventArgs e)
		{
			if(Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
			{
				errorProvider1.SetError(this, "");
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
				errorProvider1.SetError(this, "Only valid for Digit");
			}
		}
		private void MaskDecimal(KeyPressEventArgs e)
		{
			if(Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8)
			{
				e.Handled = false;
				errorProvider1.SetError(this, "");
			}
			else
			{
				e.Handled = true;
				errorProvider1.SetError(this, "Only valid for Digit and dot");
			}
		}
		private void MaskDate(KeyPressEventArgs e)
		{
			int len = this.Text.Length;
			int indx = this.Text.LastIndexOf("/");
			// if test is highlighted reset vars
			if(this.SelectedText == this.Text) 
			{
				indx=-1;
				digitPos=0;
				DelimitNumber=0;
				this.Text=null;
			}
			if(Char.IsDigit(e.KeyChar) || e.KeyChar == '/' || e.KeyChar == 8)
			{ 
				string tmp = this.Text;
				if (e.KeyChar != 8)
				{
					if (e.KeyChar != '/' )
					{
						if(indx > 0)
							digitPos = len-indx;
						else
							digitPos++;

						if (digitPos == 3 && DelimitNumber < 2)
						{
							if (e.KeyChar != '/')
							{
								DelimitNumber++;
								this.AppendText("/");
							}
						}

						errorProvider1.SetError(this, "");
						if( (digitPos == 2 || (Int32.Parse(e.KeyChar.ToString())>1 && DelimitNumber ==0) ))
						{
							string tmp2;
							if(indx == -1)
								tmp2= e.KeyChar.ToString();
							else
								tmp2 = this.Text.Substring(indx+1)+e.KeyChar.ToString();
							
							if(DelimitNumber < 2)
							{
								if(digitPos==1) this.AppendText("0");
								this.AppendText(e.KeyChar.ToString());
								if(indx <0)
								{
									if(Int32.Parse(this.Text)> 12) // check validation
									{
										string str;
										str = this.Text.Insert(0, "0");
										if(Int32.Parse(this.Text)>13)
										{
											this.Text =str.Insert(2, "/0");
											DelimitNumber++;
											this.AppendText("/");
										}
										else
										{
											this.Text =str.Insert(2, "/");
											this.AppendText("");
										}
										DelimitNumber++;
									}
									else
									{
										this.AppendText("/");
										DelimitNumber++;
									}
									e.Handled=true;
								}
								else
								{
									if( DelimitNumber == 1)
									{
										int m = Int32.Parse(this.Text.Substring(0,indx));
										if(!CheckDayOfMonth(m, Int32.Parse(tmp2)))
											errorProvider1.SetError(this, "Make sure this month have the day");
										else
										{
											this.AppendText("/");
											DelimitNumber++;
											e.Handled=true;
										}
									}
								}
							}
						}
						else if(digitPos == 1 && Int32.Parse(e.KeyChar.ToString())>3 && DelimitNumber<2)
						{
							if(digitPos==1) this.AppendText("0");
							this.AppendText(e.KeyChar.ToString());
							this.AppendText("/");
							DelimitNumber++;
							e.Handled = true;
						}
						else 
						{
							if(digitPos == 1 && DelimitNumber==2 && e.KeyChar > '2')
								errorProvider1.SetError(this, "The year should start with 1 or 2");
						}
						if(	digitPos > 4)
							e.Handled = true;
					}
					else
					{
						DelimitNumber++;
						string tmp3;
						if(indx == -1)
							tmp3 = this.Text.Substring(indx+1);
						else
							tmp3 = this.Text;
						if(digitPos == 1)
						{
							this.Text = tmp3.Insert(indx+1,"0");;
							this.AppendText("/");
							e.Handled = true;
						}
					}
				}
				else
				{
					e.Handled = false;
					if((len-indx) == 1)
					{
						DelimitNumber--;
						if (indx > -1 )
							digitPos = 2;
						else
							digitPos--;
					}
					else 
					{
						if(indx > -1)
							digitPos=len-indx-1;
						else
							digitPos=len-1;
					}
				}
			}
			else
			{
				e.Handled = true;
				errorProvider1.SetError(this, "Only valid for Digit and /");
			}
		}
		private void MaskPhoneSSN(KeyPressEventArgs e, int pos, int pos2)
		{
			int len = this.Text.Length;
			int indx = this.Text.LastIndexOf("-");
			// if test is highlighted reset vars
			if(this.SelectedText == this.Text) 
			{
				indx=-1;
				digitPos=0;
				DelimitNumber=0;
			}
			if(Char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == 8)
			{ // only digit, Backspace and - are accepted
				string tmp = this.Text;
				if (e.KeyChar != 8)
				{
					errorProvider1.SetError(this, "");
					if (e.KeyChar != '-' )
					{
						if(indx > 0)
							digitPos = len-indx;
						else
							digitPos++;
					}
					if(indx > -1 && digitPos == pos2 && DelimitNumber == 1)
					{
						if (e.KeyChar != '-')
						{
							this.AppendText(e.KeyChar.ToString());
							this.AppendText("-");
							e.Handled = true;
							DelimitNumber++;
						}
					}
					if (digitPos == pos && DelimitNumber == 0)
					{
						if (e.KeyChar != '-')
						{
							this.AppendText(e.KeyChar.ToString());
							this.AppendText("-");
							e.Handled = true;
							DelimitNumber++;
						}
					}
					if(digitPos > 4)
						e.Handled = true;
				}
				else
				{
					e.Handled = false;
					if((len-indx) == 1)
					{
						DelimitNumber--;
						if ((indx) > -1 )
							digitPos = len-indx;
						else
							digitPos--;
					}
					else 
					{
						if(indx > -1)
							digitPos=len-indx-1;
						else
							digitPos=len-1;
					}
				}
			}
			else
			{
				e.Handled = true;
				errorProvider1.SetError(this, "Only valid for Digit and -");
			}
		}
		private void MaskIpAddr(KeyPressEventArgs e)
		{
			int len = this.Text.Length;
			int indx = this.Text.LastIndexOf(".");
			// if test is highlighted reset vars
			if(this.SelectedText == this.Text) 
			{
				indx=-1;
				digitPos=0;
				DelimitNumber=0;
			}
			if(Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8)
			{ // only digit, Backspace and dot are accepted
				string tmp = this.Text;
				errorProvider1.SetError(this, "");
				if (e.KeyChar != 8)
				{
					if (e.KeyChar != '.' )
					{
						if(indx > 0)
							digitPos = len-indx;
						else
							digitPos++;	
						if(digitPos == 3 )
						{
							string tmp2 = this.Text.Substring(indx+1)+e.KeyChar;
							if(Int32.Parse(tmp2)> 255) // check validation
								errorProvider1.SetError(this,"The number can't be bigger than 255");
							else
							{
								if (DelimitNumber<3)
								{
									this.AppendText(e.KeyChar.ToString());
									this.AppendText(".");
									DelimitNumber++;
									e.Handled = true;
								}
							}
						}
						if (digitPos == 4)
						{
							if(DelimitNumber<3)
							{
								this.AppendText(".");
								DelimitNumber++;
							}
							else
								e.Handled = true;
						}
					}
					else
					{   // added - MAC
						// process the "."
						if (DelimitNumber + 1 > 3) // cant have more than 3 dots (at least for IPv4)
						{
							errorProvider1.SetError(this, "No more . please!");
							e.Handled = true; // dont add 4th dot
							this.Text.TrimEnd(e.KeyChar); 
						}
						else
						{	// got the right number, but don't allow two in a row
							if (this.Text.EndsWith("."))
							{
								errorProvider1.SetError(this, "Can't do two dots in a row");
								e.Handled = true;
							}
							else
							{	// ok, add the dot
								DelimitNumber++;
							}
						}
					}
				}
				else
				{
					e.Handled = false;
					if((len-indx) == 1)
					{
						DelimitNumber--;
						if (indx > -1 )
						{
							digitPos = len-indx;
						}
						else
							digitPos--;
					}
					else 
					{
						if(indx > -1)
							digitPos=len-indx-1;
						else
							digitPos=len-1;
					}
				}
			}
			else
			{
				e.Handled = true;
				errorProvider1.SetError(this, "Only valid for Digit abd dot");
			}
		}
		private bool CheckDayOfMonth(int mon, int day)
		{
			bool ret=true;
			if(day==0) ret=false;
			switch(mon)
			{
				case 1:
					if(day > 31 )
						ret=false;
					break;
				case 2:
					System.DateTime moment = DateTime.Now;
					int year = moment.Year;
					int d = ((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0) ) ) ? 29 : 28 ;
					if(day > d)
						ret=false;
					break;
				case 3:
					if(day > 31 )
						ret=false;
					break;
				case 4: 
					if(day > 30 )
						ret=false;
					break;
				case 5:
					if(day > 31 )
						ret=false;
					break;
				case 6:
					if(day > 30 )
						ret=false;
					break;
				case 7:
					if(day > 31 )
						ret=false;
					break;
				case 8:
					if(day > 31 )
						ret=false;
					break;
				case 9:
					if(day > 30 )
						ret=false;
					break;
				case 10:
					if(day > 31 )
						ret=false;
					break;
				case 11:
					if(day > 30 )
						ret=false;
					break;
				case 12:
					if(day > 31 )
						ret=false;
					break;
				default:
					ret=false;
					break;
			}
			return ret;
		}
	}
}
