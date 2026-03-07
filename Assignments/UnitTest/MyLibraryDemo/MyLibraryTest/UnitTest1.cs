using MyLibraryDemo;
namespace MyLibraryTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }
        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test1()
        {
            //arranging
            MyMath math = new MyMath();
            int expected = 18;
            int actual = 0;

            //act
            actual=math.GetSum(5, 3, 2, 3, 5);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test2()
        {
            //arranging
            MyMath math = new MyMath();
            int expected = -3;
            int actual = 0;

            //act
            actual = math.GetSum(-1,-2);
            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(2,3,6)]
        [TestCase(2, 4, 8)]
        [TestCase(2, 5,10)]
        public void TestMultiply(int n1,int n2,int expected)
        {
            //arranging
            MyMath math = new MyMath();
            
            int actual = 0;

            //act
            actual = math.GetMultiply(n1,n2);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}