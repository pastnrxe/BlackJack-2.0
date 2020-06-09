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
        int Tab = 0;
        List<Card> deck = new List<Card>()
        {
            #region spades
            new Card() { Value  = 2, Name = "Two Spades", Image = @"..\Image\2S.png" },
            new Card() { Value = 3, Name = "Three Spades", Image = @"..\Image\3S.png"},
            new Card() { Value = 4, Name =  "Four Spades", Image = @"..\Image\4S.png"},
            new Card() { Value = 5, Name = "Five Spades", Image = @"..\Image\5S.png" },
            new Card() { Value = 6, Name = "Six Spades", Image = @"..\Image\6S.png" },
            new Card() { Value = 7, Name = "Seven Spades", Image = @"..\Image\7S.png" },
            new Card() { Value = 8, Name = "Eight Spades", Image = @"..\Image\8S.png" },
            new Card() { Value = 9, Name = "Nine Spades", Image = @"..\Image\9S.png" },
            new Card() { Value = 10, Name = "Ten Spades", Image = @"..\Image\10S.png" },
            new Card() { Value = 10, Name = "Jack Spades", Image = @"..\Image\JS.png" },
            new Card() { Value = 10, Name = "Queen Spades", Image = @"..\Image\QS.png" },
            new Card(){ Value = 10, Name = "King Spades", Image = @"..\Image\KS.png" },
            new Card(){ Value = 11, Name = "Ace Spades", Image = @"..\Image\AS.png" },
            #endregion
            #region diamonds
            new Card() { Value  = 2, Name = "Two Diamonds", Image = @"..\Image\2D.png" },
            new Card() { Value = 3, Name = "Three Diamonds", Image = @"..\Image\3D.png" },
            new Card() { Value = 4, Name =  "Four Diamonds", Image = @"..\Image\4D.png"},
            new Card() { Value = 5, Name = "Five Diamonds", Image = @"..\Image\5D.png" },
            new Card() { Value = 6, Name = "Six Diamonds", Image = @"..\Image\6D.png" },
            new Card(){ Value = 7, Name = "Seven Diamonds", Image = @"..\Image\7D.png" },
            new Card() { Value = 8, Name = "Eight Diamonds", Image = @"..\Image\8D.png" },
            new Card() { Value = 9, Name = "Nine Diamonds", Image = @"..\Image\9D.png" },
            new Card() { Value = 10, Name = "Ten Diamonds", Image = @"..\Image\10D.png" },
            new Card() { Value = 10, Name = "Jack Diamonds", Image = @"..\Image\JD.png" },
            new Card() { Value = 10, Name = "Queen Diamonds", Image = @"..\Image\QD.png" },
            new Card(){ Value = 10, Name = "King Diamonds", Image = @"..\Image\KD.png" },
            new Card(){ Value = 11, Name = "Ace Diamonds", Image = @"..\Image\AD.png" },
            #endregion
            #region clubs
            new Card() { Value  = 2, Name = "Two Clubs", Image = @"..\Image\2C.png" },
            new Card() { Value = 3, Name = "Three Clubs", Image = @"..\Image\3C.png" },
            new Card() { Value = 4, Name =  "Four Clubs", Image = @"..\Image\4C.png"},
            new Card() { Value = 5, Name = "Five Clubs", Image = @"..\Image\5C.png" },
            new Card() { Value = 6, Name = "Six Clubs", Image = @"..\Image\6C.png" },
            new Card(){ Value = 7, Name = "Seven Clubs", Image = @"..\Image\7C.png" },
            new Card() { Value = 8, Name = "Eight Clubs", Image = @"..\Image\8C.png" },
            new Card() { Value = 9, Name = "Nine Clubs", Image= @"..\Image\9C.png" },
            new Card() { Value = 10, Name = "Ten Clubs", Image = @"..\Image\10C.png" },
            new Card() { Value = 10, Name = "Jack Clubs", Image = @"..\Image\JC.png" },
            new Card() { Value = 10, Name = "Queen Clubs", Image = @"..\Image\QC.png" },
            new Card(){ Value = 10, Name = "King Clubs", Image = @"..\Image\KC.png" },
            new Card(){ Value = 11, Name = "Ace Clubs", Image = @"..\Image\AC.png" },
            #endregion
            #region hearts
            new Card() { Value  = 2, Name = "Two Hearts", Image = @"..\Image\2H.png" },
            new Card() { Value = 3, Name = "Three Hearts", Image = @"..\Image\3H.png" },
            new Card() { Value = 4, Name =  "Four Hearts", Image = @"..\Image\4H.png"},
            new Card() { Value = 5, Name = "Five Hearts", Image = @"..\Image\5H.png" },
            new Card() { Value = 6, Name = "Six Hearts", Image = @"..\Image\6H.png" },
            new Card(){ Value = 7, Name = "Seven Hearts", Image = @"..\Image\7H.png" },
            new Card() { Value = 8, Name = "Eight Hearts", Image = @"..\Image\8H.png" },
            new Card() { Value = 9, Name = "Nine Hearts", Image = @"..\Image\9H.png" },
            new Card() { Value = 10, Name = "Ten Hearts", Image = @"..\Image\10H.png" },
            new Card() { Value = 10, Name = "Jack Hearts", Image = @"..\Image\JH.png" },
            new Card() { Value = 10, Name = "Queen Hearts", Image = @"..\Image\QH.png" },
            new Card(){ Value = 10, Name = "King Hearts", Image = @"..\Image\KH.png" },
            new Card(){ Value = 11, Name = "Ace Hearts", Image = @"..\Image\AH.png" }
            #endregion
        };
        List<Card> playercardList = new List<Card>()
        {
            new Card() { Value  = 0, Name = "null", Image = "null" }
        };
        List<Card> bankercardList = new List<Card>()
        {
            new Card() { Value  = 0, Name = "null", Image = "null" }
        };
        int playercardSum = 0;
        int bankercardSum = 0;
        Random random = new Random();
        List<int> usedCards = new List<int>();
        List<PictureBox> bankerbox = new List<PictureBox>();
        List<PictureBox> playerbox = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            resetGame();
        }
        private int selectRandomCard()
        {
            int randomCard;
            randomCard = random.Next(0, deck.Count);
            return randomCard;
        }
        private void sumPlayerCards()
        {
            playercardSum = 0;
            bool AceExist = false;
            for (int i = 0; i < playercardList.Count; i++)
            {
                playercardSum += playercardList[i].Value;
                if (playercardList[i].Name.StartsWith("Ace")) AceExist = true;
            }
            if (playercardSum > 20 && AceExist) playercardSum -= 10;
        }
        private void sumBankerCards()
        {
            bankercardSum = 0;
            bool AceExist = false;
            for (int i = 0; i < bankercardList.Count; i++)
            {
                bankercardSum += bankercardList[i].Value;
                if (bankercardList[i].Name.StartsWith("Ace")) AceExist = true;
            }
            if (bankercardSum > 20 && AceExist) bankercardSum -= 10;
        }

        private int GetValue(List<Card> cardList)
        {
            int sum = 0;
            foreach (var item in cardList)
            {
                sum += item.Value;
            }
            return sum;
        }
        private void resetGame()
        {
            Tab = 0;
            resultLabel.Text = null;
            displayCardBack(pictureBox1);
            displayCardBack(pictureBox2);
            displayCardBack(pictureBox4);
            foreach (PictureBox pb in playerbox)
            {
                this.Controls.Remove(pb); //Посмотрел в интернете
            }
            playerbox = new List<PictureBox>();
            foreach (PictureBox pb in bankerbox)
            {
                this.Controls.Remove(pb); //Посмотрел в интернете
            }
            bankerbox = new List<PictureBox>();
            playercardSum = 0;
            bankercardSum = 0;
            playercardList.Clear();
            bankercardList.Clear();
            usedCards.Clear();
            resultLabel.Text = "Press Start";
        }
        private void displayCardBack(PictureBox picturebox)
        {
            picturebox.ImageLocation = @"..\Image\b1fv.png";
            picturebox.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        private void pnlTable_Paint(object sender, PaintEventArgs e)
        {

        } //Миссклик на старую панель
        private void startButton_Click_1(object sender, EventArgs e)
        {
            resultLabel.Text = null;
            if (playercardSum > 0)
            {
                resultLabel.Text = String.Format("Already started");
            }
            else
            {
                playercardSum = 0;
                bankercardSum = 0;
                #region init player
                int randomCard1 = selectRandomCard();
                Card card1 = deck[randomCard1];
                usedCards.Add(randomCard1);
                int randomCard2 = selectRandomCard();
                while (usedCards.Contains(randomCard2))
                {
                    randomCard2 = selectRandomCard();
                }
                randomCard2 = 1 * randomCard2;

                Card card2 = deck[randomCard2];
                usedCards.Add(randomCard2);

                playercardList.Add(card1);
                playercardList.Add(card2);

                pictureBox1.ImageLocation = card1.Image;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

                pictureBox2.ImageLocation = card2.Image;
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                #endregion
                #region init banker
                int randomCard3 = selectRandomCard();
                while (usedCards.Contains(randomCard3))
                {
                    randomCard3 = selectRandomCard();
                }
                randomCard3 = 1 * randomCard3;
                Card card3 = deck[randomCard3];
                usedCards.Add(randomCard3);

                bankercardList.Add(card3);

                pictureBox4.ImageLocation = card3.Image;
                pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;

                #endregion
                sumPlayerCards();
                if (playercardSum == 21)
                {
                    resultLabel.Text = String.Format("The sum of your cards is {0}, You win!", playercardSum);
                }
            }
        }
        private void resetButton_Click_1(object sender, EventArgs e)
        {
            resetGame();
        }
        private void dealButton_Click_1(object sender, EventArgs e)
        {
            if (playercardSum == 0)
            {
                resultLabel.Text = "Press Start";
            }
            else
            {
                if (playercardSum > 33)
                {
                    resetGame();
                    resultLabel.Text = "Restarting";
                }
                else
                {
                    Tab += 90;
                    playercardSum = 0;
                    int randomCard = selectRandomCard();
                    Card card = deck[randomCard];
                    usedCards.Add(randomCard);
                    if (usedCards.Contains(randomCard)) randomCard = selectRandomCard();
                    else randomCard = 1 * randomCard;
                    PictureBox p3 = new PictureBox();
                    p3.Width = 71;
                    p3.Height = 96;
                    p3.Location = new Point(pictureBox2.Left + Tab, 285);
                    p3.ImageLocation = card.Image;
                    p3.SizeMode = PictureBoxSizeMode.AutoSize;
                    this.Controls.Add(p3);
                    playerbox.Add(p3);
                    playercardList.Add(card);
                    sumPlayerCards();
                    if (playercardSum > 21)
                    {
                        resultLabel.Text = String.Format("The sum of your cards is {0}, You lose!", playercardSum);        
                    }
                    else if (playercardSum == 21)
                    {
                        resultLabel.Text = String.Format("The sum of your cards is: {0}, You win!", playercardSum);
                    }
                }
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            Tab = 0;
            if (playercardSum == 0)
            {
                resultLabel.Text = "Press Start";
                return;
            }
            sumBankerCards();
            while (bankercardSum <= 16)
            {
                Tab += 90;
                int randomCard = selectRandomCard();
                Card card = deck[randomCard];
                usedCards.Add(randomCard);
                if (usedCards.Contains(randomCard)) randomCard = selectRandomCard();
                else randomCard = 1 * randomCard;
                PictureBox p4 = new PictureBox();
                p4.Width = 71;
                p4.Height = 96;
                p4.Location = new Point(pictureBox4.Left + Tab, 12);
                p4.ImageLocation = card.Image;
                p4.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(p4);
                bankerbox.Add(p4);
                bankercardList.Add(card);
                sumBankerCards();
            }
            if (bankercardSum > 21)
            {
                resultLabel.Text = String.Format("The sum of banker cards is {0}, You win!", bankercardSum);
            }
            else if (playercardSum <= bankercardSum)
            {
                resultLabel.Text = String.Format("The sum of your cards is {0}, You lose!", playercardSum);
            }
            else
            {
                resultLabel.Text = String.Format("The sum of your cards is {0}, You win!", playercardSum);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }//Миссклик
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }//Миссклик
        private void label1_Click(object sender, EventArgs e)
        {

        }//Миссклик
    } 
}
