using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form

    {

        //New random object created for the quiz
        Random randomizer = new Random();
        //integers for the addition
        int addend1;
        int addend2;
        //integers for the substraction
        int minuend;
        int subtrahend;
        //integers for multiplication
        int multiplicand;
        int multiplier;
        //integers for division
        int dividend;
        int divisor;
        //integer storing the time left for the quiz
        int timeLeft;

        System.Media.SoundPlayer correctSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\iu\source\repos\Math Quiz\yes.wav");
 
        public void StartTheQuiz()
        {
            //Rnadom numbers are prepared for 
            //addition and converted to string
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            //Rnadom numbers are prepared for 
            //substraction and converted to string
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Rnadom numbers are prepared for 
            //multiplication and converted to string
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Rnadom numbers are prepared for 
            //division and converted to string
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Start the timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
        if (multiplicand * multiplier == product.Value)
            {
                correctSoundPlayer.Play();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }

            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //Once the Start button is clicked...
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private bool CheckTheAnswer()
        {
            //These lines check if each answer is correct or not
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value) 
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void plusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void plusRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
         if (addend1 + addend2 == sum.Value)
            {
                correctSoundPlayer.Play();
            }
        }

        private void minusLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void minusRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                correctSoundPlayer.Play();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timesLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void dividedLeftLabel_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dividedRightLabel_Click(object sender, EventArgs e)
        {

        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                correctSoundPlayer.Play();
            }

        }
    }
}
