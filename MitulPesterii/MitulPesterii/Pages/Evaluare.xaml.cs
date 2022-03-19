using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MitulPesterii.Pages
{
    /// <summary>
    /// Interaction logic for Evaluare.xaml
    /// </summary>
    public partial class Evaluare : Page
    {

        #region Texts

        private string startingtext = "Test de evaluare \n Testul are 9 întrebări tip grilă \n Apasă pe butonul \"Start\" când ești pregătit";

        private string q1 = "1. Platon face parte din categoria filosofilor\n greci ai perioadei clasice, alături de:";
        private string a11 = "a. Parmenide și Xenofon";
        private string a12 = "b. Socrate și Aristotel";
        private string a13 = "c. Descartes și Spinoza";
        private string a14 = "d. Schopenhauer și Hegel";

        private string q2 = "2. Metafora răsucirii grumazului semnifică:";
        private string a21 = "a. un exercițiu cardio";
        private string a22 = "b. un atac violent";
        private string a23 = "c. un salt în cunoaștere";
        private string a24 = "d. o afecțiune articulară";

        private string q3 = "3. Principalul personaj al dialogurilor\n platoniciene este:";
        private string a31 = "a. Heraclit";
        private string a32 = "b. Sf.Augustin";
        private string a33 = "c. Pascal";
        private string a34 = "d. Socrate";

        private string q4 = "4. Tehnica utilizată de Socrate pentru a\n pune în evidență adevărul se numește:";
        private string a41 = "a. dialectică";
        private string a42 = "b. maieutică";
        private string a43 = "c. metafizică";
        private string a44 = "d. mecanică";

        private string q5 = "5. Mitul peșterii este prezentat în dialogul:";
        private string a51 = "a. Fedon";
        private string a52 = "b. Fedru";
        private string a53 = "c. Republica ";
        private string a54 = "d. Banchetul";

        private string q6 = "6. Mitul peșterii este o alegorie care simbolizează:";
        private string a61 = "a. concepția lui Aristotel despre om ca zoon politikon";
        private string a62 = "b. concepția lui Platon legată de cunoaștere";
        private string a63 = "c. concepția lui Heraclit din Efes despre arche";
        private string a64 = "d. concepția lui Descartes depre adevăr și eroare";

        private string q7 = "7. Teoria platoniciană a oferit o soluție\n conflictului ideatic dintre:";
        private string a71 = "a. empiriști și raționaliști";
        private string a72 = "b. școala eleată (Parmenide) și școala din \nMilet*Efes (Heraclit)";
        private string a73 = "c. cirenaici și epicurieni";
        private string a74 = "d. gnostici și agnostici";


        private string q8 = "8. Care este Ideea Ideilor în\n sistemul platonician?";
        private string a81 = "a. Ideea de Frumos";
        private string a82 = "b. Ideea de Dreptate";
        private string a83 = "c. Ideea de Albină";
        private string a84 = "d. Ideea de Bine";

        private string q9 = "9. Ce nu este sistemul platonician?";
        private string a91 = "a. o praxiologie";
        private string a92 = "b. o ontologie";
        private string a93 = "c. o gnoseologie";
        private string a94 = "d. o axiologie";

        #endregion


        #region Properties

        private List<Button> numberBtns;

        private int[] answers;

        private int questionNumber;

        #endregion

        public Evaluare()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;


            numberBtns = new List<Button>();
            answers = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            // Adding the number buttons
            numberBtns.Add(Btn1);
            numberBtns.Add(Btn2);
            numberBtns.Add(Btn3);
            numberBtns.Add(Btn4);
            numberBtns.Add(Btn5);
            numberBtns.Add(Btn6);
            numberBtns.Add(Btn7);
            numberBtns.Add(Btn8);
            numberBtns.Add(Btn9);

            // Default properties
            TopTB.Text = startingtext;
            FinishBtn.Visibility = Visibility.Hidden;
            foreach (var btn in numberBtns)
                btn.Visibility = Visibility.Hidden;
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;
            QuestionSP.Visibility = Visibility.Hidden;
            FaceImg.Visibility = Visibility.Hidden;


            foreach (var btn in numberBtns)
                btn.Click += Btn_Click;


        }


        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.Visibility = Visibility.Hidden;

            TopTB.Text = "Întrebarea 1/9";

            FinishBtn.Visibility = Visibility.Visible;
            foreach (var btn in numberBtns)
                btn.Visibility = Visibility.Visible;
            RightBtn.Visibility = Visibility.Visible;
            LeftBtn.Visibility = Visibility.Hidden;
            QuestionSP.Visibility = Visibility.Visible;
            FinishBtn.IsEnabled = false;

            Question.Text = q1;
            R1TB.Text = a11;
            R2TB.Text = a12;
            R3TB.Text = a13;
            R4TB.Text = a14;

            MenuButtonsEnabled.CanPressMenuButtons = false;

            questionNumber = 1;
        }


        #region Left and Right buttons

        /// <summary>
        /// Navigate to the right with the right button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            questionNumber++;

            if (questionNumber == 9)
                RightBtn.Visibility = Visibility.Hidden;
            else
                RightBtn.Visibility = Visibility.Visible;

            if (questionNumber == 1)
                LeftBtn.Visibility = Visibility.Hidden;
            else
                LeftBtn.Visibility = Visibility.Visible;


            SetQuestionAndAnswers();
        }

        /// <summary>
        /// Navigate to the left with the left button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            questionNumber--;

            if (questionNumber == 1)
                LeftBtn.Visibility = Visibility.Hidden;
            else
                LeftBtn.Visibility = Visibility.Visible;

            if (questionNumber == 9)
                RightBtn.Visibility = Visibility.Hidden;
            else
                RightBtn.Visibility = Visibility.Visible;

            SetQuestionAndAnswers();
        }

        #endregion

        #region RadioButtons

        private void R1_Checked(object sender, RoutedEventArgs e)
        {
            answers[questionNumber] = 1;

            CanFinish();
        }

        private void R2_Checked(object sender, RoutedEventArgs e)
        {
            answers[questionNumber] = 2;

            CanFinish();
        }

        private void R3_Checked(object sender, RoutedEventArgs e)
        {
            answers[questionNumber] = 3;

            CanFinish();
        }

        private void R4_Checked(object sender, RoutedEventArgs e)
        {
            answers[questionNumber] = 4;

            CanFinish();
        }
        

        #endregion

        #region Helpers

        /// <summary>
        /// Sets the question and the respective answers based on the question number
        /// </summary>
        private void SetQuestionAndAnswers()
        {
            R1.IsChecked = false;
            R2.IsChecked = false;
            R3.IsChecked = false;
            R4.IsChecked = false;
            switch (answers[questionNumber])
            {
                case 1:
                    R1.IsChecked = true;
                    break;
                case 2:
                    R2.IsChecked = true;
                    break;
                case 3:
                    R3.IsChecked = true;
                    break;
                case 4:
                    R4.IsChecked = true;
                    break;
                default:
                    break;
            }

            switch (questionNumber)
            {
                case 1:
                    TopTB.Text = "Întrebarea 1/9";
                    Question.Text = q1;
                    R1TB.Text = a11;
                    R2TB.Text = a12;
                    R3TB.Text = a13;
                    R4TB.Text = a14;
                    break;
                case 2:
                    TopTB.Text = "Întrebarea 2/9";
                    Question.Text = q2;
                    R1TB.Text = a21;
                    R2TB.Text = a22;
                    R3TB.Text = a23;
                    R4TB.Text = a24;
                    break;
                case 3:
                    TopTB.Text = "Întrebarea 3/9";
                    Question.Text = q3;
                    R1TB.Text = a31;
                    R2TB.Text = a32;
                    R3TB.Text = a33;
                    R4TB.Text = a34;
                    break;
                case 4:
                    TopTB.Text = "Întrebarea 4/9";
                    Question.Text = q4;
                    R1TB.Text = a41;
                    R2TB.Text = a42;
                    R3TB.Text = a43;
                    R4TB.Text = a44;
                    break;
                case 5:
                    TopTB.Text = "Întrebarea 5/9";
                    Question.Text = q5;
                    R1TB.Text = a51;
                    R2TB.Text = a52;
                    R3TB.Text = a53;
                    R4TB.Text = a54;
                    break;
                case 6:
                    TopTB.Text = "Întrebarea 6/9";
                    Question.Text = q6;
                    R1TB.Text = a61;
                    R2TB.Text = a62;
                    R3TB.Text = a63;
                    R4TB.Text = a64;
                    break;
                case 7:
                    TopTB.Text = "Întrebarea 7/9";
                    Question.Text = q7;
                    R1TB.Text = a71;
                    R2TB.Text = a72;
                    R3TB.Text = a73;
                    R4TB.Text = a74;
                    break;
                case 8:
                    TopTB.Text = "Întrebarea 8/9";
                    Question.Text = q8;
                    R1TB.Text = a81;
                    R2TB.Text = a82;
                    R3TB.Text = a83;
                    R4TB.Text = a84;
                    break;
                case 9:
                    TopTB.Text = "Întrebarea 9/9";
                    Question.Text = q9;
                    R1TB.Text = a91;
                    R2TB.Text = a92;
                    R3TB.Text = a93;
                    R4TB.Text = a94;
                    break;
            }
        }


        /// <summary>
        /// Makes so that you can navigate with the numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Name)
            {
                case "Btn1":
                    questionNumber = 1;
                    break;
                case "Btn2":
                    questionNumber = 2;
                    break;
                case "Btn3":
                    questionNumber = 3;
                    break;
                case "Btn4":
                    questionNumber = 4;
                    break;
                case "Btn5":
                    questionNumber = 5;
                    break;
                case "Btn6":
                    questionNumber = 6;
                    break;
                case "Btn7":
                    questionNumber = 7;
                    break;
                case "Btn8":
                    questionNumber = 8;
                    break;
                case "Btn9":
                    questionNumber = 9;
                    break;
                default:
                    questionNumber = 1;
                    break;
            }

            SetQuestionAndAnswers();

        }

        /// <summary>
        /// Checks if every question has an answer and does the necessary action for FinishBtn
        /// </summary>
        private void CanFinish()
        {
            int i, ok= 1;

            for(i=1;i<=9;i++)
            {
                if(answers[i]==0)
                {
                    ok = 0;
                    break;
                }
            }

            if (ok == 1)
                FinishBtn.IsEnabled = true;
            else
                FinishBtn.IsEnabled = false;
        }

        /// <summary>
        /// Returns 1 if it s the correct answer, 0 if it s not
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        private int CorrectAnswer(int question, int answer)
        {
            switch(question)
            {
                case 1:
                    if (answer == 2)
                        return 1;
                    else
                        return 0;
                case 2:
                    if (answer == 3)
                        return 1;
                    else
                        return 0;
                case 3:
                    if (answer == 4)
                        return 1;
                    else
                        return 0;
                case 4:
                    if (answer == 2)
                        return 1;
                    else
                        return 0;
                case 5:
                    if (answer == 3)
                        return 1;
                    else
                        return 0;
                case 6:
                    if (answer == 2)
                        return 1;
                    else
                        return 0;
                case 7:
                    if (answer == 2)
                        return 1;
                    else
                        return 0;
                case 8:
                    if (answer == 4)
                        return 1;
                    else
                        return 0;
                case 9:
                    if (answer == 1)
                        return 1;
                    else
                        return 0;
                default: return 0;
            }
        }

        #endregion

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            int i, nr = 0;
            for(i=1;i<=9;i++)
            {
                if(CorrectAnswer(i, answers[i])==1)
                {
                    nr++;
                }
            }

            TopTB.Text = $"\n\n\nAi raspuns corect la {nr} intrebari.";
            FinishBtn.Visibility = Visibility.Hidden;
            foreach (var btn in numberBtns)
                btn.Visibility = Visibility.Hidden;
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;
            StartBtn.Visibility = Visibility.Hidden;
            QuestionSP.Visibility = Visibility.Hidden;
            FaceImg.Visibility = Visibility.Visible;

            MenuButtonsEnabled.CanPressMenuButtons = true;

            if (nr >= 7)
                FaceImg.Source = new BitmapImage(new Uri("/Images/Faces/HappyFace.png", UriKind.Relative));
            else
            {
                if(nr>=5&&nr<=6)
                    FaceImg.Source = new BitmapImage(new Uri("/Images/Faces/NeutralFace.png", UriKind.Relative));
                else
                    FaceImg.Source = new BitmapImage(new Uri("/Images/Faces/SadFace.png", UriKind.Relative));
            }
        }
    }
}
