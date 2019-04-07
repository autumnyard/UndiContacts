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
			public string lastTime;
			public string comment;

			public ContactImport( string key, string name, string phone, string lastTime, string comment )
			{
				this.key = key;
				this.name = name;
				this.phone = phone;
				this.lastTime = lastTime;
				this.comment = comment;
			}
		}


		static readonly public string folder = "Contacts";


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