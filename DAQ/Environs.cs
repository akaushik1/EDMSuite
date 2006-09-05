using System;
using System.Collections;

using DAQ.HAL;

namespace DAQ.Environment
{
	/// <summary>
	/// The Environs class insulates the control programs from the computer they are running
	/// on. The Environs can be used to access hardware, access files, use Mathematica and
	/// control debugging in a computer independent way.
	/// </summary>
	public class Environs
	{
		/// <summary>
		/// The Hardware that is present in this Environs, presented through a
		/// standardised interface: Hardware.
		/// </summary>
		public static Hardware Hardware;

		/// <summary>
		/// This is where details of the file system specific to a computer belong.
		/// </summary>
		public static FileSystem FileSystem;

		/// <summary>
		/// This hashtable stores information about the system (as Strings). You can put
		/// pretty much anything in here that's specific to a particular computer.
		/// </summary>
		public static Hashtable Info = new Hashtable();

		/// <summary>
		/// The global debug flag. If this flag is set to true, no hardware calls will be made
		/// (if you're writing a hardware class it's your responsibility to observe this flag)
		/// and data will be synthesized.
		/// </summary>
		public static bool Debug;

        /// <summary>
        /// When FullStorage is true, every scan of a run is saved to a temporary diretory - all the
        /// data is available for writing to file at the end of the run. If this setting is false,
        /// only the average over the scans is available - keeps things fast.
        /// </summary>
        public static bool FullStorage;

		/// <summary>
		/// Experiment type is for code that needs to know what experiment it's running on.
		/// </summary>
		public static String ExperimentType;

		/// <summary>
		/// Initialise the environment. This code switches on computer name and
		/// sets up the environment accordingly.
		/// </summary>
		static Environs()
		{
			String computerName = (String)System.Environment.GetEnvironmentVariables()["COMPUTERNAME"];
			switch (computerName)
			{
				case "CRASH1":
					Hardware = new DecelerationHardware();
					FileSystem = new CrashFileSystem();
					Debug = false;
                    FullStorage = false;
					ExperimentType = "decelerator";
					break;

				case "SCHNAPS":
					Hardware = new DecelerationHardware();
					FileSystem = new SchnapsFileSystem();
					ExperimentType = "decelerator";
					Debug = false;
                    FullStorage = false;
					break;

				case "OYSTER":
					Hardware = new DecelerationHardware();
					FileSystem = new OysterFileSystem();
					Debug = true;
                    FullStorage = false;
					ExperimentType = "decelerator";
					break;

				case "CLAM":
					Hardware = new DecelerationHardware();
					FileSystem = new ClamFileSystem();
					Debug = true;
                    FullStorage = true;
					ExperimentType = "decelerator";
					break;

				case "CHROME1":
					Hardware = new EDMHardware();
					FileSystem = new ChromeFileSystem();
					Debug = false;
                    FullStorage = false;
					ExperimentType = "edm";
					break;

				case "DISCOBANDIT":
					Hardware = new EDMHardware();
					FileSystem = new DiscoBanditFileSystem();
					Debug = true;
                    FullStorage = false;
                    ExperimentType = "edm";
					break;

				case "GANYMEDE0":
					Hardware = new LiHHardware();
					FileSystem = new GanymedeFileSystem();
					Debug = false;
                    FullStorage = true;
					ExperimentType = "lih";
					break;

				case "CARMELITE":
					Hardware = new BufferGasHardware();
					FileSystem = new CarmeliteFileSystem();
					Debug = false;
                    FullStorage = false;
					ExperimentType = "buffer";
					break;
				
				case "YBF":
					Hardware = new EDMHardware();
					FileSystem = new YBFFileSystem();
					Debug = true;
                    FullStorage = false;
					ExperimentType = "edm";
					break;

				default:
					Hardware = new EDMHardware();
					FileSystem = new FileSystem();
					Debug = true;
                    FullStorage = false;
					ExperimentType = "edm";
					break;
			}
		}

	}
}
