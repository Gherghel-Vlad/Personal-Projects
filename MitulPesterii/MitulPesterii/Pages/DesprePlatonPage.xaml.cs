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
    /// Interaction logic for DesprePlatonPage.xaml
    /// </summary>
    public partial class DesprePlatonPage : Page
    {

        public List<Button> buttons;


        #region Text

        private string aboutPlaton1 { get; } = "    Deși cel mai important invătător al sau a fost  Socrate," +
            " pe care îl urmează și pe care îl va face personaj al dialogurilor lui, Platon a fost" +
            " și elev al Iui Cratylos — filosof heraclitean și al  lui Hermogenes — filosof parmenidean," +
            " aspecte marcante pentru fundamentarea gândirii sale filosofice. Aceste influențe I-au situat" +
            " la confluența marilor direcții ale filosofiei grecești, filosoful îmbinând teoria heracliteana," +
            " cea parmenidiana cu cea pythagoreica și socratica (în filosofia politică) — această sinteză ducând" +
            " la construcția sistemului sau original și conferindu-i  statutul de mare gânditor. Platon a înființat" +
            " la Atena școală numită Academia, care continuă să existe și după moartea filosofului, perpetuându-i" +
            " doctrina. Învățătura în Academie se desfășura sub formă conversațiilor a dialogului pe cele mai importante" +
            " teme de gândire — filosofie,  etică, politică, fizică.";

        private string aboutPlaton2 { get; } = "    Iaton, unul din cei mai importanți filosofi ai Greciei antice," +
            " s-a născut la Atena, a trăit între anii 427-347 î.Hr. Numele l-a dobândit datorită" +
            " înfățișării sale viguroase, Aristocles fiind numele lui original. Se spune că în tinerețe" +
            " a manifestat preocupare pentru pictură și a scris poeme, iar mai apoi, la vârstă de 20 de" +
            " ani a început să se dedice filosofiei după ce I-a întâlnit pe Socrate, căruia îi va fi elev" +
            " până la moartea acestuia. Faptul că a făcut parte dintr-o familie de aristocrați i-a conferit" +
            " nu numai privilegiul de a avea o educație bine fundamentată, ci și posibilitatea de a se implică" +
            " în politică, aspect pe care îl are în vedere prin inițierea unor proiecte filosofice în unele" +
            " din dialogurile sale.";

        private string opera { get; } = "    Spre deosebire de Socrate a cărui doctrina s-a perpetuat oral," +
            " gândirea lui  Platon este organizată într-o vastă operă scrisă, sub forma dialogurilor." +
            " Dialogul este un discurs bazat pe întrebări și răspunsuri, care are în prim plan dialectica" +
            " — artă de a vorbi, de a combate sau a susține argumente. Dialogul platonician are două caractere" +
            " generale. în primul rând vizează capacitatea de a învața, iar în al doilea rând are în vedere cercetarea." +
            " Cel dintâi (învățarea) este teoretic (fizic și logic) sau practic (etic și politic), pe când celălalt" +
            " (cercetarea) are în vedere exercitarea minții (prin care se pune la îndoială) și victoria în controversă" +
            " (prin care se critică sau se distrug anumite teze).";

        private string tinerete { get; } = "Hippias Minor(Despre minciuna)\n"+
                                            "Alcibiade(Despre natura omului)\n" +
                                            "Apologia lui Socrate\n" +
                                            "Euthyphron(Despre evlavie)\n" +
                                            "Criton(Despre datorie)\n" +
                                            "Hippias\n" +
                                            "Maior\n" +
                                            "Charmides\n" +
                                            "Lakes(Despre curaj)\n" +
                                            "Lysis(Despre prietenie)\n" +
                                            "Protagoras\n" +
                                            "Gorgias\n" +
                                            "Menon(Despre virtute)\n";
        private string maturitate { get; } = "Banchetul\n" +
            "Phaidon (Despre suflet)\n" +
            "Phaidros (Despre dragoste)\n" +
            "Statul (Republica)\n" +
            "Ion Menexenos\n" +
            "Eutidemos\n" +
            "Cratylos\n";
        private string batranete { get; } = "Armenides\n" +
            "Theaitetos\n" +
            "Sofistul\n" +
            "Politicul\n" +
            "Philebos\n" +
            "Timaios\n" +
            "Critias\n" +
            "Legile\n";

        #endregion

        #region Variables for texts

        // Keeps the name of the page so it can get easily the necesarry text
        private string pageName = "aboutPlaton";

        // Keeps the number of pages
        private int nrPages = 2;

        // Keeps the current page number
        private int currentPage = 1;

        #endregion


        public DesprePlatonPage()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;

            buttons = new List<Button>();


            // Populating the default textblock
            ContentTextBlock.Text = aboutPlaton1;

            // Default value for the button's visibility
            RightBtn.Visibility = Visibility.Visible;
            LeftBtn.Visibility = Visibility.Hidden;

            // Default value for the BiografieBtn
            BiografieBtn.Opacity = 0.75;
            BiografieBtn.IsEnabled = false;

            // Page number textblock
            PageNumberTextBlock.Text = $"{currentPage}/{nrPages}";

            // Adding the buttons to the list
            buttons.Add(BiografieBtn);
            buttons.Add(OperaBtn);
            buttons.Add(TinereteBtn);
            buttons.Add(BatraneteBtn);
            buttons.Add(MaturitateBtn);

            //// Resizing everything on the page based on the screen size
            //this.SizeChanged += DesprePlatonPage_SizeChanged;

            // Adding the style effect on the buttons
            foreach (var button in buttons)
            {
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }
        }

        private async void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Thickness tn = new Thickness(-3, 20, 0, 0);
            Animations.ButtonMarginAnimation(btn, new Thickness(btn.Margin.Left, btn.Margin.Top, btn.Margin.Right, btn.Margin.Bottom), new Thickness(btn.Margin.Left + 10, btn.Margin.Top, btn.Margin.Right + 10, btn.Margin.Bottom), 0);
            if (btn.Equals(BiografieBtn))
                BiografieTB.FontSize = 24;
            if (btn.Equals(OperaBtn))
                OperaTB.FontSize = 30;
            if (btn.Equals(TinereteBtn))
                TinereteTB.FontSize = 22;
            if (btn.Equals(MaturitateBtn))
                MaturitateTB.FontSize = 18;
            if (btn.Equals(BatraneteBtn))
                BatraneteTB.FontSize = 20;
        }

        private async void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Animations.ButtonMarginAnimation(btn, new Thickness(btn.Margin.Left, btn.Margin.Top, btn.Margin.Right, btn.Margin.Bottom), new Thickness(btn.Margin.Left -10, btn.Margin.Top, btn.Margin.Right - 10, btn.Margin.Bottom), 0);

            if (btn.Equals(BiografieBtn))
                BiografieTB.FontSize = 28;
            if (btn.Equals(OperaBtn))
                OperaTB.FontSize = 34;
            if (btn.Equals(TinereteBtn))
                TinereteTB.FontSize = 25;
            if (btn.Equals(MaturitateBtn))
                MaturitateTB.FontSize = 20;
            if (btn.Equals(BatraneteBtn))
                BatraneteTB.FontSize = 22;
        }
        

        private async void DesprePlatonPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            await Task.Delay(200);
            ContentWidth();
            ContentHeight();
            ContentFontSize();
            PageNumberLocation();
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            // Do the slide in animation for the page
            await Animations.SlideAndFadeInFromRight(this, 1, Calculations.ContentFrameWidthFormula());
        }

        #region Helpers for resize


        /// <summary>
        /// Sets the ContentTextBlock's width based on the screen
        /// </summary>
        public void ContentWidth()
        {
            double a, b, c;
            a = Calculations.ContentFrameWidthFormula();
            b = (double)3 / 5;
            c = (double)b * a;

            ContentTextBlock.Width = (((double)65 / 100) * c);
        }

        /// <summary>
        /// Change the height of the ContentTextblock based on the screen
        /// </summary>
        private void ContentHeight()
        {
            ContentTextBlock.Height = (((double)43 / 100) * MainWindowSize.MainWindowHeight);
        }

        /// <summary>
        /// Change the font size of the ContentTextBlock based on the screen
        /// </summary>
        private void ContentFontSize()
        {
            double a, b, c, d;

            a = 100 * MainWindowSize.MainWindowWidth;
            b = (double)a / 1280;
            c = 100 * MainWindowSize.MainWindowHeight;
            d = (double)c / 720;

            b = (double)(b + d + 5) / 2;

            if (MainWindowSize.MainWindowWidth < 1280 && MainWindowSize.MainWindowHeight < 800)
                ContentTextBlock.FontSize = ((double)b / 100) * 16;
            else
                ContentTextBlock.FontSize = ((double)b / 105) * 16;
        }

        /// <summary>
        /// Calculates the position for the page number
        /// </summary>
        private void PageNumberLocation()
        {
            PageNumberTextBlock.Margin = new Thickness((((double)20 / 100) * MainWindowSize.MainWindowHeight));
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Shows the next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            // Saying that we went to the next page
            currentPage++;

            // If it s the last page don t show the button for the next page
            if(currentPage == nrPages)
            {
                RightBtn.Visibility = Visibility.Hidden;
            }


            PageNumberTextBlock.Text = Convert.ToString(currentPage) + "/" + Convert.ToString(nrPages);

            // Showing the next page
            ContentTextBlock.Text = CorrespondingText(pageName, currentPage);

            // Showing the left burron
            LeftBtn.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Shows the previous page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            // Saying that we went to the next page
            currentPage--;

            // If it s the last page don t show the button for the next page
            if (currentPage == 1)
            {
                LeftBtn.Visibility = Visibility.Hidden;
            }


            PageNumberTextBlock.Text = Convert.ToString(currentPage) + "/" + Convert.ToString(nrPages);

            // Showing the next page
            ContentTextBlock.Text = CorrespondingText(pageName, currentPage);

            // Showing the left burron
            RightBtn.Visibility = Visibility.Visible;
        }

        private void OperaBtn_Click(object sender, RoutedEventArgs e)
        {
            pageName = "opera";

            // Adding the text
            ContentTextBlock.Text = CorrespondingText(pageName);

            ContentTextBlock.FontSize = 16;
            ContentTextBlock.TextAlignment = TextAlignment.Justify;

            ContentWidth();
            ContentHeight();
            ContentFontSize();

            PageNumberTextBlock.Text = String.Empty;


            // There are no next or previous pages
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;

            // Changing the button s properties to make a the pressed effect
            ChangingOpacityButtons(OperaBtn);
            ChangingIsEnabledButtons(OperaBtn);
        }

        private void BiografieBtn_Click(object sender, RoutedEventArgs e)
        {
            pageName = "aboutPlaton";
            currentPage = 1;

            // Adding the text
            ContentTextBlock.Text = CorrespondingText(pageName, currentPage);

            ContentTextBlock.FontSize = 16;
            ContentTextBlock.TextAlignment = TextAlignment.Justify;

            ContentWidth();
            ContentHeight();
            ContentFontSize();

            // Shows the page number
            PageNumberTextBlock.Text = $"{currentPage}/{nrPages}";

            // There are no next or previous pages
            RightBtn.Visibility = Visibility.Visible;
            LeftBtn.Visibility = Visibility.Hidden;

            // Changing the button s properties to make a the pressed effect
            ChangingOpacityButtons(BiografieBtn);
            ChangingIsEnabledButtons(BiografieBtn);
        }

        private void MaturitateBtn_Click(object sender, RoutedEventArgs e)
        {
            pageName = "maturitate";

            // Adding the text
            ContentTextBlock.Text = CorrespondingText(pageName);

            ContentTextBlock.FontSize = 25;
            ContentTextBlock.TextAlignment = TextAlignment.Center;

            PageNumberTextBlock.Text = String.Empty;

            // There are no next or previous pages
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;

            // Changing the button s properties to make a the pressed effect
            ChangingOpacityButtons(MaturitateBtn);
            ChangingIsEnabledButtons(MaturitateBtn);
        }

        private void TinereteBtn_Click(object sender, RoutedEventArgs e)
        {
            pageName = "tinerete";

            // Adding the text
            ContentTextBlock.Text = CorrespondingText(pageName);

            ContentTextBlock.FontSize = 25;
            ContentTextBlock.TextAlignment = TextAlignment.Center;

            PageNumberTextBlock.Text = String.Empty;

            // There are no next or previous pages
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;

            // Changing the button s properties to make a the pressed effect
            ChangingOpacityButtons(TinereteBtn);
            ChangingIsEnabledButtons(TinereteBtn);
        }

        private void BatraneteBtn_Click(object sender, RoutedEventArgs e)
        {
            pageName = "batranete";

            // Adding the text
            ContentTextBlock.Text = CorrespondingText(pageName);

            ContentTextBlock.FontSize = 25;
            ContentTextBlock.TextAlignment = TextAlignment.Center;

            PageNumberTextBlock.Text = String.Empty;

            // There are no next or previous pages
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;

            // Changing the button s properties to make a the pressed effect
            ChangingOpacityButtons(BatraneteBtn);
            ChangingIsEnabledButtons(BatraneteBtn);
        }
        #endregion

        #region Helpers
        private string CorrespondingText(string name, int number = 1)
        {
            if(name == "aboutPlaton")
            {
                switch(number)
                {
                    case 1:
                        return aboutPlaton1;
                    case 2:
                        return aboutPlaton2;
                    default: return aboutPlaton1;
                }
            }
            if(name == "opera")
            {
                return opera;
            }
            if (name == "tinerete")
                return tinerete;
            if (name == "maturitate")
                return maturitate;
            if (name == "batranete")
                return batranete;

            return String.Empty;
        }

        /// <summary>
        /// Make the pressed effect on the button sent
        /// </summary>
        /// <param name="button"></param>
        private void ChangingOpacityButtons(Button button)
        {
            foreach (var but in buttons)
                but.Opacity = 1;
            button.Opacity = 0.75;
        }

        /// <summary>
        /// Make so that the user cant press on the button sent
        /// </summary>
        /// <param name="button"></param>
        private void ChangingIsEnabledButtons(Button button)
        {
            foreach (var but in buttons)
                but.IsEnabled = true;
            button.IsEnabled = false;
        }


        #endregion

        private void BiografieBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
