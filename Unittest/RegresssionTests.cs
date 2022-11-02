using APIAutomation;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unittest
{
    [TestClass]
    public class RegresssionTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SetUpReport(TestContext testContext)
        {
            var dir = testContext.TestRunDirectory;
            Reporter.SetUpReport(dir, "SmokeTest", "Smoke test result");
        }



        [TestInitialize]
        public void SetUpTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }



        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }



        [TestMethod]
        public void VerifyListOfUsers()
        {

            var demo = new Code<ListOUserDTO>();
            var user = demo.GetUser("api/users?page=2");
            Reporter.LogToReport(Status.Fail,"Page number does not match");
            Console.WriteLine("TotalPages after hitting get request ---  " + user.TotalPages);
            Console.WriteLine("PerPage after hitting get request ---  " + user.PerPage);
        }

        
    //    [DeploymentItem("TestData\\TestCase.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV","TestCase.csv","TestCase#csv", DataAccessMethod.Sequential)]
       
        [TestMethod]
        public void CreateNewUser()
        {
                 string payload = @"{
                                    ""name"": ""morpheus"",
                                    ""job"" : ""leader""
                                            }";

                 

     //       var users = new CreateUserRequestsDTO();
      //      users.Name = TestContext.DataRow["name"].ToString();
       //     users.Job = TestContext.DataRow["job"].ToString();

            var demo = new Code<CreateUserDIO>();
            var user =demo.CreateUser("api/users",payload);
            Console.WriteLine("Name after hitting post request ---  " + user.Name);
            Console.WriteLine("Job after hitting post request ---  " + user.Job);
            Assert.AreEqual("morpheus", user.Name);
        }
        

    }
}
