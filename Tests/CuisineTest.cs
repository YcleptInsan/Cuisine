// using Xunit;
// using System.Collections.Generic;
// using System;
// using System.Data;
// using System.Data.SqlClient;
//
// namespace BestRestaurants
// {
//   public class CuisineTest : IDisposable
//   {
//     public CuisineTest()
//     {
//       DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurant_test;Integrated Security=SSPI;";
//     }
//     public void Dispose()
//     {
//       Restaurant.DeleteAll();
//       Cuisine.DeleteAll();
//     }
//
//     [Fact]
//     public void Test_CategoriesEmptyAtFirst()
//     {
//       //Arrange, Act
//       int result = Cuisine.GetAll().Count;
//
//       //Assert
//       Assert.Equal(0, result);
//     }
//
//     [Fact]
//     public void Test_Equal_ReturnsTrueForSameName()
//     {
//       //Arrange, Act
//       Cuisine firstCuisine = new Cuisine("Household chores");
//       Cuisine secondCuisine = new Cuisine("Household chores");
//
//       //Assert
//       Assert.Equal(firstCuisine, secondCuisine);
//     }

    // [Fact]
    // public void Test_Save_SavesCuisineToDatabase()
    // {
    //   //Arrange
    //   Cuisine testCuisine = new Cuisine("Household chores");
    //   testCuisine.Save();
    //
    //   //Act
    //   List<Cuisine> result = Cuisine.GetAll();
    //   List<Cuisine> testList = new List<Cuisine>{testCuisine};
    //
    //   //Assert
    //   Assert.Equal(testList, result);
    // }

    // [Fact]
    // public void Test_Save_AssignsIdToCuisineObject()
    // {
    //   //Arrange
    //   Cuisine testCuisine = new Cuisine("Household chores");
    //   testCuisine.Save();
    //
    //   //Act
    //   Cuisine savedCuisine = Cuisine.GetAll()[0];
    //
    //   int result = savedCuisine.GetId();
    //   int testId = testCuisine.GetId();
    //
    //   //Assert
    //   Assert.Equal(testId, result);
    // }
    //
    // [Fact]
    // public void Test_Find_FindsCuisineInDatabase()
    // {
    //   //Arrange
    //   Cuisine testCuisine = new Cuisine("Household chores");
    //   testCuisine.Save();
    //
    //   //Act
    //   Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());
    //
    //   //Assert
    //   Assert.Equal(testCuisine, foundCuisine);
    // }
    //
    //
    // [Fact]
    //   public void Test_GetTasks_RetrievesAllTasksWithCuisine()
    //   {
    //     Cuisine testCuisine = new Cuisine("Household chores");
    //     testCuisine.Save();
    //
    //     Task firstTask = new Task("Mow the lawn", testCuisine.GetId());
    //     firstTask.Save();
    //     Task secondTask = new Task("Do the dishes", testCuisine.GetId());
    //     secondTask.Save();
    //
    //
    //     List<Task> testTaskList = new List<Task> {firstTask, secondTask};
    //     List<Task> resultTaskList = testCuisine.GetTasks();
    //
    //     Assert.Equal(testTaskList, resultTaskList);
    //   }
    //
    //   [Fact]
    //   public void Test_Update_UpdatesCuisineInDatabase()
    //   {
    //     //Arrange
    //     string name = "Home stuff";
    //     Cuisine testCuisine = new Cuisine(name);
    //     testCuisine.Save();
    //     string newName = "Work stuff";
    //
    //     //Act
    //     testCuisine.Update(newName);
    //
    //     string result = testCuisine.GetName();
    //
    //     //Assert
    //     Assert.Equal(newName, result);
    //   }
    //
    //   [Fact]
    //   public void Test_Delete_DeletesCuisineFromDatabase()
    //   {
    //     //Arrange
    //     string name1 = "Home stuff";
    //     Cuisine testCuisine1 = new Cuisine(name1);
    //     testCuisine1.Save();
    //
    //     string name2 = "Work stuff";
    //     Cuisine testCuisine2 = new Cuisine(name2);
    //     testCuisine2.Save();
    //
    //     Task testTask1 = new Task("Mow the lawn", testCuisine1.GetId());
    //     testTask1.Save();
    //     Task testTask2 = new Task("Send emails", testCuisine2.GetId());
    //     testTask2.Save();
    //
    //     //Act
    //     testCuisine1.Delete();
    //     List<Cuisine> resultCategories = Cuisine.GetAll();
    //     List<Cuisine> testCuisineList = new List<Cuisine> {testCuisine2};
    //
    //     List<Task> resultTasks = Task.GetAll();
    //     List<Task> testTaskList = new List<Task> {testTask2};
    //
    //     //Assert
    //     Assert.Equal(testCuisineList, resultCategories);
    //     Assert.Equal(testTaskList, resultTasks);
    //   }
//   }
// }
