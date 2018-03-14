using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Kraft;
using UnityEngine;

[Serializable]
public class AppConfig : ISerializable
{
	[SerializeField] private int timer;
	public int Timer
	{
		get { return timer; }
	}
	
	[SerializeField] private List<Color> colors;
	public Color this[int index]
	{
		get
		{
			index = Mathf.Clamp(index, 0, colors.Count);
			return colors[index];
		}
	}

	public int ColorsCount
	{
		get { return colors.Count; }
	}

	public AppConfig()
	{
		
	}

	private AppConfig(SerializationInfo info, StreamingContext context)
	{
		colors = GenerateListOfColors((List<ColorWrapper>)info.GetValue("Colors",typeof(List<ColorWrapper>)));
		timer = info.GetInt32("Timer");
	}

	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		var colorWrappers = GenerateListOfColorWrappers();
		
		info.AddValue("Colors", colorWrappers);
		info.AddValue("Timer",Timer);
	}

	private List<ColorWrapper> GenerateListOfColorWrappers()
	{
		List<ColorWrapper> colorWrappers = new List<ColorWrapper>();

		foreach (var color in colors)
		{
			colorWrappers.Add(new ColorWrapper(color.r, color.g, color.b, color.a));
		}
		return colorWrappers;
	}

	private List<Color> GenerateListOfColors(List<ColorWrapper> colorWrappers)
	{
		List<Color> listColors = new List<Color>();

		foreach (var colorWrapper in colorWrappers)
		{
			listColors.Add(new Color(colorWrapper.R,colorWrapper.G,colorWrapper.B,colorWrapper.A));
		}
		return listColors;
	}
}
