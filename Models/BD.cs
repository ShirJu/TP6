namespace TP6.Models;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class BD 
{
    private static List<Jugador> _ListadoJugadores = new List<Jugador>();
    private static string _connectionString = 
        @"Server=A-PHZ2-AMI-003;DataBase=Qatar2022;Trusted_Connection=True";

    public static void  GuardarJugador(Jugador Jug)
    {
        
        string sql = "INSERT INTO Jugadores (IdEquipo,Nombre,FechaNacimiento,Foto,EquipoActual) VALUES (@pIdEquipo, @pNombre,  @pFechaNacimiento, @pFoto, @pEquipoActual)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            //crea un nuevo jugador en la base de datos con los valores de jug
            db.Execute(sql, new {  pIdEquipo = Jug.IdEquipo, pNombre = Jug.Nombre, pFechaNacimiento = Jug.FechaNacimiento, pFoto = Jug.Foto, pEquipoActual=Jug.EquipoActual});
        } 
        
    }

    public static int EliminarJugador(int IdJugador)
    {
        
        string sql = "DELETE FROM Jugadores WHERE IdJugador = @pIdJugador";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Execute(sql, new { pIdJugador = IdJugador });
        }
    }
    
    public static Equipo VerDetalleEquipo(int IdEquipo)
    {
        Equipo MiEquipo;
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Equipos WHERE IdEquipo=@pIdEquipo ";
        MiEquipo=  db.QueryFirstOrDefault<Equipo>(sql,new {pIdEquipo=IdEquipo});
       
       }
        return MiEquipo;
    }
    public static Jugador VerInfoJugador(int IdJugador)
    {
        Jugador MiJugador;
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Jugadores WHERE IdJugador=@pIdJugador ";
       MiJugador= db.QueryFirstOrDefault<Jugador>(sql,new {pIdJugador=IdJugador});
       
       }
        return MiJugador;
    }
    public static List<Equipo> ListarEquipos()
    {
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
       
        string sql = "SELECT * FROM Equipos";
        return db.Query<Equipo>(sql).ToList();
       
       }
      

    }
    public static List<Jugador> ListarJugadores(int IdEquipo)
    {

       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Jugadores where IdEquipo=@pIdEquipo";
        _ListadoJugadores =db.Query<Jugador>(sql,new{pidEquipo=IdEquipo}).ToList();
       
       }
       return _ListadoJugadores;
    }
}
