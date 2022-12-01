using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

// Author: Collin Fluke
// IGME 201 - Exam 3 Question 2
// Purpose: Presidential Guessing Game

// Known Issues:
//     Timer doesn't start when textbox is first edited, instead starts as soon as form opens
//     YouTube video of Fireworks doesn't appear when all answers are correct
//     Exit button isn't greyed out until completion (tied to the youtube video completion issue above)
//     Hyperlinks on Wikipedia pages don't say "Professor Schuh for President!" when hovered

namespace Fluke_Exam4_Q2
{
    public partial class Form1 : Form
    {
        bool checkIfDone = false;

        public Form1()
        {
            InitializeComponent();

            this.exitButton.Click += new EventHandler(ExitButton__Click);

            this.pictureBox1.MouseHover += new EventHandler(PictureBox__MouseHover);
            this.pictureBox1.MouseLeave += new EventHandler(PictureBox__MouseLeave);

            this.filterAll.Click += new EventHandler(FilterAll__Click);
            this.filterDemocrat.Click += new EventHandler(FilterDemocrat__Click);
            this.filterRepublican.Click += new EventHandler(FilterRepublican__Click);
            this.filterDemocraticRepublican.Click += new EventHandler(FilterDemocraticRepublican__Click);
            this.filterFederalist.Click += new EventHandler(FilterFederalist__Click);

            this.radioBenjaminHarrison.Click += new EventHandler(RadioBenjaminHarrison__Click);
            this.radioFranklinDRoosevelt.Click += new EventHandler(RadioFranklinDRoosevelt__Click);
            this.radioWilliamJClinton.Click += new EventHandler(RadioWilliamJClinton__Click);
            this.radioJamesBuchanan.Click += new EventHandler(RadioJamesBuchanan__Click);
            this.radioFranklinPierce.Click += new EventHandler(RadioFranklinPierce__Click);
            this.radioGeorgeWBush.Click += new EventHandler(RadioGeorgeWBush__Click);
            this.radioBarackObama.Click += new EventHandler(RadioBarackObama__Click);
            this.radioJohnFKennedy.Click += new EventHandler(RadioJohnFKennedy__Click);
            this.radioWilliamMcKinley.Click += new EventHandler(RadioWilliamMcKinley__Click);
            this.radioRonaldReagan.Click += new EventHandler(RadioRonaldReagan__Click);
            this.radioDwightDEisenhower.Click += new EventHandler(RadioDwightDEisenhower__Click);
            this.radioMartinVanBuren.Click += new EventHandler(RadioMartinVanBuren__Click);
            this.radioGeorgeWashington.Click += new EventHandler(RadioGeorgeWashington__Click);
            this.radioJohnAdams.Click += new EventHandler(RadioJohnAdams__Click);
            this.radioTheodoreRoosevelt.Click += new EventHandler(RadioTheodoreRoosevelt__Click);
            this.radioThomasJefferson.Click += new EventHandler(RadioThomasJefferson__Click);

            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;

            // I don't why the timer works as it is but if I try to change it then it doesn't work
            // The current issue is that it starts as soon as the form opens instead on a textbox changing
            // This is the best I could get it, and it goes for two minutes as per my phone's stopwatch
            // I know it's not what it's supposed to be, but if I try to do something different it either doesn't work or makes it worse
            // This took more than 8 hours as it is, and I need to work on question 3 so at this point it is what it is
            this.timer1.Tick += new EventHandler(TextBox__TextChanged);

            this.textBenjaminHarrison.Validating += new CancelEventHandler(TextBox__Validating0);
            this.textFranklinDRoosevelt.Validating += new CancelEventHandler(TextBox__Validating1);
            this.textWilliamJClinton.Validating += new CancelEventHandler(TextBox__Validating2);
            this.textJamesBuchanan.Validating += new CancelEventHandler(TextBox__Validating3);
            this.textFranklinPierce.Validating += new CancelEventHandler(TextBox__Validating4);
            this.textGeorgeWBush.Validating += new CancelEventHandler(TextBox__Validating5);
            this.textBarackObama.Validating += new CancelEventHandler(TextBox__Validating6);
            this.textJohnFKennedy.Validating += new CancelEventHandler(TextBox__Validating7);
            this.textWilliamMcKinley.Validating += new CancelEventHandler(TextBox__Validating8);
            this.textRonaldReagan.Validating += new CancelEventHandler(TextBox__Validating9);
            this.textDwightDEisenhower.Validating += new CancelEventHandler(TextBox__Validating10);
            this.textMartinVanBurren.Validating += new CancelEventHandler(TextBox__Validating11);
            this.textGeorgeWashington.Validating += new CancelEventHandler(TextBox__Validating12);
            this.textJohnAdams.Validating += new CancelEventHandler(TextBox__Validating13);
            this.textTheodoreRoosevelt.Validating += new CancelEventHandler(TextBox__Validating14);
            this.textThomasJefferson.Validating += new CancelEventHandler(TextBox__Validating15);

            foreach (Control textbox in this.Controls)
            {
                if (textbox.GetType() == typeof(TextBox))
                {
                    textbox.MouseHover += new EventHandler(TextBox_MouseHover);
                }
            }

            if (checkIfDone == true)
            {
                webBrowser.Navigate("https://www.youtube.com/embed/18212B4yfLg?autoplay=1");
            }
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox__MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Width = 300;
            pictureBox1.Height = 430;
        }

        private void PictureBox__MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Width = 150;
            pictureBox1.Height = 215;
        }

        private void FilterAll__Click(object sender, EventArgs e)
        {
            foreach (Control radio in this.Controls)
            {
                if (radio.GetType() == typeof(RadioButton))
                {
                    radio.Show();
                }
            }
            radioBenjaminHarrison.Select();
        }

        private void FilterDemocrat__Click(object sender, EventArgs e)
        {
            foreach (Control radio in this.Controls)
            {
                if (radio.GetType() == typeof(RadioButton))
                {
                    var tag = radio.Tag.ToString();
                    if (tag == "democrat")
                    {
                        radio.Show();
                    }
                    else
                    {
                        radio.Hide();
                    }
                }
            }
            radioFranklinDRoosevelt.Select();
        }

        private void FilterRepublican__Click(object sender, EventArgs e)
        {
            foreach (Control radio in this.Controls)
            {
                if (radio.GetType() == typeof(RadioButton))
                {
                    var tag = radio.Tag.ToString();
                    if (tag == "republican")
                    {
                        radio.Show();
                    }
                    else
                    {
                        radio.Hide();
                    }
                }
            }
            radioBenjaminHarrison.Select();
        }

        private void FilterDemocraticRepublican__Click(object sender, EventArgs e)
        {
            foreach (Control radio in this.Controls)
            {
                if (radio.GetType() == typeof(RadioButton))
                {
                    var tag = radio.Tag.ToString();
                    if (tag == "democratic-republican")
                    {
                        radio.Show();
                    }
                    else
                    {
                        radio.Hide();
                    }
                }
            }
            radioThomasJefferson.Select();
        }

        private void FilterFederalist__Click(object sender, EventArgs e)
        {
            foreach (Control radio in this.Controls)
            {
                if (radio.GetType() == typeof(RadioButton))
                {
                    var tag = radio.Tag.ToString();
                    if (tag == "federalist")
                    {
                        radio.Show();
                    }
                    else
                    {
                        radio.Hide();
                    }
                }
            }
            radioGeorgeWashington.Select();
        }

        private void TextBox__TextChanged(object sender, EventArgs e)
        {
            this.timer1.Start();
            
            toolStripProgressBar1.Value--;
            if (toolStripProgressBar1.Value-- <= 1)
            {
                toolStripProgressBar1.Value += 120;
                this.timer1.Stop();

                // I tried textBox.Clear(); and it didn't work so now I have to go through each one
                textBenjaminHarrison.Clear();
                textFranklinDRoosevelt.Clear();
                textWilliamJClinton.Clear();
                textJamesBuchanan.Clear();
                textFranklinPierce.Clear();
                textGeorgeWBush.Clear();
                textBarackObama.Clear();
                textJohnFKennedy.Clear();
                textWilliamMcKinley.Clear();
                textRonaldReagan.Clear();
                textDwightDEisenhower.Clear();
                textMartinVanBurren.Clear();
                textGeorgeWashington.Clear();
                textJohnAdams.Clear();
                textTheodoreRoosevelt.Clear();
                textThomasJefferson.Clear();
                foreach (Control textBox in this.Controls)
                {
                    if (textBox.GetType() == typeof(System.Windows.Forms.TextBox))
                    {
                        textBox.Text += 0;
                    }
                }
            }
        }

        private void TextBox_MouseHover(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            toolTip1.SetToolTip(textBox, "Which # President?");
        }

        private void TextBox__Validating0(object sender, CancelEventArgs e)
        {
            if (textBenjaminHarrison.Text != "23")
            {
                this.errorProvider1.SetError(textBenjaminHarrison, "That is the wrong number");
                checkIfDone = false;
            } else
            {
                this.errorProvider1.SetError(textBenjaminHarrison, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating1(object sender, CancelEventArgs e)
        {
            if (textFranklinDRoosevelt.Text != "32")
            {
                this.errorProvider1.SetError(textFranklinDRoosevelt, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textFranklinDRoosevelt, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating2(object sender, CancelEventArgs e)
        {
            if (textWilliamJClinton.Text != "42")
            {
                this.errorProvider1.SetError(textWilliamJClinton, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textWilliamJClinton, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating3(object sender, CancelEventArgs e)
        {
            if (textJamesBuchanan.Text != "15")
            {
                this.errorProvider1.SetError(textJamesBuchanan, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textJamesBuchanan, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating4(object sender, CancelEventArgs e)
        {
            if (textFranklinPierce.Text != "14")
            {
                this.errorProvider1.SetError(textFranklinPierce, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textFranklinPierce, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating5(object sender, CancelEventArgs e)
        {
            if (textGeorgeWBush.Text != "43")
            {
                this.errorProvider1.SetError(textGeorgeWBush, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textGeorgeWBush, null);
                checkIfDone = true;
            }            
        }

        private void TextBox__Validating6(object sender, CancelEventArgs e)
        {
            if (textBarackObama.Text != "44")
            {
                this.errorProvider1.SetError(textBarackObama, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textBarackObama, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating7(object sender, CancelEventArgs e)
        {
            if (textJohnFKennedy.Text != "35")
            {
                this.errorProvider1.SetError(textJohnFKennedy, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textJohnFKennedy, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating8(object sender, CancelEventArgs e)
        {
            if (textWilliamMcKinley.Text != "25")
            {
                this.errorProvider1.SetError(textWilliamMcKinley, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textWilliamMcKinley, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating9(object sender, CancelEventArgs e)
        {
            if (textRonaldReagan.Text != "40")
            {
                this.errorProvider1.SetError(textRonaldReagan, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textRonaldReagan, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating10(object sender, CancelEventArgs e)
        {
            if (textDwightDEisenhower.Text != "34")
            {
                this.errorProvider1.SetError(textDwightDEisenhower, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textDwightDEisenhower, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating11(object sender, CancelEventArgs e)
        {
            if (textMartinVanBurren.Text != "8")
            {
                this.errorProvider1.SetError(textMartinVanBurren, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textMartinVanBurren, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating12(object sender, CancelEventArgs e)
        {
            if (textGeorgeWashington.Text != "1")
            {
                this.errorProvider1.SetError(textGeorgeWashington, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textGeorgeWashington, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating13(object sender, CancelEventArgs e)
        {
            if (textJohnAdams.Text != "2")
            {
                this.errorProvider1.SetError(textJohnAdams, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textJohnAdams, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating14(object sender, CancelEventArgs e)
        {
            if (textTheodoreRoosevelt.Text != "26")
            {
                this.errorProvider1.SetError(textTheodoreRoosevelt, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textTheodoreRoosevelt, null);
                checkIfDone = true;
            }
        }

        private void TextBox__Validating15(object sender, CancelEventArgs e)
        {
            if (textThomasJefferson.Text != "3")
            {
                this.errorProvider1.SetError(textThomasJefferson, "That is the wrong number");
                checkIfDone = false;
            }
            else
            {
                this.errorProvider1.SetError(textThomasJefferson, null);
                checkIfDone = true;
            }
        }

        private void RadioBenjaminHarrison__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Benjamin_Harrison");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.BenjaminHarrison;
        }
        private void RadioFranklinDRoosevelt__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Franklin_D._Roosevelt");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.FranklinDRoosevelt;
        }
        private void RadioWilliamJClinton__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Bill_Clinton");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.WilliamJClinton;
        }
        private void RadioJamesBuchanan__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/James_Buchanan");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.JamesBuchanan;
        }
        private void RadioFranklinPierce__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Franklin_Pierce");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.FranklinPierce;
        }
        private void RadioGeorgeWBush__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/George_W._Bush");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.GeorgeWBush;
        }
        private void RadioBarackObama__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Barack_Obama");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.BarackObama;
        }
        private void RadioJohnFKennedy__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/John_F._Kennedy");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.JohnFKennedy;
        }
        private void RadioWilliamMcKinley__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/William_McKinley");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.WilliamMcKinley;
        }
        private void RadioRonaldReagan__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Ronald_Reagan");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.RonaldReagan;
        }
        private void RadioDwightDEisenhower__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Dwight_D._Eisenhower");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.DwightDEisenhower;
        }
        private void RadioMartinVanBuren__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Martin_Van_Buren");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.MartinVanBuren;
        }
        private void RadioGeorgeWashington__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/George_Washington");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.GeorgeWashington;
        }
        private void RadioJohnAdams__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/John_Adams");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.JohnAdams;
        }
        private void RadioTheodoreRoosevelt__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Theodore_Roosevelt");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.TheodoreRoosevelt;
        }
        private void RadioThomasJefferson__Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://en.m.wikipedia.org/wiki/Thomas_Jefferson");
            pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.ThomasJefferson;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radioBenjaminHarrison = new System.Windows.Forms.RadioButton();
            this.radioFranklinDRoosevelt = new System.Windows.Forms.RadioButton();
            this.radioWilliamJClinton = new System.Windows.Forms.RadioButton();
            this.radioJamesBuchanan = new System.Windows.Forms.RadioButton();
            this.radioJohnFKennedy = new System.Windows.Forms.RadioButton();
            this.radioBarackObama = new System.Windows.Forms.RadioButton();
            this.radioGeorgeWBush = new System.Windows.Forms.RadioButton();
            this.radioFranklinPierce = new System.Windows.Forms.RadioButton();
            this.radioThomasJefferson = new System.Windows.Forms.RadioButton();
            this.radioTheodoreRoosevelt = new System.Windows.Forms.RadioButton();
            this.radioJohnAdams = new System.Windows.Forms.RadioButton();
            this.radioGeorgeWashington = new System.Windows.Forms.RadioButton();
            this.radioMartinVanBuren = new System.Windows.Forms.RadioButton();
            this.radioDwightDEisenhower = new System.Windows.Forms.RadioButton();
            this.radioRonaldReagan = new System.Windows.Forms.RadioButton();
            this.radioWilliamMcKinley = new System.Windows.Forms.RadioButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.filterFederalist = new System.Windows.Forms.RadioButton();
            this.filterDemocraticRepublican = new System.Windows.Forms.RadioButton();
            this.filterRepublican = new System.Windows.Forms.RadioButton();
            this.filterDemocrat = new System.Windows.Forms.RadioButton();
            this.filterAll = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.textThomasJefferson = new System.Windows.Forms.TextBox();
            this.textTheodoreRoosevelt = new System.Windows.Forms.TextBox();
            this.textGeorgeWashington = new System.Windows.Forms.TextBox();
            this.textJohnAdams = new System.Windows.Forms.TextBox();
            this.textWilliamMcKinley = new System.Windows.Forms.TextBox();
            this.textRonaldReagan = new System.Windows.Forms.TextBox();
            this.textDwightDEisenhower = new System.Windows.Forms.TextBox();
            this.textMartinVanBurren = new System.Windows.Forms.TextBox();
            this.textBenjaminHarrison = new System.Windows.Forms.TextBox();
            this.textFranklinDRoosevelt = new System.Windows.Forms.TextBox();
            this.textWilliamJClinton = new System.Windows.Forms.TextBox();
            this.textJamesBuchanan = new System.Windows.Forms.TextBox();
            this.textFranklinPierce = new System.Windows.Forms.TextBox();
            this.textGeorgeWBush = new System.Windows.Forms.TextBox();
            this.textBarackObama = new System.Windows.Forms.TextBox();
            this.textJohnFKennedy = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioBenjaminHarrison
            // 
            this.radioBenjaminHarrison.AutoSize = true;
            this.radioBenjaminHarrison.Location = new System.Drawing.Point(13, 13);
            this.radioBenjaminHarrison.Name = "radioBenjaminHarrison";
            this.radioBenjaminHarrison.Size = new System.Drawing.Size(110, 17);
            this.radioBenjaminHarrison.TabIndex = 0;
            this.radioBenjaminHarrison.TabStop = true;
            this.radioBenjaminHarrison.Tag = "republican";
            this.radioBenjaminHarrison.Text = "Benjamin Harrison";
            this.radioBenjaminHarrison.UseVisualStyleBackColor = true;
            // 
            // radioFranklinDRoosevelt
            // 
            this.radioFranklinDRoosevelt.AutoSize = true;
            this.radioFranklinDRoosevelt.Location = new System.Drawing.Point(13, 36);
            this.radioFranklinDRoosevelt.Name = "radioFranklinDRoosevelt";
            this.radioFranklinDRoosevelt.Size = new System.Drawing.Size(124, 17);
            this.radioFranklinDRoosevelt.TabIndex = 1;
            this.radioFranklinDRoosevelt.TabStop = true;
            this.radioFranklinDRoosevelt.Tag = "democrat";
            this.radioFranklinDRoosevelt.Text = "Franklin D Roosevelt";
            this.radioFranklinDRoosevelt.UseVisualStyleBackColor = true;
            // 
            // radioWilliamJClinton
            // 
            this.radioWilliamJClinton.AutoSize = true;
            this.radioWilliamJClinton.Location = new System.Drawing.Point(12, 59);
            this.radioWilliamJClinton.Name = "radioWilliamJClinton";
            this.radioWilliamJClinton.Size = new System.Drawing.Size(101, 17);
            this.radioWilliamJClinton.TabIndex = 2;
            this.radioWilliamJClinton.TabStop = true;
            this.radioWilliamJClinton.Tag = "democrat";
            this.radioWilliamJClinton.Text = "William J Clinton";
            this.radioWilliamJClinton.UseVisualStyleBackColor = true;
            // 
            // radioJamesBuchanan
            // 
            this.radioJamesBuchanan.AutoSize = true;
            this.radioJamesBuchanan.Location = new System.Drawing.Point(13, 82);
            this.radioJamesBuchanan.Name = "radioJamesBuchanan";
            this.radioJamesBuchanan.Size = new System.Drawing.Size(107, 17);
            this.radioJamesBuchanan.TabIndex = 3;
            this.radioJamesBuchanan.TabStop = true;
            this.radioJamesBuchanan.Tag = "democrat";
            this.radioJamesBuchanan.Text = "James Buchanan";
            this.radioJamesBuchanan.UseVisualStyleBackColor = true;
            // 
            // radioJohnFKennedy
            // 
            this.radioJohnFKennedy.AutoSize = true;
            this.radioJohnFKennedy.Location = new System.Drawing.Point(13, 174);
            this.radioJohnFKennedy.Name = "radioJohnFKennedy";
            this.radioJohnFKennedy.Size = new System.Drawing.Size(102, 17);
            this.radioJohnFKennedy.TabIndex = 7;
            this.radioJohnFKennedy.TabStop = true;
            this.radioJohnFKennedy.Tag = "democrat";
            this.radioJohnFKennedy.Text = "John F Kennedy";
            this.radioJohnFKennedy.UseVisualStyleBackColor = true;
            // 
            // radioBarackObama
            // 
            this.radioBarackObama.AutoSize = true;
            this.radioBarackObama.Location = new System.Drawing.Point(12, 151);
            this.radioBarackObama.Name = "radioBarackObama";
            this.radioBarackObama.Size = new System.Drawing.Size(96, 17);
            this.radioBarackObama.TabIndex = 6;
            this.radioBarackObama.TabStop = true;
            this.radioBarackObama.Tag = "democrat";
            this.radioBarackObama.Text = "Barack Obama";
            this.radioBarackObama.UseVisualStyleBackColor = true;
            // 
            // radioGeorgeWBush
            // 
            this.radioGeorgeWBush.AutoSize = true;
            this.radioGeorgeWBush.Location = new System.Drawing.Point(13, 128);
            this.radioGeorgeWBush.Name = "radioGeorgeWBush";
            this.radioGeorgeWBush.Size = new System.Drawing.Size(101, 17);
            this.radioGeorgeWBush.TabIndex = 5;
            this.radioGeorgeWBush.TabStop = true;
            this.radioGeorgeWBush.Tag = "republican";
            this.radioGeorgeWBush.Text = "George W Bush";
            this.radioGeorgeWBush.UseVisualStyleBackColor = true;
            // 
            // radioFranklinPierce
            // 
            this.radioFranklinPierce.AutoSize = true;
            this.radioFranklinPierce.Location = new System.Drawing.Point(13, 105);
            this.radioFranklinPierce.Name = "radioFranklinPierce";
            this.radioFranklinPierce.Size = new System.Drawing.Size(95, 17);
            this.radioFranklinPierce.TabIndex = 4;
            this.radioFranklinPierce.Tag = "democrat";
            this.radioFranklinPierce.Text = "Franklin Pierce";
            this.radioFranklinPierce.UseVisualStyleBackColor = true;
            // 
            // radioThomasJefferson
            // 
            this.radioThomasJefferson.AutoSize = true;
            this.radioThomasJefferson.Location = new System.Drawing.Point(170, 173);
            this.radioThomasJefferson.Name = "radioThomasJefferson";
            this.radioThomasJefferson.Size = new System.Drawing.Size(109, 17);
            this.radioThomasJefferson.TabIndex = 15;
            this.radioThomasJefferson.TabStop = true;
            this.radioThomasJefferson.Tag = "democratic-republican";
            this.radioThomasJefferson.Text = "Thomas Jefferson";
            this.radioThomasJefferson.UseVisualStyleBackColor = true;
            // 
            // radioTheodoreRoosevelt
            // 
            this.radioTheodoreRoosevelt.AutoSize = true;
            this.radioTheodoreRoosevelt.Location = new System.Drawing.Point(169, 150);
            this.radioTheodoreRoosevelt.Name = "radioTheodoreRoosevelt";
            this.radioTheodoreRoosevelt.Size = new System.Drawing.Size(122, 17);
            this.radioTheodoreRoosevelt.TabIndex = 14;
            this.radioTheodoreRoosevelt.TabStop = true;
            this.radioTheodoreRoosevelt.Tag = "republican";
            this.radioTheodoreRoosevelt.Text = "Theodore Roosevelt";
            this.radioTheodoreRoosevelt.UseVisualStyleBackColor = true;
            // 
            // radioJohnAdams
            // 
            this.radioJohnAdams.AutoSize = true;
            this.radioJohnAdams.Location = new System.Drawing.Point(170, 127);
            this.radioJohnAdams.Name = "radioJohnAdams";
            this.radioJohnAdams.Size = new System.Drawing.Size(83, 17);
            this.radioJohnAdams.TabIndex = 13;
            this.radioJohnAdams.TabStop = true;
            this.radioJohnAdams.Tag = "federalist";
            this.radioJohnAdams.Text = "John Adams";
            this.radioJohnAdams.UseVisualStyleBackColor = true;
            // 
            // radioGeorgeWashington
            // 
            this.radioGeorgeWashington.AutoSize = true;
            this.radioGeorgeWashington.Location = new System.Drawing.Point(170, 104);
            this.radioGeorgeWashington.Name = "radioGeorgeWashington";
            this.radioGeorgeWashington.Size = new System.Drawing.Size(120, 17);
            this.radioGeorgeWashington.TabIndex = 12;
            this.radioGeorgeWashington.TabStop = true;
            this.radioGeorgeWashington.Tag = "federalist";
            this.radioGeorgeWashington.Text = "George Washington";
            this.radioGeorgeWashington.UseVisualStyleBackColor = true;
            // 
            // radioMartinVanBuren
            // 
            this.radioMartinVanBuren.AutoSize = true;
            this.radioMartinVanBuren.Location = new System.Drawing.Point(170, 81);
            this.radioMartinVanBuren.Name = "radioMartinVanBuren";
            this.radioMartinVanBuren.Size = new System.Drawing.Size(104, 17);
            this.radioMartinVanBuren.TabIndex = 11;
            this.radioMartinVanBuren.TabStop = true;
            this.radioMartinVanBuren.Tag = "democrat";
            this.radioMartinVanBuren.Text = "Martin VanBuren";
            this.radioMartinVanBuren.UseVisualStyleBackColor = true;
            // 
            // radioDwightDEisenhower
            // 
            this.radioDwightDEisenhower.AutoSize = true;
            this.radioDwightDEisenhower.Location = new System.Drawing.Point(169, 58);
            this.radioDwightDEisenhower.Name = "radioDwightDEisenhower";
            this.radioDwightDEisenhower.Size = new System.Drawing.Size(127, 17);
            this.radioDwightDEisenhower.TabIndex = 10;
            this.radioDwightDEisenhower.TabStop = true;
            this.radioDwightDEisenhower.Tag = "republican";
            this.radioDwightDEisenhower.Text = "Dwight D Eisenhower";
            this.radioDwightDEisenhower.UseVisualStyleBackColor = true;
            // 
            // radioRonaldReagan
            // 
            this.radioRonaldReagan.AutoSize = true;
            this.radioRonaldReagan.Location = new System.Drawing.Point(170, 35);
            this.radioRonaldReagan.Name = "radioRonaldReagan";
            this.radioRonaldReagan.Size = new System.Drawing.Size(100, 17);
            this.radioRonaldReagan.TabIndex = 9;
            this.radioRonaldReagan.TabStop = true;
            this.radioRonaldReagan.Tag = "republican";
            this.radioRonaldReagan.Text = "Ronald Reagan";
            this.radioRonaldReagan.UseVisualStyleBackColor = true;
            // 
            // radioWilliamMcKinley
            // 
            this.radioWilliamMcKinley.AutoSize = true;
            this.radioWilliamMcKinley.Location = new System.Drawing.Point(170, 12);
            this.radioWilliamMcKinley.Name = "radioWilliamMcKinley";
            this.radioWilliamMcKinley.Size = new System.Drawing.Size(104, 17);
            this.radioWilliamMcKinley.TabIndex = 8;
            this.radioWilliamMcKinley.TabStop = true;
            this.radioWilliamMcKinley.Tag = "republican";
            this.radioWilliamMcKinley.Text = "William McKinley";
            this.radioWilliamMcKinley.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(6, 19);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(587, 527);
            this.webBrowser.TabIndex = 16;
            this.webBrowser.Url = new System.Uri("https://en.m.wikipedia.org/wiki/Benjamin_Harrison", System.UriKind.Absolute);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.filterFederalist);
            this.groupBoxFilter.Controls.Add(this.filterDemocraticRepublican);
            this.groupBoxFilter.Controls.Add(this.filterRepublican);
            this.groupBoxFilter.Controls.Add(this.filterDemocrat);
            this.groupBoxFilter.Controls.Add(this.filterAll);
            this.groupBoxFilter.Location = new System.Drawing.Point(170, 203);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(175, 140);
            this.groupBoxFilter.TabIndex = 17;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // filterFederalist
            // 
            this.filterFederalist.AutoSize = true;
            this.filterFederalist.Location = new System.Drawing.Point(6, 111);
            this.filterFederalist.Name = "filterFederalist";
            this.filterFederalist.Size = new System.Drawing.Size(70, 17);
            this.filterFederalist.TabIndex = 22;
            this.filterFederalist.TabStop = true;
            this.filterFederalist.Text = "Federalist";
            this.filterFederalist.UseVisualStyleBackColor = true;
            // 
            // filterDemocraticRepublican
            // 
            this.filterDemocraticRepublican.AutoSize = true;
            this.filterDemocraticRepublican.Location = new System.Drawing.Point(6, 88);
            this.filterDemocraticRepublican.Name = "filterDemocraticRepublican";
            this.filterDemocraticRepublican.Size = new System.Drawing.Size(136, 17);
            this.filterDemocraticRepublican.TabIndex = 21;
            this.filterDemocraticRepublican.TabStop = true;
            this.filterDemocraticRepublican.Text = "Democratic-Republican";
            this.filterDemocraticRepublican.UseVisualStyleBackColor = true;
            // 
            // filterRepublican
            // 
            this.filterRepublican.AutoSize = true;
            this.filterRepublican.Location = new System.Drawing.Point(6, 65);
            this.filterRepublican.Name = "filterRepublican";
            this.filterRepublican.Size = new System.Drawing.Size(79, 17);
            this.filterRepublican.TabIndex = 20;
            this.filterRepublican.TabStop = true;
            this.filterRepublican.Text = "Republican";
            this.filterRepublican.UseVisualStyleBackColor = true;
            // 
            // filterDemocrat
            // 
            this.filterDemocrat.AutoSize = true;
            this.filterDemocrat.Location = new System.Drawing.Point(6, 42);
            this.filterDemocrat.Name = "filterDemocrat";
            this.filterDemocrat.Size = new System.Drawing.Size(71, 17);
            this.filterDemocrat.TabIndex = 19;
            this.filterDemocrat.TabStop = true;
            this.filterDemocrat.Text = "Democrat";
            this.filterDemocrat.UseVisualStyleBackColor = true;
            // 
            // filterAll
            // 
            this.filterAll.AutoSize = true;
            this.filterAll.Location = new System.Drawing.Point(6, 19);
            this.filterAll.Name = "filterAll";
            this.filterAll.Size = new System.Drawing.Size(36, 17);
            this.filterAll.TabIndex = 18;
            this.filterAll.TabStop = true;
            this.filterAll.Text = "All";
            this.filterAll.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fluke_Exam4_Q2.Properties.Resources.BenjaminHarrison;
            this.pictureBox1.Location = new System.Drawing.Point(10, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(882, 577);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 20;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // textThomasJefferson
            // 
            this.textThomasJefferson.Location = new System.Drawing.Point(317, 174);
            this.textThomasJefferson.Name = "textThomasJefferson";
            this.textThomasJefferson.Size = new System.Drawing.Size(27, 20);
            this.textThomasJefferson.TabIndex = 21;
            this.textThomasJefferson.Tag = "democratic-republican";
            this.textThomasJefferson.Text = "0";
            // 
            // textTheodoreRoosevelt
            // 
            this.textTheodoreRoosevelt.Location = new System.Drawing.Point(317, 150);
            this.textTheodoreRoosevelt.Name = "textTheodoreRoosevelt";
            this.textTheodoreRoosevelt.Size = new System.Drawing.Size(27, 20);
            this.textTheodoreRoosevelt.TabIndex = 22;
            this.textTheodoreRoosevelt.Tag = "republican";
            this.textTheodoreRoosevelt.Text = "0";
            // 
            // textGeorgeWashington
            // 
            this.textGeorgeWashington.Location = new System.Drawing.Point(317, 103);
            this.textGeorgeWashington.Name = "textGeorgeWashington";
            this.textGeorgeWashington.Size = new System.Drawing.Size(27, 20);
            this.textGeorgeWashington.TabIndex = 24;
            this.textGeorgeWashington.Tag = "federalist";
            this.textGeorgeWashington.Text = "0";
            // 
            // textJohnAdams
            // 
            this.textJohnAdams.Location = new System.Drawing.Point(317, 126);
            this.textJohnAdams.Name = "textJohnAdams";
            this.textJohnAdams.Size = new System.Drawing.Size(27, 20);
            this.textJohnAdams.TabIndex = 23;
            this.textJohnAdams.Tag = "federalist";
            this.textJohnAdams.Text = "0";
            // 
            // textWilliamMcKinley
            // 
            this.textWilliamMcKinley.Location = new System.Drawing.Point(317, 10);
            this.textWilliamMcKinley.Name = "textWilliamMcKinley";
            this.textWilliamMcKinley.Size = new System.Drawing.Size(27, 20);
            this.textWilliamMcKinley.TabIndex = 28;
            this.textWilliamMcKinley.Tag = "republican";
            this.textWilliamMcKinley.Text = "0";
            // 
            // textRonaldReagan
            // 
            this.textRonaldReagan.Location = new System.Drawing.Point(317, 33);
            this.textRonaldReagan.Name = "textRonaldReagan";
            this.textRonaldReagan.Size = new System.Drawing.Size(27, 20);
            this.textRonaldReagan.TabIndex = 27;
            this.textRonaldReagan.Tag = "republican";
            this.textRonaldReagan.Text = "0";
            // 
            // textDwightDEisenhower
            // 
            this.textDwightDEisenhower.Location = new System.Drawing.Point(317, 57);
            this.textDwightDEisenhower.Name = "textDwightDEisenhower";
            this.textDwightDEisenhower.Size = new System.Drawing.Size(27, 20);
            this.textDwightDEisenhower.TabIndex = 26;
            this.textDwightDEisenhower.Tag = "republican";
            this.textDwightDEisenhower.Text = "0";
            // 
            // textMartinVanBurren
            // 
            this.textMartinVanBurren.Location = new System.Drawing.Point(317, 80);
            this.textMartinVanBurren.Name = "textMartinVanBurren";
            this.textMartinVanBurren.Size = new System.Drawing.Size(27, 20);
            this.textMartinVanBurren.TabIndex = 25;
            this.textMartinVanBurren.Tag = "democrat";
            this.textMartinVanBurren.Text = "0";
            // 
            // textBenjaminHarrison
            // 
            this.textBenjaminHarrison.Location = new System.Drawing.Point(137, 11);
            this.textBenjaminHarrison.Name = "textBenjaminHarrison";
            this.textBenjaminHarrison.Size = new System.Drawing.Size(27, 20);
            this.textBenjaminHarrison.TabIndex = 36;
            this.textBenjaminHarrison.Tag = "republican";
            this.textBenjaminHarrison.Text = "0";
            // 
            // textFranklinDRoosevelt
            // 
            this.textFranklinDRoosevelt.Location = new System.Drawing.Point(137, 34);
            this.textFranklinDRoosevelt.Name = "textFranklinDRoosevelt";
            this.textFranklinDRoosevelt.Size = new System.Drawing.Size(27, 20);
            this.textFranklinDRoosevelt.TabIndex = 35;
            this.textFranklinDRoosevelt.Tag = "democrat";
            this.textFranklinDRoosevelt.Text = "0";
            // 
            // textWilliamJClinton
            // 
            this.textWilliamJClinton.Location = new System.Drawing.Point(137, 58);
            this.textWilliamJClinton.Name = "textWilliamJClinton";
            this.textWilliamJClinton.Size = new System.Drawing.Size(27, 20);
            this.textWilliamJClinton.TabIndex = 34;
            this.textWilliamJClinton.Tag = "democrat";
            this.textWilliamJClinton.Text = "0";
            // 
            // textJamesBuchanan
            // 
            this.textJamesBuchanan.Location = new System.Drawing.Point(137, 81);
            this.textJamesBuchanan.Name = "textJamesBuchanan";
            this.textJamesBuchanan.Size = new System.Drawing.Size(27, 20);
            this.textJamesBuchanan.TabIndex = 33;
            this.textJamesBuchanan.Tag = "democrat";
            this.textJamesBuchanan.Text = "0";
            // 
            // textFranklinPierce
            // 
            this.textFranklinPierce.Location = new System.Drawing.Point(137, 104);
            this.textFranklinPierce.Name = "textFranklinPierce";
            this.textFranklinPierce.Size = new System.Drawing.Size(27, 20);
            this.textFranklinPierce.TabIndex = 32;
            this.textFranklinPierce.Tag = "democrat";
            this.textFranklinPierce.Text = "0";
            // 
            // textGeorgeWBush
            // 
            this.textGeorgeWBush.Location = new System.Drawing.Point(137, 127);
            this.textGeorgeWBush.Name = "textGeorgeWBush";
            this.textGeorgeWBush.Size = new System.Drawing.Size(27, 20);
            this.textGeorgeWBush.TabIndex = 31;
            this.textGeorgeWBush.Tag = "republican";
            this.textGeorgeWBush.Text = "0";
            // 
            // textBarackObama
            // 
            this.textBarackObama.Location = new System.Drawing.Point(137, 151);
            this.textBarackObama.Name = "textBarackObama";
            this.textBarackObama.Size = new System.Drawing.Size(27, 20);
            this.textBarackObama.TabIndex = 30;
            this.textBarackObama.Tag = "democrat";
            this.textBarackObama.Text = "0";
            // 
            // textJohnFKennedy
            // 
            this.textJohnFKennedy.Location = new System.Drawing.Point(137, 175);
            this.textJohnFKennedy.Name = "textJohnFKennedy";
            this.textJohnFKennedy.Size = new System.Drawing.Size(27, 20);
            this.textJohnFKennedy.TabIndex = 29;
            this.textJohnFKennedy.Tag = "democrat";
            this.textJohnFKennedy.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser);
            this.groupBox1.Location = new System.Drawing.Point(358, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(599, 552);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "https://en.m.wikipedia.org/wiki/Benjamin_Harrison";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 616);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(969, 25);
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Maximum = 120;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(945, 19);
            this.toolStripProgressBar1.Value = 120;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(969, 641);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBenjaminHarrison);
            this.Controls.Add(this.textFranklinDRoosevelt);
            this.Controls.Add(this.textWilliamJClinton);
            this.Controls.Add(this.textJamesBuchanan);
            this.Controls.Add(this.textFranklinPierce);
            this.Controls.Add(this.textGeorgeWBush);
            this.Controls.Add(this.textBarackObama);
            this.Controls.Add(this.textJohnFKennedy);
            this.Controls.Add(this.textWilliamMcKinley);
            this.Controls.Add(this.textRonaldReagan);
            this.Controls.Add(this.textDwightDEisenhower);
            this.Controls.Add(this.textMartinVanBurren);
            this.Controls.Add(this.textGeorgeWashington);
            this.Controls.Add(this.textJohnAdams);
            this.Controls.Add(this.textTheodoreRoosevelt);
            this.Controls.Add(this.textThomasJefferson);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.radioThomasJefferson);
            this.Controls.Add(this.radioTheodoreRoosevelt);
            this.Controls.Add(this.radioJohnAdams);
            this.Controls.Add(this.radioGeorgeWashington);
            this.Controls.Add(this.radioMartinVanBuren);
            this.Controls.Add(this.radioDwightDEisenhower);
            this.Controls.Add(this.radioRonaldReagan);
            this.Controls.Add(this.radioWilliamMcKinley);
            this.Controls.Add(this.radioJohnFKennedy);
            this.Controls.Add(this.radioBarackObama);
            this.Controls.Add(this.radioGeorgeWBush);
            this.Controls.Add(this.radioFranklinPierce);
            this.Controls.Add(this.radioJamesBuchanan);
            this.Controls.Add(this.radioWilliamJClinton);
            this.Controls.Add(this.radioFranklinDRoosevelt);
            this.Controls.Add(this.radioBenjaminHarrison);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Presidents";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
// im gonna lose it