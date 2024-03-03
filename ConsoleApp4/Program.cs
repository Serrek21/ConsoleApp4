using System;

class CreditCard
{
    public string CardNumber { get; }
    private string cardholderName;
    private string cvc;
    private DateTime expirationDate;

    public CreditCard(string cardNumber, string cardholderName, string cvc, DateTime expirationDate)
    {
        SetCardNumber(cardNumber);
        SetCardholderName(cardholderName);
        SetCvc(cvc);
        SetExpirationDate(expirationDate);
    }

    public string CardholderName
    {
        get { return cardholderName; }
    }

    public string Cvc
    {
        get { return cvc; }
    }

    public DateTime ExpirationDate
    {
        get { return expirationDate; }
    }

    private void SetCardNumber(string number)
    {
        if (string.IsNullOrEmpty(number))
        {
            throw new ArgumentException("Неправильний номер картки");
        }

        cardNumber = number;
    }

    private void SetCardholderName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Неправильне ПІБ власника");
        }

        cardholderName = name;
    }

    private void SetCvc(string cvc)
    {
        if (string.IsNullOrEmpty(cvc) || cvc.Length != 3)
        {
            throw new ArgumentException("Неправильний CVC");
        }

        this.cvc = cvc;
    }

    private void SetExpirationDate(DateTime date)
    {
        if (date < DateTime.Now)
        {
            throw new ArgumentException("Неправильна дата завершення картки");
        }

        expirationDate = date;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть рядок з цифрами від 0 до 9:");
        string input = Console.ReadLine();

        try
        {
            int number = Convert.ToInt32(input);
            Console.WriteLine("Введене число: " + number);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Переповнення діапазону int. Будь ласка, введіть менше число.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Некоректний формат вводу. Будь ласка, введіть ціле число.");
        }


        Console.WriteLine("Введіть рядок з 0 і 1:");
        string binaryInput = Console.ReadLine();

        try
        {
            int decimalNumber = Convert.ToInt32(binaryInput, 2);
            Console.WriteLine("Десяткове число: " + decimalNumber);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Переповнення діапазону int. Введіть менше число.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Неправильний формат введеного рядка. Введіть тільки 0 і 1.");
        }


        try
        {
            CreditCard myCard = new CreditCard("1234567812345678", "John Doe", "123", new DateTime(2025, 12, 31));

            Console.WriteLine("Номер картки: " + myCard.CardNumber);
            Console.WriteLine("Власник: " + myCard.CardholderName);
            Console.WriteLine("CVC: " + myCard.Cvc);
            Console.WriteLine("Дата завершення: " + myCard.ExpirationDate.ToShortDateString());
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Помилка ініціалізації кредитної картки");
        }

    }

 
}