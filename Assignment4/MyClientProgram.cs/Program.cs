// See https://aka.ms/new-console-template for more information

using ClientCartW;


Client myClient = new Client();
List<Client> listOfClients = [];

LoadFileValuesToMemory(listOfClients);

bool loopAgain = true;
while (loopAgain)
{
    try 
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter menu selection: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = newClient();
        if (mainMenuChoice == "S")
            ShowClientInfo(myClient);
		if (mainMenuChoice == "Q")
		{
			SaveMemoryValuesToFile(listOfClients);
			loopAgain = false;
			throw new Exception("Bye, hope to see you again.");
		}
		if (mainMenuChoice == "E")
		{
			while (true)
			{
				DisplayEditMenu();
				string editMenuChoice = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
				if (editMenuChoice == "F")
					GetFirstName(myClient);
				if (editMenuChoice == "L")
					GetLastName(myClient);
				if (editMenuChoice == "H")
					GetHeight(myClient);
				if (editMenuChoice == "W")
					GetWeight(myClient);
				if (editMenuChoice == "R")
					throw new Exception("Returning to Main Menu");
			}
		}
    }
	catch (Exception ex)
	{
		Console.WriteLine($"{ex.Message}");
	}
}




void DisplayMainMenu()
{
    Console.WriteLine("\nMenu Options");
    Console.WriteLine("[N]ew client");
    Console.WriteLine("[S]how client BMI info");
    Console.WriteLine("[E]dit client");
    Console.WriteLine("[Q]uit");
}

void DisplayEditMenu()
{
	Console.WriteLine("[F]irst name");
	Console.WriteLine("[L]ast name");
	Console.WriteLine("[H]eight");
	Console.WriteLine("[W]eight");
	Console.WriteLine("[R]eturn to main menu");
}

string Prompt(string prompt)
{
	string myString = "";
	while (true)
	{
		try
		{
		Console.Write(prompt);
		myString = Console.ReadLine().Trim();
		if(string.IsNullOrEmpty(myString))
			throw new Exception($"Empty Input: Please enter something.");
		break;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	return myString;
}


double PromptDoubleBetweenMinMax(String msg, double min, double max)
{
	double num = 0;
	while (true)
	{
		try
		{
			Console.Write($"{msg} between {min} and {max} inclusive: ");
			num = double.Parse(Console.ReadLine());
			if (num < min || num > max)
				throw new Exception($"Must be between {min:n2} and {max:n2}");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Invalid: {ex.Message}");
		}
	}
	return num;
}


Client NewClient()
{
	Client myClient = new Client();
	GetFirstName(myClient);
	GetLastName(myClient);
	GetWeight(myClient);
	GetHeight(myClient);
	return myClient;
}


void GetFirstName (Client client)
{
    string myString = Prompt($"Enter client's first name: ");
    client.FirstName = myString;
}

void GetLastName (Client client)
{
    string myString = Prompt($"Enter client's last name: ");
    client.FirstName = myString;
}

void GetWeight (Client client)
{
    double myDouble = PromptDoubleBetweenMinMax("Enter weight in pounds: ", 0, 1000);
    client.Weight = myDouble;
}

void GetHeight (Client client)
{
    double myDouble = PromptDoubleBetweenMinMax("Enter height in inches: ", 0, 1000);
    client.Height = myDouble;
}


void ShowClientInfo(Client client)
{
    if (client == null)
            throw new Exception($"No client in Memory");
         Console.WriteLine($"\n{Client.ToString()}");
         Console.WriteLine($"Bmi Score  :\t{Client.BmiScore:n4}");
         Console.WriteLine($"Bmi Status :\t{Client.BmiStatus}");
}















void LoadFileValuesToMemory(List<Client> listOfClients)
{
	while(true){
		try
		{
			//string fileName = Prompt("Enter file name including .csv or .txt: ");
			string fileName = "regin.csv";
			string filePath = $"./data/{fileName}";
			if (!File.Exists(filePath))
				throw new Exception($"The file {fileName} does not exist.");
			string[] csvFileInput = File.ReadAllLines(filePath);
			for(int i = 0; i < csvFileInput.Length; i++)
			{
				//Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
				string[] items = csvFileInput[i].Split(',');
				for(int j = 0; j < items.Length; j++)
				{
					//Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
				}
				Client myClient = new Client(items[0], items[1], double.Parse(items[2]), double.Parse(items[3]), items[4]);
				listOfClients.Add(myClient);
			}
			Console.WriteLine($"Load complete. {fileName} has {listOfClients.Count} data entries");
			break;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}
}

void SaveMemoryValuesToFile(List<Client> listOfClients)
{
	//string fileName = Prompt("Enter file name including .csv or .txt: ");
	string fileName = "regout.csv";
	string filePath = $"./data/{fileName}";
	string[] csvLines = new string[listOfClients.Count];
	for (int i = 0; i < listOfClients.Count; i++)
	{
		csvLines[i] = listOfPets[i].ToString();
	}
	File.WriteAllLines(filePath, csvLines);
	Console.WriteLine($"Save complete. {fileName} has {listOfClients.Count} entries.");
}