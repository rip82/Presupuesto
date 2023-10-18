namespace ManejoPresupuesto.Servicios
{
    public interface IRespositorioCuentas
    {

    }

    public class RepositorioCuentas: IRespositorioCuentas
    {
        private readonly string connectionString;
        public RepositorioCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
