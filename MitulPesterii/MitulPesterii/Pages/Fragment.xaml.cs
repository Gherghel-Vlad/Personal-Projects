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
    /// Interaction logic for Fragment.xaml
    /// </summary>
    public partial class Fragment : Page
    {
        #region Texts

        private string tablou1text1 = "     \"«Mai departe — am zis — asemuiește firea noastră în privință educației cu următoarea" +
            " întâmplare: iată mai mulți oameni aflați într-o încăpere subpământeana, că într-o peșteră, al cărei" +
            " drum de intrare dă spre lumină, drum lung față de /lungimea/întregului peșterii. În această încăpere," +
            " ei se găsesc, încă din copilărie, cu picioarele și grumazurile legate, astfel încât trebuie să stea" +
            " locului și să privească doar înainte, fără să poată să-și rotească capetele din pricină legăturilor." +
            " Lumina le vine de sus și de departe, de la un foc aprins înapoia lor; iar între foc și oamenii legați," +
            " este un drum așezat mai sus, de-a lungul căruia, iată, e zidit un mic perete, așa cum este paravanul" +
            " scamatorilor, pus dinaintea celor ce privesc, deasupra cărora își arată ei scamatoriile .... »  " +
            "\n«Văd»-spuse el.  ";

        private string tablou1text2 = "     «... mai încearcă să vezi și că, de-a lungul acestui perete, niște" +
            " oameni poartă felurite obiecte care depășesc în înălțime zidul, mai poartă și statui de oameni," +
            " că și alte făpturi de piatră sau lemn, lucrate în chipul cel mai divers. lar dintre cei care le" +
            " poartă, unii, cum e și firesc, scot sunete, alții păstrează tăcerea.»\n «Ciudata imagine și ciudați" +
            " sunt oamenii legați! »\n «Sunt asemănători nouă-am spus. Căci crezi că astfel de oameni au văzut, mai" +
            " întâi, din ei înșiși, cât și din soții lor, altceva decât umbrele care cad, aruncate, de foc, pe" +
            " zidul de dinaintea lor?»\" \n„«lar dacă ei ar fi în stare să stea de vorba unii cu alții, nu crezi" +
            " că oamenii noștri ar socoti că, numind aceste umbre pe care le văd, ei numesc realitatea?»\"\n \"«În" +
            " general, deci-am spus eu-asemenea oameni nu ar putea lua drept adevăr decât umbrele lucrurilor. »" +
            " \n«E cu totul obligatoriu.»  ";

        private string tablou1semnificatie = "     Prima treaptă a cunoașterii: înlănțuirea oamenilor și contactul lor" +
            " cu umbrele.\n •condiția omului: Mai mulți oameni se află într-o încăpere subpământeana, ca într-o peșteră." +
            " Ei stau din copilărie legați de picioare și de grumaz, încât nu pot privi decât înainte. Lumina le vine" +
            " de sus și din spate de la un foc. Între ei și foc e un drum așezat mai sus, iar de- a lungul lui, un zid," +
            " prin spatele căruia trec alți oameni, purtând statui de oameni și tot felul de lucruri situate deasupra" +
            " paravanului.\n •consecința ontologică: pentru cei legați, realitatea constă în mod necesar în umbrele lor," +
            " ale semenilor, ale obiectelor proiectate pe perete.\n •consecinta gnoseologica: cei legați consideră drept" +
            " adevăr doar ceea ce văd: umbrele, lucrurile.  ";

        private string tablou2text1 = "     «Privește acum în ce fel ar putea fi dezlegarea lor din lanțuri și vindecarea" +
            " de lipsa lor de minte, dacă așa ceva le-ar sta în fire: atunci când vreunul dintre ei s-ar pomeni" +
            " dezlegat și silit, deodată, să se ridice, să-și rotească grumazul, să umble și să privească spre" +
            " lumină, făcând el toate acestea, ar resimți tot felul de dureri, iar din pricina strălucirii focului" +
            " n-ar putea privi acele obiecte, ale căror umbre le văzuse înainte. Ce crezi că ar zice, dacă cineva" +
            " i-ar spune că ceea ce văzuse mai înainte erau deșertăciuni, dar că acum se află mai aproape de ceea" +
            "-ce-este și că, întors către ceea-ce-este în mai mare măsură vede mai conform cu adevărul? În plus, dacă," +
            " arătându-i-l pe fiecare dintre obiectele purtate, l-ar sili, prin întrebări, să răspundă ce anume este lucrul" +
            " respectiv? Nu crezi că el s-ar putea afla în încurcătură și că ar putea socoti că cele văzute mai înainte" +
            " erau mai adevărate decât cele arătate acum?» ";

        private string tablou2text2 = "     \"«Iar, dacă l-ar sili să privească spre lumina însăși, nu crezi că" +
            " l-ar durea ochii și că ar da fuga îndărăt, întorcându-se spre acele lucruri pe care poate să le vadă" +
            " și că le-ar socoti pe acestea, în fapt, mai sigure decât cele arătate?»\"\n «Chiar așa!» ";

        private string tablou2semnificatie = "      A doua treaptă a cunoașterii: eliberarea din lanțuri și dificultatea" +
            " contactului cu lucrurile reale.\n • condiția omului: ce-l care este dezlegat silit să-și rotească grumazul" +
            " și să privească spre lumină, datorită strălucirii focului, nu va putea privi obiectele reale.\n" +
            " •consecința ontologică: el nu acceptă ca cele pe care le văzuse mai înainte erau deșertăciuni ca" +
            " lucrurile către care se află întors acum constituie „ceea-ce-este în mai mare măsură\".\n" +
            "•consecința gnoseologică: el nu va accepta nici că, întors spre lucrurile reale, „vede mai" +
            " conform cu adevărul\" va fugi îndărăt socotind că umbrele lucrurilor sunt mai sigure decât lucrurile reale. ";

        private string tablou3text1 = "     «Dar, dacă cineva l-ar smulge cu forța din locuința aceasta, ducându-l pe un suiș" +
            " greu pieptiș, nedându-i drumul până ce nu l-ar fi tras la lumina soarelui, oare nu ar suferi și nu s-ar mânia" +
            " că e tras? Iar când ar ieși la soare, nu i s-ar umple ochii de strălucire, astfel încât nu ar putea vedea" +
            " nimic din lucrurile socotite acum adevărate?»\"\n \"«Cred că ar avea nevoie de obișnuință, dacă ar fi ca el" +
            " să vadă lumea cea de sus. Iar mai întâi, el ar vedea mai lesne umbrele, după aceea oglindirile oamenilor și" +
            " ale celorlalte lucruri, apoi lucrurile ele însele. În continuare, i-ar fi mai ușor să privească în timpul nopții" +
            " ceea ce e pe cer și cerul însuși, privind, deci, lumina stelelor și a lunii mai curând decât, în timpul zilei" +
            ", soarele și lumina sa».\"\n „«La urmă, el va privi soarele, nu în apă, nici reflexiile sale în vreun loc străin," +
            " ci l-ar putea vedea și contempla, așa cum este, pe el însuși, în locul său propriu. »\" ";

        private string tablou3text2 = "     «După aceasta, ar cugeta în legătură cu soarele, cum că acesta determină anotimpurile" +
            " anii, că, el cârmuiește totul în lumea vizibilă, fiind cumva răspunzător și pentru toate imaginile acelea, văzute" +
            " de ei / în peșteră/.»\n «E clar că aici ar ajunge, după ce va fi străbătut toate celelalte etape.»\n «Ei, și nu crezi" +
            " că, dacă omul acesta și-ar aminti de prima sa locuință, de înțelepciunea de acolo, ca de părtașii săi la lanțuri," +
            " el s-ar socoti pe sine fericit de pe urma schimbării, iar de ceilalți nu i-ar fi milă?»\n «Cu totul.» \n«lar dacă la" +
            " ei ar exista laude și cinstiri și s-ar da răsplata celui mai ager în a vedea umbrele ce trec alături și care își" +
            " amintește cel mai bine cele ce, de obicei, se preced, se succed sau trec laolaltă, și care, în temeiul acestor observații," +
            " ar putea cel mai bine să prezică ce urmează în viitor să se mai întâmple, ";

        private string tablou3text3 = "     \"ți se pare oare că omul nostru ar putea să poftească răsplățile acelea să-i invidieze" +
            " pe cei onorați la ei și cei aflti la putere? Sau ar simți ce spune Homer, voind nespus mai degraăi argat să fie pe pământ" +
            " la cineva neînsemnat, sărman și fără de stare, consimțind să pâță orișice, mai degrabă decât să aibă părerile de acolo" +
            " și să trăiască în acel chip?»\"";

        private string tablou3semnificatie = "      A treia treaptă a cunoașterii: ieșirea din peșteră și contemplarea lucrurilor reale în" +
            " lumina soarelui\n • condiția omului: dacă cel dezlegat ar fi împins cu forța spre lumea de afară, acesta ar urca cu greum," +
            " ar fi mânios că e tras, iar odată ajuns afară, la început ar fi orbit de lumină nu va vedea nimic, apoi se va obișnui" +
            " treptat cu lucrurile.\n •consecința ontologică - gnoseologică:\n • mai întâi, el va vedea mai ușor umbrele lucrurilor, apoi" +
            " oglindirile lor, în cele din urmă, lucrurile reale\n • va privi mai upr stelele și luna, iar apoi soarele\n • cugetând în" +
            " legătură cu soarele, își va da seama ca acesta „ cârmuiește totul în lumea vizibilă„ și că e răspunzător de imaginile lucrurilor. ";

        private string tablou4text1 = "     \"«Mai gândește-te și la următorul aspect: dacă, iarăși, acel om coborând, s-ar așeza în același scaun de unde" +
            " a plecat, oare nu ar avea ochii plini de întunecime, sosind deodată dinspre lumea însorită?»\n «Ba da» - zise.\n «lar dacă el ar" +
            " trebui din nou că, interpretând umbrele acelea, să se ia la întrecere cu oamenii ce au rămas totdeauna legați și dacă ar trebui" +
            " s-o facă chiar în clipa când nu vede bine, înainte de a- și obișnui ochii, iar dacă acest timp cerut de reobișnuire nu ar fi" +
            " cu totul scurt, oare nu ar da el prilej de râs? Și nu s-ar spune despre el că, după ce s-a urcat, a revenit cu vederea comptă" +
            " și că, deci, nici nu merită să încerci a sui? lar pe cel ce încearcă să-i dezlege și să-i conducă pe drum în sus, în caz că" +
            " ei ar putea să pună mâinile pe el și să-l ucidă, oare nu l-ar ucide?»\n «Ba chiar așa.» ";

        private string tablou4text2 = "     «Iată, dragă Glaucon, - am spus eu - imaginea care trebuie, în întregime pusă în legătură" +
            " cu cele zise mai înainte: domeniul deschis vederii e asemănător cu locuință-închisoare, lumina focului din ea - eu" +
            " puterea soarelui. Iar dacă, ai socoti urcușul contemplarea lumii de sus ca reprezentând suișul sufletului către locul" +
            " inteligibilului, ai înțelege mai bine ceea ce nădăjduiam să spun, de vreme ce așa ceva ai dorit să asculți. Dacă deznădejdea" +
            " aceasta e îndreptățită, Zeul o știe. Opiniile mele, însă, acestea sunt, anume că în domeniul inteligibilului, mai presus de" +
            " toate, este ideea Binelui, că ea este anevoie de văzut, dar că, odată văzută, ea trebuie concepută ca fiind pricina pentru" +
            " tot ce-i drept și frumos; ea zămislește în domeniul vizibil lumina și pe domnul acesteia, iar în domeniul inteligibil, chiar" +
            " ea domnește, producând adevăr și intelect; și iarăși cred că cel ce voiește să facă ceva cugetat în viața privată sau în cea" +
            " publică trebuie s-o contemple.»\" ";

        private string tablou4semnificatie = "      A patra treaptă a cunoașterii: revenirea în peștera\n • condiția omului: situația celui" +
            " ce revine în peșteră\n • cel ce revine din lumea de afară și se așează în peșteră pe locul de unde a plecat, la început din cauza" +
            " întunecimii, nu va vedea bine și nu va putea să recunoască umbrele de pe perete. De aceea cei din peștera vor spune că a" +
            " revenit cu privirea coruptă și nu merită să încerci să urci la lumină\n • va fi luat în derâdere și chiar ucis dacă cei" +
            " legați s-ar elibera ";
        #endregion

        #region Properties

        private List<Button> menuButtons;

        private List<Button> menuButtonsImage;

        private Button buttonPressed;

        private int pageNumber = 2;

        private int currentPageNumber = 1;


        #endregion

        public Fragment()
        {
            InitializeComponent();

            MenuButtonsEnabled.CanPressMenuButtons = true;

            menuButtons = new List<Button>();
            menuButtonsImage = new List<Button>();
            buttonPressed = new Button();

            // Adding the menu buttons to the list so i can control them easier
            menuButtons.Add(Tablou1Btn);
            menuButtons.Add(Tablou1BtnSemnification);
            menuButtons.Add(Tablou2Btn);
            menuButtons.Add(Tablou2BtnSemnification);
            menuButtons.Add(Tablou3Btn);
            menuButtons.Add(Tablou3BtnSemnification);
            menuButtons.Add(Tablou4Btn);
            menuButtons.Add(Tablou4BtnSemnification);

            menuButtonsImage.Add(Tablou1BtnImage);
            menuButtonsImage.Add(Tablou2BtnImage);
            menuButtonsImage.Add(Tablou3BtnImage);
            menuButtonsImage.Add(Tablou4BtnImage);

            //Adding the first text
            TB.Text = tablou1text1;

            //Showing/hiding the default arrow set
            RightBtn.Visibility = Visibility.Visible;
            LeftBtn.Visibility = Visibility.Hidden;

            // Default button pressed will always be the Tabloul 1
            Tablou1Btn.IsEnabled = false;
            Tablou1Btn.Opacity = 0.75;
            buttonPressed = Tablou1Btn;

            // Showing the page number
            PageNumber.Content = $"{currentPageNumber}/{pageNumber}";

            // adding the functionality for buttons
            foreach (var button in menuButtons)
            {
                button.Click += Button_Click;
            }
            foreach (var button in menuButtonsImage)
            {
                button.Click += Button_Click1;
            }

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            RightBtn.Visibility = Visibility.Hidden;
            LeftBtn.Visibility = Visibility.Hidden;

            var btn = sender as Button;

            Image.Source = new BitmapImage( new Uri(ImagePath(btn.Name), UriKind.Absolute));

            //Doing the pressed effect and functionality
            foreach (var button in menuButtons)
            {
                button.Opacity = 1;
                button.IsEnabled = true;
            }
            foreach (var button in menuButtonsImage)
            {
                button.Opacity = 1;
                button.IsEnabled = true;
            }
            btn.Opacity = 0.75;
            btn.IsEnabled = false;

            TB.Visibility = Visibility.Hidden;
            Image.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            buttonPressed = btn;

            TB.Visibility = Visibility.Visible;
            Image.Visibility = Visibility.Hidden;

            pageNumber = NumberOfPages(btn.Name);

            // Resolving the cases for the label that shows the number of pages
            if (pageNumber > 1)
            {
                currentPageNumber = 1;
                PageNumber.Content = $"{currentPageNumber}/{pageNumber}";
                RightBtn.Visibility = Visibility.Visible;
            }
            else
                if (pageNumber == 1)
            {
                PageNumber.Content = string.Empty;
                RightBtn.Visibility = Visibility.Hidden;
                LeftBtn.Visibility = Visibility.Hidden;
            }

            // Loads the first paragraf
            TB.Text = Texts(btn.Name, 1);

            //Doing the pressed effect and functionality
            foreach (var button in menuButtons)
            {
                button.Opacity = 1;
                button.IsEnabled = true;
            }
            foreach (var button in menuButtonsImage)
            {
                button.Opacity = 1;
                button.IsEnabled = true;
            }
            btn.Opacity = 0.75;
            btn.IsEnabled = false;

        }

        #region Helpers

        /// <summary>
        /// Returns the number of pages for the button name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int NumberOfPages(string name)
        {
            switch (name)
            {
                case "Tablou1Btn":
                    return 2;
                case "Tablou2Btn":
                    return 2;
                case "Tablou4Btn":
                    return 2;
                case "Tablou3Btn":
                    return 3;
                default: return 1;
            }
        }


        /// <summary>
        /// Returns the text content for the specified button
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string Texts(string name, int page = 1)
        {
            switch (name)
            {
                case "Tablou1Btn":
                    {
                        switch (page)
                        {
                            case 1: return tablou1text1;
                            case 2: return tablou1text2;
                            default: return tablou1text1;
                        }
                    }
                case "Tablou2Btn":
                    {
                        switch (page)
                        {
                            case 1: return tablou2text1;
                            case 2: return tablou2text2;
                            default: return tablou2text1;
                        }
                    }
                case "Tablou4Btn":
                    {
                        switch (page)
                        {
                            case 1: return tablou4text1;
                            case 2: return tablou4text2;
                            default: return tablou4text1;
                        }
                    }
                case "Tablou3Btn":
                    {
                        switch (page)
                        {
                            case 1: return tablou3text1;
                            case 2: return tablou3text2;
                            case 3: return tablou3text3;
                            default: return tablou3text1;
                        }
                    }
                case "Tablou1BtnSemnification":
                    return tablou1semnificatie;
                case "Tablou2BtnSemnification":
                    return tablou2semnificatie;
                case "Tablou3BtnSemnification":
                    return tablou3semnificatie;
                case "Tablou4BtnSemnification":
                    return tablou4semnificatie;
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Returns the path to the image based on the button s name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string ImagePath(string name)
        {
            switch(name)
            {
                case "Tablou1BtnImage":
                    return @"pack://application:,,,/Images/Pictures/Tablou1Pic.jpg";
                case "Tablou2BtnImage":
                    return @"pack://application:,,,/Images/Pictures/Tablou2Pic.jpg";
                case "Tablou3BtnImage":
                    return @"pack://application:,,,/Images/Pictures/Tablou3Pic.jpg";
                case "Tablou4BtnImage":
                    return @"pack://application:,,,/Images/Pictures/Tablou4Pic1.jpg";
                default: return @"pack://application:,,,/Images/Pictures/Tablou1Pic.jpg";
            }
        }

        #endregion

        /// <summary>
        /// Functionality for the left arrow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentPageNumber > 1)
            {
                currentPageNumber--;
                if(currentPageNumber == 1)
                {
                    LeftBtn.Visibility = Visibility.Hidden;
                }

                RightBtn.Visibility = Visibility.Visible;
            }

            PageNumber.Content = $"{currentPageNumber}/{pageNumber}";

            // Loads the text  
            TB.Text = Texts(buttonPressed.Name, currentPageNumber);
        }

        /// <summary>
        /// Functionality for the right arrow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            TB.Text = Texts(buttonPressed.Name, currentPageNumber);
        }
    }
}
