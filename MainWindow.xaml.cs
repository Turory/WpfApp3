using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Film> films = new ObservableCollection<Film>();

        ObservableCollection<Film> display = new ObservableCollection<Film>();

        ObservableCollection<string> genres = new ObservableCollection<string>();


        public MainWindow()
        {
            InitializeComponent();

            films.Add(new Film { Title = "Колобок", Genre = "Хоррор", Description = "страшное фэнтези и спин-офф популярной российской франшизы о Белогорье." });
            films.Add(new Film { Title = "Твое сердце будет разбито", Genre = "Хоррор", Description = "популярный роман в жанре молодежной прозы писательницы Анны Джейн." });
            films.Add(new Film { Title = "Чебурашка 3", Genre = "Кринж комедия", Description = "семейная комедия о мохнатом ушастом зверьке из далекой апельсиновой страны, который попадает в тихий приморский городок на Черном море." });
            films.Add(new Film { Title = "Алиса в Стране чудес", Genre = "Фэнтези", Description = "современная вольная адаптация сказки Льюиса Кэрролла, вдохновленная культовым советским радиоспектаклем 1976 года на стихи Владимира Высоцкого." });
            films.Add(new Film { Title = "Борат", Genre = "Черная комедия", Description = "сатирическая комедия в жанре мокьюментари, рассказывающая о путешествии эксцентричного казахстанского тележурналиста Бората Сагдиева в США." });
            //films.Add(new Film { Title = "", Genre = "", Description = "" });

            listFilm.ItemsSource = films;

            genres.Add("Хоррор");
            genres.Add("Кринж комедия");
            genres.Add("Фэнтези");
            genres.Add("Черная комедия");

            comboGenre.ItemsSource = genres;
        }

        private void comboGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGenre = comboGenre.SelectedItem.ToString();
            listFilm.ItemsSource = films.Where(f => f.Genre == selectedGenre).ToList();
        }

        private void showDesc_Click(object sender, RoutedEventArgs e)
        {
            if (listFilm.SelectedItem is Film selectedFilm)
            {
                txtDesc.Text = "Описание: " + selectedFilm.Description;
            }
            else
            {
                MessageBox.Show("Выберите фильм.");
            }
        }
    }
}