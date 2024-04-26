namespace AppCrudNet8.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public string Correo { get; set; }

        public DateTime FechaContrato { get; set; }

        public bool Activo { get; set; }
    }
}
