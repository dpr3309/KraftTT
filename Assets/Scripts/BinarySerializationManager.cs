using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializationManager{

	public static void Save(object serializeObject)
	{
		string paht = "Assets/Resources/KraftTTAppConfig.bytes";
		BinaryFormatter _BinaryFormater = new BinaryFormatter();
		FileStream stream;
		stream = new FileStream(paht,FileMode.OpenOrCreate,FileAccess.ReadWrite);
		_BinaryFormater.Serialize(stream, serializeObject);

		stream.Close();

	}

	public static AppConfig RuntimeLoadFile()
	{

		TextAsset configFile = Resources.Load<TextAsset>("KraftTTAppConfig");
		MemoryStream stream = new MemoryStream(configFile.bytes);

		return DeserializeStream(stream);
	}


	public static AppConfig LoadFile()
	{
		string paht = "Assets/Resources/KraftTTAppConfig.bytes";	
		FileStream stream = new FileStream(paht, FileMode.Open);

		return DeserializeStream(stream);
	}

	private static AppConfig DeserializeStream(Stream stream)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		
		AppConfig config = new AppConfig();
		
		config = formatter.Deserialize(stream) as AppConfig;
		
		stream.Close();

		return config;
	}

}
