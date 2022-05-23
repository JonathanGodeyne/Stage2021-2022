using MpleoEmployeeTest;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowMpleoEmployeeTest.Specs.StepDefinitions
{
    [Binding]
    public class WriteMpleoEmployeesToTextFileStepDefinitions
    {
         
        private List<MpleoEmployee>? _employees;
        private string? _url;
       
        [Given(@"a working url is '([^']*)'")]
        public void GivenAWorkingUrlIs(string url)
        {
            _url = url;
        }

        [Given(@"a wrong url is '([^']*)'")]
        public void GivenAWrongUrlIs(string url)
        {
            _url = url;
        }


        [When(@"the function GetMpleoEmployeesAsync gets called")]
        public void WhenTheFunctionGetMpleoEmployeesAsyncGetsCalled()
        {
            _employees = GetEmployees.GetMpleoEmployeesAsync(_url).Result;
        }


        [Then(@"the resulting list should not be empty")]
        public void ThenTheResultingListShouldNotBeEmpty()
        {
            _employees.Should().NotBeNullOrEmpty();
        }
        

        [Then(@"the resulting list should be empty")]
        public void ThenTheResultingListShouldBeEmpty()
        {
            _employees.Should().BeNullOrEmpty();
        }

    }
}
