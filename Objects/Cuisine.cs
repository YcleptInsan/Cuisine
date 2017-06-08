using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BestRestaurants
{
  public class Cuisine
  {
    private int _id;
    private string _type;

    public Cuisine(string type, int id = 0)
    {
      _type = type;
      _id = id;
    }

    public override bool Equals(System.Object otherCuisine)
    {
        if (!(otherCuisine is Cuisine))
        {
          return false;
        }
        else
        {
          Cuisine newCuisine = (Cuisine) otherCuisine;
          bool idEquality = this.GetId() == newCuisine.GetId();
          bool typeEquality = this.GetType() == newCuisine.GetType();
          return (idEquality && typeEquality);
        }
    }

    public int GetId()
    {
      return _id;
    }
    public string GetType()
    {
      return _type;
    }
    public void SetType(string newType)
    {
      _type = newType;
    }
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisine = new List<Cuisine>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisine;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int cuisineId = rdr.GetInt32(0);
        string cuisineType = rdr.GetString(1);
        Cuisine newCuisine = new Cuisine(cuisineType, cuisineId);
        allCuisine.Add(newCuisine);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allCuisine;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO cuisine (type) OUTPUT INSERTED.id VALUES (@CuisineType);", conn);

      SqlParameter typeParameter = new SqlParameter();
      typeParameter.ParameterName = "@CuisineType";
      typeParameter.Value = this.GetType();
      cmd.Parameters.Add(typeParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM cuisine;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static Cuisine Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisine WHERE id = @CuisineId;", conn);
      SqlParameter cuisineIdParameter = new SqlParameter();
      cuisineIdParameter.ParameterName = "@CuisineId";
      cuisineIdParameter.Value = id.ToString();
      cmd.Parameters.Add(cuisineIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundCuisineId = 0;
      string foundCuisineDescription = null;

      while(rdr.Read())
      {
        foundCuisineId = rdr.GetInt32(0);
        foundCuisineDescription = rdr.GetString(1);
      }
      Cuisine foundCuisine = new Cuisine(foundCuisineDescription, foundCuisineId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundCuisine;
    }

    public List<Restaurant> GetRestaurants()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant WHERE cuisine_id = @CuisineId;", conn);
     SqlParameter cuisineIdParameter = new SqlParameter();
     cuisineIdParameter.ParameterName = "@CuisineId";
     cuisineIdParameter.Value = this.GetId();
     cmd.Parameters.Add(cuisineIdParameter);
     SqlDataReader rdr = cmd.ExecuteReader();

     List<Restaurant> restaurants = new List<Restaurant> {};
     while(rdr.Read())
     {
       int restaurantId = rdr.GetInt32(0);
       string restaurantName = rdr.GetString(1);
       int restaurantCuisineId = rdr.GetInt32(2);
       Restaurant newRestaurant = new Restaurant(restaurantName, restaurantCuisineId, restaurantId);
       restaurants.Add(newRestaurant);
     }
     if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }
     return restaurants;
   }

   public void Update(string newType)
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("UPDATE cuisine SET type = @NewType OUTPUT INSERTED.type WHERE id = @CuisineId;", conn);

    SqlParameter newTypeParameter = new SqlParameter();
    newTypeParameter.ParameterName = "@NewType";
    newTypeParameter.Value = newType;
    cmd.Parameters.Add(newTypeParameter);


    SqlParameter cuisineIdParameter = new SqlParameter();
    cuisineIdParameter.ParameterName = "@CuisineId";
    cuisineIdParameter.Value = this.GetId();
    cmd.Parameters.Add(cuisineIdParameter);

    SqlDataReader rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      this._type = rdr.GetString(0);
    }

    if (rdr != null)
    {
      rdr.Close();
    }

    if (conn != null)
    {
      conn.Close();
    }
    }

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM cuisine WHERE id = @CuisineId; DELETE FROM restaurant WHERE cuisine_id = @CuisineId;", conn);

      SqlParameter cuisineIdParameter = new SqlParameter();
      cuisineIdParameter.ParameterName = "@CuisineId";
      cuisineIdParameter.Value = this.GetId();

      cmd.Parameters.Add(cuisineIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
