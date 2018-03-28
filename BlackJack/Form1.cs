using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        public int playercard = 0;
        public int dealercard = 0;

        Random rnd1 = new Random();
        List<int> playerdeck = new List<int>();
        List<int> dealerdeck = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdDeal_Click(object sender, EventArgs e)
        {
            if (playercard == 0)
            {
                pictureBox1.Image = (Image)GenerateCard();
                pictureBox2.Image = (Image)GenerateCard();
            }
            else if (playercard == 2)
                pictureBox3.Image = (Image)GenerateCard();
            else if (playercard == 3)
                pictureBox4.Image = (Image)GenerateCard();
            else if (playercard == 4)
                pictureBox5.Image = (Image)GenerateCard();

            playerScore.Text = CountPlayerScore();

            if (dealercard == 0)
            {
                pictureBox10.Image = (Image)GenerateCard();
                pictureBox9.Image = (Image)GenerateCard();
                dealercard = 2;
            }

            dealerScore.Text = CountDealerScore();

            //DisplayImage(GenerateCard());
        }

        private string CountPlayerScore()
        {
            int score = 0;

            score = playerdeck.Sum();

            if(playerdeck.Any(x => x == 1))
            {
                if (score + 10 <= 21)
                    score = score + 10;
            }

            if (playerdeck.Any(x => x == 11))
            {
                score = score - 1;
            }

            if (playerdeck.Any(x => x == 12))
            {
                score = score - 2;
            }

            if (playerdeck.Any(x => x == 13))
            {
                score = score - 3;
            }

            if (score > 21)
            {
                this.label1.Show();
                playercard = 5;
            }
                

            return score.ToString();
        }

        private string CountDealerScore()
        {
            int score = 0;

            score = dealerdeck.Sum();

            if (dealerdeck.Any(x => x == 1))
            {
                if (score + 10 <= 21)
                    score = score + 10;
            }

            if (dealerdeck.Any(x => x == 11))
            {
                score = score - 1;
            }

            if (dealerdeck.Any(x => x == 12))
            {
                score = score - 2;
            }

            if (dealerdeck.Any(x => x == 13))
            {
                score = score - 3;
            }

            if (score > 21)
            {
                this.label2.Show();
                dealercard = 5;
            }


            return score.ToString();
        }

        private void DisplayImage(string file)
        {
            PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(125, 200),
                Location = new Point(playercard * 140 + 10, 5),
                Image = Image.FromFile(file),
                SizeMode = PictureBoxSizeMode.AutoSize
            };

            Controls.Add(picture);
            playercard++;
        }

        private bool CheckCard(int cardno)
        {
            bool alreadyExists = playerdeck.Any(x => x == cardno);
            return alreadyExists;
        }

        private Bitmap GenerateCard()
        {
            string cardimage = ""; 
            int cardno = 0;
            cardno = rnd1.Next(1, 14);

            if (playerdeck.Count != 13)
            {
                while (CheckCard(cardno))
                    cardno = rnd1.Next(1, 14);
            }

            switch (cardno)
            {
                case 1:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\A.PNG";
                    break;
                case 2:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\2.PNG";
                    break;
                case 3:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\3.PNG";
                    break;
                case 4:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\4.PNG";
                    break;
                case 5:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\5.PNG";
                    break;
                case 6:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\6.PNG";
                    break;
                case 7:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\7.PNG";
                    break;
                case 8:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\8.PNG";
                    break;
                case 9:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\9.PNG";
                    break;
                case 10:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\10.PNG";
                    break;
                case 11:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\J.PNG";
                    break;
                case 12:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\Q.PNG";
                    break;
                case 13:
                    cardimage = "C:\\Users\\bc110\\source\\repos\\BlackJack\\BlackJack\\images\\K.PNG";
                    break;
            }
            playerdeck.Add(cardno);

            Bitmap image = new Bitmap(cardimage);
            playercard++;

            return image; // cardimage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playercard = 0;

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;

            playerScore.Text = "";
            this.label1.Hide();
            playerdeck.Clear();

            //foreach (Control item in Controls) //.OfType<PictureBox>()
            //{
            //    if (item.Name.Contains("pictureBox"))
            //        Controls.Remove(item);
            //}

        }

        private void cmdNewGame_Click(object sender, EventArgs e)
        {
            Deck player = new Deck();

            pictureBox1.Image = (Image)player.DisplayCard(player.DrawCard());
            pictureBox2.Image = (Image)player.DisplayCard(player.DrawCard());
        }
    }
}
