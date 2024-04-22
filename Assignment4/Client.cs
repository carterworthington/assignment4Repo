// See https://aka.ms/new-console-template for more information


namespace ClientCartW
{
	public class Client
	{
		private string _firstname;
		private string _lastname;
		private string _weight;
		private string _height;




		// Non-Greedy Constructor.
		public Client()
		{
			
			FirstName = "YYYY";
			LastName = "XXXX";
			Weight = 0;
			Height = 0;
		}

		//Greedy Constructor
		public Client(string FirstName, string LastName, int Weight, int Height)
		{
			FirstName = firstname;
			LastName = lastName;
			Weight = weight;
			Height = Height;
		}





		public string FirstName
		{
			get { return _firstname; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Name is required. Must not be empty or blank.");
				_firstname = value;
			}
		}

		public string LastName
		{
			get { return _lastname; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Name is required. Must not be empty or blank.");
				_lastname = value;
			}
		}

		public int Weight
		{
			get { return _weight; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Weight must be a positive value (0 or greater)");
				_weight = value;
			}
		}

		public int Height
		{
			get { return _height; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Heigh must be a positive value (0 or greater)");
				_height = value;
			}
		}




	}
}


//Read Only Fully Implemented Properties 

public double BmiScore
{
	get {
		return	(weight / (height * height)) * 703;
	}
}

public string BmiStatus 
{
	get {
		if BmiScore < 18.4
	}
}