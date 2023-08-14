using System;

public class Move
{
	private int id { get; set; }
	private string name { get; set; }
	private string description { get; set; }
	private int sweatRate { get; set; }

	public Move(string name, string description)
	{
		this.name = name;
		this.description = description;
	}
}
