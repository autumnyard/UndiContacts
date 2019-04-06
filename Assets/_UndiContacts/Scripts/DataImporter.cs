using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UndiContacts
{
	public class DataImporter : MonoBehaviour
	{
		[System.Serializable]
		public struct ContactImport

		{
			public string key;
			public string name;
			public string phone;
			public string comment;

			public ContactImport( string key, string name, string phone, string comment )
			{
				this.key = key;
				this.name = name;
				this.phone = phone;
				this.comment = comment;
			}
		}


		static readonly public string folder = "Contacts";

		public static ContactImport[] ImportData()
		{
			// Read the file in Resources
			var raw = Resources.Load( folder ) as TextAsset;
			var json = raw.ToString();

			// Convert to our data structure
			ContactImport[] data = JsonTools.FromJson<ContactImport>( json );
			return data;
		}


		public static ContactImport[] GetContactsData()
		{
			// Read the file in Resources
			var raw = Resources.Load( folder ) as TextAsset;
			var json = raw.ToString();

			// Convert to our data structure
			ContactImport[] data = JsonTools.FromJson<ContactImport>( json );
			return data;
		}
	}
}