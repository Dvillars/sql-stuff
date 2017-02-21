using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory
{
  public class InventoryTest : IDisposable
  {
    public InventoryTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=inventory_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Bills_PC.GetAll().Count;
      int resultTest = 0;

      //Assert
      Assert.Equal(resultTest, result);
    }

    [Fact]
    public void Test_Save()
    {
        Bills_PC testPokemon = new Bills_PC(001, "Bulbasaur", "Sprite", 11);
        testPokemon.Save();
        List<Bills_PC> result = Bills_PC.GetAll();
        Console.WriteLine(result[0].GetDex() + " " + result[0].GetName() + " " + result[0].GetNick() + " " + result[0].GetLv());
        string resultTest = "Bulbasaur";
        Assert.Equal(resultTest, result[0].GetName());
    }

    public void Dispose()
    {
      Bills_PC.DeleteAll();
    }
  }
}
