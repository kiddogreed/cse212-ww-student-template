
public class Practice
{
  // arrays

  //fix arrays cannot grow or shrink in size
 static void Main() {
  var myArray = new int[5]; // fixed size array
  myArray[0] = 10;
  myArray[1] = 20;
  myArray[2] = 30;

  var numbers = new[] { 1, 2, 3, 4, 5 }; // fixed size array with initialization

  //Dynamic arrays can grow or shrink in size (basically a fix array but copy it self to a doubled array size)

  // In C#, a dynamic array is created by using a List object.
  var numbersList = new List<int>(); // dynamic array
    numbersList.Add(100);
    numbersList.Add(200);
    numbersList.Add(300);

    var secondNumList = new List<int> { 1, 2, 3 };

    foreach (var number in numbersList)
        {
            Console.WriteLine(number);
        }
 }
}

