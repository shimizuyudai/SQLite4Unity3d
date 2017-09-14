using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Linq;
using UnityEngine.UI;

public class TestDB : MonoBehaviour {
	[SerializeField]
	string dbName;

	[SerializeField]
	Text text;

	public enum DemoType{
		Create,
		Read
	}

	[SerializeField]
	DemoType demoType;

	// Use this for initialization
	void Start () {
		switch(demoType){
		case DemoType.Create:
			Create ();
			break;

		case DemoType.Read:
			Read ();
			break;

		default:

			break;
		}

	}

	void Read()
	{
		var ds = new DataService (dbName);
		var people = ds.Connection.Table<Person> ();
		var str = "read\n";
		foreach(var person in people){
			str += person.Id.ToString() + " : " + person.Name + ", "  + person.Age.ToString () + "\n";
		}
		text.text = str;
	}

	void Create()
	{
		var ds = new DataService(dbName);
		ds.Connection.DropTable<Person> ();
		ds.Connection.CreateTable<Person> ();
		ds.Connection.InsertAll (new[] {
			new Person {
				Id = 1,
				Name = "Tom",
				Age = 56
			},
			new Person {
				Id = 2,
				Name = "Fred",
				Age = 16
			},
			new Person {
				Id = 3,
				Name = "John",
				Age = 25
			},
			new Person {
				Id = 4,
				Name = "Roberto",
				Age = 37
			}
		});

		var people = ds.Connection.Table<Person> ();
		var str = "create\n";
		foreach(var person in people){
			str += person.Id.ToString() + " : " + person.Name + ", "  + person.Age.ToString () + "\n";
		}
		text.text = str;
	}
}
