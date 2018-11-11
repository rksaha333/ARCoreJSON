//Data
public class Segment
	{
		public int id;
		public string url;
		public string identifier;
		public int state;
		public string[] state_name=new string[5] 
		{
		 "Idle",
		"Unmount",
		"Error Transfer",
		"Reading Wait",
		"Transfer Sleep"
		"Error B1"
		"No Carrier Waiting"
		"Error B1"

		};
		public bool create_order;
		public string carrier;
		public string reset;
	}
	class DataBase
	{
		public string url;
		public int id;
		public string name;
		public Segment[] segments;
	}