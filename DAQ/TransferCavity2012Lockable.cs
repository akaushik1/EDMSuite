﻿using System;
using System.Collections;

namespace DAQ.TransferCavityLock2012
{
    /// <summary>
    /// This is an interface for all the capabilities necessary for a transfer cavity lock.
    /// </summary>
    public interface TransferCavity2012Lockable
    {

        void ConfigureReadAI(int numberOfMeasurements, bool autostart);
        void ConfigureSetLaserVoltage(double voltage);

        double[,] ReadAI(int numberOfMeasurements);
        void SetLaserVoltage(double voltage);

        void DisposeAITask();
        void DisposeLaserTask();

    }


}
