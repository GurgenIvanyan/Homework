namespace Gorcnakan;

public class Bigint
{
    public int[] Number;


    public Bigint(int[] number)
    {
        Number = number;

    }

    public int[] gumarum(int[] number1, int[] number2)
    {
        int max = Math.Max(number1.Length, number2.Length);
        int[] result = new int[max + 1];
        int carry = 0;
        int i = number1.Length - 1;
        int j = number2.Length - 1;
        int k = result.Length - 1;
        while (i >= 0 || j >= 0 || carry != 0)
        {
            int sum = carry;
            if (i >= 0) sum += number1[i--];
            if (j >= 0) sum += number2[j--];
            result[k--] = sum % 10;
            carry = sum / 10;
        }

        return result;
    }

    public int[] hanum(int[] number1, int[] number2)
    {
        int max = Math.Max(number1.Length, number2.Length);
        int[] firstnumber = new int[max];
        int[] secondnumber = new int[max];
        int[] result = new int[max];
        Array.Copy(number1, firstnumber, number1.Length);
        Array.Copy(number2, secondnumber, number2.Length);
        for (int i = max - 1; i >= 0; i--)
        {
            if (firstnumber[i] >= secondnumber[i])
            {
                result[i] = firstnumber[i] - secondnumber[i];
            }
            else
            {
                firstnumber[i] += 10;
                result[i] = firstnumber[i] - secondnumber[i];
                if (i-1 >= 0 && firstnumber[i - 1] >= 1)
                {
                    firstnumber[i - 1] -= 1;
                }
                
                else if (i - 1 == 0)
                {
                    int k = i - 1;
                    int x = k;
                    while (true)
                    {
                        if (firstnumber[k] == 0)
                        {
                            result[k] = 9;
                            if (number1[x-1] != 0)
                            {
                                number1[x-1] -= 1;
                                k--;
                                break;
                            }
                            
                            
                        }
                    }
                    
                }

               
                }
            }
        

        return result;
    }
}

class Program

    {
        static void Main(string[] args)
        {
            Bigint number1 = new Bigint(new int[] { 1, 2, 3, 4, 5, 7 });
            Bigint number2 = new Bigint(new int[] { 1, 8, 7, 4, 5 });
            int[] result = number1.gumarum(number1.Number, number2.Number);
            Console.WriteLine(string.Join(" ",result));
            int[] result1=number1.hanum(number1.Number, number2.Number);
            Console.WriteLine(string.Join(" ",result1));

        }
    }

    
