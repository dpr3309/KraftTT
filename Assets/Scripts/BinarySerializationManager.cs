using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializationManager{

	private static string paht = "Assets/Resources/KraftTTAppConfig.bytes";
	private static BinaryFormatter binaryFormater = new BinaryFormatter();
	
	public static void Save(object serializeObject)
	{
		var stream = new FileStream(paht,FileMode.OpenOrCreate,FileAccess.ReadWrite);
		binaryFormater.Serialize(stream, serializeObject);

		stream.Close();
	}

	public static AppConfig LoadFileFromResources()
	{
		
#if UNITY_EDITOR 
		UnityEditor.AssetDatabase.ImportAsset(paht);
#endif

		var configFile = Resources.Load<TextAsset>("KraftTTAppConfig");
		var stream = new MemoryStream(configFile.bytes);

		return DeserializeStream(stream);
	}


	public static AppConfig LoadFile()
	{
		var stream = new FileStream(paht, FileMode.Open);

		return DeserializeStream(stream);
	}

	private static AppConfig DeserializeStream(Stream stream)
	{
		var config = new AppConfig();
		config = binaryFormater.Deserialize(stream) as AppConfig;
		
		stream.Close();
		
		return config;
	}
}
