using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GbSnd
{
    internal class SndInterop
    {
        [DllImport("GbSndLib.dll", EntryPoint = "gb_write_reg")]
        public static extern void WriteReg(int addr, int data);
        [DllImport("GbSndLib.dll", EntryPoint = "gb_sample_rate")]
        public static extern bool SampleRate(long rate);
        [DllImport("GbSndLib.dll", EntryPoint = "gb_end_frame")]
        public static extern void EndFrame();
        [DllImport("GbSndLib.dll", EntryPoint = "gb_read_samples")]
        public static extern long ReadSamples([In] short[] buf, long buf_size);
        [DllImport("GbSndLib.dll", EntryPoint = "gb_sound_init")]
        public static extern string SoundInit(long sample_rate, int chan_count = 1);
        [DllImport("GbSndLib.dll", EntryPoint = "gb_sound_write")]
        public static extern void SoundWrite([In] short[] ina, long count);
        [DllImport("GbSndLib.dll", EntryPoint = "gb_play_samples")]
        public static extern void PlaySamples([In] short[] ina, long count);
    }
}
