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
        Random rnd1 = new Random();
        List<int> playerdeck = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            DisplayImage(GenerateCard());
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

        private string GenerateCard()
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

            return cardimage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playercard = 0;
            foreach (Control item in Controls.OfType<PictureBox>())
            {
                if (item.Name.Contains("pictureBox"))
                    Controls.Remove(item);
            }

        }
    }
}
