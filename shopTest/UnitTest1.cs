using shopModel;
using Xunit;

namespace shopTest
{
    public class customerModelTest
    {
        [Fact]
        public void custIDShouldSetValidData()
        {
            Customer custObj = new Customer();
            int CustID = 34;

            custObj.custID = CustID;
        
            Assert.NotNull(custObj.custID);
            Assert.Equal(CustID, custObj.custID);
        }

          [Theory]
        [InlineData(-19)]
        [InlineData(-1290)]
        [InlineData(0)]
        [InlineData(-12983)]
          [InlineData(-14)]
        [InlineData(-129043)]
        [InlineData(-54353455)]
        [InlineData(-129)]
        public void custID_should_fail_set_invalid_data(int p_custID)
        {
            Customer custObj = new Customer();
            

            Assert.Throws<System.ComponentModel.DataAnnotations.ValidationException>(() => 
                {    
                    custObj.custID = p_custID;
                }
            );
        }
    }
}