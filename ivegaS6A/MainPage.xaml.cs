using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ivegaS6A
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.56.1/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<ivegaS6A.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            this.obtener();
        }

        public async void obtener()
        {
            var content = await client.GetStringAsync(Url);
            List<ivegaS6A.Datos> posts = JsonConvert.DeserializeObject<List<ivegaS6A.Datos>>(content);
            _post = new ObservableCollection<ivegaS6A.Datos>(posts);
            MyListView.ItemsSource = _post;
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnGet_Clicked(object sender, EventArgs e)
        {

        }
    }
}
