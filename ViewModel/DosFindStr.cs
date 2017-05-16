namespace UsingMVVMLight.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Diagnostics;
	using GalaSoft.MvvmLight;
	using System.Collections.ObjectModel;

	/// <summary>
	/// This whole endeavour started because WebMis uses ASPOSE.dll and the old version that WebMis used
	/// could not work with IE11 AND turns out the license would not work unless the FIPS was turned off
	/// which is a MAJOR STIG violation...so I remembered that MPC was exporting to excel with simple
	/// HTTPcontext.type metadata....so...I went looking for that code...but couldn't remember exactly
	/// where it was and GrepforWin10 is probably not allowed to be installed on our govt boxes...sooooo
	/// here is a solution with credits to the google searches I did for the call to dos findstr from c#
	/// </summary>
	public partial class DosFindStr
	{

	public static ObservableCollection<DosFindStrResult> FindStringValue(string filepath, string stringToFind, string fileExtension)
		{
			var sb = new StringBuilder();
			var proc = new Process();
			proc.StartInfo = new ProcessStartInfo("cmd.exe")
			{
				Arguments = $"/c findstr /s /i /n /o {stringToFind} {fileExtension}",
				//Arguments = "/c findstr /s /i /n /o excel *.vb",
				//Arguments = "/c dir",
				//WorkingDirectory = @"C:\Downloads\MyDocs\Workspace\MPC",
				WorkingDirectory = filepath,
				CreateNoWindow = true,
				ErrorDialog = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute=false
			};

			proc.Start();
			sb.Append(proc.StandardOutput.ReadToEnd());
			var errs = proc.StandardError.ReadToEnd();
			proc.WaitForExit();
			return GetFindStrResults(sb.ToString());
		}

		private static ObservableCollection<DosFindStrResult> GetFindStrResults(string searchResultOutput)
		{
			ObservableCollection<DosFindStrResult> results = new ObservableCollection<DosFindStrResult>();
			char delim = Convert.ToChar("\n");
			foreach (var str in searchResultOutput.Split(delim))
			{
				if (str?.Trim().Length > 0)
				{
					results.Add(GetAFindStrResult(str));
				}
			}
			return results;
		}

		private static DosFindStrResult GetAFindStrResult(string str)
		{
			var split = str.Split(':');
			DosFindStrResult result = null;
			if (split.Length > 3)
			{
				result = new DosFindStrResult()
				{
					FileName = split[0],
					LineNumber = split[1],
					SeekOffset = Int32.Parse(split[2]),
					Content = split[3]
				};
			}
			return result;
		}
	}

	public partial class DosFindStrResult: ObservableObject
	{
		private string _fileName;
		public string FileName
		{
			get { return _fileName; }
			set { Set(()=> FileName, ref _fileName, value); }
		}
		private string _lineNumber;

		public string LineNumber
		{
			get { return _lineNumber; }
			set { Set(() => LineNumber, ref _lineNumber, value); }
		}

		private string _content;

		public string Content
		{
			get { return _content; }
			set { Set(() => Content, ref _content, value); }
		}

		private int _seekOffset;

		public int SeekOffset
		{
			get { return _seekOffset; }
			set { Set(() => SeekOffset, ref _seekOffset, value); }
		}


		public override string ToString()
		{
			return $"{FileName}:{LineNumber}:{SeekOffset}:{Content}";
		}
	}

}
