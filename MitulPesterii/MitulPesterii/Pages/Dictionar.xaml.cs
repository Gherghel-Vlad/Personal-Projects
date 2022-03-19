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
    /// Interaction logic for Dictionar.xaml
    /// </summary>
    public partial class Dictionar : Page
    {

        #region Texts

        private string text1 = "Anamnesis - gr. reamintire, recunoaștere a formelor pure în obiectele sensibile; principiul gnoseologiei platoniciene." +
            " \nDialectica - (gr. Dialektike), din „dia\" și „legein\" = „a vorbi\", „a discuta\" teorie generală a principiilor" +
            " devenirii. \nDianoia - cunoașterea de tip matematic. \nDoxa - gr. părere, element al cunoașterii inferioare. \nEpisteme" +
            " - (gr. cunoaștere, știință) cunoaștere veridică, autentică. \nGnoseologie - ramură a filosofiei care cercetează condițiile," +
            " izvoarele, validitatea procesului cunoașterii. \nIdee - (gr.eidos sau idea, derivate din idein) „aspect exterior\", „forma" +
            " vizibilă\" - la Platon -forma pură, perfectă, imuabilă, prototip al celor celor sensibile, „ceea ce este\". \nInteligibil -" +
            " la Platon - esența ideală care ar putea fi cunpscuză numai de rațiune, de gândire, independent și în opoziție cu sensibilul.";

        private string text2 = "Mit - (gr. mithos), povestire, narațiune arhaică despre zei, eroi sau oameni, despre forțe ale" +
            " naturii sau ale societății, reprezentate adesea ca ființe supranaturale. \nOntologie - ramură a filosofiei sau" +
            " teoria existenței. \nRelația de participare - stabilită între idei și obiectele lumii sensibile; cele din urmă copiază" +
            " sau împrumută trăsături ale ideilor. \nSensibil - ceea ce poate fi perceput sau ceea ce poate fi cunoscut la nivelul" +
            " treptei senzoriale a cunoașterii prin intermediul senzației, percepției și reprezentării, deosebindu-se de inteligibil. ";

        #endregion

        #region Properties

        private int pageNumber = 2;

        private int currentPageNumber = 1;

        #endregion
        public Dictionar()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;

            //Default text
            TB.Text = text1;


            //Default for the arrows
            RightBtn.Visibility = Visibility.Visible;
            LeftBtn.Visibility = Visibility.Hidden;

            // Showing the page number
            PageNumber.Content = $"{currentPageNumber}/{pageNumber}";
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber < pageNumber)
            {
                currentPageNumber++;
                if (currentPageNumber == pageNumber)
                {
                    RightBtn.Visibility = Visibility.Hidden;
                }

                LeftBtn.Visibility = Visibility.Visible;
            }

            PageNumber.Content = $"{currentPageNumber}/{pageNumber}";


            // Loads the text  
            if (currentPageNumber == 1)
                TB.Text = text1;
            else
                TB.Text = text2;

        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber--;
                if (currentPageNumber == 1)
                {
                    LeftBtn.Visibility = Visibility.Hidden;
                }

                RightBtn.Visibility = Visibility.Visible;
            }

            PageNumber.Content = $"{currentPageNumber}/{pageNumber}";

            // Loads the text  
            if (currentPageNumber == 1)
                TB.Text = text1;
            else
                TB.Text = text2;
        }
    }
}
