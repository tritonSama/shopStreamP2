using shopModel;
using Xunit;

namespace shopTest
{
    public class itemModelTest
    {
        [Fact]
        public void itemIDshouldSetValid()
        {
            Item itemObj = new Item();
            int ItemID = 34;

            itemObj.itemID = ItemID;

            Assert.NotNull(itemObj.itemID);
            Assert.Equal(ItemID, itemObj.itemID);
        }

    }
}