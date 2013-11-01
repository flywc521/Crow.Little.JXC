namespace Crow.Little.JXC.BasicControl.Model
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Xml;

	[Serializable]
	public partial class Commodity
	{
		#region Field
		#endregion
		#region Property
		public string ID {get;set;}
		public long Code {get;set;}
		public string CommodityName {get;set;}
		public long CommodityStyle {get;set;}
		public long CommodityType {get;set;}
		public long CommodityMaterial {get;set;}
		public long CommodityBrand {get;set;}
		public long IsActive {get;set;}
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
