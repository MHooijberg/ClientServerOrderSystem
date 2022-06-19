using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OrderSystem_Server
{
	public class JSONExportVisitor : IOrderVisitor
	{
		public void VisitOrderDetails(OrderDetails OrderDetails) {
			FileStream file = File.Create($"Order-{OrderDetails.Date}.json");
			string jsonExport = JsonSerializer.Serialize(OrderDetails);
			byte[] streamBytes = new UTF8Encoding(true).GetBytes(jsonExport);
			file.Write(streamBytes);
			file.Close();			
		}

		public void VisitOrderDirectory(OrderDirectory OrderDirectory) {
			FileStream file = File.Create($"OrderDirectory-{DateTime.UtcNow}.json");
			string jsonExport = JsonSerializer.Serialize(OrderDirectory);
			byte[] streamBytes = new UTF8Encoding(true).GetBytes(jsonExport);
			file.Write(streamBytes);
			file.Close();
		}
	}
}