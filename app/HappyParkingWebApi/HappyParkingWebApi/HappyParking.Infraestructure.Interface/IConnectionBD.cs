using System.Data;

namespace HappyParking.Infraestructure.Interface
{
    public interface IConnectionBD
    {
        IDbConnection GetConnectionMySql { get; }
    }
}
