using sem5Tapia.Models;

namespace sem5Tapia.Vistas;

public partial class vPrincipal : ContentPage
{
    public vPrincipal()
    {
        InitializeComponent();
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> people = App.personRepo.GetAllPeorle();
        ListaPersona.ItemsSource = people;
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessageE.Text = "";

        if (!int.TryParse(txtEliminar.Text, out int personId))
        {
            statusMessageE.Text = "Ingrese un ID válido.";
            return;
        }

        // Llama al método de eliminación en tu repositorio
        App.personRepo.DeletePerson(personId);

        // Actualiza la lista después de la eliminación
        List<Persona> people = App.personRepo.GetAllPeorle();
        ListaPersona.ItemsSource = people;

        statusMessageE.Text = "Persona eliminada exitosamente.";

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessageA.Text = "";

        if (!int.TryParse(txtActualizar.Text, out int personId))
        {
            statusMessageA.Text = "Ingrese un ID válido.";
            return;
        }

        string updatedName = txtActualizar1.Text;

        if (string.IsNullOrEmpty(updatedName))
        {
            statusMessageA.Text = "Ingrese el nuevo nombre.";
            return;
        }

        Persona selectedPerson = App.personRepo.GetPersonById(personId);

        if (selectedPerson != null)
        {

            selectedPerson.Name = updatedName;


            App.personRepo.UpdatePerson(selectedPerson);


            List<Persona> people = App.personRepo.GetAllPeorle();
            ListaPersona.ItemsSource = people;

            statusMessageA.Text = "Persona actualizada exitosamente.";
        }
        else
        {
            statusMessageA.Text = "Persona no encontrada.";
        }
    }
}