using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text.RegularExpressions;
public class CalculatorControllerScript : MonoBehaviour{
	[SerializeField] private UIControllerScript UIController;
	void Start(){
		LoadData();
	}
	public void Calucalate(string textEquation){
		if(VerifyEquation(textEquation)){
			string answer = DoEval(textEquation);
			UIController.ShowResult(answer);
		}else{
			UIController.ShowError();
		}

	}
	public void OpenNewEquation(){
		UIController.CloseMessageErrorPanel();
	}
	private string DoEval(string textEquation){
		string result;
		string[] parts = textEquation.Split("/", 2);
		result = ((float) Convert.ToInt32(parts[0]) / (float) Convert.ToInt32(parts[1])).ToString();
		return result;
	}
	private bool VerifyEquation(string textEquation){
		string correctPatterEquation = @"^(\d+\/\d+)$";
		return (Regex.IsMatch(textEquation, correctPatterEquation));
	}
	public void QuitProgram(){ Application.Quit(); }
	Data data;
	private void LoadData(){
		data = SaveLoadControllerScript.LoadData();
		UIController.SetInputFieldText(data.GetLastEquation);
	}
	private void SaveData(){
		data.SetLastEquation = UIController.GetInputFieldText;
		SaveLoadControllerScript.SaveData(data);
	}
	void OnApplicationQuit(){
		SaveData();
	}
}
