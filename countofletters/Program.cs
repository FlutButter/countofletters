using System;

public class Countofletters
{
    public static void Check_errors (string letters)
    {
        if (String.IsNullOrEmpty(letters))
        {
            Console.WriteLine("Буков нет, считать нечего");
            System.Environment.Exit(0);
        }
        foreach (char c in letters)
        {
            if (!char.IsLetter(c))
            {
                Console.WriteLine("В строке присутствуют не только буквы");
                System.Environment.Exit(0);
            }
        }
    }
    public static IEnumerable<string> Counter (string letters) //Тип возвращаемого значения указан не был, поэтому я решил взять список строк
    {
        int i;
        int j;
        string part;
        List<string> list = new List<string>();

        Check_errors(letters);
        i = 0;
        letters = letters.ToLower(); // Про заглавные буквы тоже указаний не было, решил переводить к строчным
        while (i < letters.Length)
        {
            j = 0;
            part = string.Empty;
            while ((i + j < letters.Length) && (letters[i] == letters[i + j]))
                j++;
            part += letters[i] + "," + j;
            list.Add(part);
            i += j;
        }
        return list;
    }
    static void Main() //Так как особых критериев к выполнению нет, я разрешил себе пару условностей:)
    {
        Console.WriteLine("Введите латинские буквы для подсчета");
        string? letters = Console.ReadLine();
        List<string> list = new List<string>(Counter(letters)); // чек что все посчиталось без ошибок
        foreach (string part in list)
            Console.WriteLine(part);
        return;
    }
}
