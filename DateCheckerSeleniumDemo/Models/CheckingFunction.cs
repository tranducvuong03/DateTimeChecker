namespace DateCheckerSeleniumDemo.Models
{
	public class CheckingFunction
	{
		public static int CheckDayInMonth(int year, int month)
		{
			int day = 0;
			if (month >= 1 && month <= 12)
			{
				//if month = 1,3,5,7,8,10,12
				switch (month)
				{
					case 1:
					case 3:
					case 5:
					case 7:
					case 8:
					case 10:
					case 12:
						day = 31;
						break;
				}

				//if month = 4,6,9,11
				switch (month)
				{
					case 4:
					case 6:
					case 9:
					case 11:
						day = 30;
						break;
				}

				//if month = 2
				switch (month)
				{
					case 2:
						// Leap year
						if (year % 400 == 0 || year % 4 == 0)
						{
							day = 29;
						}
						// Not Leap year
						else if (year % 100 == 0 || year % 4 != 0)
						{
							day = 28;
						}
						break;
				}
			}
			return day;
		}

		public static bool CheckDate(int year, int month, int day)
		{
			bool result = false;

			if (month >= 1 && month <= 12)
			{
				if (day >= 1 && year >= 1)
				{
					if (day <= CheckDayInMonth(year, month))
					{
						result = true;
					}
				}
			}

			return result;
		}
	}
}
