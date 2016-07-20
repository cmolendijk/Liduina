using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Liduina.UITest
{
	/// <summary>
	/// Sample testclass to demonstrate how to create and operate UITest.
	/// Manipulating the UI is done by setting the AutomationId property on your controls. See <see cref="CreateUserView.xaml"/> for examples of these.
	/// The app object contains a programmatic representation of the contents currently VISIBLE on the screens.
	/// If the control you wish to manipulate is out of view, you need to use a command like app.ScrollDownTo() before you can manipulate it.
	/// Manipulating can be done by issuing commands like Tap, EnterText, Swipe, back etc.
	/// Use app.Repl to start a terminal you can use to play around with the GUI via commands.
	/// Type copy in the command line to copy your history and paste it inside a test to get started quickly.
	/// 
	/// For more info, please see https://developer.xamarin.com/guides/xamarin-forms/deployment,_testing,_and_metrics/uitest-and-test-cloud/
	/// </summary>
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class SampleTestClass
	{
		IApp app;
		Platform platform;

		public SampleTestClass(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void SampleTest()
		{
			app.Screenshot("First page.");
			//app.Repl(); //Launches the REPL tool which can be used to programmatically manipulate the GUI
			app.Tap(x => x.Marked("NameText")); //Click something that contains the identifier 'NameText' (set via the AutomationId property in the xaml)
			app.EnterText("John Doe");
			app.Tap(x => x.Marked("NextButton"));
			app.Screenshot("Second page.");
			app.WaitForElement(x => x.Marked("CityText")); //Make sure we have reached the next page

		}
	}
}

