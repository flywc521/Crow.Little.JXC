namespace Crow.Little.JXC.BasicControl.Model
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Xml;

	[Serializable]
	public partial class PurchaseExchangeTo
	{
		#region Field
		#endregion
		#region Property
		public string ToID {get;set;}
		public string DetailID {get;set;}
		public string CommodityID {get;set;}
		public long CommodityColor {get;set;}
		public long CommoditySize {get;set;}
		public long Quantity {get;set;}
		public float UnitPrice {get;set;}
		public float ReferencePrice {get;set;}
		#endregion
		#region Constructor
		#endregion
		#region Event
		#endregion
		#region Method
		#endregion
	}
}
