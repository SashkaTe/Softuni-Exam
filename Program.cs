
int[] textileInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] medicamentsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Queue<int> textile = new Queue<int>(textileInput);
Stack<int> medicaments = new Stack<int>(medicamentsInput);

Dictionary<string, int> elements = new Dictionary<string, int>()
{
    {"Patch",30 },
    {"Bandage", 40 },
    {"MedKit", 100 }
};

SortedDictionary<string, int> elementsMade = new SortedDictionary<string, int>();
int sum = 0;


while (textile.Any() && medicaments.Any())
{
    int tempMedicament = medicaments.Pop();
    sum = textile.Dequeue() + tempMedicament;

    if (elements.Any(e => e.Value == sum))
    {
        string keyElement = elements.FirstOrDefault(e => e.Value == sum).Key;
        if (!elementsMade.ContainsKey(keyElement))
        {
            elementsMade.Add(keyElement, 0);
        }
        elementsMade[keyElement]++;
    }
    else if (sum > 100)
    {
        if (!elementsMade.ContainsKey("MedKit"))
        {
            elementsMade.Add("MedKit", 0);
        }
        elementsMade["MedKit"]++;
        tempMedicament=medicaments.Pop() + (sum - 100);
        medicaments.Push(tempMedicament);
    }
    else
    {
        tempMedicament += 10;
        medicaments.Push(tempMedicament);
    }
}
if (!textile.Any() && medicaments.Any())
{
    Console.WriteLine("Textiles are empty.");

}
if (!medicaments.Any() && textile.Any())
{
    Console.WriteLine("Medicaments are empty.");
}
if(!medicaments.Any() && !textile.Any())
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}

if (elementsMade.Any())
{
    foreach (var item in elementsMade.OrderByDescending(e=>e.Value))
    {
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}

if (medicaments.Any())
{
    Console.WriteLine($"Medicaments left: {string.Join(", ",medicaments)}");
}
if (textile.Any())
{
    Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
}


