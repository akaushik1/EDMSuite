using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

namespace DAQ.Remoting
{
    public class RemotingHelper
    {

        public static void ConnectScanMaster()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                    Type.GetType("ScanMaster.Controller, ScanMaster"),
                    "tcp://localhost:1170/controller.rem"
                    );
        }

        public static void ConnectBlockHead()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                    Type.GetType("BlockHead.Controller, BlockHead"),
                    "tcp://localhost:1171/controller.rem"
                    );
        }

        public static void ConnectEDMHardwareControl()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                    Type.GetType("EDMHardwareControl.Controller, EDMHardwareControl"),
                    "tcp://localhost:1172/controller.rem"
                    );
        }

        public static void ConnectPhaseLock()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                    Type.GetType("PhaseLock.MainForm, PhaseLock"),
                    "tcp://localhost:1175/controller.rem"
                    );
        }

        public static void ConnectLaserLock()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                Type.GetType("LaserLock.LaserController, LaserLock"),
                "tcp://localhost:1176/controller.rem"
                );
        }

        public static void ConnectDecelerationHardwareControl()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                    Type.GetType("DecelerationHardwareControl.Controller, DecelerationHardwareControl"),
                    "tcp://localhost:1177/controller.rem"
                    );
        }

    }
}