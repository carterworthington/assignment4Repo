// See https://aka.ms/new-console-template for more information


namespace ClientCartW

{
	public class Client
	{
		private string _firstname;
		private string _lastname;
		private double _weight;
		private double _height;




		// Non-Greedy Constructor.
		public Client()
		{

			_firstname = "YYYY";
			_lastname = "XXXX";
			_weight = 0;
			_height = 0;
		}

		//Greedy Constructor
		public Client(string FirstName, string LastName, double Weight, double Height)
		{
			_firstname = FirstName;
            _lastname = LastName;
            _weight = Weight;
            _height = Height;
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

		public double Weight
		{
			get { return _weight; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Weight must be a positive value (0 or greater)");
				_weight = value;
			}
		}

		public double Height
		{
			get { return _height; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Heigh must be a positive value (0 or greater)");
				_height = value;
			}
		}








		//Read Only Fully Implemented Properties 

		public double BmiScore
		{
			get
			{
				return (_weight / ((double)_height * _height)) * 703;
			}
		}

		public string BmiStatus
		{
			get
			{
				if (BmiScore <= 18.4)
				{
					return "Underweight";
				}
				else if (BmiScore <= 24.9)
				{
					return "Normal";
				}
				else if (BmiScore <= 39.9)
				{
					return "Overweight";
				}
				else
				{
					return "Obese";
				}
			}
		}
		//method
		public override string ToString()
		{
			return $"{FirstName},{LastName},{Weight},{Height}";
		}
	}
	
}