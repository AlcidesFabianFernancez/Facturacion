using Npgsql;

namespace Factura.Clases
{
    internal class NpgqlCommand
    {
        private string sql;
        private NpgqlCommand cone;

        public NpgqlCommand(string sql, NpgqlCommand cone)
        {
            this.sql = sql;
            this.cone = cone;
        }

        public NpgqlCommand(string sql, NpgsqlConnection cone1)
        {
            this.sql = sql;
            Cone = cone1;
        }

        public NpgsqlConnection Cone { get; }
    }
}