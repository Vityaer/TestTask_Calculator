using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIControllerScript : MonoBehaviour{
	[SerializeField] private TMP_InputField inputFieldComponentEquation;
	[SerializeField] private TextMeshProUGUI textComponentAnswer;
	[SerializeField] private GameObject messageErrorPanel;
	[SerializeField] private CalculatorControllerScript CalculatorController;

	public void ShowResult(string result){
		textComponentAnswer.text = result;
	}
	public void ShowError(){
		textComponentAnswer.text = string.Empty;
		messageErrorPanel.SetActive(true);
	}
	public void CloseMessageErrorPanel(){
		messageErrorPanel.SetActive(false);
	}
	public void StartCalculate(){
		CalculatorController.Calucalate(inputFieldComponentEquation.text);
	}
	public string GetInputFieldText{get => inputFieldComponentEquation.text;}
	public void SetInputFieldText(string newText){inputFieldComponentEquation.text = newText;}
}