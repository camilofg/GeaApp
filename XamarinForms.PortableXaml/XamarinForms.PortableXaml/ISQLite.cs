using SQLite;

namespace XamarinForms.PortableXaml
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
