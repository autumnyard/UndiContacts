using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UndiContacts
{
	public class ContactEntry : Selectable /* UnityEngine.EventSystems.ISelectHandler*/
	{
		public Text key;
		public Contact data;
		 
		public delegate void Delegate( Contact data );
		public Delegate OnSelected;

		public override void OnSelect( BaseEventData eventData )
		{
			if( OnSelected != null )
			{
				OnSelected( data );
			}
		}

		public void Set( Contact data )
		{
			this.data = data;
			key.text = data.Key;
		}

	}
}
