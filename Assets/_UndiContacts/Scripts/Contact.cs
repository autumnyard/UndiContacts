using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndiContacts
{
	[System.Serializable]
	public class Contact : ScriptableObject
	{
		[SerializeField] private string key;
		[SerializeField] private new string name;
		[SerializeField] private int phone;
		[SerializeField] private string lastTime;
		[SerializeField] private string comment;


		// Getters
		public string Key { get { return key; } }
		public string Name { get { return name; } }
		public int Phone { get { return phone; } }
		public string LastTime { get { return lastTime; } }
		public string Comment { get { return comment; } }


		// Operators and overrides
		public bool Equals( Contact other ) => (Key.Equals( other.Key ));
		public static bool operator ==( Contact x, Contact y ) => x.Equals( y );
		public static bool operator !=( Contact x, Contact y ) => !x.Equals( y );
		public override string ToString() => Key.ToString();
		public override bool Equals( object obj ) => base.Equals( obj );
		public override int GetHashCode() => base.GetHashCode();


		public void Set( string key, string name, int phone, string lastTime, string comment )
		{
			this.key = key;
			this.name = name;
			this.phone = phone;
			this.lastTime = lastTime;
			this.comment = comment;
			UnityEditor.EditorUtility.SetDirty( this );
		}
	}
}