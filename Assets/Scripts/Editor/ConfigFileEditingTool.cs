using UnityEditor;
using UnityEngine;

public class ConfigFileEditingTool : ScriptableWizard
{
	[SerializeField]private AppConfig config;

	[MenuItem("Kraft/ConfigEditor")]
	static void CreateWizard()
	{
		ScriptableWizard.DisplayWizard("ConfigEditor", typeof(ConfigFileEditingTool), "Save");
	}

	private void OnEnable()
	{
		config= new AppConfig();
		config = BinarySerializationManager.LoadFile();
	}

	private void OnWizardCreate()
	{
		BinarySerializationManager.Save(config);
	}
}
