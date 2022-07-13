namespace TP6.Models;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

public class BD {

    private static string _connectionString = 
        @"Server=A-AMI-202;DataBase=Qatar22;Trusted_Connection=True";

    

    public static void AgregarJugador(Jugador Jug ){

        string sql = "INSERT INTO Jugadores  (IdEquipo,Nombre,FechaNacimiento) VALUES (@pNombre, pIdEquipo, pFechaNacimiento,)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = Jug.Nombre, pIdEquipo = Jug.IdEquipo,pFechaNacimiento = Jug.FechaNacimiento});
        }
       
    }

    public static void EliminarJugador(int IdJugador){
        string sql = "DELETE FROM Jugadores WHERE IdJugador = @pIdJugador";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdJugador = IdJugador });
        }
    }
public static Equipo VerInfoEquipo(int IdEquipo)
{
    Equipo MiEquipo=null;
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Equipo WHERE IdEquipo=@pIdEquipo ";
        MiEquipo= db.QueryFirstOrDefault<Equipo>(sql,new {pIdEquipo=IdEquipo});
       
       }
        return MiEquipo;
    }
   public static Jugador VerInfoJugador(int IdJugador)
{
    Jugador MiJugador=null;
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Jugadores WHERE IdJugador=@pIdJugador ";
       MiJugador= db.QueryFirstOrDefault<Jugador>(sql,new {pIdJugador=IdJugador});
       
       }
        return MiJugador;
    }
    public static void Equipo ListarEquipos()
{
    
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Equipo";
        _ListadoEquipos= db.Query<Equipo>(sql).ToList();
       
       }

}
}