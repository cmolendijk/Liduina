using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace Liduina.UITest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class RegistrationTest
	{
		IApp app;
		Platform platform;

		public RegistrationTest(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}


		[Test]
		public void RegisterUser()
		{
			app.Tap(x => x.Marked("NameText"));
			app.EnterText("John Doe");
			app.Tap(x => x.Marked("EmailText"));
			app.EnterText("John.Doe@Liduina.com");
			app.DismissKeyboard();
			app.Tap(x => x.Marked("NextButton"));

			app.WaitForElement(x => x.Marked("CityText"));

		}
	}
}

