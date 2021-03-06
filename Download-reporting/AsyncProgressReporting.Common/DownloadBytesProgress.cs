﻿using System;

namespace AsyncProgressReporting.Common
{
	public class DownloadBytesProgress
	{
		public DownloadBytesProgress (string filename, int bytesReceived, int totalBytes)
		{
			Filename = filename;
			BytesReceived = bytesReceived;
			TotalBytes = totalBytes;
		}

		public int TotalBytes { get; private set; }

		public int BytesReceived { get; private set; }

		public float PercentComplete { 
			get {
				return (float)BytesReceived / TotalBytes; 
			}
		}

		public string Filename { get; private set; }

		public bool IsFinished {get { return BytesReceived == TotalBytes; }}
	}
}

