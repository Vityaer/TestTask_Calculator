using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using UnityEditor;
internal class SaveLoadControllerScript : MonoBehaviour{
    private static string NameFile        = "CalculatorSave";

//API
	//Game status
		public static void SaveData(Data data){
	    	StreamWriter sw = CreateStream(NameFile, false);
		    sw.WriteLine( JsonUtility.ToJson(data) );
			sw.Close();
		}


		public static Data LoadData(){
			Data result = new Data();
			List<string> rows = ReadFile(NameFile);
			if(rows.Count > 0){
				result = JsonUtility.FromJson<Data>(rows[0]); 
			}
			return result;
		}
//Core
	private static string GetPrefix(){
			string prefixNameFile;
		#if UNITY_EDITOR_WIN
			prefixNameFile = Application.dataPath;	
	    #endif
	    #if UNITY_ANDROID && !UNITY_EDITOR
			prefixNameFile = Application.persistentDataPath;	
	    #endif
			return prefixNameFile;
	}
	private static List<string> ReadFile(string NameFile){
		CheckFile(NameFile);
		List<string> ListResult = new List<string>(); 
		try{
			ListResult = new List<string>(File.ReadAllLines(GetPrefix() + "/" + NameFile + ".data"));
		}catch{}
		return ListResult;
	}
	private static StreamWriter CreateStream(string NameFile, bool AppendFlag){
    	return new StreamWriter(GetPrefix() + "/" + NameFile + ".data", append: AppendFlag);
    	
    }
    public static void CheckFile(string NameFile){
    	if(!File.Exists(GetPrefix() + "/" + NameFile + ".data")){
    		CreateFile(NameFile);
    	}
    }
    public static void CreateFile(string NameFile){
        StreamWriter sw = CreateStream(NameFile, false);
        sw.Close();
    }
}
