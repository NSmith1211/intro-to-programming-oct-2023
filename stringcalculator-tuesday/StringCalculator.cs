
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers, char delimiter)
    {
        int result = 0;
        int absValResult = 0;
        List<int> negatives = new List<int>();
        if (numbers == "")
        {
            return result;

        }
        else
        {
            //Replace the newline with delimiter
            numbers = numbers.Replace('\n', delimiter);

            //Split the string of numbers
            string[] strings = numbers.Split(delimiter);

            //Loop through the array
            for (int i = 0; i < strings.Length; i++)
            {
                //Find the absolute value result
                absValResult += Math.Abs(int.Parse(strings[i]));
                //Find the normal result
                result += int.Parse(strings[i]);
                //Find the negatives and add them to the list
                if (int.Parse(strings[i]) < 0)
                {
                    negatives.Add(int.Parse(strings[i]));
                }
            }

        }

        if (absValResult != result)
        {
            //Throw negative number exception. List the numbers
            throw new Exception($"Negatives not allowed: {negatives.ToString()}");
        }
        else
        {
            return result;
        }


    }

}
