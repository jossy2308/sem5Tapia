namespace sem5Tapia
{
    public partial class App : Application
    {
        public static PersonaRepository personRepo { get; set; }
        public App(PersonaRepository personRepository)
        {
            InitializeComponent();

            MainPage = new Vistas.vPrincipal ();
            personRepo = personRepository;
        }
    }
}
