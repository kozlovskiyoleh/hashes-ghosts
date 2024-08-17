using System;
using System.Net.Mime;
using System.Numerics;
using System.Text;
using System.Reflection;

namespace hashes;

public class GhostsTask : 
	IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
	IMagic
{
	private readonly Vector _vector;
	private readonly Segment _segment;
	private readonly Cat _cat;
	private readonly Robot _robot;
	private readonly Document _document;

	public GhostsTask()
	{
        _vector = new Vector(1, 1);
        _segment = new Segment(_vector, new Vector(2, 4));
		_cat = new Cat(name: "Murchik", breed:"British-shorthair", DateTime.Today);
		_robot = new Robot(id: "1231", 10.0);
		_document = new Document("LOVE", Encoding.UTF8, Encoding.UTF8.GetBytes("Maria"));
    }

	public void DoMagic()
	{
        Random rnd = new Random();
        Robot.BatteryCapacity = rnd.Next(0, 100);
        _vector.Add(new Vector(-10, 1));
		_cat.Rename("Leo");
		var info = typeof(Document).GetField("content", BindingFlags.NonPublic|BindingFlags.Instance);
		var encodingString = Encoding.UTF8.GetBytes("12");
        info.SetValue(_document, encodingString);
    }

	Vector IFactory<Vector>.Create() => _vector;

	Segment IFactory<Segment>.Create() => _segment;

	Document IFactory<Document>.Create() => _document;

	Cat IFactory<Cat>.Create() => _cat;

	Robot IFactory<Robot>.Create() => _robot;
}