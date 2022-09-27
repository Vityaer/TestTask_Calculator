using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data{
	[SerializeField] private string lastEquation = string.Empty;
	public string GetLastEquation{get => lastEquation;}
	public string SetLastEquation{set => lastEquation = value;} 
}