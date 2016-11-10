using System;
using Gtk;

namespace Org.InstitutoSerpis.Ad{

	public class WindowHelper{
		public static bool Confirm(Window parent, String messaje){
			MessageDialog messageDialog = new MessageDialog(parent, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, messaje);
			messageDialog.Title = parent.Title;
			ResponseType response = (ResponseType)messageDialog.Run();
			return response == ResponseType.Yes;
		}
	}

}