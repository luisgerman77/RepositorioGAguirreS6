using Newtonsoft.Json;
using System.Collections.ObjectModel;


namespace GAguirreS6.Views;

public partial class vEstudiante : ContentPage
{
    private const string Url = "http://10.2.7.123/semana6/estudiantews.php";

    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Models.Estudiante> estudiante;

    public vEstudiante()
	{
		InitializeComponent();
        visualizar();
    }
    public async void visualizar()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Models.Estudiante> visualizar = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
        estudiante = new ObservableCollection<Models.Estudiante>(visualizar);
        listaEstudiantes.ItemsSource = estudiante;
    }
}