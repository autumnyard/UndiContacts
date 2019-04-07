using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UndiContacts
{
	public class UIContacts : MonoBehaviour
	{
		public Transform content;
		[Space( 10 )]
		public GameObject contactEntryPrefab;
		private Contact[] contacts;
		public List<GameObject> entries;

		[Space( 10 )]
		public Text keyUI;
		public Text nameUI;
		public Text phoneUI;
		public Text lastTimeUI;
		public Text commentUI;

		private void Start()
		{
			Populate();
		}

		//public void Refresh()
		//{
		//	DataImporter.
		//}

		public void Populate()
		{
			contacts = Resources.LoadAll<Contact>( "Data" );

			foreach( var contact in contacts )
			{
				var go = Instantiate( contactEntryPrefab, content );
				var script = go.GetComponent<ContactEntry>();
				script.Set( contact );
				script.OnSelected += OnSelectContact;
				entries.Add( go );
			}
		}

		public void OnSelectContact( Contact data )
		{
			keyUI.text = data.Key;
			nameUI.text = data.Name;
			phoneUI.text = data.Phone.ToString();
			lastTimeUI.text = data.LastTime;
			commentUI.text = data.Comment;
		}
	}
}
