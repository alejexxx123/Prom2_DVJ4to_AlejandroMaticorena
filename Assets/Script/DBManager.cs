using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System;
using Mono.Data.Sqlite;

public class DBManager : MonoBehaviour {
    private string connectionString;
    
	// Use this for initialization
	void Start () {
	    connectionString = "URI=file:" + Application.dataPath + "/Payday2DB.sqlite";
        Debug.Log(connectionString);
        //InsertCharacter(2,1,"Jose",6,8,10); // puede añadir datos a la DB, solo esta comentado para no añadir cada compilada.
        GetCharacter();
        Debug.Log("*/------------------------------------------/*");
        GetMask();
        Debug.Log("*/------------------------------------------/*");
        GetSkill();
        Debug.Log("*/------------------------------------------/*");
        GetWeapon();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void GetCharacter()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) 
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand()) 
            {
                string sqlQuery = "SELECT * FROM Character"; 
                dbCommand.CommandText = sqlQuery; 
                using (IDataReader reader = dbCommand.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        Debug.Log("ID: " + reader.GetInt32(0) + "- " + "ID Weapon: " + reader.GetInt32(1) + "-" + "ID Mask:" + reader.GetInt32(2)
                            + " -" + "Name: " + reader.GetString(3) + "-" + "Armor: " + reader.GetInt32(4) + "- " + "Health: " + reader.GetInt32(5) + "- " +
                            "Speed: " + reader.GetInt32(6));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }


        }
    }
    private void GetMask()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Mask";
                dbCommand.CommandText = sqlQuery;
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("ID: " + reader.GetInt32(0) + "- " + "Name: " + reader.GetString(1) + "-" + "Description: " + reader.GetString(2) + "- " + "Health: " + reader.GetInt32(3) + "- " +
                            "Cost: " + reader.GetInt32(3));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }


        }
    }
    private void GetSkill()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Skill";
                dbCommand.CommandText = sqlQuery;
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("ID: " + reader.GetInt32(0) + "- " + "Name: " + reader.GetString(1) + "-" + "Mod Ammo:" + reader.GetInt32(2)
                            + " -" + "Mod Accury: " + reader.GetInt32(3) ) ;
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }


        }
    }

    private void GetWeapon()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Weapon";
                dbCommand.CommandText = sqlQuery;
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("ID: " + reader.GetInt32(0) + "- " + "ID Skill: " + reader.GetInt32(1) + "-" + "Name: " + reader.GetString(2) + "-" + "Total Ammo: " + reader.GetInt32(3) + "- " + "Damage: " + reader.GetInt32(4) + "- " +
                            "Accuracy: " + reader.GetInt32(5));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }


        }
    }

    private void InsertCharacter(int id_weapon, int id_mask, string name, int armor, int health, int speed)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) 
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand()) 
            {
                string sqlQuery = string.Format("INSERT INTO Character(ID_Weapon, ID_Mask, Name, Armor, Health, Speed) VALUES(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", id_weapon, id_mask, name, armor, health, speed);
              
                dbCommand.CommandText = sqlQuery; 
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }


        }
    }


}
