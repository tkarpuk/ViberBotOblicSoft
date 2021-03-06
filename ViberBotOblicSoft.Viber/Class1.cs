using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viber.Bot;

namespace ViberBotOblicSoft.Viber
{
    public class Class1
    {
		// <summary>
		/// Viber API.
		/// </summary>
		private IViberBotClient _viberBotClient;

		private string _authToken;
		private string _webhookUrl;
		private string _adminId;

		public void Init()
		{

			_authToken = "";//config["authToken"];
			_webhookUrl = "";//config["webhookUrl"];
			_adminId = "";//config["adminId"];

			_viberBotClient = new ViberBotClient(_authToken);
		}

		public async Task SetWebhookAsync()
		{
			var result = await _viberBotClient.SetWebhookAsync(_webhookUrl);
			return;
		}

		//[TestMethod]
		public async Task GetUserDetailsAsyncTest()
		{
			var result = await _viberBotClient.GetUserDetailsAsync(_adminId);
			return;
		}

		public async Task SendTextMessageAsyncTest()
		{
			var result = await _viberBotClient.SendTextMessageAsync(new TextMessage
			{
				Receiver = _adminId,
				Sender = new UserBase
				{
					Name = "Smbdy"
				},
				Text = "Hi!:)"
			});
			return;
		}

		//public async Task SendPictureMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendPictureMessageAsync(new PictureMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Media = "https://upload.wikimedia.org/wikipedia/commons/5/57/Viber-logo.png"
		//	});
		//	return;
		//}


		//public async Task SendContactMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendContactMessageAsync(new ContactMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Contact = new Contact
		//		{
		//			Name = "Brad Pitt",
		//			TN = "+0123456789"
		//		}
		//	});
		//	return;
		//}


		//public async Task SendFileMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendFileMessageAsync(new FileMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Media = "http://www.sample-videos.com/audio/mp3/crowd-cheering.mp3",
		//		FileName = "audio.mp3",
		//		Size = 443926
		//	});
		//	return;
		//}


		//public async Task SendLocationMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendLocationMessageAsync(new LocationMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Location = new Location
		//		{
		//			Lon = 1,
		//			Lat = -2
		//		}
		//	});
		//	return;
		//}


		//public async Task SendStickerMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendStickerMessageAsync(new StickerMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		StickerId = "40108"
		//	});
		//	return;
		//}

		//public async Task SendVideoMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendVideoMessageAsync(new VideoMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Media = "https://github.com/mediaelement/mediaelement-files/blob/master/big_buck_bunny.mp4?raw=true",
		//		Size = 5510872
		//	});
		//	return;
		//}


		//public async Task SendUrlMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendUrlMessageAsync(new UrlMessage
		//	{
		//		Receiver = _adminId,
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Media = "https://www.google.com"
		//	});
		//	return;
		//}


		public async Task SendKeyboardMessageAsyncTest()
		{
			var result = await _viberBotClient.SendKeyboardMessageAsync(new KeyboardMessage
			{
				Receiver = _adminId,
				Sender = new UserBase
				{
					Name = "Smbdy"
				},
				Text = "Test keyboard",
				Keyboard = new Keyboard
				{
					Buttons = new[]
					{
						new KeyboardButton
						{
							Text = "Button 1",
							ActionBody = "AB1"
						}
					}
				},
				TrackingData = "td"
			});
			return;
		}

		//public async Task SendBroadcastMessageAsyncTest()
		//{
		//	var result = await _viberBotClient.SendBroadcastMessageAsync(new BroadcastMessage
		//	{
		//		Sender = new UserBase
		//		{
		//			Name = "Smbdy"
		//		},
		//		Text = "Broadcast message!:)",
		//		BroadcastList = new[]
		//		{
		//			_adminId
		//		}
		//	});
		//	return;
		//}
	}
}
