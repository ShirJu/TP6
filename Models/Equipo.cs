namespace TP6.Models;

public class Equipo
{
    private int _idEquipo;
    private string _nombre;
    private string _escudo;
    private string _camiseta;
    private string _continente;
    private int _copasGanadas;

    public Equipo(string nombre, string escudo, string camiseta, string continente, int copasGanadas)
    {
        _nombre = nombre;
        _escudo = escudo;
        _camiseta = camiseta;
        _continente = continente;
        _copasGanadas = copasGanadas;
    }

    public Equipo()
    {
        _idEquipo = 0;
        _nombre = "";
        _escudo = "";
        _camiseta = "";
        _continente = "";
        _copasGanadas = 0;
    }


    public int IdEquipo
    {
        get
        {
            return _idEquipo;
        }
        set{
            _idEquipo = value;
        }
    }

     public string Nombre
    {
        get
        {
            return _nombre;
        }
        set{
            _nombre = value;
        }
    }

    public string Escudo
    {
        get
        {
            return _escudo;
        }
        set{
            _escudo = value;
        }
    }

    public string Camiseta
    {
        get
        {
            return _camiseta;
        }
        set{
            _camiseta = value;
        }
    }

    public string Continente
    {
        get
        {
            return _continente;
        }
        set{
            _continente = value;
        }
    }

    public int CopasGanadas
    {
        get
        {
            return _copasGanadas;
        }
        set{
            _copasGanadas = value;
        }
    }

}