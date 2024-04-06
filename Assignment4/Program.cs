// See https://aka.ms/new-console-template for more information


namespace Client
{


    //Greedy Constructor
public Client(string FirstName, string LastName, int Weight, int Height)
{
    FirstName=firstname;
    LastName=lastName;
    Weight=weight;
    Height=Height;
}





public string FirstName
		{
			get { return _firstname; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Name is required. Must not be empty or blank.");
				_name = value;
			}
		}











}
