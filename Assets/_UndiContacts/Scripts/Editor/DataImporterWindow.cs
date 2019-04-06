using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace UndiContacts
{
	public class DataImporterWindow : EditorWindow
	{
		//https://docs.google.com/spreadsheets/d/1J61P1iTU8yeiUPolI1BBhvrkbYjviY_p_1wEQpC02OE/edit?usp=sharing
		private string googleId = "1J61P1iTU8yeiUPolI1BBhvrkbYjviY_p_1wEQpC02OE";
		private GameObject go;
		private GoogleSpreadsheetsToJSON converter;

		[MenuItem( "UndiContacts/Data importer" )]
		public static void ShowWindow()
		{
			//var window = GetWindow( typeof( DataImporterWindow ) );
			//var window = GetWindow( typeof(  ), false, "Data Importer" );
			var window = GetWindow<DataImporterWindow>( "Data Importer" );
		}

		private void OnGUI()
		{

			EditorGUILayout.LabelField( $"Filename: Import/Contacts" );
			EditorGUILayout.TextField( googleId );
			if( GUILayout.Button( "Download" ) )
			{
				GetConverter();
				DownloadData();
				CleanConverter();
				SaveDataOnAssets();
			}
		}


		// Import

		private void DownloadData()
		{
			converter.spreadSheetKey = googleId;
			converter.outputFileName = DataImporter.folder;
			converter.Init();
			converter.DownloadToJson();
		}

		private void GetConverter()
		{
			if( converter == null )
			{
				converter = (GoogleSpreadsheetsToJSON)FindObjectOfType( typeof( GoogleSpreadsheetsToJSON ) );
			}
			if( converter == null )
			{
				go = new GameObject();
				go.name = "Google2Json helper (REMOVE THIS)";
				converter = go.AddComponent<GoogleSpreadsheetsToJSON>();
			}
			else
			{
				go = converter.gameObject;
			}
		}

		private void CleanConverter()
		{
			DestroyImmediate( go );
		}


		// Create assets

		private void SaveDataOnAssets()
		{
			Debug.Log( "DataImporter: Overwriting data for ItemObjects" );
			DataImporter.ContactImport[] items = DataImporter.GetContactsData();
			foreach( var item in items )
			{
				var go = Resources.Load( "Data/" + item.key );
				if( go != null )
				{
					// We have the object
					Debug.Log( $"We have {item.key} asset. Update." );
					var contact = go as Contact;

					int phone = Int32.Parse(item.phone);
					//int.TryParse( item.phone, out phone );
					
					contact.Set( item.key, item.name, phone, item.comment );
				}
				else
				{
					Debug.Log( $"We don't have asset for {item.key}. Create." );
					Contact asset = ScriptableObject.CreateInstance<Contact>();
					AssetDatabase.CreateAsset( asset, $"Assets/Resources/Data/{item.key}.asset" );
					AssetDatabase.SaveAssets();
					
					//int phone = 0;
					//int.TryParse( item.phone, out phone );
					int phone = Int32.Parse(item.phone);
					asset.Set( item.key, item.name, phone, item.comment );
				}
			}
		}
	}


}