using System;
using System.Threading.Tasks;
using AsyncProgressReporting.Common;

using Android.App;
using Android.Widget;
using Android.OS;


namespace Downloadreporting
{
	[Activity (Label = "Download-reporting", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		ProgressBar _progressbar;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			_progressbar = FindViewById<ProgressBar> (Resource.Id.progressbar);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += StartDownloadHandler;
		}

		async void StartDownloadHandler(object sender, System.EventArgs e)
		{
			_progressbar.Progress = 0;
			Progress<DownloadBytesProgress> progressReporter = new Progress<DownloadBytesProgress> ();
			progressReporter.ProgressChanged += (s, args) =>  _progressbar.Progress = (int) (100 * args.PercentComplete);

			Task<int> downloadTask = DownloadHelper.CreateDownloadTask (DownloadHelper.ImageToDownload, (IProgress<AsyncProgressReporting.Common.DownloadBytesProgress>)progressReporter);
			int bytesDownloaded = await downloadTask;
			System.Diagnostics.Debug.WriteLine ("Download {0} bytes", bytesDownloaded);

		}
	}
}


