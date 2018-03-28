using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        Random rnd1 = new Random();
        List<int> carddeck = new List<int>();

        public int DrawCard()
        {
            int cardno = 0;

            cardno = rnd1.Next(1, 14);

            if (carddeck.Count != 5)
            {
                while (CheckCard(cardno))
                    cardno = rnd1.Next(1, 14);
            }

            carddeck.Add(cardno);
            return cardno;
        }

        private bool CheckCard(int cardno)
        {
            bool alreadyExists = carddeck.Any(x => x == cardno);
            return alreadyExists;
        }

        public int GetNoOfCards()
        {
            int total = 0;


            return total;
        }

        public Bitmap DisplayCard(int cardno)
        {
            string cardimage = "";

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

            Bitmap image = new Bitmap(cardimage);

            return image; // cardimage;
        }
    }
}
