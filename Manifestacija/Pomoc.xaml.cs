using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Manifestacija
{
    /// <summary>
    /// Interaction logic for Pomoc.xaml
    /// </summary>
    public partial class Pomoc : Window
    {
        public Pomoc()
        {
            InitializeComponent();
            
            //TreeView tree = new TreeView();
            /*TreeViewItem ceo = new TreeViewItem() { Header = "CEO" };
            TreeViewItem manager1 = new TreeViewItem() { Header = "Manager1" };
            TreeViewItem manager2 = new TreeViewItem() { Header = "Manager2" };
            TreeViewItem person1 = new TreeViewItem() { Header = "person1" };
            TreeViewItem person2 = new TreeViewItem() { Header = "person2" };

            manager1.Items.Add(person1);
            manager2.Items.Add(person2);
            ceo.Items.Add(manager1);
            ceo.Items.Add(manager2);
            tree.Items.Add(ceo);
            */
          
        }
        private void Manifestaciju_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za dodavanje nove manifestacije. \n\nManifestacija može da se doda ako je predhodno kreiran barem jedan tip. Etiketa može a ne mora biti kreirana."+
            "\n\nManifestacija može da se dodaje na tri načina:\n - Iz menija na sledeći način:\n\tKlikne se na Dodaj -> Manifestaciju\n - Prečicom sa tastature \"Ctrl + M\"\n - Pritiskom na prvo dugme iz palete sa alatkama.\n" +
            "\nOtvara se novi dijalog, gde nakon unosa podataka je potrebno pritisnuti na dugme \"Unesi\".";
        }

        private void Tip_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za dodavanje novog tipa. \n\nTip bi trebalo prvi da se kreira, jer bez kreiranog barem nednog tipa ne može da se kreira manifestacija." +
            "\n\nTip, kao i manifestacija, može da se dodaje na tri načina:\n - Iz menija na sledeći način:\n\tKlikne se na Dodaj -> Tip\n - Prečicom sa tastature \"Ctrl + T\"\n - Pritiskom na drugo dugme po redu iz palete sa alatkama.\n" +
            "\nOtvara se novi dijalog, gde nakon unosa podataka je potrebno pritisnuti na dugme \"Unesi\".";
        
        }

        private void Etiketu_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za dodavanje nove etikete. \n\nEtiketa može da se kreira u nezavsnosti od postojanja tipa i manifestacije. Etiketa može da postoji više, a ne mora ni jedna u manifestaciji" +
            "\n\nEtiketa može da se dodaje na tri načina:\n - Iz menija na sledeći način:\n\tKlikne se na Dodaj -> Etiketu\n - Prečicom sa tastature \"Ctrl + E\"\n - Pritiskom na treće dugme po redu iz palete sa alatkama.\n" +
            "\nOtvara se novi dijalog, gde nakon unosa podataka je potrebno pritisnuti na dugme \"Unesi\".";
        
        }

        private void Manifestacijuu_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za brisanje već kreirane manifestacije. \n\nManifestacija može da se obriše ako je predhodno kreirana i ako je selektovana u tabeli manifestacija." +
            "\n\nManifestacija može da se briše na tri načina. Da bi se obrisala prvo je potrebno da bude selektovana manifestacija iz tabele koju korisnik želi da obriše, a zatim \n - Iz menija na sledeći način:\n\tKlikne se na Obriši -> Manifestaciju\n - Prečicom sa tastature \"Delete\"\n - Pritiskom na četvro po redu dugme iz palete sa alatkama.";
        
        }

        private void Tipp_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za brisanje već kreiranog tipa. \n\nTip može da se obriše ako je predhodno kreiran i ako je selektovan u tabeli tipova." +
            "\n\nTip može da se briše na dva načina. Da bi se obrisao prvo je potrebno da bude selektovan tip iz tabele koju korisnik želi da obriše, a zatim \n - Iz menija na sledeći način:\n\tKlikne se na Obriši -> Tip\n - Pritiskom na peto po redu dugme iz palete sa alatkama.";
        
        }

        private void Etiketuu_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za brisanje već kreirane etikete. \n\nEtiketa može da se obriše ako je predhodno kreirana i ako je selektovana u tabeli etiketa." +
            "\n\nEtiketa može da se briše na dva načina. Da bi se obrisala prvo je potrebno da bude selektovana etiketa iz tabele koju korisnik želi da obriše, a zatim \n - Iz menija na sledeći način:\n\tKlikne se na Obriši -> Etiketu\n - Pritiskom na šesto po redu dugme iz palete sa alatkama.";
        
        }

        private void Manifestacijuuu_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za izmenu već kreirane, postojeće manifestacije. \n\nManifestacija može da se menja ako je predhodno kreirana i ako je selektovana u tabeli manifestacija." +
                        "\n\nManifestacija može da se menja na tri načina. Da bi se izmenila prvo je potrebno da bude selektovana manifestacija iz tabele koju korisnik želi da izmeni, a zatim \n - Iz menija na sledeći način:\n\tKlikne se na Izmeni -> Manifestaciju\n - Pritiskom na dugme sa tastature \"Ctrl + I\"\n - Pritiskom na sedmo po redu dugme iz palete sa alatkama.";
        
        }

        private void Tippp_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za izmenu već kreiranog, postojećeg tipa. \n\nTip može da se menja ako je predhodno kreiran i ako je selektovan u tabeli tipova." +
                       "\n\nTip može da se menja na dva načina. Da bi se izmenio prvo je potrebno da bude selektovan tip iz tabele koji korisnik želi da izmeni, a zatim \n - Iz menija na sledeći način:\n\tKlikne se na Izmeni -> Tip\n - Pritiskom na osmo po redu dugme iz palete sa alatkama.";
        
        }

        private void Etiketuuu_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za izmenu već kreirane, postojeće etikete. \n\nEtiketa može da se menja ako je predhodno kreirana i ako je selektovana u tabeli etiketa." +
                       "\n\nEtiketa može da se menja na dva načina. Da bi se izmenila prvo je potrebno da bude selektovana etiketa iz tabele koju korisnik želi da izmeni, a zatim \n - Iz menija na sledeći način:\n\tKlikne se na Izmeni -> Etiketu\n - Pritiskom na deveto po redu dugme iz palete sa alatkama.";
        
        }

        private void tabela_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za menjanje pregleda tabele po tabovima. Tabova ima 3 i sadrže vrednosti Manifestacija, Tip i Etiketa.\nSelektovanje se vrši pokazivačem (mišem).\nMoguć je uvek prelazak između tabova tj između tabela.";
        
        }

        private void Sacuvaj_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Služi za čuvanje sadržaja sa kojim se radi. Ako korisnik vrši izmene potrebno je na kraju sačuvati te izmene jer u suprotnom neće biti sačuvane.\n"+
                "Čuvanjem se čuva trenutni sadržaj tabela manifestacija, tipova i etiketa, kao i položaj manifestacija na mapi.\n"
                + "Čuvanje je moguće na tri načina izvršiti:\n - Iz menija na sledeći način: Sačuvaj -> Sačuvaj Manifestacije\n - Prečicom sa tastature \"S\"\n - Pritiskom na deseto po redu dugme iz palete sa alatkama.";
        }

        private void precice_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Prečice služe da bi korisnicima olakšale rad sa aplikacijom.\n\nAplikacija ima sledece prečice:\n"+
            "\tDodavanje nove manifestacije: Ctrl + M\n\tDodavanje novog tipa: Ctrl + T\n\tDodavanje nove etikete: Ctrl + E\n\tBrisanje postojeće manifestacije: Delete\n\tIzmena postojeće manifestacije: Ctrl + I\n\tČuvanje manifestacija: Ctrl + S\n\tPomoć: F1\n\tDemo: F2";
        }

        private void demo_Selected(object sender, RoutedEventArgs e)
        {
            text.Text = "Demo služi da novim korisnicima prikaže kako se sa aplikacojom manipuliše.";
        }



       
    }
}
