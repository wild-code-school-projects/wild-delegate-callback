

using System.Text;

namespace MyApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


        #region PassingByPointer
            FormatMoney callFunction = ShowMoneyFR;

            // Call with the FR currency :
            callFunction(500m);

            callFunction = ShowMoneyUS;

            // Call with the US currency :
            callFunction(500m);
        #endregion


        #region PassingByCallBackPointer
            // Call with the FR currency :
            ShowMoney(ShowMoneyFR, 500);

            // Call with the US currency :
            ShowMoney(ShowMoneyUS, 500);
        #endregion

        Console.ReadKey();
    }

    public delegate void FormatMoney(decimal amount);
    public static void ShowMoney(FormatMoney cb, decimal amount)
    {
        cb(amount);
    }

    public static void ShowMoneyFR(decimal amount)
    {
        Console.WriteLine($"{amount}€");
    }

    public static void ShowMoneyUS(decimal amount)
    {
        Console.WriteLine($"{amount}$");
    }
}