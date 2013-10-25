namespace Crow.Little.JXC.BasicControl.Model
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Xml;

	[Serializable]
	public partial class PurchaseAdded
	{
		#region Field
		#endregion
		#region Property
		public string DetailID {get;set;}
		public string PurchaseID {get;set;}
		public string CommodityID {get;set;}
		public long CommodityColor {get;set;}
		public long CommoditySize {get;set;}
		public long Quantity {get;set;}
		public decimal UnitPrice {get;set;}
		public decimal ReferencePrice {get;set;}
		public string Description {get;set;}
		#endregion
		#region Constructor
		#endregion
		#region Event
		#endregion
		#region Method
		#endregion
	}
}
