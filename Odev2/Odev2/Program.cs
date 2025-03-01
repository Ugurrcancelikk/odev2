Menu();
//Main Functions
void Menu()
{
    while (true)
    {
        Console.Clear(); 
        Console.WriteLine("==== Project 2 ====");
        Console.WriteLine(".1 - Sum Of Digits");
        Console.WriteLine(".2 - Get Valid Number");
        Console.WriteLine(".3 - Categorize Ages");
        Console.WriteLine(".4 - Find Duplicates");
        Console.WriteLine(".5 - Find Longest And Shortest Words");
        Console.WriteLine(".6 - Sort By Alphabetical And Display Words");
        Console.WriteLine(".7 - Dynamic String Array");
        Console.WriteLine(".8 - Reverse Array");
        Console.WriteLine(".9 - Sort Numbers In Array");
        Console.WriteLine("10 - Delete In Array Small Than Ten Numbers");
        Console.WriteLine("11 - Update Notes");
        Console.WriteLine(".0 - Exit");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SumOfDigits();
                break;
            case "2":
                GetValidNumber();
                break;
            case "3":
                CategorizeAges();
                break;
            case "4":
                FindDuplicates();
                break;
            case "5":
                FindLongestAndShortestWords();
                break;
            case "6":
                SortByAlphabeticalAndDisplayWords();
                break;
            case "7":
                DynamicStringArrayTester();
                break;
            case "8":
                ReverseArrayTester();
                break;
            case "9":
                SortNumbersInArray();
                break;
            case "10":
                DeleteInArraySmallThanTenNumbers();
                break;
            case "11":
                UpdateNotes();
                break;
            
            case "0":
                Console.WriteLine("Exiting program...");
                return; 
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }

        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey(); 
    }
}

void SumOfDigits()
{
    Console.Write("Enter a number: ");
    int num = int.Parse(Console.ReadLine());
    int total = 0;
    
    for (int temp = Math.Abs(num); temp > 0; temp /= 10)
    {
        total += temp % 10; 
    }

    Console.WriteLine("Sum of digits: " + total);
}

void GetValidNumber()
{
    int number;
    while (true) 
    {
        Console.Write("Enter a number between 10 and 100: ");

        if (int.TryParse(Console.ReadLine(), out number))
        {
            if (number >= 10 && number <= 100)
            {
                Console.WriteLine("You entered a valid number: " + number);
                break; 
            }
        }
        Console.WriteLine("Invalid input. Please try again.");
    }
}

void CategorizeAges()
{
    int[] ages = { 3, 15, 25, 70, 10, 18, 40, 80 };
    foreach (int age in ages)
    {
        string category;

        if (age >= 0 && age <= 12)
            category = "Child";
        else if (age >= 13 && age <= 19)
            category = "Teenager";
        else if (age >= 20 && age <= 64)
            category = "Adult";
        else
            category = "Senior";

        Console.WriteLine($"Age {age}: {category}");
    }
}

static void FindDuplicates()
{
    
    int[] array = { 4, 2, 7, 4, 8, 2, 9, 1, 7, 6, 8, 8 };
    
    Console.WriteLine("Array elements:");
    
    foreach (int item in array)
    {
        Console.Write(item + " ");
    }
    
    Console.WriteLine("\nDuplicate elements:");

    for (int i = 0; i < array.Length; i++)
    {
        bool isDuplicate = false;

        for (int k = 0; k < i; k++)
        {
            if (array[i] == array[k])
            {
                isDuplicate = true; 
                break;
            }
        }

        if (isDuplicate) continue; 

        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] == array[j])
            {
                Console.WriteLine(array[i]); 
                break;
            }
        }
    }
}

void FindLongestAndShortestWords()
{
    string[] array = { "apple", "banana", "kiwi", "grape", "strawberry", "fig", "blueberry" }; // Sample array

    Console.Write("Words: ");
    foreach (string word in array)
    {
        Console.Write(word + " ");
    }
    
    if (array.Length == 0)
    {
        Console.WriteLine("\nThe array is empty.");
        return;
    }

    string longest = array[0];
    string shortest = array[0];

    for (int i = 1; i < array.Length; i++)
    {
        int currentLength = 0, longestLength = 0, shortestLength = 0;

        while (currentLength < array[i].Length)
            currentLength++;

        while (longestLength < longest.Length)
            longestLength++;

        while (shortestLength < shortest.Length)
            shortestLength++;

        if (currentLength > longestLength)
            longest = array[i];

        if (currentLength < shortestLength)
            shortest = array[i];
    }

    Console.WriteLine("\nLongest word: " + longest);
    Console.WriteLine("\nShortest word: " + shortest);
}

void SortByAlphabeticalAndDisplayWords()
{
    Console.WriteLine("Enter a sentence:");
    string sentence = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(sentence))
    {
        Console.WriteLine("No valid input provided.");
        return;
    }

    string[] words = SplitSentence(sentence);

    BubbleSort(words);

    Console.WriteLine("Sorted words:");
    foreach (var word in words)
    {
        Console.WriteLine(word);
    }
}

void DynamicStringArrayTester()
{
    DynamicStringArray dynamicArray = new DynamicStringArray();

    Console.Write("Enter words (type 'ok' to stop):");

    while (true)
    {
        string? input = Console.ReadLine();

        if (input?.ToLower() == "ok") 
            break;

        dynamicArray.Add(input);
        Console.WriteLine("\nUpdated array:");
        dynamicArray.Display(); 
    }

    Console.WriteLine("Final array:");
    dynamicArray.Display(); 
}

void ReverseArrayTester()
{
    Console.WriteLine("Enter words (type 'exit' to stop):");

    string[] words = new string[10]; 
    int count = 0;

    while (true)
    {
        string input = Console.ReadLine();
        if (input.ToLower() == "exit") break; 

        if (count == words.Length)
        {
            words = ExpandArray(words);
        }

        words[count] = input;
        count++;
    }

    ReverseArray(words, count);

    Console.WriteLine("\nWords in reverse order:");
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(words[i]);
    }
}

void SortNumbersInArray()
{
    Console.WriteLine("Enter numbers (type 'done' to finish):");

    int[] numbers = new int[10]; 
    int count = 0;

    while (true)
    {
        string input = Console.ReadLine();
        if (input.ToLower() == "done") break; 

        if (int.TryParse(input, out int number))
        {
            if (count == numbers.Length)
            {
                numbers = ExpandArrayForNumbers(numbers);
            }

            numbers[count] = number;
            count++;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    if (count == 0)
    {
        Console.WriteLine("No numbers entered.");
        return;
    }

    double average = CalculateAverage(numbers, count);

    SortArray(numbers, count);

    Console.WriteLine($"\nAverage: {average:F2}");
    Console.WriteLine("Numbers in ascending order:");
    for (int i = 0; i < count; i++)
    {
        Console.Write(numbers[i] + " ");
    }
}

void DeleteInArraySmallThanTenNumbers()
{
    Console.WriteLine("Enter numbers (type 'done' to finish):");

    int[] numbers = new int[10]; 
    int count = 0;

    while (true)
    {
        string input = Console.ReadLine();
        if (input.ToLower() == "done") break;

        if (int.TryParse(input, out int number))
        {
            if (count == numbers.Length)
            {
                numbers = ExpandArrayForNumbers(numbers);
            }

            numbers[count] = number;
            count++;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    if (count == 0)
    {
        Console.WriteLine("No numbers entered.");
        return;
    }

    numbers = RemoveSmallNumbers(numbers, count, out int newCount);

    Console.Write("\nNumbers >= 10: ");
    for (int i = 0; i < newCount; i++)
    {
        Console.Write(numbers[i] + " ");
    }

}

void UpdateNotes()
{
    Console.WriteLine("Enter student grades (type 'done' to finish):");

    int[] grades = new int[10]; 
    int count = 0;

    while (true)
    {
        string input = Console.ReadLine();
        if (input.ToLower() == "done") break;

        if (int.TryParse(input, out int grade))
        {
            if (count == grades.Length)
            {
                grades = ExpandArrayForNumbers(grades);
            }

            grades[count] = grade;
            count++;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid grade.");
        }
    }

    if (count == 0)
    {
        Console.WriteLine("No grades entered.");
        return;
    }

    UpdateLowGrades(grades, count);

    Console.Write("\nUpdated grades: ");
    for (int i = 0; i < count; i++)
    {
        Console.Write(grades[i] + " ");
    }
}

//Side Functions
string[] SplitSentence(string sentence)
    {
        string tempWord = "";
        int wordCount = 0;

        foreach (char c in sentence)
        {
            if (c == ' ')
            {
                if (tempWord.Length > 0)
                {
                    wordCount++;
                    tempWord = "";
                }
            }
            else
            {
                tempWord += c;
            }
        }
        if (tempWord.Length > 0) wordCount++;

        string[] words = new string[wordCount];
        tempWord = "";
        int index = 0;

        foreach (char c in sentence)
        {
            if (c == ' ')
            {
                if (tempWord.Length > 0)
                {
                    words[index++] = tempWord;
                    tempWord = "";
                }
            }
            else
            {
                tempWord += c;
            }
        }
        if (tempWord.Length > 0) words[index] = tempWord;

        return words;
    }

void BubbleSort(string[] words)
    {
        int n = words.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (CompareStrings(words[j], words[j + 1]) > 0)
                {
                    string temp = words[j];
                    words[j] = words[j + 1];
                    words[j + 1] = temp;
                }
            }
        }
    }

int CompareStrings(string str1, string str2)
    {
        int len1 = str1.Length;
        int len2 = str2.Length;
        int minLen = len1 < len2 ? len1 : len2;

        for (int i = 0; i < minLen; i++)
        {
            if (char.ToLower(str1[i]) < char.ToLower(str2[i])) return -1;
            if (char.ToLower(str1[i]) > char.ToLower(str2[i])) return 1;
        }

        return len1.CompareTo(len2);
    }

string[] ExpandArray(string[] oldArray)
{
    int newSize = oldArray.Length * 2;
    string[] newArray = new string[newSize];

    for (int i = 0; i < oldArray.Length; i++)
    {
        newArray[i] = oldArray[i];
    }

    return newArray;
}

void ReverseArray(string[] array, int length)
{
    for (int i = 0; i < length / 2; i++)
    {
        string temp = array[i];
        array[i] = array[length - i - 1];
        array[length - i - 1] = temp;
    }
}

double CalculateAverage(int[] array, int length)
{
    int sum = 0;
    for (int i = 0; i < length; i++)
    {
        sum += array[i];
    }
    return (double)sum / length;
}

void SortArray(int[] array, int length)
{
    for (int i = 0; i < length - 1; i++)
    {
        for (int j = 0; j < length - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
    }
}

static int[] RemoveSmallNumbers(int[] array, int length, out int newCount)
{
    int[] tempArray = new int[length]; 
    newCount = 0;

    for (int i = 0; i < length; i++)
    {
        if (array[i] >= 10)
        {
            tempArray[newCount] = array[i];
            newCount++;
        }
    }

    int[] resultArray = new int[newCount];
    for (int i = 0; i < newCount; i++)
    {
        resultArray[i] = tempArray[i];
    }

    return resultArray;
}

int[] ExpandArrayForNumbers(int[] oldArray)
{
    int newSize = oldArray.Length * 2;
    int[] newArray = new int[newSize];

    for (int i = 0; i < oldArray.Length; i++)
    {
        newArray[i] = oldArray[i];
    }

    return newArray;
}

static void UpdateLowGrades(int[] array, int length)
{
    for (int i = 0; i < length; i++)
    {
        if (array[i] < 50)
        {
            array[i] = 50;
        }
    }
}
public class DynamicStringArray
{
    private string[] array;
    private int count;
    private int capacity;

    public DynamicStringArray()
    {
        capacity = 4; 
        array = new string[capacity];
        count = 0;
    }

    public void Add(string item)
    {
        if (count == capacity)
        {
            ExpandArray();
        }

        array[count] = item;
        count++;
    }

    private void ExpandArray()
    {
        capacity *= 2; 
        string[] newArray = new string[capacity];

        for (int i = 0; i < count; i++)
        {
            newArray[i] = array[i];
        }

        array = newArray;
    }

    public void Display()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

